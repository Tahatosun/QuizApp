using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace YazılımSınamaOdevi
{
    public partial class OgretmenEkrani : MetroFramework.Forms.MetroForm
    {
        public OgretmenEkrani()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=.; Initial Catalog=YazilimSinama;Integrated Security=SSPI");
        SqlCommand komut;

        private void OgretmenEkrani_Load(object sender, EventArgs e)
        {
            

        }
        public void SoruyuVeritabaninaEkle()
        {
            Soru soru = SoruOzellikleriniAl();
          
            komut = new SqlCommand("Insert into dbo.Sorular (SoruTur,Konu,SoruMetni,SoruResimYolu,AsikkiMetni,AsikkiResimYolu,BsikkiMetni,BsikkiResimYolu,CsikkiMetni,CsikkiResimYolu,DsikkiMetni,DsikkiResimYolu,DogruCevap) values (@SoruTur,@KonuAdi,@SoruMetni,@SoruResimYolu,@AsikkiMetni,@AsikkiResimYolu,@BsikkiMetni,@BsikkiResimYolu,@CsikkiMetni,@CsikkiResimYolu,@DsikkiMetni,@DsikkiResimYolu,@DogruCevap)", baglanti);
            komut.Parameters.AddWithValue("@SoruTur",soru.SoruTuru );
            komut.Parameters.AddWithValue("@KonuAdi",soru.KonuAdi );
            komut.Parameters.AddWithValue("@SoruMetni",soru.SoruMetni );
            komut.Parameters.AddWithValue("@SoruResimYolu", soru.SoruResmiDosyaYolu );
            komut.Parameters.AddWithValue("@AsikkiMetni",soru.ASikkiMetin );
            komut.Parameters.AddWithValue("@AsikkiResimYolu",soru.ASikkiResim );            
            komut.Parameters.AddWithValue("@BsikkiMetni", soru.BSikkiMetin);
            komut.Parameters.AddWithValue("@BsikkiResimYolu", soru.BSikkiResim);
            komut.Parameters.AddWithValue("@CsikkiMetni", soru.CSikkiMetin);
            komut.Parameters.AddWithValue("@CsikkiResimYolu", soru.CSikkiResim);
            komut.Parameters.AddWithValue("@DsikkiMetni", soru.DSikkiMetin);
            komut.Parameters.AddWithValue("@DsikkiResimYolu", soru.DSikkiResim);
            komut.Parameters.AddWithValue("@DogruCevap", soru.DogruCevap);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public Soru SoruOzellikleriniAl()
        {
            Soru soru = new Soru();
            soru.SoruTuru = 0;
            soru.KonuAdi = "";
            soru.SoruMetni = "";
            soru.SoruResmiDosyaYolu = "";
            soru.ASikkiMetin = "";
            soru.BSikkiMetin = "";
            soru.CSikkiMetin = "";
            soru.DSikkiMetin = "";
            soru.ASikkiResim = "";
            soru.BSikkiResim = "";
            soru.CSikkiResim = "";
            soru.DSikkiResim = "";
            soru.DogruCevap = "";

            switch (cmbBxSoruTuru.SelectedIndex)
            {
                case 0:
                    soru.SoruTuru = 1;
                    soru.KonuAdi = ogretmenEkraniSoruTuru1.cmbBxKonuSec.Text;
                    soru.SoruMetni = ogretmenEkraniSoruTuru1.txtSoruMetni.Text;
                    soru.ASikkiMetin = ogretmenEkraniSoruTuru1.txtASikki.Text;
                    soru.BSikkiMetin = ogretmenEkraniSoruTuru1.txtBSikki.Text;
                    soru.CSikkiMetin = ogretmenEkraniSoruTuru1.txtCSikki.Text;
                    soru.DSikkiMetin = ogretmenEkraniSoruTuru1.txtDSikki.Text;
                    soru.DogruCevap = cmbBoxDogruCevap.Text;
                    break;
                case 1:
                    soru.SoruTuru = 2;
                    soru.KonuAdi = ogretmenEkraniSoruTuru2.cmbBxKonuSec.Text;
                    soru.SoruMetni = ogretmenEkraniSoruTuru2.txtSoruMetni.Text;
                    soru.SoruResmiDosyaYolu = ogretmenEkraniSoruTuru2.SoruResmi.ImageLocation;
                    soru.ASikkiMetin = ogretmenEkraniSoruTuru2.txtASikki.Text;
                    soru.BSikkiMetin = ogretmenEkraniSoruTuru2.txtBSikki.Text;
                    soru.CSikkiMetin = ogretmenEkraniSoruTuru2.txtCSikki.Text;
                    soru.DSikkiMetin = ogretmenEkraniSoruTuru2.txtDSikki.Text;
                    soru.DogruCevap = cmbBoxDogruCevap.Text;
                    break;
                case 2:
                    soru.SoruTuru = 3;
                    soru.KonuAdi = ogretmenEkraniSoruTuru3.cmbBxKonuSec.Text;
                    soru.SoruMetni = ogretmenEkraniSoruTuru3.txtSoruMetni.Text;
                    soru.SoruResmiDosyaYolu = ogretmenEkraniSoruTuru3.SoruResmi.ImageLocation;
                    soru.ASikkiResim= ogretmenEkraniSoruTuru3.ASikkiPictureBox.ImageLocation;
                    soru.BSikkiResim= ogretmenEkraniSoruTuru3.BSikkiPictureBox.ImageLocation;
                    soru.CSikkiResim= ogretmenEkraniSoruTuru3.CSikkiPictureBox.ImageLocation;
                    soru.DSikkiResim= ogretmenEkraniSoruTuru3.DSikkiPictureBox.ImageLocation;
                    soru.DogruCevap = cmbBoxDogruCevap.Text;
                    break;
                case 3:
                    soru.SoruTuru = 3;
                    soru.KonuAdi = ogretmenEkraniSoruTuru4.cmbBxKonuSec.Text;
                    soru.SoruMetni = ogretmenEkraniSoruTuru4.txtSoruMetni.Text;                   
                    soru.ASikkiResim = ogretmenEkraniSoruTuru4.ASikkiPictureBox.ImageLocation;
                    soru.BSikkiResim = ogretmenEkraniSoruTuru4.BSikkiPictureBox.ImageLocation;
                    soru.CSikkiResim = ogretmenEkraniSoruTuru4.CSikkiPictureBox.ImageLocation;
                    soru.DSikkiResim = ogretmenEkraniSoruTuru4.DSikkiPictureBox.ImageLocation;
                    soru.DogruCevap = cmbBoxDogruCevap.Text;
                    break;
            }
            return soru;
        }

        public bool AlanlarBosmu()
        {
            if (cmbBxSoruTuru.SelectedIndex == 0)
            {
                if(cmbBoxDogruCevap.SelectedIndex==-1|| ogretmenEkraniSoruTuru1.cmbBxKonuSec.SelectedIndex==-1|| ogretmenEkraniSoruTuru1.txtSoruMetni.Text=="" ||ogretmenEkraniSoruTuru1.txtASikki.Text=="" || ogretmenEkraniSoruTuru1.txtBSikki.Text == "" || ogretmenEkraniSoruTuru1.txtCSikki.Text == "" || ogretmenEkraniSoruTuru1.txtDSikki.Text == "")
                {
                   
                    return false;
                }
                else
                {
                    return true;
                }
               
            }
            else if (cmbBxSoruTuru.SelectedIndex == 1)
            {
                if (ogretmenEkraniSoruTuru2.SoruResmi.ImageLocation == null || ogretmenEkraniSoruTuru2.SoruResmi.ImageLocation == ""||cmbBoxDogruCevap.SelectedIndex == -1 || ogretmenEkraniSoruTuru2.cmbBxKonuSec.SelectedIndex ==-1 || ogretmenEkraniSoruTuru2.txtSoruMetni.Text == "" || ogretmenEkraniSoruTuru2.txtASikki.Text == "" || ogretmenEkraniSoruTuru2.txtBSikki.Text == "" || ogretmenEkraniSoruTuru2.txtCSikki.Text == "" || ogretmenEkraniSoruTuru2.txtDSikki.Text == "")
                {
                   
                    return false;
                }
                else
                {
                    return true;
                }

            }
            else if (cmbBxSoruTuru.SelectedIndex == 2)
            {
                if (cmbBoxDogruCevap.SelectedIndex == -1 || ogretmenEkraniSoruTuru3.cmbBxKonuSec.SelectedIndex == -1 || ogretmenEkraniSoruTuru3.txtSoruMetni.Text == "" || ogretmenEkraniSoruTuru3.ASikkiPictureBox.ImageLocation== null || ogretmenEkraniSoruTuru3.BSikkiPictureBox.ImageLocation == null || ogretmenEkraniSoruTuru3.CSikkiPictureBox.ImageLocation == null || ogretmenEkraniSoruTuru3.DSikkiPictureBox.ImageLocation== null || ogretmenEkraniSoruTuru3.SoruResmi.ImageLocation == null|| ogretmenEkraniSoruTuru3.ASikkiPictureBox.ImageLocation == "" || ogretmenEkraniSoruTuru3.BSikkiPictureBox.ImageLocation == "" || ogretmenEkraniSoruTuru3.CSikkiPictureBox.ImageLocation == "" || ogretmenEkraniSoruTuru3.DSikkiPictureBox.ImageLocation == "" || ogretmenEkraniSoruTuru3.SoruResmi.ImageLocation == "")
                {
                    
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (cmbBxSoruTuru.SelectedIndex == 3)
            {
                if (cmbBoxDogruCevap.SelectedIndex == -1 || ogretmenEkraniSoruTuru4.cmbBxKonuSec.SelectedIndex == -1 || ogretmenEkraniSoruTuru4.txtSoruMetni.Text == "" || ogretmenEkraniSoruTuru4.ASikkiPictureBox.ImageLocation == null || ogretmenEkraniSoruTuru4.BSikkiPictureBox.ImageLocation == null || ogretmenEkraniSoruTuru4.CSikkiPictureBox.ImageLocation == null || ogretmenEkraniSoruTuru4.DSikkiPictureBox.ImageLocation == null)
                {
                    
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private void cmbBxSoruTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBxSoruTuru.SelectedIndex == 0)
            {
                ogretmenEkraniSoruTuru1.Visible = true;
                ogretmenEkraniSoruTuru2.Visible = false;
                ogretmenEkraniSoruTuru3.Visible = false;
                ogretmenEkraniSoruTuru4.Visible = false;
            }
            else if (cmbBxSoruTuru.SelectedIndex == 1)
            {
                ogretmenEkraniSoruTuru1.Visible = false;
                ogretmenEkraniSoruTuru2.Visible = true;
                ogretmenEkraniSoruTuru3.Visible = false;
                ogretmenEkraniSoruTuru4.Visible = false;

            }
            else if (cmbBxSoruTuru.SelectedIndex == 2)
            {
                ogretmenEkraniSoruTuru1.Visible = false;
                ogretmenEkraniSoruTuru2.Visible = false;
                ogretmenEkraniSoruTuru3.Visible = true;
                ogretmenEkraniSoruTuru4.Visible = false;
            }
            else if (cmbBxSoruTuru.SelectedIndex == 3)
            {
                ogretmenEkraniSoruTuru1.Visible = false;
                ogretmenEkraniSoruTuru2.Visible = false;
                ogretmenEkraniSoruTuru3.Visible = false;
                ogretmenEkraniSoruTuru4.Visible = true;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            

            if (AlanlarBosmu() && cmbBxSoruTuru.SelectedIndex != -1)
            {
                SoruyuVeritabaninaEkle();
                cmbBoxDogruCevap.SelectedIndex = -1;
                ogretmenEkraniSoruTuru1.Sıfırla();
                ogretmenEkraniSoruTuru2.Sıfırla();
                ogretmenEkraniSoruTuru3.Sıfırla();
                ogretmenEkraniSoruTuru4.Sıfırla();

            }
            else
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz");
            }
            
           
            
        }
    }
}
