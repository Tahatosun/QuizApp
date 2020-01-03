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
    public partial class SoruTuru2 : MetroFramework.Controls.MetroUserControl
    {
        public SoruTuru2()
        {
            InitializeComponent();
        }
        
        private void SoruTuru2_Load(object sender, EventArgs e)
        {


        }
        public void SecilenSıkHatırla(string secilenSık)
        {
            switch (secilenSık)
            {
                case "A":
                    ButtonA.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
                    break;
                case "B":
                    ButtonB.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
                    break;
                case "C":
                    ButtonC.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
                    break;
                case "D":
                    ButtonD.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
                    break;
            }
        }
        public void CevapfontWeigthSıfırla()
        {
            ButtonA.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Light;
            ButtonB.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Light;
            ButtonC.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Light;
            ButtonD.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Light;

        }
        public void Sıfırla()
        {
            CevapfontWeigthSıfırla();
            ButtonA.Style = MetroFramework.MetroColorStyle.Blue;
            ButtonB.Style = MetroFramework.MetroColorStyle.Blue;
            ButtonC.Style = MetroFramework.MetroColorStyle.Blue;
            ButtonD.Style = MetroFramework.MetroColorStyle.Blue;
            ButtonA.Enabled = true;
            ButtonB.Enabled = true;
            ButtonC.Enabled = true;
            ButtonD.Enabled = true;
        }
        public void DogruCevapKontrolFunc(string secilenSık)
        {
            SecilenSıkHatırla(secilenSık);
            if (secilenSık == lblDogruCevap.Text.Trim())
            {
                DogruVeYanlisCevapRenklendir(secilenSık);
            }
            else
            {
                DogruVeYanlisCevapRenklendir(lblDogruCevap.Text.Trim());
            }


        }
        public void DogruVeYanlisCevapRenklendir(string secilenSık)
        {
            switch (secilenSık)
            {
                case "A":
                    ButtonA.Style = MetroFramework.MetroColorStyle.Green;
                    ButtonB.Style = MetroFramework.MetroColorStyle.Red;
                    ButtonC.Style = MetroFramework.MetroColorStyle.Red;
                    ButtonD.Style = MetroFramework.MetroColorStyle.Red;

                    break;
                case "B":
                    ButtonA.Style = MetroFramework.MetroColorStyle.Red;
                    ButtonB.Style = MetroFramework.MetroColorStyle.Green;
                    ButtonC.Style = MetroFramework.MetroColorStyle.Red;
                    ButtonD.Style = MetroFramework.MetroColorStyle.Red;
                    break;
                case "C":
                    ButtonA.Style = MetroFramework.MetroColorStyle.Red;
                    ButtonB.Style = MetroFramework.MetroColorStyle.Red;
                    ButtonC.Style = MetroFramework.MetroColorStyle.Green;
                    ButtonD.Style = MetroFramework.MetroColorStyle.Red;
                    break;
                case "D":
                    ButtonA.Style = MetroFramework.MetroColorStyle.Red;
                    ButtonB.Style = MetroFramework.MetroColorStyle.Red;
                    ButtonC.Style = MetroFramework.MetroColorStyle.Red;
                    ButtonD.Style = MetroFramework.MetroColorStyle.Green;
                    break;
            }

        }
        private void ButtonA_Click(object sender, EventArgs e)
        {
            lblVerilenCevap.Text = "A";

            CevapfontWeigthSıfırla();
            ButtonA.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
        }

        private void ButtonB_Click(object sender, EventArgs e)
        {
            lblVerilenCevap.Text = "B";

            CevapfontWeigthSıfırla();
            ButtonB.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
        }

        private void ButtonC_Click(object sender, EventArgs e)
        {
            lblVerilenCevap.Text = "C";

            CevapfontWeigthSıfırla();
            ButtonC.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
        }

        private void ButtonD_Click(object sender, EventArgs e)
        {
            lblVerilenCevap.Text = "D";

            CevapfontWeigthSıfırla();
            ButtonD.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
        }
    }
}
