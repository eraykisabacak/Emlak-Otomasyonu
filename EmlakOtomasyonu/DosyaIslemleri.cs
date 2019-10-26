using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakOtomasyonu
{
    class DosyaIslemleri
    {
        public static List<Kullanici> DosyaOkuma(string dosya_yolu)
        {
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            List<Kullanici> kullanicilar = new List<Kullanici>();
            string yazi = sr.ReadLine();

            while(yazi != null)
            {
                string[] parca = yazi.Split('|');
                kullanicilar.Add(new Kullanici(parca[0],parca[1]));
                yazi = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
            return kullanicilar;
        }

        public static List<string> DosyaOkumaSemt(string dosya_yolu,string il)
        {
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("windows-1254"));
            List<string> semtler = new List<string>();
            string yazi = sr.ReadLine();
            while (yazi != null)
            {
                string[] parca = yazi.Split('|');
                if (il.Equals(parca[0]))
                {
                    semtler.Add(parca[1]);
                }
                yazi = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
            return semtler;
        }
    }
}
