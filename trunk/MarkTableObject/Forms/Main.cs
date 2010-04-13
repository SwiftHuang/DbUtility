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

        private void Main_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            if (!System.IO.File.Exists(XMLHelper.MenuPath))
            {
                Common.CreateFile(XMLHelper.MenuPath);
                XMLHelper.SaveTreeView(tvServers);
            }
            XMLHelper.GetMenu(ref tvServers);
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
                SelectObjFrm frm = new SelectObjFrm();
                frm.PrjInfo = GetProjectInfo(tvServers.SelectedNode);
                frm.ShowDialog();
                //List<string> tableList = new List<string>();
                //List<string> viewList = new List<string>();
                //Entity.ProjectInfo prj = GetProjectInfo(tvServers.SelectedNode);

                //BLL.MSSQL.BuilderColumn.GetTableList(prj.ConnectionString, out tableList, out viewList);

                //GeneralFrm frm = new GeneralFrm();
                //frm.ProjectInfo = prj;
                //frm.TableList = tableList;
                //frm.ViewList = viewList;

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

                BLL.MSSQL.BuilderColumn.GetTableList(prj.Database.ConnectionString, out tableList, out viewList);

                TreeNode tableNode = new TreeNode("表");
                tableNode.Tag = "TABLE";
                foreach (string s in tableList)
                {
                    TreeNode t = new TreeNode(s);
                    t.Tag = tvServers.SelectedNode.Tag;
                    tableNode.Nodes.Add(t);
                }
                tvServers.SelectedNode.Nodes.Add(tableNode);

                TreeNode viewNode = new TreeNode("视图");
                viewNode.Tag = "VIEW";
                foreach (string s in viewList)
                {
                    TreeNode t = new TreeNode(s);
                    t.Tag = tvServers.SelectedNode.Tag;
                    viewNode.Nodes.Add(t);
                }
                tvServers.SelectedNode.Nodes.Add(viewNode);
            }
        }

        private Entity.ProjectInfo GetProjectInfo(TreeNode node)
        {
            string fileName = Common.GetProjectFileName(node.Tag.ToString());
            return Common.GetProjectInfo(fileName);
        }

        private void tvServers_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1)
                tsMenuConn_Click(null, null);
            else if (e.Node.Level == 3)
            {
                if (e.Node.Parent.Tag != null)
                {
                    if (e.Node.Parent.Tag.ToString() == "TABLE")
                    {
                    }
                    else if (e.Node.Parent.Tag.ToString() == "VIEW")
                    {
                    }
                }
            }
        }

    }
}
