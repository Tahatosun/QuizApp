using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazılımSınamaOdevi
{
    public partial class OgretmenEkraniSoruTuru1 : MetroFramework.Controls.MetroUserControl
    {
        public OgretmenEkraniSoruTuru1()
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
        }
        private void OgretmenEkraniSoruTuru1_Load(object sender, EventArgs e)
        {

        }
    }
}
