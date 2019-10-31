using ClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmlakOtomasyonu
{
    class DosyaIslemleri
    {
        public static void DosyaIdBelirleme()
        {
            FileStream fs = new FileStream("../../satilik.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string yazi = sr.ReadLine();

            while (yazi != null)
            {
                yazi = sr.ReadLine();
                Console.WriteLine("+1 Satilik");
                Ev.id += 1;
            }
            sr.Close();
            fs.Close();


            fs = new FileStream("../../kiralik.txt", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fs);
            yazi = sr.ReadLine();
            while (yazi != null)
            {
                yazi = sr.ReadLine();
                Console.WriteLine("+1 Kiralik");
                Ev.id += 1;
            }

            sr.Close();
            fs.Close();
        }

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
            fs.Flush();
            sr.Close();
            fs.Close();
            return semtler;
        }

        public static void DosyaSatilikYazmak(string dosya_yolu, string durum)
        {
            if (!File.Exists(dosya_yolu))
            {
                File.Create(dosya_yolu);
            }
            FileStream fs = new FileStream(dosya_yolu, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
                foreach (SatilikEv ev in SatilikEv.evler)
                {
                    if (ev.turu.Equals("satilik"))
                    {
                        sw.WriteLine(ev.EmlakNumarasi + "|" + ev.OdaSayisi + "|" + ev.KatNumarasi + "|" + ev.il + "|" + ev.Semt + "|" + ev.Alan + "|" 
                            + ev.turuSayi + "|"+  ev.turu + "|" + ev.Aktif + "|" + ev.YapimTarihi + "|" + ev.Fiyat);
                    }
                }
            sw.Close();
            fs.Close();
        }
        public static void DosyaKiralikEvYazmak(string dosya_yolu, string durum)
        {
            if (!File.Exists(dosya_yolu))
            {
                File.Create(dosya_yolu);
            }
            FileStream fs = new FileStream(dosya_yolu, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            foreach (KiralikEv ev in KiralikEv.evler)
            {
                if (ev.turu.Equals("kiralik"))
                {
                    sw.WriteLine(ev.EmlakNumarasi + "|" + ev.OdaSayisi + "|" + ev.KatNumarasi + "|" + ev.il + "|" + ev.Semt + "|" + ev.Alan + "|" + ev.turuSayi + "|" +
                        ev.turu + "|" + ev.Aktif + "|" + ev.YapimTarihi + "|" + ev.Kira + "|"+ ev.Depozito);
                }
            }

            sw.Close();
            fs.Close();
        }

        public static List<SatilikEv> DosyaSatilikEvOkuma()
        {
            List<SatilikEv> evler = new List<SatilikEv>();
            string dosya_yolu = @"../../satilik.txt";
            
            if (!File.Exists(dosya_yolu))
            {
                MessageBox.Show("Satilik Dosya Bulunamadı");
            }
            else
            {               
                FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string yazi = sr.ReadLine();
                while(yazi != null)
                {
                    string[] dosya = yazi.Split('|');
                    
                    evler.Add(new SatilikEv(int.Parse(dosya[1]),int.Parse(dosya[2]),dosya[3],dosya[4],decimal.Parse(dosya[5]),
                              int.Parse(dosya[6]),dosya[7], bool.Parse(dosya[8]), DateTime.Parse(dosya[9]),decimal.Parse(dosya[10]),decimal.Parse(dosya[0])));

                    Ev.evler.Add(new SatilikEv(int.Parse(dosya[1]), int.Parse(dosya[2]), dosya[3], dosya[4], decimal.Parse(dosya[5]),
                              int.Parse(dosya[6]), dosya[7], bool.Parse(dosya[8]), DateTime.Parse(dosya[9]), decimal.Parse(dosya[10]), decimal.Parse(dosya[0])));

                    Console.WriteLine(dosya[0] + " " + int.Parse(dosya[1]) + " " + int.Parse(dosya[2]) + " " + dosya[3] + " " + dosya[4] + " "
                        + " " + decimal.Parse(dosya[5]) + " " + int.Parse(dosya[6]) + " " + dosya[7] + " " + bool.Parse(dosya[8])
                       + " " + DateTime.Parse(dosya[9]) + " " + decimal.Parse(dosya[10]));

                    yazi = sr.ReadLine();
                }
                sr.Close();
                fs.Close();
            }
            return evler;
        }

        public static List<KiralikEv> DosyaKiralikEvOkuma()
        {
            List<KiralikEv> evler = new List<KiralikEv>();
            string dosya_yolu = @"../../kiralik.txt";

            if (!File.Exists(dosya_yolu))
            {
                MessageBox.Show("Satilik Dosya Bulunamadı");
            }
            else
            {
                FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string yazi = sr.ReadLine();
                while (yazi != null)
                {
                    string[] dosya = yazi.Split('|');

                    Console.WriteLine(dosya[1] + " " + dosya[2] + " " + dosya[3] + " " + dosya[4] + " " + dosya[5] + " "+ dosya[6] + " "+
                                        dosya[7] + " " + dosya[8] + " " + dosya[9] + " " + dosya[10]);
                    
                    evler.Add(new KiralikEv(int.Parse(dosya[1]), int.Parse(dosya[2]), dosya[3], dosya[4], decimal.Parse(dosya[5]),
                              int.Parse(dosya[6]), dosya[7], bool.Parse(dosya[8]), DateTime.Parse(dosya[9]), decimal.Parse(dosya[10]),decimal.Parse(dosya[11]),decimal.Parse(dosya[0])));

                    Ev.evler.Add(new KiralikEv(int.Parse(dosya[1]), int.Parse(dosya[2]), dosya[3], dosya[4], decimal.Parse(dosya[5]),
                              int.Parse(dosya[6]), dosya[7], bool.Parse(dosya[8]), DateTime.Parse(dosya[9]), decimal.Parse(dosya[10]), decimal.Parse(dosya[11]), decimal.Parse(dosya[0])));


                    yazi = sr.ReadLine();
                }
                sr.Close();
                fs.Close();
            }
            return evler;
        }

        public static void DosyaAkifPasif(string dosya_yolu,string deger)
        {
            if (!File.Exists(dosya_yolu))
            {
                File.Create(dosya_yolu);
            }

            if (deger.Equals("satilik"))
            {
                FileStream fs = new FileStream(dosya_yolu, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                foreach(SatilikEv ev in Ev.evler)
                {
                    sw.WriteLine(ev.EmlakNumarasi + "|" + ev.OdaSayisi + "|" + ev.KatNumarasi + "|" + ev.il + "|" + ev.Semt + "|" + ev.Alan + "|"
                            + ev.turuSayi + "|" + ev.turu + "|" + ev.Aktif + "|" + ev.YapimTarihi + "|" + ev.Fiyat);
                }
                sw.Close();
                fs.Close();
            }
            else
            {
                FileStream fs = new FileStream(dosya_yolu, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                foreach (KiralikEv ev in Ev.evler)
                {
                    sw.WriteLine(ev.EmlakNumarasi + "|" + ev.OdaSayisi + "|" + ev.KatNumarasi + "|" + ev.il + "|" + ev.Semt + "|" + ev.Alan + "|" + ev.turuSayi + "|" +
                       ev.turu + "|" + ev.Aktif + "|" + ev.YapimTarihi + "|" + ev.Kira + "|" + ev.Depozito);
                }
                sw.Close();
                fs.Close();
            }
        }

        public static int RoomCastSayisi(ComboBox cb)
        {
            FileStream fs = new FileStream("../../room_cost.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string yazi = sr.ReadLine();
            int a = 0;
            while (yazi != null)
            {
                string[] dosya = yazi.Split('|');
                if (cb.Text == dosya[0])
                {
                    break;
                }
                yazi = sr.ReadLine();
                a++;
            }
            sr.Close();
            fs.Close();
            return a;
        }
    }
}
