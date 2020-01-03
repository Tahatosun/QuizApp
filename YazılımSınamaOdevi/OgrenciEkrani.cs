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
    public partial class OgrenciEkrani : MetroFramework.Forms.MetroForm
    {
        public OgrenciEkrani()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=.; Initial Catalog=YazilimSinama;Integrated Security=SSPI");
        SqlCommand komut;
        public SqlDataReader reader;

        int dakika = 0;
        int saniye = 0;

        public int OgrenciID;
        public List<Soru> Sorular = new List<Soru>();
        string[] konular = { "Olasılık", "Çarpanlar ve Katlar", "Veri Analizi", "Üçgenler", "Eşitsizlikler" };
        double[,] KonuDogruYanlisYüzdeBilgileri = new double[5, 4];
        public bool isTestBitti = false;
        int AnlikSoru = 0;
        string[] VerilenCevaplar= new string[50];
        int[,] MevcutSinavinDogruYanlısBilgileri = new int[5, 2];

        public void GenelBasariGrafigiDoldur(int konuİndex)
        {
            if (konuİndex == 1)
            {
               
                BasariGrafigi.Series["Olasılık"].Points.AddXY("Dogru Sayısı", KonuDogruYanlisYüzdeBilgileri[0, 0]);
                BasariGrafigi.Series["Olasılık"].Points.AddXY("Yanlış Sayısı", KonuDogruYanlisYüzdeBilgileri[0, 1]);
                BasariGrafigi.Series["Olasılık"].Points.AddXY("Başarı Yüzdesi", (KonuDogruYanlisYüzdeBilgileri[0, 0]*100)/(KonuDogruYanlisYüzdeBilgileri[0, 0]+ KonuDogruYanlisYüzdeBilgileri[0, 1]));
            }
            else if (konuİndex == 2)
            {
                BasariGrafigi.Series["Çarpanlar ve Katlar"].Points.AddXY("Dogru Sayısı", KonuDogruYanlisYüzdeBilgileri[1, 0]);
                BasariGrafigi.Series["Çarpanlar ve Katlar"].Points.AddXY("Yanlış Sayısı", KonuDogruYanlisYüzdeBilgileri[1, 1]);
                BasariGrafigi.Series["Çarpanlar ve Katlar"].Points.AddXY("Başarı Yüzdesi", (KonuDogruYanlisYüzdeBilgileri[1, 0] * 100) / (KonuDogruYanlisYüzdeBilgileri[1, 0] + KonuDogruYanlisYüzdeBilgileri[1, 1]));
            }
            else if (konuİndex == 3)
            {
                BasariGrafigi.Series["Veri Analizi"].Points.AddXY("Dogru Sayısı", KonuDogruYanlisYüzdeBilgileri[2, 0]);
                BasariGrafigi.Series["Veri Analizi"].Points.AddXY("Yanlış Sayısı", KonuDogruYanlisYüzdeBilgileri[2, 1]);
                BasariGrafigi.Series["Veri Analizi"].Points.AddXY("Başarı Yüzdesi", (KonuDogruYanlisYüzdeBilgileri[2, 0] * 100) / (KonuDogruYanlisYüzdeBilgileri[2, 0] + KonuDogruYanlisYüzdeBilgileri[2, 1]));
            }
            else if (konuİndex == 4)
            {
                BasariGrafigi.Series["Üçgenler"].Points.AddXY("Dogru Sayısı", KonuDogruYanlisYüzdeBilgileri[3, 0]);
                BasariGrafigi.Series["Üçgenler"].Points.AddXY("Yanlış Sayısı", KonuDogruYanlisYüzdeBilgileri[3, 1]);
                BasariGrafigi.Series["Üçgenler"].Points.AddXY("Başarı Yüzdesi", (KonuDogruYanlisYüzdeBilgileri[3, 0] * 100) / (KonuDogruYanlisYüzdeBilgileri[3, 0] + KonuDogruYanlisYüzdeBilgileri[3, 1]));
            }else if (konuİndex == 5)
            {
                BasariGrafigi.Series["Eşitsizlikler"].Points.AddXY("Dogru Sayısı", KonuDogruYanlisYüzdeBilgileri[4, 0]);
                BasariGrafigi.Series["Eşitsizlikler"].Points.AddXY("Yanlış Sayısı", KonuDogruYanlisYüzdeBilgileri[4, 1]);
                BasariGrafigi.Series["Eşitsizlikler"].Points.AddXY("Başarı Yüzdesi", (KonuDogruYanlisYüzdeBilgileri[4, 0] * 100) / (KonuDogruYanlisYüzdeBilgileri[4, 0] + KonuDogruYanlisYüzdeBilgileri[4, 1]));
            }

            
        }

        private void OgrenciEkrani_Load(object sender, EventArgs e)
        {
            cmbBxGrafikEkraniKonuSec.SelectedIndex = 0;

            for(int i = 0; i < 50; i++)
            {
                VerilenCevaplar[i] = "";
            }
            for (int i = 0; i < 5; i++)
            {
                MevcutSinavinDogruYanlısBilgileri[i,0]= 0;
                MevcutSinavinDogruYanlısBilgileri[i,1]= 0;
            }
            soruTuru1.Visible = false;
            soruTuru2.Visible = false;
            soruTuru3.Visible = false;
            soruTuru4.Visible = false;
            KonuDogruYanlisYüzdeBilgileri[0, 3] = OgrenciID;

            VeritabanındanSorularıGetir();
           

        }
       
        public double[,] SoruDagilimFunc()
        {
            
            komut = new SqlCommand("SELECT SUM(Konu1DogruSayisi),SUM(Konu1YanlisSayisi),SUM(Konu2DogruSayisi),SUM(Konu2YanlisSayisi),SUM(Konu3DogruSayisi),SUM(Konu3YanlisSayisi),SUM(Konu4DogruSayisi),SUM(Konu4YanlisSayisi),SUM(Konu5DogruSayisi),SUM(Konu5YanlisSayisi) FROM dbo.İstatistik WHERE OgrenciID='"+ OgrenciID + "'", baglanti);
            baglanti.Open();
            reader = komut.ExecuteReader();

            while (reader.Read())
            {
                
                KonuDogruYanlisYüzdeBilgileri[0, 0] =Convert.ToDouble(reader[0]);
                KonuDogruYanlisYüzdeBilgileri[0, 1] = Convert.ToDouble(reader[1]);
                KonuDogruYanlisYüzdeBilgileri[1, 0] = Convert.ToDouble(reader[2]);
                KonuDogruYanlisYüzdeBilgileri[1, 1] =Convert.ToDouble(reader[3]);
                KonuDogruYanlisYüzdeBilgileri[2, 0] =Convert.ToDouble(reader[4]);
                KonuDogruYanlisYüzdeBilgileri[2, 1] = Convert.ToDouble(reader[5]);
                KonuDogruYanlisYüzdeBilgileri[3, 0] = Convert.ToDouble(reader[6]);
                KonuDogruYanlisYüzdeBilgileri[3, 1] = Convert.ToDouble(reader[7]);
                KonuDogruYanlisYüzdeBilgileri[4, 0] = Convert.ToDouble(reader[8]);
                KonuDogruYanlisYüzdeBilgileri[4, 1] = Convert.ToDouble(reader[9]);

            }
            baglanti.Close();
            double yuzde = 0;


            for (int i = 0; i < 5; i++)
            {

                yuzde += (KonuDogruYanlisYüzdeBilgileri[i, 1] * 100) / (KonuDogruYanlisYüzdeBilgileri[i, 0] + KonuDogruYanlisYüzdeBilgileri[i, 1]);

            }
            KonuDogruYanlisYüzdeBilgileri[0, 2]= ((KonuDogruYanlisYüzdeBilgileri[0, 1] * 100) / (KonuDogruYanlisYüzdeBilgileri[0, 0] + KonuDogruYanlisYüzdeBilgileri[0, 1]))/(yuzde/50);
            KonuDogruYanlisYüzdeBilgileri[1, 2]= ((KonuDogruYanlisYüzdeBilgileri[1, 1] * 100) / (KonuDogruYanlisYüzdeBilgileri[1, 0] + KonuDogruYanlisYüzdeBilgileri[1, 1]))/(yuzde/50);
            KonuDogruYanlisYüzdeBilgileri[2, 2]= ((KonuDogruYanlisYüzdeBilgileri[2, 1] * 100) / (KonuDogruYanlisYüzdeBilgileri[2, 0] + KonuDogruYanlisYüzdeBilgileri[2, 1]))/(yuzde/50);
            KonuDogruYanlisYüzdeBilgileri[3, 2]= ((KonuDogruYanlisYüzdeBilgileri[3, 1] * 100) / (KonuDogruYanlisYüzdeBilgileri[3, 0] + KonuDogruYanlisYüzdeBilgileri[3, 1]))/(yuzde/50);
            KonuDogruYanlisYüzdeBilgileri[4, 2]= ((KonuDogruYanlisYüzdeBilgileri[4, 1] * 100) / (KonuDogruYanlisYüzdeBilgileri[4, 0] + KonuDogruYanlisYüzdeBilgileri[4, 1]))/(yuzde/50);

            
            //MessageBox.Show("A Konusu Sorulacak Sayi:" + Math.Round(KonuDogruYanlisYüzdeBilgileri[0, 2]).ToString()+Environment.NewLine+ "B Konusu Sorulacak Sayi:" + Math.Round(KonuDogruYanlisYüzdeBilgileri[1, 2]).ToString() + Environment.NewLine + "C Konusu Sorulacak Sayi:" + Math.Round(KonuDogruYanlisYüzdeBilgileri[2, 2]).ToString() + Environment.NewLine + "D Konusu Sorulacak Sayi:" + Math.Round(KonuDogruYanlisYüzdeBilgileri[3, 2]).ToString() + Environment.NewLine + "E Konusu Sorulacak Sayi:" + Math.Round(KonuDogruYanlisYüzdeBilgileri[4, 2]).ToString());

            return KonuDogruYanlisYüzdeBilgileri;
            
        }

        public void SecilenSıkHatırla(int SoruTuru)
        {
            switch (SoruTuru)
            {
                case 1:
                    soruTuru1.SecilenSıkHatırla(VerilenCevaplar[AnlikSoru]);
                    break;
                case 2:
                    soruTuru2.SecilenSıkHatırla(VerilenCevaplar[AnlikSoru]);
                    break;
                case 3:
                    soruTuru3.SecilenSıkHatırla(VerilenCevaplar[AnlikSoru]);
                    break;
                case 4:
                    soruTuru4.SecilenSıkHatırla(VerilenCevaplar[AnlikSoru]);
                    break;
            }
        }

        public void VeritabanındanSorularıGetir()
        {
           
            double[,] sorular = SoruDagilimFunc();
            
            for (int i = 0; i < 5; i++)
            {
                komut = new SqlCommand("SELECT TOP " + Math.Round(sorular[i, 2]) + " * FROM dbo.Sorular WHERE Konu = '" + konular[i] + "'", baglanti);
                baglanti.Open();
                reader = komut.ExecuteReader();
                
                while (reader.Read())
                {
                    
                    Soru soru = new Soru();
                    soru.SoruID = Convert.ToInt16(reader["SoruID"]);
                    soru.SoruTuru = Convert.ToInt16(reader["SoruTur"]);
                    soru.KonuAdi = reader["Konu"].ToString();
                    soru.SoruMetni = reader["SoruMetni"].ToString();
                    soru.SoruResmiDosyaYolu = reader["SoruResimYolu"].ToString();
                    soru.ASikkiMetin = reader["AsikkiMetni"].ToString();
                    soru.ASikkiResim = reader["AsikkiResimYolu"].ToString();
                    soru.BSikkiMetin = reader["BsikkiMetni"].ToString();
                    soru.BSikkiResim = reader["BsikkiResimYolu"].ToString();
                    soru.CSikkiMetin = reader["CsikkiMetni"].ToString();
                    soru.CSikkiResim = reader["CsikkiResimYolu"].ToString();
                    soru.DSikkiMetin = reader["DsikkiMetni"].ToString();
                    soru.DSikkiResim = reader["DsikkiResimYolu"].ToString();                     
                    soru.DogruCevap = reader["DogruCevap"].ToString();
                    Sorular.Add(soru);

                }
                baglanti.Close();
            }
           
           
        }

        public void SoruTuruAyırma(Soru soru)
        {
            lblSoruSayaci.Text = "Soru:" + (AnlikSoru+1) + "/50";
            lblDogruCevap.Text = soru.DogruCevap;
            switch (soru.SoruTuru)
            {
                case 1:
                    SoruTuru1Doldur(soru);
                    soruTuru1.Visible = true;
                    soruTuru2.Visible = false;
                    soruTuru3.Visible = false;
                    soruTuru4.Visible = false;

                    break;
                case 2:
                    SoruTuru2Doldur(soru);
                    soruTuru1.Visible = false;
                    soruTuru2.Visible = true;
                    soruTuru3.Visible = false;
                    soruTuru4.Visible = false;
                    break;
                case 3:
                    SoruTuru3Doldur(soru);
                    soruTuru1.Visible = false;
                    soruTuru2.Visible = false;
                    soruTuru3.Visible = true;
                    soruTuru4.Visible = false;
                    break;
                case 4:
                    SoruTuru4Doldur(soru);
                    soruTuru1.Visible = false;
                    soruTuru2.Visible = false;
                    soruTuru3.Visible = true;
                    soruTuru4.Visible = false;
                    break;
                default:
                    MessageBox.Show("Soru Türü Girilmemiş");
                    break;
            }
            
        }

        public void SoruTuru1Doldur(Soru soru)
        {
            
            soruTuru1.Sıfırla();
            soruTuru1.lblSoru.Text="Soru "+(AnlikSoru+1)+":";
            if (soru.SoruMetni.Length>=136)
            {
                soruTuru1.lblSoruMetni.Text = soru.SoruMetni.Substring(0, 136) + Environment.NewLine + soru.SoruMetni.Substring(136);
            }
            else
            {
                soruTuru1.lblSoruMetni.Text = soru.SoruMetni;
            }

            soruTuru1.lblKonu.Text = "Konu: "+soru.KonuAdi;
            soruTuru1.lblASikkiMetni.Text = soru.ASikkiMetin;
            soruTuru1.lblBSikkiMetni.Text = soru.BSikkiMetin;
            soruTuru1.lblCSikkiMetni.Text = soru.CSikkiMetin;
            soruTuru1.lblDSikkiMetni.Text = soru.DSikkiMetin;
            soruTuru1.lblDogruCevap.Text = soru.DogruCevap;
            soruTuru1.lblVerilenCevap.Text = VerilenCevaplar[AnlikSoru];
            

            if (isTestBitti == true)
            {
                soruTuru1.Enabled = false;
            }
        }

        public void SoruTuru2Doldur(Soru soru)
        {
            soruTuru2.Sıfırla();
            soruTuru2.lblSoru.Text = "Soru " + (AnlikSoru + 1) + ":";

            if (soru.SoruMetni.Length >= 136)
            {
                soruTuru2.lblSoruMetni.Text = soru.SoruMetni.Substring(0, 136) + Environment.NewLine + soru.SoruMetni.Substring(136);
            }
            else
            {
                soruTuru2.lblSoruMetni.Text = soru.SoruMetni;
            }
            soruTuru2.lblKonu.Text = "Konu: " + soru.KonuAdi;
            soruTuru2.SoruResmi.Image = Image.FromFile(soru.SoruResmiDosyaYolu);
            soruTuru2.lblASikki.Text = soru.ASikkiMetin;
            soruTuru2.lblBSikki.Text = soru.BSikkiMetin;
            soruTuru2.lblCSikki.Text = soru.CSikkiMetin;
            soruTuru2.lblDSikki.Text = soru.DSikkiMetin;
            soruTuru2.lblDogruCevap.Text = soru.DogruCevap;
            

            if (isTestBitti == true)
            {
                soruTuru2.Enabled = false;
            }

        }

        public void SoruTuru3Doldur(Soru soru)
        {
            soruTuru3.Sıfırla();
            soruTuru3.lblSoru.Text = "Soru " + (AnlikSoru + 1) + ":";
            if (soru.SoruMetni.Length >= 136)
            {
                soruTuru3.SoruMetni.Text = soru.SoruMetni.Substring(0, 136) + Environment.NewLine + soru.SoruMetni.Substring(136);
            }
            else
            {
                soruTuru3.SoruMetni.Text = soru.SoruMetni;
            }
            soruTuru3.lblKonu.Text = "Konu: " + soru.KonuAdi;
            soruTuru3.SoruResmi.Image = Image.FromFile(soru.SoruResmiDosyaYolu);
            soruTuru3.ASikkiPictureBox.Image = Image.FromFile(soru.ASikkiResim);
            soruTuru3.BSikkiPictureBox.Image = Image.FromFile(soru.BSikkiResim);
            soruTuru3.CSikkiPictureBox.Image = Image.FromFile(soru.CSikkiResim);
           soruTuru3.DSikkiPictureBox.Image = Image.FromFile(soru.DSikkiMetin);
           

            if (isTestBitti == true)
            {
                soruTuru3.Enabled = false;
            }
        }

        public void SoruTuru4Doldur(Soru soru)
        {
            soruTuru4.Sıfırla();
            soruTuru4.lblSoru.Text = "Soru " + (AnlikSoru + 1) + ":";
            if (soru.SoruMetni.Length >= 136)
            {
                soruTuru4.lblSoruMetni.Text = soru.SoruMetni.Substring(0, 136) + Environment.NewLine + soru.SoruMetni.Substring(136);
            }
            else
            {
                soruTuru4.lblSoruMetni.Text = soru.SoruMetni;
            }
            soruTuru4.ASikkiPictureBox.Image = Image.FromFile(soru.ASikkiResim);
            soruTuru4.BSikkiPictureBox.Image = Image.FromFile(soru.BSikkiResim);
            soruTuru4.CSikkiPictureBox.Image = Image.FromFile(soru.CSikkiResim);
            soruTuru4.DSikkiPictureBox.Image = Image.FromFile(soru.DSikkiMetin);
            
            

            if (isTestBitti == true)
            {
                soruTuru4.Enabled = false;
            }
        }

        public void TestiBitir()
        {
            isTestBitti = true;
            MessageBox.Show("Test Bitti");
            AnlikSoru = 0;
            MevcutSinavinDogruYanlisSayiliariniBul();
            TestSonucunuVeriTabaninaKaydet();
            SoruTuruAyırma(Sorular[AnlikSoru]);
            
            
        }

        public void TestSonucunuVeriTabaninaKaydet()
        {
            baglanti.Open();
            komut = new SqlCommand("INSERT INTO dbo.İstatistik(OgrenciID,Konu1DogruSayisi,Konu1YanlisSayisi,Konu2DogruSayisi,Konu2YanlisSayisi,Konu3DogruSayisi,Konu3YanlisSayisi,Konu4DogruSayisi,Konu4YanlisSayisi,Konu5DogruSayisi,Konu5YanlisSayisi,SınavTarihi) VALUES(@OgrenciID,@Konu1dogruSayisi,@Konu1yanlisSayisi,@Konu2dogruSayisi,@Konu2yanlisSayisi,@Konu3dogruSayisi,@Konu3yanlisSayisi,@Konu4dogruSayisi,@Konu4yanlisSayisi,@Konu5dogruSayisi,@Konu5yanlisSayisi,@SınavTarihi)", baglanti);
            komut.Parameters.AddWithValue("@OgrenciID", OgrenciID);
            komut.Parameters.AddWithValue("@Konu1dogruSayisi", MevcutSinavinDogruYanlısBilgileri[0, 0] );
            komut.Parameters.AddWithValue("@Konu1yanlisSayisi", MevcutSinavinDogruYanlısBilgileri[0, 1] );
            komut.Parameters.AddWithValue("@Konu2dogruSayisi", MevcutSinavinDogruYanlısBilgileri[1, 0]);
            komut.Parameters.AddWithValue("@Konu2yanlisSayisi", MevcutSinavinDogruYanlısBilgileri[1, 1]);
            komut.Parameters.AddWithValue("@Konu3dogruSayisi", MevcutSinavinDogruYanlısBilgileri[2, 0]);
            komut.Parameters.AddWithValue("@Konu3yanlisSayisi", MevcutSinavinDogruYanlısBilgileri[2, 1]);
            komut.Parameters.AddWithValue("@Konu4dogruSayisi", MevcutSinavinDogruYanlısBilgileri[3, 0]);
            komut.Parameters.AddWithValue("@Konu4yanlisSayisi", MevcutSinavinDogruYanlısBilgileri[3, 1]);
            komut.Parameters.AddWithValue("@Konu5dogruSayisi", MevcutSinavinDogruYanlısBilgileri[4, 0]);
            komut.Parameters.AddWithValue("@Konu5yanlisSayisi", MevcutSinavinDogruYanlısBilgileri[4, 1]);
            komut.Parameters.AddWithValue("@SınavTarihi", DateTime.Now.ToString("MM/dd/yyyy"));
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public void MevcutSinavinDogruYanlisSayiliariniBul()
        {
            for(int i=0;i<50;i++){
                switch (Sorular[i].KonuAdi)
                {
                    case "Olasılık":
                        if (VerilenCevaplar[i] == Sorular[i].DogruCevap.Trim())
                        {
                            MevcutSinavinDogruYanlısBilgileri[0, 0] += 1;
                        }
                        else
                        {
                            MevcutSinavinDogruYanlısBilgileri[0, 1] += 1;
                        }
                        break;
                    case "Çarpanlar ve Katlar":
                        if (VerilenCevaplar[i] == Sorular[i].DogruCevap.Trim())
                        {
                            MevcutSinavinDogruYanlısBilgileri[1, 0] += 1;
                        }
                        else
                        {
                            MevcutSinavinDogruYanlısBilgileri[1, 1] += 1;
                        }
                        break;
                    case "Veri Analizi":
                        if (VerilenCevaplar[i] == Sorular[i].DogruCevap.Trim())
                        {
                            MevcutSinavinDogruYanlısBilgileri[2, 0] += 1;
                        }
                        else
                        {
                            MevcutSinavinDogruYanlısBilgileri[2, 1] += 1;
                        }
                        break;
                    case "Üçgenler":
                        if (VerilenCevaplar[i] == Sorular[i].DogruCevap.Trim())
                        {
                            MevcutSinavinDogruYanlısBilgileri[3, 0] += 1;
                        }
                        else
                        {
                            MevcutSinavinDogruYanlısBilgileri[3, 1] += 1;
                        }
                        break;
                    case "Eşitsizlikler":
                        if (VerilenCevaplar[i] == Sorular[i].DogruCevap.Trim())
                        {
                            MevcutSinavinDogruYanlısBilgileri[4, 0] += 1;
                        }
                        else
                        {
                            MevcutSinavinDogruYanlısBilgileri[4, 1] += 1;
                        }

                        break;
                }
            }
           
        }

        public void MevcutSınavGrafigiDoldur(int konuİndex)
        {
            if (konuİndex == 1 && isTestBitti == true)
            {
                MevcutSinavGrafik.Series["Olasılık"].Points.AddXY("Dogru Sayısı", MevcutSinavinDogruYanlısBilgileri[0, 0]);
                MevcutSinavGrafik.Series["Olasılık"].Points.AddXY("Yanlış Sayısı", MevcutSinavinDogruYanlısBilgileri[0, 1]);
                MevcutSinavGrafik.Series["Olasılık"].Points.AddXY("Başarı Yüzdesi", (MevcutSinavinDogruYanlısBilgileri[0, 0] * 100) / (MevcutSinavinDogruYanlısBilgileri[0, 0] + MevcutSinavinDogruYanlısBilgileri[0, 1]));
            }
            else if (konuİndex == 2 && isTestBitti == true)
            {
                MevcutSinavGrafik.Series["Çarpanlar ve Katlar"].Points.AddXY("Dogru Sayısı", MevcutSinavinDogruYanlısBilgileri[1, 0]);
                MevcutSinavGrafik.Series["Çarpanlar ve Katlar"].Points.AddXY("Yanlış Sayısı", MevcutSinavinDogruYanlısBilgileri[1, 1]);
                MevcutSinavGrafik.Series["Çarpanlar ve Katlar"].Points.AddXY("Başarı Yüzdesi", (MevcutSinavinDogruYanlısBilgileri[1, 0] * 100) / (MevcutSinavinDogruYanlısBilgileri[1, 0] + MevcutSinavinDogruYanlısBilgileri[1, 1]));
            }
            else if (konuİndex == 3 && isTestBitti == true)
            {
                MevcutSinavGrafik.Series["Veri Analizi"].Points.AddXY("Dogru Sayısı", MevcutSinavinDogruYanlısBilgileri[2, 0]);
                MevcutSinavGrafik.Series["Veri Analizi"].Points.AddXY("Yanlış Sayısı", MevcutSinavinDogruYanlısBilgileri[2, 1]);
                MevcutSinavGrafik.Series["Veri Analizi"].Points.AddXY("Başarı Yüzdesi", (MevcutSinavinDogruYanlısBilgileri[2, 0] * 100) / (MevcutSinavinDogruYanlısBilgileri[2, 0] + MevcutSinavinDogruYanlısBilgileri[2, 1]));
            }
            else if (konuİndex == 4 && isTestBitti == true)
            {
                MevcutSinavGrafik.Series["Üçgenler"].Points.AddXY("Dogru Sayısı", MevcutSinavinDogruYanlısBilgileri[3, 0]);
                MevcutSinavGrafik.Series["Üçgenler"].Points.AddXY("Yanlış Sayısı", MevcutSinavinDogruYanlısBilgileri[3, 1]);
                MevcutSinavGrafik.Series["Üçgenler"].Points.AddXY("Başarı Yüzdesi", (MevcutSinavinDogruYanlısBilgileri[3, 0] * 100) / (KonuDogruYanlisYüzdeBilgileri[3, 0] + MevcutSinavinDogruYanlısBilgileri[3, 1]));
            }
            else if (konuİndex == 5 && isTestBitti == true)
            {
                MevcutSinavGrafik.Series["Eşitsizlikler"].Points.AddXY("Dogru Sayısı", MevcutSinavinDogruYanlısBilgileri[4, 0]);
                MevcutSinavGrafik.Series["Eşitsizlikler"].Points.AddXY("Yanlış Sayısı", MevcutSinavinDogruYanlısBilgileri[4, 1]);
                MevcutSinavGrafik.Series["Eşitsizlikler"].Points.AddXY("Başarı Yüzdesi", (MevcutSinavinDogruYanlısBilgileri[4, 0] * 100) / (MevcutSinavinDogruYanlısBilgileri[4, 0] + MevcutSinavinDogruYanlısBilgileri[4, 1]));
            }else
            {
                MessageBox.Show("Lütfen Önce Sınav Sorularını Cevaplayınız");
            }


        }

        public void GenelCizgiGrafigiDoldur(int konuİndex)
        {

            if (konuİndex == 1 )
            {
                komut = new SqlCommand("SELECT Konu1DogruSayisi,Konu1YanlisSayisi,SınavTarihi FROM dbo.İstatistik WHERE OgrenciID='" + OgrenciID + "'", baglanti);
                baglanti.Open();
                reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    GenelCizgiChart.Series["Olasılık"].Points.AddXY(reader["SınavTarihi"].ToString(), (Convert.ToInt16(reader["Konu1DogruSayisi"])*100)/(Convert.ToInt16(reader["Konu1DogruSayisi"])+ Convert.ToInt16(reader["Konu1YanlisSayisi"])));
                }
                baglanti.Close();
               
            }
            else if (konuİndex == 2 )
            {
                komut = new SqlCommand("SELECT Konu2DogruSayisi,Konu2YanlisSayisi,SınavTarihi FROM dbo.İstatistik WHERE OgrenciID='" + OgrenciID + "'", baglanti);
                baglanti.Open();
                reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    GenelCizgiChart.Series["Çarpanlar ve Katmanlar"].Points.AddXY(reader["SınavTarihi"].ToString(), (Convert.ToInt16(reader["Konu2DogruSayisi"]) * 100) / (Convert.ToInt16(reader["Konu2DogruSayisi"]) + Convert.ToInt16(reader["Konu2YanlisSayisi"])));
                }
                baglanti.Close();
            }
            else if (konuİndex == 3 )
            {
                komut = new SqlCommand("SELECT Konu3DogruSayisi,Konu3YanlisSayisi,SınavTarihi FROM dbo.İstatistik WHERE OgrenciID='" + OgrenciID + "'", baglanti);
                baglanti.Open();
                reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    GenelCizgiChart.Series["Veri Analizi"].Points.AddXY(reader["SınavTarihi"].ToString(), (Convert.ToInt16(reader["Konu3DogruSayisi"]) * 100) / (Convert.ToInt16(reader["Konu3DogruSayisi"]) + Convert.ToInt16(reader["Konu3YanlisSayisi"])));
                }
                baglanti.Close();
            }
            else if (konuİndex == 4 )
            {
                komut = new SqlCommand("SELECT Konu4DogruSayisi,Konu4YanlisSayisi,SınavTarihi FROM dbo.İstatistik WHERE OgrenciID='" + OgrenciID + "'", baglanti);
                baglanti.Open();
                reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    GenelCizgiChart.Series["Üçgenler"].Points.AddXY(reader["SınavTarihi"].ToString(), (Convert.ToInt16(reader["Konu4DogruSayisi"]) * 100) / (Convert.ToInt16(reader["Konu4DogruSayisi"]) + Convert.ToInt16(reader["Konu4YanlisSayisi"])));
                }
                baglanti.Close();

            }
            else if (konuİndex == 5 )
            {
                komut = new SqlCommand("SELECT Konu5DogruSayisi,Konu5YanlisSayisi,SınavTarihi FROM dbo.İstatistik WHERE OgrenciID='" + OgrenciID + "'", baglanti);
                baglanti.Open();
                reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    GenelCizgiChart.Series["Eşitsizlikler"].Points.AddXY(reader["SınavTarihi"].ToString(), (Convert.ToInt16(reader["Konu5DogruSayisi"]) * 100) / (Convert.ToInt16(reader["Konu5DogruSayisi"]) + Convert.ToInt16(reader["Konu5YanlisSayisi"])));
                }
                baglanti.Close();
            }
            


        }
        
        private void TesteBaslaButton_Click(object sender, EventArgs e)
        {
            lblSure.Visible = true;
            SınavSuresiTimer.Start();
            TesteBaslaButton.Visible = false;
            SoruTuruAyırma(Sorular[AnlikSoru]);
            lblSoruSayaci.Visible = true;
            btnOncekiSoru.Visible = true;
            btnSonrakiSoru.Visible = true;
            btnTestiBitir.Visible = true;
        }

        private void btnSonrakiSoru_Click(object sender, EventArgs e)
        {
            if (AnlikSoru == 49)
            {
                btnSonrakiSoru.Enabled = false;
            }
            else
            {
                VerilenCevaplar[AnlikSoru] = soruTuru1.lblVerilenCevap.Text;
                AnlikSoru++;
                SoruTuruAyırma(Sorular[AnlikSoru]);
                btnOncekiSoru.Enabled = true;
                if (isTestBitti==true)
                {
                    soruTuru1.DogruCevapKontrolFunc(VerilenCevaplar[AnlikSoru]);
                    soruTuru2.DogruCevapKontrolFunc(VerilenCevaplar[AnlikSoru]);
                    soruTuru3.DogruCevapKontrolFunc(VerilenCevaplar[AnlikSoru]);
                    soruTuru4.DogruCevapKontrolFunc(VerilenCevaplar[AnlikSoru]);
                }
                SecilenSıkHatırla(Sorular[AnlikSoru].SoruTuru);

            }

        }
        
        private void btnOncekiSoru_Click(object sender, EventArgs e)
        {

            if (AnlikSoru == 0)
            {
                btnOncekiSoru.Enabled = false;
            }
            else
            {

                VerilenCevaplar[AnlikSoru] = soruTuru1.lblVerilenCevap.Text;
                btnSonrakiSoru.Enabled = true;
                AnlikSoru--;
                SoruTuruAyırma(Sorular[AnlikSoru]);
                if (isTestBitti == true)
                {
                    soruTuru1.DogruCevapKontrolFunc(VerilenCevaplar[AnlikSoru]);
                    soruTuru2.DogruCevapKontrolFunc(VerilenCevaplar[AnlikSoru]);
                    soruTuru3.DogruCevapKontrolFunc(VerilenCevaplar[AnlikSoru]);
                    soruTuru4.DogruCevapKontrolFunc(VerilenCevaplar[AnlikSoru]);

                }
                SecilenSıkHatırla(Sorular[AnlikSoru].SoruTuru);
            }
        }

        private void btnTestiBitir_Click(object sender, EventArgs e)
        {
                btnTestiBitir.Visible = false;
            SınavSuresiTimer.Stop();
            TestiBitir();
                if (isTestBitti == true)
                {
                    soruTuru1.DogruCevapKontrolFunc(VerilenCevaplar[AnlikSoru]);
                    soruTuru2.DogruCevapKontrolFunc(VerilenCevaplar[AnlikSoru]);
                    soruTuru3.DogruCevapKontrolFunc(VerilenCevaplar[AnlikSoru]);
                    soruTuru4.DogruCevapKontrolFunc(VerilenCevaplar[AnlikSoru]);
                }
            
            
        }
        
        private void cmbBxDersSecin_SelectedIndexChanged(object sender, EventArgs e)
        {
            BasariGrafigi.Series["Olasılık"].Points.Clear();
            BasariGrafigi.Series["Çarpanlar ve Katlar"].Points.Clear();
            BasariGrafigi.Series["Veri Analizi"].Points.Clear();
            BasariGrafigi.Series["Üçgenler"].Points.Clear();
            BasariGrafigi.Series["Eşitsizlikler"].Points.Clear();
            GenelBasariGrafigiDoldur(cmbBxGrafikEkraniKonuSec.SelectedIndex);
        }
        
        private void OgrenciEkraniTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OgrenciEkraniTabControl.SelectedIndex == 0)
            {
                if (TesteBaslaButton.Visible == false)
                {
                    lblSoruSayaci.Visible = true;
                    btnOncekiSoru.Visible = true;
                    btnSonrakiSoru.Visible = true;
                    btnTestiBitir.Visible = true;
                }
                
            }
            else
            {
                
                lblSoruSayaci.Visible = false;
                btnOncekiSoru.Visible = false;
                btnSonrakiSoru.Visible = false ;
                btnTestiBitir.Visible = false;
            }
        }

        private void cmboBoxMevcutSinavGrafigiKonusSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            MevcutSinavGrafik.Series["Olasılık"].Points.Clear();
            MevcutSinavGrafik.Series["Çarpanlar ve Katlar"].Points.Clear();
            MevcutSinavGrafik.Series["Veri Analizi"].Points.Clear();
            MevcutSinavGrafik.Series["Üçgenler"].Points.Clear();
            MevcutSinavGrafik.Series["Eşitsizlikler"].Points.Clear();
            MevcutSınavGrafigiDoldur(cmboBoxMevcutSinavGrafigiKonusSec.SelectedIndex);
        }

        private void cmbBxGenelCizgiGrafigiKonuSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenelCizgiChart.Series["Olasılık"].Points.Clear();
            GenelCizgiChart.Series["Çarpanlar ve Katmanlar"].Points.Clear();
            GenelCizgiChart.Series["Veri Analizi"].Points.Clear();
            GenelCizgiChart.Series["Üçgenler"].Points.Clear();
            GenelCizgiChart.Series["Eşitsizlikler"].Points.Clear();
            GenelCizgiGrafigiDoldur(cmbBxGenelCizgiGrafigiKonuSec.SelectedIndex);
        }

        private void SınavSuresiTimer_Tick(object sender, EventArgs e)
        {
            saniye++;
            if (saniye==60)
            {
                saniye = 0;
                dakika++;
            }

            if (dakika == 60)
            {
                SınavSuresiTimer.Stop();
                btnTestiBitir.Visible = false;

                TestiBitir();
                if (isTestBitti == true)
                {
                    soruTuru1.DogruCevapKontrolFunc(VerilenCevaplar[AnlikSoru]);
                    soruTuru2.DogruCevapKontrolFunc(VerilenCevaplar[AnlikSoru]);
                    soruTuru3.DogruCevapKontrolFunc(VerilenCevaplar[AnlikSoru]);
                    soruTuru4.DogruCevapKontrolFunc(VerilenCevaplar[AnlikSoru]);
                }
            }
            lblSure.Text = "Süre: " + dakika + ":" + saniye;
        }
    }
}
