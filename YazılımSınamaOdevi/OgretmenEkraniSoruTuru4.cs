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
    public partial class OgretmenEkraniSoruTuru4 : MetroFramework.Controls.MetroUserControl
    {
        public OgretmenEkraniSoruTuru4()
        {
            InitializeComponent();
        }

        public void Sıfırla()
        {
            ASikkiPictureBox.ImageLocation = null;
            BSikkiPictureBox.ImageLocation = null;
            CSikkiPictureBox.ImageLocation = null;
            DSikkiPictureBox.ImageLocation = null;
            txtSoruMetni.Text = "";
            cmbBxKonuSec.SelectedIndex = -1;
        }
        OpenFileDialog file = new OpenFileDialog();
        private void OgretmenEkraniSoruTuru4_Load(object sender, EventArgs e)
        {

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

        private void btnCSikkiResimSec_Click(object sender, EventArgs e)
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

        private void btnBSikkiResimSec_Click(object sender, EventArgs e)
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
