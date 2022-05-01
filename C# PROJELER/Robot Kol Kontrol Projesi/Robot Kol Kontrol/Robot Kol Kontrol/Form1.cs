using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robot_Kol_Kontrol
{
    public partial class Form1 : Form
    {
               public Form1()
        {
            InitializeComponent();
        }

     
        private void Form1_Load(object sender, EventArgs e)
        {
            connectbtn.Enabled = true;
            dconnectbtn.Enabled = false;
            refbtn.Enabled = true;
            controlpanel.Enabled = false;
            m1s.ForeColor = Color.Red;
            m2s.ForeColor = Color.Red;
            m3s.ForeColor = Color.Red;
            m4s.ForeColor = Color.Red;
            m5s.ForeColor = Color.Red;
            m6s.ForeColor = Color.Red;
            baudrateinf.SelectedIndex = 4;
            for (int i = 0; i < 30; i++)
            {
                try
                {
                    serialPort1.PortName = "COM" + i.ToString();
                    serialPort1.Open();
                    portinf.Items.Add(serialPort1.PortName);
                    serialPort1.Close();

                }
                catch (Exception)
                { continue; }
            }
            if (portinf.Items.Count > 1)
                portinf.SelectedIndex = 1;
            else
                portinf.SelectedIndex = 0;
        }

        private void refbtn_Click(object sender, EventArgs e)
        {
            portinf.Items.Clear();
            for (int i = 0; i < 30; i++)
            {
                try
                {
                    serialPort1.PortName = "COM" + i.ToString();
                    serialPort1.Open();
                    portinf.Items.Add(serialPort1.PortName);
                    serialPort1.Close();
                }
                catch (Exception)
                { continue; }
            }
        }

        private void connectbtn_Click(object sender, EventArgs e)
        {
            if (portinf.Text == "" || baudrateinf.Text == "")
            {
                MessageBox.Show("Not selected PortName or baudRate. Please select PortName and baudRate", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                serialPort1.BaudRate = int.Parse(baudrateinf.Text);
                serialPort1.PortName = portinf.Text;
                serialPort1.Open();
                controlpanel.Enabled = true;
                connectbtn.Enabled = false;
                dconnectbtn.Enabled = true;
            }
        }

        private void dconnectbtn_Click(object sender, EventArgs e)
        {
            serialPort1.Write("allstop");
            dconnectbtn.Enabled = false;
            connectbtn.Enabled = true;
            serialPort1.Close();
            controlpanel.Enabled = false;
        }

        private void portinf_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void baudrateinf_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m1f_MouseUp(object sender, MouseEventArgs e)//ÇEKİLDİ
        {
            m1s.ForeColor = Color.Red;
            serialPort1.Write("allstop");


        }

        private void m1f_MouseDown(object sender, MouseEventArgs e)//BASILDI
        {
            m1s.ForeColor = Color.Green;
            serialPort1.Write("m1gof");
          
        }
        private void m1b_MouseUp(object sender, MouseEventArgs e)//ÇEKİLDİ
        {
            m1s.ForeColor = Color.Red;
            serialPort1.Write("allstop");
        }

        private void m1b_MouseDown(object sender, MouseEventArgs e)//BASILDI
        {
            m1s.ForeColor = Color.Green;
            serialPort1.Write("m1gob");
        }
        private void m2f_MouseUp(object sender, MouseEventArgs e)//ÇEKİLDİ
        {
            m2s.ForeColor = Color.Red;
            serialPort1.Write("allstop");
        }

        private void m2f_MouseDown(object sender, MouseEventArgs e)//BASILDI
        {
            m2s.ForeColor = Color.Green;
            serialPort1.Write("m2gof");
        }
        private void m2b_MouseUp(object sender, MouseEventArgs e)//ÇEKİLDİ
        {
            m2s.ForeColor = Color.Red;
            serialPort1.Write("allstop");
        }

        private void m2b_MouseDown(object sender, MouseEventArgs e)//BASILDI
        {
            m2s.ForeColor = Color.Green;
            serialPort1.Write("m2gob");
        }
        private void m3f_MouseUp(object sender, MouseEventArgs e)//ÇEKİLDİ
        {
            m3s.ForeColor = Color.Red;
            serialPort1.Write("allstop");
        }

        private void m3f_MouseDown(object sender, MouseEventArgs e)//BASILDI
        {
            m3s.ForeColor = Color.Green;
            serialPort1.Write("m3gof");
        }
        private void m3b_MouseUp(object sender, MouseEventArgs e)//ÇEKİLDİ
        {
            m3s.ForeColor = Color.Red;
            serialPort1.Write("allstop");
        }

        private void m3b_MouseDown(object sender, MouseEventArgs e)//BASILDI
        {
            m3s.ForeColor = Color.Green;
            serialPort1.Write("m3gob");
        }
        private void m4f_MouseUp(object sender, MouseEventArgs e)//ÇEKİLDİ
        {
            m4s.ForeColor = Color.Red;
            serialPort1.Write("allstop");
        }

        private void m4f_MouseDown(object sender, MouseEventArgs e)//BASILDI
        {
            m4s.ForeColor = Color.Green;
            serialPort1.Write("m4gof");
        }
        private void m4b_MouseUp(object sender, MouseEventArgs e)//ÇEKİLDİ
        {
            m4s.ForeColor = Color.Red;
            serialPort1.Write("allstop");
        }

        private void m4b_MouseDown(object sender, MouseEventArgs e)//BASILDI
        {
            m4s.ForeColor = Color.Green;
            serialPort1.Write("m4gob");
        }
        private void m5f_MouseUp(object sender, MouseEventArgs e)//ÇEKİLDİ
        {
            m5s.ForeColor = Color.Red;
            serialPort1.Write("allstop");
        }
        
        private void m5f_MouseDown(object sender, MouseEventArgs e)//BASILDI
        {
            m5s.ForeColor = Color.Green;
            serialPort1.Write("m5gof");
        }
        private void m5b_MouseUp(object sender, MouseEventArgs e)//ÇEKİLDİ
        {
            m5s.ForeColor = Color.Red;
            serialPort1.Write("allstop");
        }

        private void m5b_MouseDown(object sender, MouseEventArgs e)//BASILDI
        {
            m5s.ForeColor = Color.Green;
            serialPort1.Write("m5gob");
        }
        private void m6f_MouseUp(object sender, MouseEventArgs e)//ÇEKİLDİ
        {
            m6s.ForeColor = Color.Red;
            serialPort1.Write("allstop");
        }

        private void m6f_MouseDown(object sender, MouseEventArgs e)//BASILDI
        {
            m6s.ForeColor = Color.Green;
            serialPort1.Write("m6gof");
        }
        private void m6b_MouseUp(object sender, MouseEventArgs e)//ÇEKİLDİ
        {
            m6s.ForeColor = Color.Red;
            serialPort1.Write("allstop");
        }

        private void m6b_MouseDown(object sender, MouseEventArgs e)//BASILDI
        {
            m6s.ForeColor = Color.Green;
            serialPort1.Write("m6gob");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
