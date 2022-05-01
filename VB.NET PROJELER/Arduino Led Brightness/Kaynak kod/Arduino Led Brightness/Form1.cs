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

namespace Arduino_Led_Brightness
{
    public partial class Form1 : Form
    {
        SerialPort serialport;
        public Form1()
        {
            InitializeComponent();
            serialport = new SerialPort();
            serialport.BaudRate = 9600;
           }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "COM4";
            groupBox2.Enabled = false;
            Button2.Enabled = false;
        }

        //Timer_Tick
         //Durdur
            private void label3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.facebook.com/liveenes");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
                            timer1.Start();
                try
                {
                                 serialport.PortName = textBox1.Text;
                    if (!serialport.IsOpen)
                        serialport.Open();
                    MessageBox.Show("Bağlandi");
                    groupBox2.Enabled = true;
                    Button2.Enabled = true;
                    Button1.Enabled = false;
                    textBox1.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("Seri Port Hatası!");
                    Button1.Enabled = true;
                    Button2.Enabled = false;
                }
                    }

        private void Button2_Click(object sender, EventArgs e)
        {
                            timer1.Stop();
                serialport.Close();
                groupBox2.Enabled = false;
                Button2.Enabled = false;
                Button1.Enabled = true;
                textBox1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                string ledval = trackBar1.Value.ToString();
                textBox2.Text = ledval;
                serialport.WriteLine(ledval);
                serialport.WriteLine(",");
            }
            catch (Exception ex) { }
        }
                    private void timer2_Tick(object sender, EventArgs e)
        {
            label3.Text = label3.Text.Substring(1) + label3.Text.Substring(1, 0) + label3.Text.Substring(0, 1);
        }
    }
}