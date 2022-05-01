namespace ardcsharp
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
            this.on = new System.Windows.Forms.Button();
            this.off = new System.Windows.Forms.Button();
            this.sp = new System.IO.Ports.SerialPort(this.components);
            this.connect = new System.Windows.Forms.Button();
            this.disconnect = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // on
            // 
            this.on.Location = new System.Drawing.Point(41, 82);
            this.on.Name = "on";
            this.on.Size = new System.Drawing.Size(75, 47);
            this.on.TabIndex = 0;
            this.on.Text = "ON";
            this.on.UseVisualStyleBackColor = true;
            this.on.Click += new System.EventHandler(this.button1_Click);
            // 
            // off
            // 
            this.off.Location = new System.Drawing.Point(154, 82);
            this.off.Name = "off";
            this.off.Size = new System.Drawing.Size(75, 47);
            this.off.TabIndex = 1;
            this.off.Text = "OFF";
            this.off.UseVisualStyleBackColor = true;
            this.off.Click += new System.EventHandler(this.button2_Click);
            // 
            // sp
            // 
            this.sp.PortName = "COM10";
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(31, 35);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(85, 23);
            this.connect.TabIndex = 2;
            this.connect.Text = "CONNECT";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.button3_Click);
            // 
            // disconnect
            // 
            this.disconnect.Location = new System.Drawing.Point(154, 35);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(85, 23);
            this.disconnect.TabIndex = 3;
            this.disconnect.Text = "DİSCONNECT";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.button4_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(103, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "NULL";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.disconnect);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.off);
            this.Controls.Add(this.on);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button off;
        public System.IO.Ports.SerialPort sp;
        protected System.Windows.Forms.Button on;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button disconnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}

