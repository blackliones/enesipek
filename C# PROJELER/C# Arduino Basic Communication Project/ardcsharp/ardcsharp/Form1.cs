using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
namespace ardcsharp
{
    public partial class Form1 : Form
    {
        public bool connected;
        public Form1()
        {
            InitializeComponent();
            sp.BaudRate = 9600;
            sp.PortName = "COM10";
            connect.Enabled = true;
            disconnect.Enabled = false;
            on.Enabled = false;
            off.Enabled = false;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sp.WriteLine("d" + "-" + "1");
            
                       off.Enabled = true;
            on.Enabled = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
                 sp.WriteLine("d" + "-" + "0");
            on.Enabled = true;
            off.Enabled = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            sp.Open();
            connect.Enabled = false;
                 disconnect.Enabled = true;
            connected = true;
            on.Enabled = true;
                        off.Enabled = false;
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sp.Close();
          
            connect.Enabled = true;
            disconnect.Enabled = false;
            connected = false;
            on.Enabled = false;
           
            off.Enabled = false;
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        
        }

     
    }
}
