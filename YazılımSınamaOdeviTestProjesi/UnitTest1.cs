using System;
using System.Reflection.Emit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using System.Data.SqlClient;

namespace YazılımSınamaOdeviTestProjesi
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VeritabanindanSorulariGetir()
        {
            YazılımSınamaOdevi.OgrenciEkrani ogrenciEkrani = new YazılımSınamaOdevi.OgrenciEkrani();
            ogrenciEkrani.VeritabanındanSorularıGetir();
            Assert.IsNotNull(ogrenciEkrani.Sorular[0]);
        }
        [TestMethod]
        public void OgrenciBilgileriniKontrolEt()
        {
            YazılımSınamaOdevi.GirisEkrani girisEkrani = new YazılımSınamaOdevi.GirisEkrani();            

            Assert.IsTrue(girisEkrani.OgrenciBilgileriniKontrolEt("taha", "1234"));
        }
        [TestMethod]
        public void OgretmenBilgileriniKontrolEt()
        {
            YazılımSınamaOdevi.GirisEkrani girisEkrani = new YazılımSınamaOdevi.GirisEkrani();

            Assert.IsTrue(girisEkrani.OgretmenBilgileriniKontrolEt("oguz", "1234"));
        }


    }
}
