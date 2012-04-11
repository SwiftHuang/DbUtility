using System;
using System.Text;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.CSharp;
using System.Web.Services.Description;
using System.Collections.Generic;

namespace TestWIN
{
    public partial class BOToolsFrm : Form
    {
        private const string @namespace = "EnterpriseServerBase.WebService.DynamicWebCalling";

        public BOToolsFrm()
        {
            InitializeComponent();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {

            txtResult.Clear();
            MethodInfo mi = InvokeWebService(txtWSUrl.Text, string.Empty, txtMethod.Text, null, string.Empty);
            txtResult.Text = GeneralText(mi, "invWS", "BOClassWS", "invWin", "BOClassWIN");
        }
        private void btnSetData_Click(object sender, EventArgs e)
        {
            BOClassWS.BOToolsSoapClient svc = new TestWIN.BOClassWS.BOToolsSoapClient("BOToolsSoap", txtWSUrl.Text);
            BOClassWS.Invoice inv = svc.GetInvoice();

            BOClassWIN.Invoice invWin = new TestWIN.BOClassWIN.Invoice();

            if (inv != null)
            {
                invWin.CompanyCode = inv.CompanyCode;
                invWin.InvNum = inv.InvNum;
                invWin.QTY = inv.QTY;
                invWin.Amount = inv.Amount;

                if (inv.HotelInfo != null)
                {
                    invWin.HotelInfo = new TestWIN.BOClassWIN.Hotel();
                    invWin.HotelInfo.HotelCode = inv.HotelInfo.HotelCode;
                }

                invWin.Tickets = new List<TestWIN.BOClassWIN.Ticket>();
                if (inv.Tickets != null)
                {
                    foreach (BOClassWS.Ticket tkt in inv.Tickets)
                    {
                        BOClassWIN.Ticket tktWin = new TestWIN.BOClassWIN.Ticket();
                        tktWin.TicketNum = tkt.TicketNum;

                        tktWin.Details = new List<TestWIN.BOClassWIN.Ticket.TicketDetail>();
                        if (tkt.Details != null)
                        {
                            foreach (BOClassWS.TicketDetail dtl in tkt.Details)
                            {
                                BOClassWIN.Ticket.TicketDetail dtlWin = new TestWIN.BOClassWIN.Ticket.TicketDetail();
                                dtlWin.SegNum = dtl.SegNum;

                                tktWin.Details.Add(dtlWin);
                            }
                        }

                        invWin.Tickets.Add(tktWin);
                    }
                }
            }

        }

        private MethodInfo InvokeWebService(string url, string classname, string methodname, object[] args, string fileName)
        {

            if ((classname == null) || (classname == ""))
            {
                classname = GetWsClassName(url);
            }

            try
            {
                //获取WSDL
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(url + "?WSDL");

                ServiceDescription sd = ServiceDescription.Read(stream);
                ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
                sdi.AddServiceDescription(sd, "", "");
                CodeNamespace cn = new CodeNamespace(@namespace);

                //生成客户端代理类代码
                CodeCompileUnit ccu = new CodeCompileUnit();

                ccu.Namespaces.Add(cn);
                sdi.Import(cn, ccu);
                CSharpCodeProvider csc = new CSharpCodeProvider();
                //ICodeCompiler icc = csc.CreateCompiler();

                //设定编译参数
                CompilerParameters cplist = new CompilerParameters();
                cplist.GenerateExecutable = false;

                if (!string.IsNullOrEmpty(fileName))
                {
                    cplist.OutputAssembly = fileName;
                    cplist.GenerateInMemory = false;
                }
                else
                    cplist.GenerateInMemory = true;

                cplist.ReferencedAssemblies.Add("System.dll");
                cplist.ReferencedAssemblies.Add("System.XML.dll");
                cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
                cplist.ReferencedAssemblies.Add("System.Data.dll");

                //编译代理类
                //CompilerResults cr = icc.CompileAssemblyFromDom(cplist, ccu);
                CompilerResults cr = csc.CompileAssemblyFromDom(cplist, ccu);
                if (true == cr.Errors.HasErrors)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    foreach (System.CodeDom.Compiler.CompilerError ce in cr.Errors)
                    {
                        sb.Append(ce.ToString());
                        sb.Append(System.Environment.NewLine);
                    }
                    throw new Exception(sb.ToString());
                }

                if (string.IsNullOrEmpty(fileName))
                {
                    //生成代理实例，并调用方法
                    Assembly assembly = cr.CompiledAssembly;
                    Type t = assembly.GetType(@namespace + "." + classname, true, true);
                    object obj = Activator.CreateInstance(t);
                    MethodInfo mi = t.GetMethod(methodname);
                    return mi;
                    //if (mi != null)
                    //{
                    //    if (args == null)
                    //        return mi.Invoke(obj, null);
                    //    else
                    //        return mi.Invoke(obj, args);
                    //}
                    //else
                    //{
                    //    throw new Exception(string.Format("Invalid Method Name:{0}", methodname));
                    //}
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, new Exception(ex.InnerException.StackTrace));
                else
                    throw ex;
            }
        }
        private string GetWsClassName(string wsUrl)
        {
            string[] parts = wsUrl.Split('/');
            string[] pps = parts[parts.Length - 1].Split('.');

            return pps[0];
        }
        private string GeneralText(MethodInfo mi, string fromClassName, string fromNamespace, string toClassName, string toNamespace)
        {
            if (mi != null)
            {

                object obj = Activator.CreateInstance(mi.ReturnType);
                string s = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(obj);
                TransferClass tc = new TransferClass(obj, fromClassName, fromNamespace, toClassName, toNamespace);
                return tc.BuildTransferMethod();
            }
            return string.Empty;
        }


    }
}
