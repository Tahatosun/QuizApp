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
    public partial class OgretmenEkraniSoruTuru2 : MetroFramework.Controls.MetroUserControl
    {
        public OgretmenEkraniSoruTuru2()
        {
            InitializeComponent();
        }

        public void Sıfırla()
        {
            txtASikki.Text = "";
            txtBSikki.Text = "";
            txtCSikki.Text = "";
            txtDSikki.Text = "";
            txtSoruMetni.Text = "";
            cmbBxKonuSec.SelectedIndex = -1;
            SoruResmi.ImageLocation = null;
        }
        OpenFileDialog file = new OpenFileDialog();
        private void OgretmenEkraniSoruTuru2_Load(object sender, EventArgs e)
        {

        }

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            file.Filter = "Resim Dosyası |*.png;*.jpg;*.jpeg";
            file.ShowDialog();
            string ad = "images\\" + DateTime.Now.Ticks.ToString() + ".jpg";
            if (file.FileName != "")
            {
                File.Copy(@file.FileName, @ad);
            }
            SoruResmi.ImageLocation = ad;
        }
    }
}
