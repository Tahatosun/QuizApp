using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazılımSınamaOdevi
{
    public class Soru
    {
       
        public int SoruID { get; set; }
        public string KonuAdi { get; set; }
        public int SoruTuru { get; set; }
        public string SoruResmiDosyaYolu { get; set; }
        public string SoruMetni { get; set; }
        public string ASikkiMetin { get; set; }
        public string ASikkiResim { get; set; }
        public string BSikkiMetin { get; set; }
        public string BSikkiResim { get; set; }
        public string CSikkiMetin { get; set; }
        public string CSikkiResim { get; set; }
        public string DSikkiMetin { get; set; }
        public string DSikkiResim { get; set; }
        public string DogruCevap { get; set; }


    }
}
