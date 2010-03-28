using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace hwj.MarkTableObject.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }


        private void tBtnAddPrj_Click(object sender, EventArgs e)
        {
            Forms.ProjectFrm prj = new ProjectFrm();
            prj.IsAddMode = true;
            prj.ShowDialog();

            if (prj.Project != null)
            {
                TreeNode node = new TreeNode(prj.Project.Name);
                node.Tag = prj.Project.Key;
                tvServers.Nodes[0].Nodes.Add(node);
                XMLHelper.SaveTreeView(tvServers);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            if (!System.IO.File.Exists(XMLHelper.MenuPath))
                XMLHelper.SaveTreeView(tvServers);
            XMLHelper.GetMenu(ref tvServers);
        }

        private void tvServers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                TreeNode CurrentNode = tvServers.GetNodeAt(ClickPoint);
                if (CurrentNode != null)
                {
                    switch (CurrentNode.Level)
                    {
                        case 1:
                            CurrentNode.ContextMenuStrip = treeMenu;
                            break;
                        default:
                            break;
                    }
                    tvServers.SelectedNode = CurrentNode;
                }
            }

        }

        private void tsMenuGeneral_Click(object sender, EventArgs e)
        {
            if (tvServers.SelectedNode.Tag != null)
            {
                List<string> tableList = new List<string>();
                List<string> viewList = new List<string>();
                Entity.ProjectInfo prj = GetProjectInfo(tvServers.SelectedNode);

                BLL.MSSQL.BuilderColumn.GetTableList(prj.ConnectionString, out tableList, out viewList);

                GeneralFrm frm = new GeneralFrm();
                frm.ProjectInfo = prj;
                frm.TableList = tableList;
                frm.ViewList = viewList;
                frm.ShowDialog();
            }
        }

        private void tsMenuSetting_Click(object sender, EventArgs e)
        {
            if (tvServers.SelectedNode.Tag != null)
            {
                Entity.ProjectInfo prj = GetProjectInfo(tvServers.SelectedNode);
                ProjectFrm frm = new ProjectFrm();
                frm.Project = prj;
                frm.ShowDialog();
            }
        }

        private void tsMenuConn_Click(object sender, EventArgs e)
        {
            if (tvServers.SelectedNode.Tag != null)
            {
                tvServers.SelectedNode.Nodes.Clear();

                Entity.ProjectInfo prj = GetProjectInfo(tvServers.SelectedNode);

                List<string> tableList = new List<string>();
                List<string> viewList = new List<string>();

                BLL.MSSQL.BuilderColumn.GetTableList(prj.ConnectionString, out tableList, out viewList);

                TreeNode tableNode = new TreeNode("表");
                foreach (string s in tableList)
                {
                    tableNode.Nodes.Add(s);
                }
                tvServers.SelectedNode.Nodes.Add(tableNode);

                TreeNode viewNode = new TreeNode("视图");
                foreach (string s in viewList)
                {
                    viewNode.Nodes.Add(s);
                }
                tvServers.SelectedNode.Nodes.Add(viewNode);
            }
        }
        private Entity.ProjectInfo GetProjectInfo(TreeNode node)
        {
            string fileName = Common.GetProjectFileName(node.Tag.ToString());
            return Common.GetProjectInfo(fileName);
        }
    }
}
