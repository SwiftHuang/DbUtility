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
using TestWIN;

namespace TestWIN
{
    public partial class BOToolsFrm : Form
    {
        private const string @namespace = "WebService.DynamicWebCalling";
        List<Assembly> assemblyList = new List<Assembly>();

        private TransferClass.AssemblyType TransferType = TransferClass.AssemblyType.None;

        public BOToolsFrm()
        {
            InitializeComponent();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            try
            {
                //txtWSUrl.Text = "http://localhost:2212/BOTools.asmx";
                //txtToNamespace.Text = "BOClassWIN";
                //txtToClassName.Text = "invWin";
                //txtFromNamespace.Text = "BOClassWS";
                //txtFromClassName.Text = "invWS";
                GeneralText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnSetData_Click(object sender, EventArgs e)
        {
            SetData();
        }
        private void btnUpdateWSTypeList_Click(object sender, EventArgs e)
        {
            try
            {
                assemblyList.Add(GetAssembly(txtWSUrl.Text));
                UpdateAssembly(assemblyList);
                TransferType = TransferClass.AssemblyType.WebService;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnFile_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Multiselect = true;
                openFileDialog1.Filter = "程序集|*.dll|所有文件|*.*";
                openFileDialog1.RestoreDirectory = true;
                openFileDialog1.FilterIndex = 1;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    foreach (string s in openFileDialog1.FileNames)
                    {
                        txtFileName.AppendText(s + "\r\n");
                        assemblyList.Add(GetAssemblyByFile(s));
                    }

                }

                UpdateAssembly(assemblyList);

                TransferType = TransferClass.AssemblyType.DLL;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateAssembly(List<Assembly> assemblyList)
        {
            cboTypeList.Items.Clear();

            if (assemblyList != null)
            {
                foreach (Assembly a in assemblyList)
                {
                    foreach (Type t in a.GetTypes())
                    {
                        if (t.IsEnum != true)
                        {
                            cboTypeList.Items.Add(t);
                        }
                    }
                }
                if (cboTypeList.Items.Count > 0)
                {
                    btnGen.Enabled = true;
                    cboTypeList.SelectedIndex = 0;
                }
                else
                {
                    btnGen.Enabled = false;
                }
            }
        }

        private Assembly GetAssembly(string url)
        {
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

                //生成代理实例，并调用方法
                Assembly assembly = cr.CompiledAssembly;
                return assembly;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, new Exception(ex.InnerException.StackTrace));
                else
                    throw ex;
            }
        }
        private Assembly GetAssemblyByFile(string fileName)
        {
            Assembly assembly = Assembly.LoadFrom(fileName);
            return assembly;
        }
        private string GetWsClassName(string wsUrl)
        {
            string[] parts = wsUrl.Split('/');
            string[] pps = parts[parts.Length - 1].Split('.');

            return pps[0];
        }
        private void GeneralText()
        {
            txtTranMethod.Clear();
            txtClass.Clear();

            if (assemblyList != null)
            {
                TransferClass tc = new TransferClass(TransferType, txtFromClassName.Text, txtFromNamespace.Text, txtToClassName.Text, txtToNamespace.Text);
                tc.Build(cboTypeList.SelectedItem.ToString(), assemblyList);
                txtTranMethod.Text = tc.MethodText;
                txtClass.Text = tc.ClassText;
            }
        }
        private void SetData()
        {
            BOClassWS.BOToolsSoapClient svc = new TestWIN.BOClassWS.BOToolsSoapClient("BOToolsSoap", txtWSUrl.Text);
            BOClassWS.Invoice invWS = svc.GetInvoice();
            BOClassWIN.Invoice invWIN = new BOClassWIN.Invoice();

            if (invWS != null)
            {
                invWIN.CompanyCode = invWS.CompanyCode;
                invWIN.InvNum = invWS.InvNum;
                invWIN.QTY = invWS.QTY;
                invWIN.Amount = invWS.Amount;
                invWIN.Types = (BOClassWIN.InvoiceType)Enum.Parse(typeof(BOClassWIN.InvoiceType), invWS.Types.ToString());

                if (invWS.HotelInfo != null)
                {
                    invWIN.HotelInfo = new BOClassWIN.Hotel();
                    invWIN.HotelInfo.HotelCode = invWS.HotelInfo.HotelCode;
                }

                invWIN.XOList = new List<BOClassWIN.XO>();
                if (invWS.XOList != null)
                {
                    foreach (BOClassWS.XO _frXO in invWS.XOList)
                    {
                        BOClassWIN.XO _XO = new BOClassWIN.XO();
                        _XO.XONum = _frXO.XONum;

                        _XO.Details = new List<BOClassWIN.XODetail>();
                        if (_frXO.Details != null)
                        {
                            foreach (BOClassWS.XODetail _frXODetail in _frXO.Details)
                            {
                                BOClassWIN.XODetail _XODetail = new BOClassWIN.XODetail();
                                _XODetail.SegNum = _frXODetail.SegNum;

                                _XO.Details.Add(_XODetail);
                            }
                        }

                        invWIN.XOList.Add(_XO);
                    }
                }

                invWIN.Tickets = new List<BOClassWIN.Ticket>();
                if (invWS.Tickets != null)
                {
                    foreach (BOClassWS.Ticket _frTicket in invWS.Tickets)
                    {
                        BOClassWIN.Ticket _Ticket = new BOClassWIN.Ticket();
                        _Ticket.TicketNum = _frTicket.TicketNum;

                        _Ticket.Details = new List<BOClassWIN.TicketDetail>();
                        if (_frTicket.Details != null)
                        {
                            foreach (BOClassWS.TicketDetail _frTicketDetail in _frTicket.Details)
                            {
                                BOClassWIN.TicketDetail _TicketDetail = new BOClassWIN.TicketDetail();
                                _TicketDetail.SegNum = _frTicketDetail.SegNum;

                                _Ticket.Details.Add(_TicketDetail);
                            }
                        }

                        invWIN.Tickets.Add(_Ticket);
                    }
                }
            }
        }

        private void cboTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtToClassName.Text))
            {
                txtToClassName.Text = "to" + cboTypeList.Text;
            }
            if (string.IsNullOrEmpty(txtFromClassName.Text))
            {
                txtFromClassName.Text = "frm" + cboTypeList.Text;
            }
            lblTypeFullName.Text = cboTypeList.SelectedItem.ToString();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                Clipboard.SetDataObject(txtClass.Text);
            }
            else
            {
                Clipboard.SetDataObject(txtTranMethod.Text);
            }
        }

    }
}
