using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakOtomasyonu
{
    class Kullanici
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }

        public Kullanici(string kullaniciAdi, string sifre)
        {
            this.KullaniciAdi = kullaniciAdi;
            this.Sifre = sifre;
        }
    }
}
