using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web.Services.Description;
using System.Windows.Forms;
using Microsoft.CSharp;
using hwj.MarkTableObject.BLL;
using hwj.MarkTableObject.Entity;

namespace hwj.MarkTableObject.Components
{
    public partial class AssignEntity : UserControl
    {
        public ProjectInfo PrjInfo { get; set; }
        private const string @namespace = "WebService.DynamicWebCalling";
        List<Assembly> assemblyList = new List<Assembly>();
        private ClassTransfer.AssemblyType TransferType = ClassTransfer.AssemblyType.None;

        public AssignEntity()
        {
            InitializeComponent();
        }

        private void btnGenSql_Click(object sender, EventArgs e)
        {

        }

        private void btnFile_Click(object sender, EventArgs e)
        {

            try
            {
                txtFileName.Clear();
                assemblyList.Clear();

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

                TransferType = ClassTransfer.AssemblyType.DLL;
            }
            catch (Exception ex)
            {
                Common.MsgError(ex.Message, ex);
            }

        }

        #region Private Members
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
                cboTypeList.Sorted = true;
                if (cboTypeList.Items.Count > 0)
                {
                    btnGenCode.Enabled = true;
                    cboTypeList.SelectedIndex = 0;
                }
                else
                {
                    btnGenCode.Enabled = false;
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
        #endregion

        private void cboPrjInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (cboPrjInfo.SelectedValue != null && !string.IsNullOrEmpty(cboPrjInfo.SelectedValue.ToString()))
            {
                PrjInfo = Common.GetProjectInfoByKey(cboPrjInfo.SelectedValue.ToString());
            }
        }

        private void AssignEntity_Enter(object sender, EventArgs e)
        {
            if (!DesignMode && cboPrjInfo.DataSource == null)
            {
                cboPrjInfo.DisplayMember = "Title";
                cboPrjInfo.ValueMember = "Key";
                cboPrjInfo.DataSource = XMLHelper.GetPrjDataTable();
            }
        }
    }
}
