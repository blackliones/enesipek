using System.IO;
using System.Drawing.Imaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webCamCapture1.Start(0);
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webCamCapture1.Stop();
            button1.Enabled = true;
            button2.Enabled = false;
        }
        private void webCamCapture1_ImageCaptured(object source, WebCam_Capture.WebcamEventArgs e)
        {
            pictureBox1.Image = e.WebCamImage;
        }
        int a = 0;
        int b = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();//yeni bir kaydetme diyaloğu oluşturuyoruz.

            sfd.Filter = "Jpeg dosyası(*.jpg)|*.jpg|Png Dosyası(*.png)|*.png";

            sfd.Title = "Kayıt";//diğaloğumuzun başlığını belirliyoruz.

            sfd.FileName = "WebCamPicture1";//kaydedilen resmimizin adını 'resim' olarak belirliyoruz.

            DialogResult sonuç = sfd.ShowDialog();

            if (sonuç == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName);//Böylelikle resmi istediğimiz yere kaydediyoruz.
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Hide();
            trackBar1.Value = 100;

            webCamCapture1.CaptureWidth = 666; //form yüklenmesi esnasında alınan görüntü genişliği 640px
            webCamCapture1.CaptureHeight = 358;//form yüklenmesi esnasında alınan görüntü genişliği 640px
            webCamCapture1.Start(0);
            button1.Enabled = false;
            timer2.Enabled = true;//timer varsayılan olarak devre dışı halde olur, program açılışında
            //etkindeştiriyoruz
            timer2.Interval = 1000;//timer2'in tick olayının çalışması için gereken süre (ms)
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            b = b + 1; //her saniye bir arttırması için
            if (b < 60) //eğer b, 60'tan küçükse
            {
                this.Text = "Web Camera - PAW FİVE " + b.ToString() + " Saniyedir Kayıtta..."; //diye yazdırdık
            }
            else //değilse yani b 60'tan büyükse dakikayı yazmak için
                this.Text = "Web Camera - PAW FİVE " + (b / 60).ToString() + " Dakikadır Kayıtta..."; //b'yi 60'a bölüp
            //this.text'e yani Form1.ActiveForm.Text'e, yani form başlığına yazdırdık
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.Opacity = trackBar1.Value / 100.0;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label1.Show();
            label2.Hide();
            trackBar1.Visible = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Hide();
            label2.Show();
            trackBar1.Visible = false;

        }


        private void button4_Click(object sender, EventArgs e)
        {
                 this.Opacity = 0;
            SaveFileDialog sfd2 = new SaveFileDialog();//yeni bir kaydetme diyaloğu oluşturuyoruz.

            sfd2.Filter = "Jpeg dosyası(*.jpg)|*.jpg|Png Dosyası(*.png)|*.png";
            sfd2.Title = "Kayıt";//diğaloğumuzun başlığını belirliyoruz.

            sfd2.FileName = "Webcam Photo 1";//kaydedilen resmimizin adını 'resim' olarak belirliyoruz.

            DialogResult sonuç = sfd2.ShowDialog();

            if (sonuç == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd2.FileName);   
                System.Threading.Thread.Sleep(1000);
                this.Opacity = 100;
            }
        }
        
private Bitmap Screenshot() // Bitmap türünde olşuturuyoruz  fonksiyonumuzu. 
        {
            Bitmap Screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics GFX = Graphics.FromImage(Screenshot);
            GFX.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size);
            return Screenshot;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
           
                button4.PerformClick();
             
            }
        }

        private void renkliyazı_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            label3.ForeColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));

        }

        private void label3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Yapımcının Facebook Adresine Bağlanılıyor...", "Waiting...", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("www.facebook.com/liveenes");
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            webCamCapture1.CaptureWidth = 1366; //form yüklenmesi esnasında alınan görüntü genişliği 640px
            webCamCapture1.CaptureHeight = 703;//form yüklenmesi esnasında alınan görüntü genişliği 640px
            pictureBox1.Location = new Point(-1, 1);
            button1.Location = new Point(12, 710);
            button2.Location = new Point(93, 710);
            button3.Location = new Point(396, 710);
            button4.Location = new Point(174, 710);
            label1.Location = new Point(310, 715);
            label2.Location = new Point(310, 715);
            label3.Location = new Point(490, 715);
            label4.Location = new Point(559, 715);
            pictureBox2.Location = new Point(543, 716);

            button5.Hide();
            button6.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {    
            Application.Restart();
        }
        private void ekranGörüntüsüAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
            Screenshot().Save(@"C:\Users\Enes\Desktop\ScreenShot1.jpg ",ImageFormat.Jpeg);
      System.Threading.Thread.Sleep(1000);
      this.Opacity = 100;
        }
    }
}
                                       
    
                     
               
       
        