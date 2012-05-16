using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class AdjacencyFrm : Form
    {
        public AdjacencyFrm()
        {
            InitializeComponent();
        }

        private void xButton1_Click(object sender, EventArgs e)
        {
            AdjacencyList<string> a = new AdjacencyList<string>();
            //a.AddVertex("V1");
            //a.AddVertex("V2");
            //a.AddVertex("V3");
            //a.AddVertex("V4");
            //a.AddVertex("V5");
            //a.AddVertex("V6");
            //a.AddVertex("V7");
            //a.AddVertex("V8");
            //a.AddEdge("V1", "V2");
            //a.AddEdge("V1", "V3");
            //a.AddEdge("V2", "V4");
            //a.AddEdge("V2", "V5");
            //a.AddEdge("V3", "V6");
            //a.AddEdge("V3", "V7");
            //a.AddEdge("V4", "V8");
            //a.AddEdge("V5", "V8");
            //a.AddEdge("V6", "V8");
            //a.AddEdge("V7", "V8");

            a.AddVertex("A");
            a.AddVertex("B");
            a.AddVertex("C");
            a.AddVertex("D");
            a.AddEdge("A", "B");
            a.AddEdge("A", "D");
            a.AddEdge("B", "C");
            a.AddEdge("C", "D");

            AdjacencyList<string>.PathList<string> lst = a.Search("A", "B");
            AdjacencyList<string>.PathList<string> lst2 = a.Search("A", "C");
            a.DFSTraverse();
            a.BFSTraverse();
        }
    }
}
