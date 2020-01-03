using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace YazılımSınamaOdevi
{
    public partial class OgretmenEkraniSoruTuru3 : MetroFramework.Controls.MetroUserControl
    {
        public OgretmenEkraniSoruTuru3()
        {
            InitializeComponent();
        }
        OpenFileDialog file = new OpenFileDialog();

        public void Sıfırla()
        {
            ASikkiPictureBox.ImageLocation = null;
            BSikkiPictureBox.ImageLocation = null;
            CSikkiPictureBox.ImageLocation = null;
            DSikkiPictureBox.ImageLocation = null;
            txtSoruMetni.Text = "";
            cmbBxKonuSec.SelectedIndex = -1;
            SoruResmi.ImageLocation = null;
        }
        private void OgretmenEkraniSoruTuru3_Load(object sender, EventArgs e)
        {

        }

        private void btnSoruResimSec_Click(object sender, EventArgs e)
        {
            
            file.Filter = "Resim Dosyası |*.png;*.jpg;*.jpeg";            
            file.ShowDialog();
            string ad = "images\\" + DateTime.Now.Ticks.ToString() + ".jpg";            
            if (file.FileName != "") {
                File.Copy(@file.FileName, @ad);
            }
            SoruResmi.ImageLocation = ad;
            
        }

        private void btnASikkiResimSec_Click(object sender, EventArgs e)
        {
            file.Filter = "Resim Dosyası |*.png;*.jpg;*.jpeg";
            file.ShowDialog();
            string ad = "images\\" + DateTime.Now.Ticks.ToString() + ".jpg";
            if (file.FileName != "")
            {
                File.Copy(@file.FileName, @ad);
            }
            ASikkiPictureBox.ImageLocation = ad;
        }

        private void btnBSikkiResimSec_Click(object sender, EventArgs e)
        {

            file.Filter = "Resim Dosyası |*.png;*.jpg;*.jpeg";
            file.ShowDialog();            
            string ad = "images\\" + DateTime.Now.Ticks.ToString() + ".jpg";
            if (file.FileName != "")
            {
                File.Copy(@file.FileName, @ad);
            }
            BSikkiPictureBox.ImageLocation = ad;
        }

        private void btnCSikkiResimSec_Click(object sender, EventArgs e)
        {

            file.Filter = "Resim Dosyası |*.png;*.jpg;*.jpeg";
            file.ShowDialog();            
            string ad = "images\\" + DateTime.Now.Ticks.ToString() + ".jpg";
            if (file.FileName != "")
            {
                File.Copy(@file.FileName, @ad);
            }
            CSikkiPictureBox.ImageLocation = ad;
        }

        private void btnDSikkiResimSec_Click(object sender, EventArgs e)
        {
            file.Filter = "Resim Dosyası |*.png;*.jpg;*.jpeg";
            file.ShowDialog();
            string ad = "images\\" + DateTime.Now.Ticks.ToString() + ".jpg";
            if (file.FileName != "")
            {
                File.Copy(@file.FileName, @ad);
            }
            DSikkiPictureBox.ImageLocation = ad;
        }
    }
}
