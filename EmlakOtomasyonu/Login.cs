using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmlakOtomasyonu
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();            
        }
        
        private void btnGiris_Click(object sender, EventArgs e)
        {
            string dosya_yolu = "../../users.txt";
            if (!File.Exists(dosya_yolu))
            {
                MessageBox.Show("Kullanıcı Dosyası Bulunmuyor. Öncelikle Kullanıcı Ekleyiniz");
            }
            else
            {
                MessageBox.Show("Kullanıcı Dosyası Bulundu");
                List<Kullanici> kullanicilar = DosyaIslemleri.DosyaOkuma(dosya_yolu);
                string kullaniciAdi = txtKullaniciAdi.Text;
                string sifre = txtSifre.Text;

                foreach(Kullanici kullanici in kullanicilar)
                {
                    if(kullanici.KullaniciAdi.Equals(kullaniciAdi) && kullanici.Sifre.Equals(sifre))
                    {
                        MessageBox.Show("Giriş Başarılı");
                        Form1 form1 = new Form1();
                        form1.Visible = true;
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Yanlış Kullanıcı Adı veya Şifre Giriniz");
                    }
                }
            }
        }
    }
}
