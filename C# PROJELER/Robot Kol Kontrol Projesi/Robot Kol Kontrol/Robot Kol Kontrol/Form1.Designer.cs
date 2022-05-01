namespace Robot_Kol_Kontrol
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.connectbtn = new System.Windows.Forms.Button();
            this.portinf = new System.Windows.Forms.ComboBox();
            this.baudrateinf = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dconnectbtn = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.refbtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.controlpanel = new System.Windows.Forms.Panel();
            this.m6s = new System.Windows.Forms.Label();
            this.m5s = new System.Windows.Forms.Label();
            this.m4s = new System.Windows.Forms.Label();
            this.m3s = new System.Windows.Forms.Label();
            this.m2s = new System.Windows.Forms.Label();
            this.m1s = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m6b = new System.Windows.Forms.Button();
            this.m6f = new System.Windows.Forms.Button();
            this.m5b = new System.Windows.Forms.Button();
            this.m5f = new System.Windows.Forms.Button();
            this.m4b = new System.Windows.Forms.Button();
            this.m4f = new System.Windows.Forms.Button();
            this.m3b = new System.Windows.Forms.Button();
            this.m3f = new System.Windows.Forms.Button();
            this.m2b = new System.Windows.Forms.Button();
            this.m2f = new System.Windows.Forms.Button();
            this.m1b = new System.Windows.Forms.Button();
            this.m1f = new System.Windows.Forms.Button();
            this.controlpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectbtn
            // 
            this.connectbtn.BackColor = System.Drawing.Color.Black;
            this.connectbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.connectbtn.ForeColor = System.Drawing.Color.Green;
            this.connectbtn.Location = new System.Drawing.Point(174, 72);
            this.connectbtn.Name = "connectbtn";
            this.connectbtn.Size = new System.Drawing.Size(75, 21);
            this.connectbtn.TabIndex = 0;
            this.connectbtn.Text = "CONNECT";
            this.connectbtn.UseVisualStyleBackColor = false;
            this.connectbtn.Click += new System.EventHandler(this.connectbtn_Click);
            // 
            // portinf
            // 
            this.portinf.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.portinf.FormattingEnabled = true;
            this.portinf.Location = new System.Drawing.Point(12, 30);
            this.portinf.Name = "portinf";
            this.portinf.Size = new System.Drawing.Size(156, 21);
            this.portinf.TabIndex = 2;
            this.portinf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.portinf_KeyPress);
            // 
            // baudrateinf
            // 
            this.baudrateinf.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.baudrateinf.FormattingEnabled = true;
            this.baudrateinf.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.baudrateinf.Items.AddRange(new object[] {
            "300\t",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "74880",
            "115200",
            "230400",
            "250000"});
            this.baudrateinf.Location = new System.Drawing.Point(12, 72);
            this.baudrateinf.Name = "baudrateinf";
            this.baudrateinf.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.baudrateinf.Size = new System.Drawing.Size(156, 21);
            this.baudrateinf.TabIndex = 4;
            this.baudrateinf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.baudrateinf_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Baud Rate";
            // 
            // dconnectbtn
            // 
            this.dconnectbtn.BackColor = System.Drawing.Color.Black;
            this.dconnectbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dconnectbtn.ForeColor = System.Drawing.Color.Red;
            this.dconnectbtn.Location = new System.Drawing.Point(255, 72);
            this.dconnectbtn.Name = "dconnectbtn";
            this.dconnectbtn.Size = new System.Drawing.Size(87, 21);
            this.dconnectbtn.TabIndex = 6;
            this.dconnectbtn.Text = "DISCONNECT";
            this.dconnectbtn.UseVisualStyleBackColor = false;
            this.dconnectbtn.Click += new System.EventHandler(this.dconnectbtn_Click);
            // 
            // refbtn
            // 
            this.refbtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.refbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.refbtn.Location = new System.Drawing.Point(174, 30);
            this.refbtn.Name = "refbtn";
            this.refbtn.Size = new System.Drawing.Size(75, 21);
            this.refbtn.TabIndex = 7;
            this.refbtn.Text = "REFRESH";
            this.refbtn.UseVisualStyleBackColor = false;
            this.refbtn.Click += new System.EventHandler(this.refbtn_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // controlpanel
            // 
            this.controlpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlpanel.BackgroundImage = global::Robot_Kol_Kontrol.Properties.Resources.robot_mechanical_arm_cutout_1;
            this.controlpanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.controlpanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.controlpanel.Controls.Add(this.m6s);
            this.controlpanel.Controls.Add(this.m5s);
            this.controlpanel.Controls.Add(this.m4s);
            this.controlpanel.Controls.Add(this.m3s);
            this.controlpanel.Controls.Add(this.m2s);
            this.controlpanel.Controls.Add(this.m1s);
            this.controlpanel.Controls.Add(this.label8);
            this.controlpanel.Controls.Add(this.label7);
            this.controlpanel.Controls.Add(this.label6);
            this.controlpanel.Controls.Add(this.label5);
            this.controlpanel.Controls.Add(this.label4);
            this.controlpanel.Controls.Add(this.label3);
            this.controlpanel.Controls.Add(this.m6b);
            this.controlpanel.Controls.Add(this.m6f);
            this.controlpanel.Controls.Add(this.m5b);
            this.controlpanel.Controls.Add(this.m5f);
            this.controlpanel.Controls.Add(this.m4b);
            this.controlpanel.Controls.Add(this.m4f);
            this.controlpanel.Controls.Add(this.m3b);
            this.controlpanel.Controls.Add(this.m3f);
            this.controlpanel.Controls.Add(this.m2b);
            this.controlpanel.Controls.Add(this.m2f);
            this.controlpanel.Controls.Add(this.m1b);
            this.controlpanel.Controls.Add(this.m1f);
            this.controlpanel.Location = new System.Drawing.Point(12, 99);
            this.controlpanel.Name = "controlpanel";
            this.controlpanel.Size = new System.Drawing.Size(330, 294);
            this.controlpanel.TabIndex = 8;
            // 
            // m6s
            // 
            this.m6s.AutoSize = true;
            this.m6s.BackColor = System.Drawing.Color.Transparent;
            this.m6s.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.m6s.Location = new System.Drawing.Point(288, 250);
            this.m6s.Name = "m6s";
            this.m6s.Size = new System.Drawing.Size(22, 24);
            this.m6s.TabIndex = 3;
            this.m6s.Text = "✓";
            // 
            // m5s
            // 
            this.m5s.AutoSize = true;
            this.m5s.BackColor = System.Drawing.Color.Transparent;
            this.m5s.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.m5s.Location = new System.Drawing.Point(288, 206);
            this.m5s.Name = "m5s";
            this.m5s.Size = new System.Drawing.Size(22, 24);
            this.m5s.TabIndex = 3;
            this.m5s.Text = "✓";
            // 
            // m4s
            // 
            this.m4s.AutoSize = true;
            this.m4s.BackColor = System.Drawing.Color.Transparent;
            this.m4s.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.m4s.Location = new System.Drawing.Point(288, 160);
            this.m4s.Name = "m4s";
            this.m4s.Size = new System.Drawing.Size(22, 24);
            this.m4s.TabIndex = 3;
            this.m4s.Text = "✓";
            // 
            // m3s
            // 
            this.m3s.AutoSize = true;
            this.m3s.BackColor = System.Drawing.Color.Transparent;
            this.m3s.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.m3s.Location = new System.Drawing.Point(288, 114);
            this.m3s.Name = "m3s";
            this.m3s.Size = new System.Drawing.Size(22, 24);
            this.m3s.TabIndex = 3;
            this.m3s.Text = "✓";
            // 
            // m2s
            // 
            this.m2s.AutoSize = true;
            this.m2s.BackColor = System.Drawing.Color.Transparent;
            this.m2s.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.m2s.Location = new System.Drawing.Point(288, 68);
            this.m2s.Name = "m2s";
            this.m2s.Size = new System.Drawing.Size(22, 24);
            this.m2s.TabIndex = 3;
            this.m2s.Text = "✓";
            // 
            // m1s
            // 
            this.m1s.AutoSize = true;
            this.m1s.BackColor = System.Drawing.Color.Transparent;
            this.m1s.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.m1s.Location = new System.Drawing.Point(288, 25);
            this.m1s.Name = "m1s";
            this.m1s.Size = new System.Drawing.Size(22, 24);
            this.m1s.TabIndex = 3;
            this.m1s.Text = "✓";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 248);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 26);
            this.label8.TabIndex = 2;
            this.label8.Text = "M6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 26);
            this.label7.TabIndex = 2;
            this.label7.Text = "M5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 26);
            this.label6.TabIndex = 2;
            this.label6.Text = "M4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 26);
            this.label5.TabIndex = 2;
            this.label5.Text = "M3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 26);
            this.label4.TabIndex = 2;
            this.label4.Text = "M2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "M1";
            // 
            // m6b
            // 
            this.m6b.BackColor = System.Drawing.SystemColors.ControlText;
            this.m6b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m6b.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F);
            this.m6b.ForeColor = System.Drawing.Color.Red;
            this.m6b.Location = new System.Drawing.Point(181, 241);
            this.m6b.Name = "m6b";
            this.m6b.Size = new System.Drawing.Size(89, 40);
            this.m6b.TabIndex = 1;
            this.m6b.Text = ">";
            this.m6b.UseVisualStyleBackColor = false;
            this.m6b.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m6b_MouseDown);
            this.m6b.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m6b_MouseUp);
            // 
            // m6f
            // 
            this.m6f.BackColor = System.Drawing.SystemColors.ControlText;
            this.m6f.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m6f.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m6f.ForeColor = System.Drawing.Color.Red;
            this.m6f.Location = new System.Drawing.Point(86, 241);
            this.m6f.Name = "m6f";
            this.m6f.Size = new System.Drawing.Size(89, 40);
            this.m6f.TabIndex = 0;
            this.m6f.Text = "<";
            this.m6f.UseVisualStyleBackColor = false;
            this.m6f.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m6f_MouseDown);
            this.m6f.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m6f_MouseUp);
            // 
            // m5b
            // 
            this.m5b.BackColor = System.Drawing.SystemColors.ControlText;
            this.m5b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m5b.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F);
            this.m5b.ForeColor = System.Drawing.Color.Red;
            this.m5b.Location = new System.Drawing.Point(181, 197);
            this.m5b.Name = "m5b";
            this.m5b.Size = new System.Drawing.Size(89, 40);
            this.m5b.TabIndex = 1;
            this.m5b.Text = ">";
            this.m5b.UseVisualStyleBackColor = false;
            this.m5b.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m5b_MouseDown);
            this.m5b.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m5b_MouseUp);
            // 
            // m5f
            // 
            this.m5f.BackColor = System.Drawing.SystemColors.ControlText;
            this.m5f.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m5f.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m5f.ForeColor = System.Drawing.Color.Red;
            this.m5f.Location = new System.Drawing.Point(86, 197);
            this.m5f.Name = "m5f";
            this.m5f.Size = new System.Drawing.Size(89, 40);
            this.m5f.TabIndex = 0;
            this.m5f.Text = "<";
            this.m5f.UseVisualStyleBackColor = false;
            this.m5f.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m5f_MouseDown);
            this.m5f.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m5f_MouseUp);
            // 
            // m4b
            // 
            this.m4b.BackColor = System.Drawing.SystemColors.ControlText;
            this.m4b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m4b.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F);
            this.m4b.ForeColor = System.Drawing.Color.Red;
            this.m4b.Location = new System.Drawing.Point(181, 151);
            this.m4b.Name = "m4b";
            this.m4b.Size = new System.Drawing.Size(89, 40);
            this.m4b.TabIndex = 1;
            this.m4b.Text = ">";
            this.m4b.UseVisualStyleBackColor = false;
            this.m4b.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m4b_MouseDown);
            this.m4b.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m4b_MouseUp);
            // 
            // m4f
            // 
            this.m4f.BackColor = System.Drawing.SystemColors.ControlText;
            this.m4f.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m4f.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m4f.ForeColor = System.Drawing.Color.Red;
            this.m4f.Location = new System.Drawing.Point(86, 151);
            this.m4f.Name = "m4f";
            this.m4f.Size = new System.Drawing.Size(89, 40);
            this.m4f.TabIndex = 0;
            this.m4f.Text = "<";
            this.m4f.UseVisualStyleBackColor = false;
            this.m4f.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m4f_MouseDown);
            this.m4f.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m4f_MouseUp);
            // 
            // m3b
            // 
            this.m3b.BackColor = System.Drawing.SystemColors.ControlText;
            this.m3b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m3b.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F);
            this.m3b.ForeColor = System.Drawing.Color.Red;
            this.m3b.Location = new System.Drawing.Point(181, 105);
            this.m3b.Name = "m3b";
            this.m3b.Size = new System.Drawing.Size(89, 40);
            this.m3b.TabIndex = 1;
            this.m3b.Text = ">";
            this.m3b.UseVisualStyleBackColor = false;
            this.m3b.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m3b_MouseDown);
            this.m3b.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m3b_MouseUp);
            // 
            // m3f
            // 
            this.m3f.BackColor = System.Drawing.SystemColors.ControlText;
            this.m3f.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m3f.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m3f.ForeColor = System.Drawing.Color.Red;
            this.m3f.Location = new System.Drawing.Point(86, 105);
            this.m3f.Name = "m3f";
            this.m3f.Size = new System.Drawing.Size(89, 40);
            this.m3f.TabIndex = 0;
            this.m3f.Text = "<";
            this.m3f.UseVisualStyleBackColor = false;
            this.m3f.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m3f_MouseDown);
            this.m3f.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m3f_MouseUp);
            // 
            // m2b
            // 
            this.m2b.BackColor = System.Drawing.SystemColors.ControlText;
            this.m2b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m2b.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F);
            this.m2b.ForeColor = System.Drawing.Color.Red;
            this.m2b.Location = new System.Drawing.Point(181, 59);
            this.m2b.Name = "m2b";
            this.m2b.Size = new System.Drawing.Size(89, 40);
            this.m2b.TabIndex = 1;
            this.m2b.Text = ">";
            this.m2b.UseVisualStyleBackColor = false;
            this.m2b.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m2b_MouseDown);
            this.m2b.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m2b_MouseUp);
            // 
            // m2f
            // 
            this.m2f.BackColor = System.Drawing.SystemColors.ControlText;
            this.m2f.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m2f.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m2f.ForeColor = System.Drawing.Color.Red;
            this.m2f.Location = new System.Drawing.Point(86, 59);
            this.m2f.Name = "m2f";
            this.m2f.Size = new System.Drawing.Size(89, 40);
            this.m2f.TabIndex = 0;
            this.m2f.Text = "<";
            this.m2f.UseVisualStyleBackColor = false;
            this.m2f.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m2f_MouseDown);
            this.m2f.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m2f_MouseUp);
            // 
            // m1b
            // 
            this.m1b.BackColor = System.Drawing.SystemColors.ControlText;
            this.m1b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m1b.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F);
            this.m1b.ForeColor = System.Drawing.Color.Red;
            this.m1b.Location = new System.Drawing.Point(181, 16);
            this.m1b.Name = "m1b";
            this.m1b.Size = new System.Drawing.Size(89, 40);
            this.m1b.TabIndex = 1;
            this.m1b.Text = ">";
            this.m1b.UseVisualStyleBackColor = false;
            this.m1b.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m1b_MouseDown);
            this.m1b.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m1b_MouseUp);
            // 
            // m1f
            // 
            this.m1f.BackColor = System.Drawing.SystemColors.ControlText;
            this.m1f.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m1f.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m1f.ForeColor = System.Drawing.Color.Red;
            this.m1f.Location = new System.Drawing.Point(86, 16);
            this.m1f.Name = "m1f";
            this.m1f.Size = new System.Drawing.Size(89, 40);
            this.m1f.TabIndex = 0;
            this.m1f.Text = "<";
            this.m1f.UseVisualStyleBackColor = false;
            this.m1f.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m1f_MouseDown);
            this.m1f.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m1f_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 405);
            this.Controls.Add(this.controlpanel);
            this.Controls.Add(this.refbtn);
            this.Controls.Add(this.dconnectbtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.baudrateinf);
            this.Controls.Add(this.portinf);
            this.Controls.Add(this.connectbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(366, 444);
            this.MinimumSize = new System.Drawing.Size(366, 444);
            this.Name = "Form1";
            this.Text = "Robot Controller";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.controlpanel.ResumeLayout(false);
            this.controlpanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectbtn;
        private System.Windows.Forms.ComboBox portinf;
        private System.Windows.Forms.ComboBox baudrateinf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button dconnectbtn;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button refbtn;
        private System.Windows.Forms.Panel controlpanel;
        private System.Windows.Forms.Button m1f;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button m6b;
        private System.Windows.Forms.Button m6f;
        private System.Windows.Forms.Button m5b;
        private System.Windows.Forms.Button m5f;
        private System.Windows.Forms.Button m4b;
        private System.Windows.Forms.Button m4f;
        private System.Windows.Forms.Button m3b;
        private System.Windows.Forms.Button m3f;
        private System.Windows.Forms.Button m2b;
        private System.Windows.Forms.Button m2f;
        private System.Windows.Forms.Button m1b;
        private System.Windows.Forms.Label m6s;
        private System.Windows.Forms.Label m5s;
        private System.Windows.Forms.Label m4s;
        private System.Windows.Forms.Label m3s;
        private System.Windows.Forms.Label m2s;
        private System.Windows.Forms.Label m1s;
        private System.Windows.Forms.Timer timer1;
    }
}

