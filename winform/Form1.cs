using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
            main();
            textBox1.Text = theGraph.ShowToText();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            main();
            
        }

        static Random ran = new Random();
        static Graph theGraph = new Graph();
        private void main()
        {
            
            theGraph.AddVertex("v0"); theGraph.AddVertex("v1");
            theGraph.AddVertex("v2"); theGraph.AddVertex("v3");
            theGraph.AddVertex("v4"); theGraph.AddVertex("v5");
            theGraph.AddVertex("v6"); theGraph.AddVertex("v7");

            theGraph.AddEdge(0, 1, ran.Next(1, 9)*10); theGraph.AddEdge(0, 2, ran.Next(1, 9) * 10);
            theGraph.AddEdge(1, 2, ran.Next(1, 9) * 10); theGraph.AddEdge(1, 3, ran.Next(1, 9) * 10);
            theGraph.AddEdge(1, 4, ran.Next(1, 9) * 10); theGraph.AddEdge(1, 5, ran.Next(1, 9) * 10);
            theGraph.AddEdge(2, 4, ran.Next(1, 9) * 10); theGraph.AddEdge(3, 4, ran.Next(1, 9) * 10);
            theGraph.AddEdge(3, 5, ran.Next(1, 9) * 10); theGraph.AddEdge(4, 5, ran.Next(1, 9) * 10);
            theGraph.AddEdge(6, 7, ran.Next(1, 9) * 10); theGraph.AddEdge(3, 6, ran.Next(1, 9) * 10);
            theGraph.AddEdge(5, 6, ran.Next(1, 9) * 10);
            theGraph.AddEdgeByValue("v5", "v7", ran.Next(1, 9)*10);
            
        }
        string input, result;
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                input = textBox2.Text;
                textBox3.Text = theGraph.Path(input);
            }
        }
/*        void AddTextbox()
        {
            TextBox textBox3 = new TextBox();
            
            textBox3.Location = new System.Drawing.Point(423, 362);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new System.Drawing.Size(379, 128);
            textBox3.TabIndex = 4;
            textBox3.Text = input;
        }*/
    
    }
}
