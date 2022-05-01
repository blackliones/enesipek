namespace eiDesktopApplication
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.removebtn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.ofiledialog = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.addbtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.clearlist = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openbtn = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.adminlabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.defbtn = new System.Windows.Forms.Button();
            this.replacetbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.classAdd = new System.Windows.Forms.Button();
            this.ClassLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.filenamepanel = new System.Windows.Forms.Panel();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.myfilepanel = new System.Windows.Forms.Panel();
            this.unrealtext = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.donebtn = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.realtext = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openfilelocation = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.filenamepanel.SuspendLayout();
            this.myfilepanel.SuspendLayout();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // removebtn
            // 
            this.removebtn.BackColor = System.Drawing.Color.Black;
            this.removebtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.removebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removebtn.ForeColor = System.Drawing.Color.Crimson;
            this.removebtn.Location = new System.Drawing.Point(1, 369);
            this.removebtn.Name = "removebtn";
            this.removebtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.removebtn.Size = new System.Drawing.Size(106, 23);
            this.removebtn.TabIndex = 1;
            this.removebtn.Text = "Remove File";
            this.toolTip1.SetToolTip(this.removebtn, "Remove your selected to file");
            this.removebtn.UseVisualStyleBackColor = false;
            this.removebtn.Click += new System.EventHandler(this.removebtn_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.ForeColor = System.Drawing.Color.Yellow;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 175);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox1.Size = new System.Drawing.Size(106, 130);
            this.listBox1.TabIndex = 2;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            this.listBox1.MouseHover += new System.EventHandler(this.listBox1_MouseHover);
            // 
            // ofiledialog
            // 
            this.ofiledialog.FileName = "Select to File";
            this.ofiledialog.InitialDirectory = "Desktop";
            this.ofiledialog.Title = "Browse";
            this.ofiledialog.FileOk += new System.ComponentModel.CancelEventHandler(this.ofiledialog_FileOk);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Desktop;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.Color.Yellow;
            this.textBox1.Location = new System.Drawing.Point(0, 3);
            this.textBox1.MaxLength = 32676;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.Size = new System.Drawing.Size(107, 45);
            this.textBox1.TabIndex = 3;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.textBox1.MouseHover += new System.EventHandler(this.textBox1_MouseHover);
            // 
            // addbtn
            // 
            this.addbtn.BackColor = System.Drawing.Color.Black;
            this.addbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbtn.ForeColor = System.Drawing.Color.Crimson;
            this.addbtn.Location = new System.Drawing.Point(2, 311);
            this.addbtn.Name = "addbtn";
            this.addbtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.addbtn.Size = new System.Drawing.Size(106, 23);
            this.addbtn.TabIndex = 1;
            this.addbtn.Text = "Add File";
            this.toolTip1.SetToolTip(this.addbtn, "Add your selected to file");
            this.addbtn.UseVisualStyleBackColor = false;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // clearlist
            // 
            this.clearlist.BackColor = System.Drawing.Color.Black;
            this.clearlist.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.clearlist.ForeColor = System.Drawing.Color.Crimson;
            this.clearlist.Location = new System.Drawing.Point(1, 398);
            this.clearlist.Name = "clearlist";
            this.clearlist.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.clearlist.Size = new System.Drawing.Size(106, 23);
            this.clearlist.TabIndex = 5;
            this.clearlist.Text = "Clear List";
            this.toolTip1.SetToolTip(this.clearlist, "Clear All List");
            this.clearlist.UseVisualStyleBackColor = false;
            this.clearlist.Click += new System.EventHandler(this.clearlist_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(177, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(98, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Hide";
            this.toolTip1.SetToolTip(this.button2, "Hide");
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(-1, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Files";
            // 
            // openbtn
            // 
            this.openbtn.BackColor = System.Drawing.Color.Black;
            this.openbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.openbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.openbtn.ForeColor = System.Drawing.Color.Crimson;
            this.openbtn.Location = new System.Drawing.Point(2, 340);
            this.openbtn.Name = "openbtn";
            this.openbtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.openbtn.Size = new System.Drawing.Size(106, 23);
            this.openbtn.TabIndex = 6;
            this.openbtn.Text = "Open File";
            this.toolTip1.SetToolTip(this.openbtn, "Open the selected file");
            this.openbtn.UseVisualStyleBackColor = false;
            this.openbtn.Click += new System.EventHandler(this.openbtn_Click);
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(3, 175);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(105, 130);
            this.listBox2.TabIndex = 2;
            this.listBox2.Visible = false;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 100;
            this.toolTip1.BackColor = System.Drawing.Color.Lavender;
            // 
            // adminlabel
            // 
            this.adminlabel.AutoSize = true;
            this.adminlabel.BackColor = System.Drawing.Color.DimGray;
            this.adminlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.adminlabel.ForeColor = System.Drawing.Color.Lime;
            this.adminlabel.Location = new System.Drawing.Point(121, 478);
            this.adminlabel.Name = "adminlabel";
            this.adminlabel.Size = new System.Drawing.Size(53, 13);
            this.adminlabel.TabIndex = 10;
            this.adminlabel.Text = "Jazz Corp";
            this.toolTip1.SetToolTip(this.adminlabel, "Enes İpek");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.defbtn);
            this.panel1.Controls.Add(this.replacetbox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.classAdd);
            this.panel1.Controls.Add(this.ClassLabel);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.listBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.addbtn);
            this.panel1.Controls.Add(this.clearlist);
            this.panel1.Controls.Add(this.openbtn);
            this.panel1.Controls.Add(this.removebtn);
            this.panel1.Location = new System.Drawing.Point(98, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(106, 462);
            this.panel1.TabIndex = 8;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.Black;
            this.checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox2.ForeColor = System.Drawing.Color.Lime;
            this.checkBox2.Location = new System.Drawing.Point(12, 427);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(89, 17);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "Run in startup";
            this.checkBox2.UseVisualStyleBackColor = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // defbtn
            // 
            this.defbtn.BackColor = System.Drawing.Color.Black;
            this.defbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.defbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.defbtn.ForeColor = System.Drawing.Color.Crimson;
            this.defbtn.Location = new System.Drawing.Point(45, 150);
            this.defbtn.Name = "defbtn";
            this.defbtn.Size = new System.Drawing.Size(61, 22);
            this.defbtn.TabIndex = 14;
            this.defbtn.Text = "Default";
            this.defbtn.UseVisualStyleBackColor = false;
            this.defbtn.Click += new System.EventHandler(this.defbtn_Click);
            // 
            // replacetbox
            // 
            this.replacetbox.BackColor = System.Drawing.Color.Black;
            this.replacetbox.ForeColor = System.Drawing.Color.Yellow;
            this.replacetbox.Location = new System.Drawing.Point(0, 99);
            this.replacetbox.Name = "replacetbox";
            this.replacetbox.Size = new System.Drawing.Size(106, 20);
            this.replacetbox.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(7, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "√";
            // 
            // classAdd
            // 
            this.classAdd.BackColor = System.Drawing.Color.Black;
            this.classAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.classAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.classAdd.ForeColor = System.Drawing.Color.Crimson;
            this.classAdd.Location = new System.Drawing.Point(45, 125);
            this.classAdd.Name = "classAdd";
            this.classAdd.Size = new System.Drawing.Size(61, 23);
            this.classAdd.TabIndex = 11;
            this.classAdd.Text = "Replace";
            this.classAdd.UseVisualStyleBackColor = false;
            this.classAdd.Click += new System.EventHandler(this.classAdd_Click);
            // 
            // ClassLabel
            // 
            this.ClassLabel.AutoSize = true;
            this.ClassLabel.Location = new System.Drawing.Point(0, 56);
            this.ClassLabel.Name = "ClassLabel";
            this.ClassLabel.Size = new System.Drawing.Size(32, 13);
            this.ClassLabel.TabIndex = 10;
            this.ClassLabel.Text = "Class";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.Black;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox1.ForeColor = System.Drawing.Color.Yellow;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 72);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(106, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // filenamepanel
            // 
            this.filenamepanel.Controls.Add(this.cancelbtn);
            this.filenamepanel.Controls.Add(this.myfilepanel);
            this.filenamepanel.Controls.Add(this.donebtn);
            this.filenamepanel.Controls.Add(this.checkBox1);
            this.filenamepanel.Controls.Add(this.realtext);
            this.filenamepanel.Controls.Add(this.label3);
            this.filenamepanel.Location = new System.Drawing.Point(5, 2);
            this.filenamepanel.Name = "filenamepanel";
            this.filenamepanel.Size = new System.Drawing.Size(94, 159);
            this.filenamepanel.TabIndex = 9;
            // 
            // cancelbtn
            // 
            this.cancelbtn.BackColor = System.Drawing.Color.Black;
            this.cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cancelbtn.ForeColor = System.Drawing.Color.Red;
            this.cancelbtn.Location = new System.Drawing.Point(0, 136);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(56, 23);
            this.cancelbtn.TabIndex = 11;
            this.cancelbtn.Text = "Cancel";
            this.cancelbtn.UseVisualStyleBackColor = false;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // myfilepanel
            // 
            this.myfilepanel.Controls.Add(this.unrealtext);
            this.myfilepanel.Controls.Add(this.label4);
            this.myfilepanel.Location = new System.Drawing.Point(1, 84);
            this.myfilepanel.Name = "myfilepanel";
            this.myfilepanel.Size = new System.Drawing.Size(93, 46);
            this.myfilepanel.TabIndex = 10;
            // 
            // unrealtext
            // 
            this.unrealtext.BackColor = System.Drawing.Color.Black;
            this.unrealtext.ForeColor = System.Drawing.Color.Yellow;
            this.unrealtext.Location = new System.Drawing.Point(5, 21);
            this.unrealtext.Name = "unrealtext";
            this.unrealtext.Size = new System.Drawing.Size(86, 20);
            this.unrealtext.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(8, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "My File Name";
            // 
            // donebtn
            // 
            this.donebtn.BackColor = System.Drawing.Color.Black;
            this.donebtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.donebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.donebtn.ForeColor = System.Drawing.Color.Lime;
            this.donebtn.Location = new System.Drawing.Point(59, 136);
            this.donebtn.Name = "donebtn";
            this.donebtn.Size = new System.Drawing.Size(35, 23);
            this.donebtn.TabIndex = 7;
            this.donebtn.Text = "Ok";
            this.donebtn.UseVisualStyleBackColor = false;
            this.donebtn.Click += new System.EventHandler(this.donebtn_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(3, 52);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 30);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "I want select \r\nmy file name";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // realtext
            // 
            this.realtext.BackColor = System.Drawing.Color.Black;
            this.realtext.ForeColor = System.Drawing.Color.Yellow;
            this.realtext.Location = new System.Drawing.Point(6, 26);
            this.realtext.Name = "realtext";
            this.realtext.Size = new System.Drawing.Size(82, 20);
            this.realtext.TabIndex = 8;
            this.realtext.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.realtext_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Original File Name";
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openfilelocation});
            this.cms.Name = "menuStrip1";
            this.cms.Size = new System.Drawing.Size(169, 26);
            // 
            // openfilelocation
            // 
            this.openfilelocation.Name = "openfilelocation";
            this.openfilelocation.Size = new System.Drawing.Size(168, 22);
            this.openfilelocation.Text = "Open file location";
            this.openfilelocation.Click += new System.EventHandler(this.openfilelocation_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(206, 495);
            this.Controls.Add(this.adminlabel);
            this.Controls.Add(this.filenamepanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(250, 0);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MainWindow";
            this.TransparencyKey = System.Drawing.Color.DimGray;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.filenamepanel.ResumeLayout(false);
            this.filenamepanel.PerformLayout();
            this.myfilepanel.ResumeLayout(false);
            this.myfilepanel.PerformLayout();
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button removebtn;
        private System.Windows.Forms.OpenFileDialog ofiledialog;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button clearlist;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button openbtn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ClassLabel;
        private System.Windows.Forms.Button classAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox replacetbox;
        private System.Windows.Forms.Button defbtn;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Panel filenamepanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button donebtn;
        private System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.TextBox realtext;
        private System.Windows.Forms.Panel myfilepanel;
        public System.Windows.Forms.TextBox unrealtext;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Label adminlabel;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem openfilelocation;
    }
}

