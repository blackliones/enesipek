using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

     

             private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
                               
        }

             private void listBox1_DragDrop(object sender, DragEventArgs e)
             {
                 if (listBox1.Items.Count != 0)
                 {
                     listBox1.Items.Clear();
                 }
                 string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                 int i;
                 for (i = 0; i < s.Length; i++)
                     listBox1.Items.Add(Path.GetFileName(s[i]));
             }
             private void button1_Click(object sender, EventArgs e)
             {
              }
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (string item in Properties.Settings.Default.myList)
            {
                listBox1.Items.Add(item);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
       
        }
    }
}
