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
    public partial class GirisEkrani : MetroFramework.Forms.MetroForm
    {
        public GirisEkrani()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=.; Initial Catalog=YazilimSinama;Integrated Security=SSPI");
        SqlCommand komut;
       public SqlDataReader reader;
        public int OgrenciID;


        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        public bool OgrenciBilgileriniKontrolEt(string kullaniciAdi, string Sifre)
        {
            komut = new SqlCommand("SELECT * FROM dbo.Kullanicilar WHERE KullaniciTuru=1 ", baglanti);
            baglanti.Open();
            reader = komut.ExecuteReader();

            while (reader.Read())
            {
                if (kullaniciAdi == reader["KullaniciAdi"].ToString() && Sifre == reader["Sifre"].ToString())
                {
                    OgrenciID = Convert.ToInt16(reader["KullaniciID"]);
                    return true;
                }

            }
            baglanti.Close();
            return false;
        }
        public bool OgretmenBilgileriniKontrolEt(string kullaniciAdi,string Sifre)
        {
            komut = new SqlCommand("SELECT * FROM dbo.Kullanicilar WHERE KullaniciTuru=2 ", baglanti);
            baglanti.Open();
            reader = komut.ExecuteReader();

            while (reader.Read())
            {
                if (kullaniciAdi == reader["KullaniciAdi"].ToString() && Sifre==reader["Sifre"].ToString())
                {
                    
                    return true;
                }
               
            }
            baglanti.Close();
            return false;
        }

        private void tileGirisYap_Click(object sender, EventArgs e)
        {
            if (radioButtonOgretmen.Checked==true)
            {
                if (OgretmenBilgileriniKontrolEt(txtBxKullaniciAdi.Text, txtBxSifre.Text))
                {
                    
                    OgretmenEkrani ogretmenEkrani = new OgretmenEkrani();
                    ogretmenEkrani.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanici Bulunumadi");

                }
            }
            else if (radioBtnOgrenci.Checked == true)
            {
                if(OgrenciBilgileriniKontrolEt(txtBxKullaniciAdi.Text, txtBxSifre.Text))
                {
                    OgrenciEkrani ogrenciEkrani = new OgrenciEkrani();
                    ogrenciEkrani.OgrenciID = OgrenciID;
                    ogrenciEkrani.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanici Bulunumadi");

                }

            }
        }
    }
}
