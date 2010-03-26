using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace hwj.MarkTableObject
{
    public class XMLHelper
    {
        public static void SaveTreeView(TreeView treeView)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Menu></Menu>");
            XmlNode root = doc.DocumentElement;
            doc.InsertBefore(doc.CreateXmlDeclaration("1.0", "utf-8", "yes"), root);
            TreeNode2Xml(treeView.Nodes, root);
            doc.Save("Menu.xml");
        }
        private static void TreeNode2Xml(TreeNodeCollection treeNodes, XmlNode xmlNode)
        {
            XmlDocument doc = xmlNode.OwnerDocument;
            foreach (TreeNode treeNode in treeNodes)
            {
                XmlNode element = doc.CreateNode("element", "Item", "");
                XmlAttribute attr = doc.CreateAttribute("Title");
                attr.Value = treeNode.Text;
                element.Attributes.Append(attr);

                if (treeNode.Tag != null)
                {
                    XmlAttribute attrKey = doc.CreateAttribute("Key");
                    attrKey.Value = treeNode.Tag.ToString();
                    element.Attributes.Append(attrKey);

                }
                //element.AppendChild(doc.CreateCDataSection(treeNode.Tag.ToString()));
                xmlNode.AppendChild(element);

                if (treeNode.Nodes.Count > 0)
                {
                    TreeNode2Xml(treeNode.Nodes, element);
                }
            }
        }
        public static void GetMenu(ref TreeView treeView)
        {
            TreeView tv = new TreeView();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Menu.xml");

            XmlNodeList xmlNodes = xmlDoc.DocumentElement.ChildNodes;

            treeView.BeginUpdate();
            treeView.Nodes.Clear();
            XmlNode2TreeNode(xmlNodes, treeView.Nodes);
            treeView.EndUpdate();
        }

        private static void XmlNode2TreeNode(XmlNodeList xmlNode, TreeNodeCollection treeNode)
        {
            foreach (XmlNode var in xmlNode)
            {
                if (var.NodeType != XmlNodeType.Element)
                {
                    continue;
                }
                TreeNode newTreeNode = new TreeNode();
                newTreeNode.Text = var.Attributes["Title"].Value;
                if (var.Attributes["Key"] != null)
                    newTreeNode.Tag = var.Attributes["Key"].Value;

                if (var.HasChildNodes)
                {
                    if (var.ChildNodes[0].NodeType == XmlNodeType.CDATA)
                    {
                        newTreeNode.Tag = var.ChildNodes[0].Value;
                    }

                    XmlNode2TreeNode(var.ChildNodes, newTreeNode.Nodes);
                }

                treeNode.Add(newTreeNode);
            }
        }

    }
}
