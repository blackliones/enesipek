using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;

namespace eiDesktopApplication
{
    public partial class Form1 : Form
    {
        public string sfname;
        public string fname;
        bool hideState;
        public bool filepanelbool;
        bool comboReplaceBool;

                public Form1()
        {
            
            InitializeComponent();
        }

        private void ofiledialog_FileOk(object sender, CancelEventArgs e)
        {
            sfname = ofiledialog.SafeFileName;
            fname = ofiledialog.FileName;
            sfname = sfname.Replace(".exe", "");
            realtext.Text = sfname;
            unrealtext.Text = sfname;
            filenamepanel.Visible = true;
            checkBox1.Checked = false;
            panel1.Visible = false;
            filepanelbool = true;
                  }
        private void addbtn_Click(object sender, EventArgs e)//OQ
        {
            //    ofiledialog.Filter = ".exe |*.exe|.txt|*.txt";
            ofiledialog.Filter = "*.*|*.*";
            ofiledialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofiledialog.FilterIndex = 2;
            ofiledialog.CheckFileExists = true;
            ofiledialog.Title = "Waiting..";
            ofiledialog.Multiselect = false;
            ofiledialog.ShowDialog();
                          }

        private void removebtn_Click(object sender, EventArgs e)
        {
                     if (listBox1.Items.Count > 0)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    Properties.Settings.Default.fn1.Remove(listBox1.SelectedItem.ToString());
                    Properties.Settings.Default.fl1.Remove(listBox2.SelectedItem.ToString());
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    Properties.Settings.Default.fn2.Remove(listBox1.SelectedItem.ToString());
                    Properties.Settings.Default.fl2.Remove(listBox2.SelectedItem.ToString());
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    Properties.Settings.Default.fn3.Remove(listBox1.SelectedItem.ToString());
                    Properties.Settings.Default.fl3.Remove(listBox2.SelectedItem.ToString());
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    Properties.Settings.Default.fn4.Remove(listBox1.SelectedItem.ToString());
                    Properties.Settings.Default.fl4.Remove(listBox2.SelectedItem.ToString());
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                }
                Properties.Settings.Default.Save();
                if (listBox1.Items.Count > 0)
                    listBox1.SelectedIndex = 0;
                              textBox1.Text = "";
            }
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            Properties.Settings.Default.startuprun = checkBox2.Checked;
           if (listBox1.Items.Count > 0)
            {
                listBox2.SelectedIndex = listBox1.SelectedIndex;
            }
            if (listBox1.SelectedIndex >= 0)
            {
                openbtn.Enabled = true;
                clearlist.Enabled = true;
                removebtn.Enabled = true;
            }
            else
            {
                openbtn.Enabled = false;
                clearlist.Enabled = false;
                removebtn.Enabled = false;
            }

        }
             private void clearlist_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                if (MessageBox.Show("Do you want remove to all file location?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();

                    if (comboBox1.SelectedIndex == 0)
                    {
                        Properties.Settings.Default.fl1.Clear();
                        Properties.Settings.Default.fn1.Clear();
                    }
                   else if (comboBox1.SelectedIndex == 1)
                    {
                        Properties.Settings.Default.fl2.Clear();
                        Properties.Settings.Default.fn2.Clear();
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        Properties.Settings.Default.fl3.Clear();
                        Properties.Settings.Default.fn3.Clear();
                    }
                    else if (comboBox1.SelectedIndex == 3)
                    {
                        Properties.Settings.Default.fl4.Clear();
                        Properties.Settings.Default.fn4.Clear();
                    }

                    textBox1.Text = "";
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Closing the program ?", "YES/NO", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Properties.Settings.Default.Save();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                     hideState = !hideState;
            if (hideState)
            {
                button1.Visible=false;
                panel1.Visible=false;
                filenamepanel.Visible = false;
                button2.Location = new Point(button2.Location.X + 58, button2.Location.Y);
                adminlabel.Visible = false;
                button2.ForeColor = Color.Lime;
            }
            else
            {
                if (filepanelbool)
                    filenamepanel.Visible = true;
                button2.Location = new Point(button2.Location.X - 58, button2.Location.Y);
                panel1.Visible=true;
                button1.Visible = true;
                adminlabel.Visible = true;
                button2.ForeColor = Color.Red;
            }
        }
   
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(1160, 0);
            label2.ForeColor = Color.Black;
            replacetbox.Visible = false;
            myfilepanel.Visible = false;
            //Properties.Settings.Default.Reset();
            checkBox2.Checked = Properties.Settings.Default.startuprun;
            Properties.Settings.Default.Save();
            filenamepanel.Visible = false;
            filepanelbool = false;
            comboReplaceBool = false;
            foreach (string item2 in Properties.Settings.Default.comboClass)
            {
                comboBox1.Items.Add(item2);
            }
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "" + listBox2.SelectedItem;
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    
        private void openbtn_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to start the run as an administrator?", "Selection", MessageBoxButtons.YesNoCancel);
             
                if (dialogResult == DialogResult.Yes)
                {
                    
                    try
                    {
                        new Process() { StartInfo = new ProcessStartInfo(textBox1.Text) { Verb = "runas" } }.Start();
                    }
                    catch 
                    {
                     
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    try
                    {
                        Process.Start(textBox1.Text);
                    }
                    catch
                    {
                       
                    }
                }
                           }
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox1, textBox1.Text);

        }

        private void listBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(listBox1, "" + listBox1.SelectedItem);
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void classAdd_Click(object sender, EventArgs e)
        {

            comboReplaceBool = !comboReplaceBool;
            if (comboReplaceBool)
            {
                label2.ForeColor = Color.Lime;
                classAdd.ForeColor = Color.Green;
                replacetbox.Visible = true;
            }
            else
            {
                classAdd.ForeColor = Color.Red;
                int index = comboBox1.SelectedIndex;
                if (replacetbox.Text != "" && comboBox1.Text != "General Applications" && !comboBox1.Items.Contains(replacetbox.Text))
                {
                    comboBox1.Text = "";
                    Properties.Settings.Default.comboClass.Remove(comboBox1.SelectedItem.ToString());
                    Properties.Settings.Default.comboClass.Insert(index, replacetbox.Text);
                    comboBox1.Items.RemoveAt(index);
                    comboBox1.Items.Insert(index, replacetbox.Text);
                    comboBox1.SelectedIndex = index;
                }
                else
                {
                    
                    MessageBox.Show("Try again please. You must can't remove main item and You must can't add same");
                                 }
                Properties.Settings.Default.Save();
                label2.ForeColor = Color.Black;
                replacetbox.Visible = false;
            }
        }

        private void defbtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Return to defaults ?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                comboBox1.Items.Clear();
                comboBox1.Items.Insert(0, "General Applications");
                comboBox1.Items.Insert(1, "Custom Applications");
                comboBox1.Items.Insert(2, "Null1");
                comboBox1.Items.Insert(3, "Null2");
                Properties.Settings.Default.comboClass.Clear();
                Properties.Settings.Default.comboClass.Insert(0, "General Applications");
                Properties.Settings.Default.comboClass.Insert(1, "Custom Applications");
                Properties.Settings.Default.comboClass.Insert(2, "Null1");
                Properties.Settings.Default.comboClass.Insert(3, "Null2");
                comboBox1.SelectedIndex = 0;
                Properties.Settings.Default.Save();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox1.Text = "";
            callingFile();
        }
        void callingFile()
        {
            if (comboBox1.SelectedIndex == 0)
            {
                foreach (string item in Properties.Settings.Default.fn1)
                {
                    listBox1.Items.Add(item);
                }
                foreach (string item1 in Properties.Settings.Default.fl1)
                {
                    listBox2.Items.Add(item1);
                }
            }
           else if (comboBox1.SelectedIndex == 1)
            {
                foreach (string item in Properties.Settings.Default.fn2)
                {
                    listBox1.Items.Add(item);
                }
                foreach (string item1 in Properties.Settings.Default.fl2)
                {
                    listBox2.Items.Add(item1);
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                foreach (string item in Properties.Settings.Default.fn3)
                {
                    listBox1.Items.Add(item);
                }
                foreach (string item1 in Properties.Settings.Default.fl3)
                {
                    listBox2.Items.Add(item1);
                }
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                foreach (string item in Properties.Settings.Default.fn4)
                {
                    listBox1.Items.Add(item);
                }
                foreach (string item1 in Properties.Settings.Default.fl4)
                {
                    listBox2.Items.Add(item1);
                }
            }
            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;
            if (listBox2.Items.Count > 0)
                listBox2.SelectedIndex = 0;
        }

        private void donebtn_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            filenamepanel.Visible = false;
            filepanelbool = false;
            if (checkBox1.Checked)
            {
                sfname = unrealtext.Text;
            }
            else
            {
                sfname = realtext.Text;
            }
            if (listBox1.Items.Contains(sfname)||listBox2.Items.Contains(fname))
            {
                DialogResult dialogResult = MessageBox.Show("This file is available to list! Do you want still to add?", "Operation..", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    addlist();
                }
                         }
            else
            {
                addlist();
            }
        }
        void addlist()
        {
            if (comboBox1.SelectedIndex == 0)
            {

                Properties.Settings.Default.fn1.Add(sfname);
                Properties.Settings.Default.fl1.Add(fname);
                Properties.Settings.Default.Save();
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (string item in Properties.Settings.Default.fn1)
                {
                    listBox1.Items.Add(item);
                    listBox1.SelectedItem = item;
                }
                foreach (string item in Properties.Settings.Default.fl1)
                {
                    listBox2.Items.Add(item);
                    listBox2.SelectedItem = item;
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                Properties.Settings.Default.fn2.Add(sfname);
                Properties.Settings.Default.fl2.Add(fname);
                Properties.Settings.Default.Save();
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (string item in Properties.Settings.Default.fn2)
                {
                    listBox1.Items.Add(item);
                    listBox1.SelectedItem = item;
                }
                foreach (string item in Properties.Settings.Default.fl2)
                {
                    listBox2.Items.Add(item);
                    listBox2.SelectedItem = item;
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                Properties.Settings.Default.fn3.Add(sfname);
                Properties.Settings.Default.fl3.Add(fname);
                Properties.Settings.Default.Save();
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (string item in Properties.Settings.Default.fn3)
                {
                    listBox1.Items.Add(item);
                    listBox1.SelectedItem = item;
                }
                foreach (string item in Properties.Settings.Default.fl3)
                {
                    listBox2.Items.Add(item);
                    listBox2.SelectedItem = item;
                }
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                Properties.Settings.Default.fn4.Add(sfname);
                Properties.Settings.Default.fl4.Add(fname);
                Properties.Settings.Default.Save();
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (string item in Properties.Settings.Default.fn4)
                {
                    listBox1.Items.Add(item);
                    listBox1.SelectedItem = item;
                }
                foreach (string item in Properties.Settings.Default.fl4)
                {
                    listBox2.Items.Add(item);
                    listBox2.SelectedItem = item;
                }
            }
        }//after donebtn
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                myfilepanel.Visible = true;
              unrealtext.Text = realtext.Text;
            }
            else
            {
                myfilepanel.Visible = false;
                unrealtext.Text = "";
            }
        }

        private void realtext_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            filepanelbool = false;
            panel1.Visible = true;
            checkBox1.Checked = false;
            myfilepanel.Visible = false;
            filenamepanel.Visible = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            SetStartup();
        }
        private void SetStartup()
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (checkBox2.Checked)
            {
                     rkApp.SetValue("ApplicationName",Application.ExecutablePath);
                         }
            else
            {
                    rkApp.DeleteValue("ApplicationName");
                         }
            }
        
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to start the run as an administrator?", "Selection", MessageBoxButtons.YesNoCancel);

                if (dialogResult == DialogResult.Yes)
                {

                    try
                    {
                        new Process() { StartInfo = new ProcessStartInfo(textBox1.Text) { Verb = "runas" } }.Start();
                    }
                    catch
                    {
                     
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
              
                    try
                    {
                    Process.Start(textBox1.Text);
                    }
                    catch
                    {
                     
                    }
                }
            }
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
              
                cms.Show(Cursor.Position);
            }
          
        }

        private void openfilelocation_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text))
            {
                Process.Start(new ProcessStartInfo("explorer.exe", " /select, " + textBox1.Text));
            }
        }
    }
  
}