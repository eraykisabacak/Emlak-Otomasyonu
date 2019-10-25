﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Ev
    {
        int OdaSayisi {
            get
            {
                return OdaSayisi;
            }
            set
            {
                if (value > 0)
                {
                    this.OdaSayisi = value;
                }
                else
                {
                    this.OdaSayisi = 0;
                }
            }
        }
        int KatNumarasi { get; set; }
        string Semt { get; set; }
        static DateTime YapimTarihi {
            get
            {
                return YapimTarihi;
            }
            set
            {
                if (DateTime.Now.Day >= value.Day)
                {
                    YapimTarihi = value;
                }
                else
                {
                    YapimTarihi = DateTime.Now;
                }
            }
        }
        bool Aktif { get; set; }
        decimal EmlakNumarasi
        {   // Şehir Plaka Kodu-YapimTarihYili-ID  -- 42 2018 001  --- Her ev için farklı bir numara
            get
            {
                return EmlakNumarasi;
            }
            set
            {
                if (value >= 011948001) // 012018001
                {
                    this.EmlakNumarasi = value;
                }
                else
                {
                    this.EmlakNumarasi = 111111111;
                }
            }
        }
        decimal Alan {
            get
            {
                return Alan;
            }
            set
            {
                if (value > 0)
                {
                    this.Alan = value;
                }
                else
                {
                    this.Alan = 10;
                }
            }
        }

        private int Yas = DateTime.Now.Day - YapimTarihi.Day;

        int turuSayi = 0;

        private enum Turu
        {
            Daire, Bahceli, Dubleks, Mustakil
        }

        public Ev(int OdaSayisi = 0, int KatNumarasi = 0, string Semt = "Selçuk Üniversitesi", decimal Alan = 10)
        {
            this.OdaSayisi = OdaSayisi;
            this.KatNumarasi = KatNumarasi;
            this.Semt = Semt;
            this.Alan = Alan;
        }
        public Ev(int KatNumarasi = 0, string Semt = "Selçuk Üniversitesi", decimal Alan = 10)
        {
            this.OdaSayisi = OdaSayisi;
            this.KatNumarasi = 0;
            this.Semt = Semt;
            this.Alan = Alan;
        }

        public string EvBilgileri()
        {
            return string.Format("Oda Sayısı : {0} Kat Numarası : {1} Semt : {2} Alan : {3} Turu : {4} Yaşı: {5}", OdaSayisi, KatNumarasi, Alan, (Turu)turuSayi, Yas);
        }

        public int FiyatHesapla()
        {
            string dosya_yolu = "../../room_cost.txt";
            int katSayi = 200;

            if (!File.Exists(dosya_yolu))
            {
                return katSayi * OdaSayisi;
            }
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            string yazi = sw.ReadLine();
            {
                string[] dizi = yazi.Split('|');
                if (dizi[0].Equals((Turu)turuSayi))
                {
                    katSayi = int.Parse(dizi[1]);
                }
            }
            sw.Close();
            fs.Close();
            return katSayi * OdaSayisi;

        }
    }

    public class KiralikEv : Ev
    {
        decimal Kira, Depozito; 
        
        public KiralikEv(int OdaSayisi = 0, int KatNumarasi = 0, string Semt = "Selçuk Üniversitesi", decimal Alan = 10,decimal Kira = 800, decimal Depozito = 100): base(OdaSayisi,KatNumarasi ,Semt, Alan)
        {

        }
    }

    public class SatilikEv : Ev
    {
        decimal Fiyat;
    }
}