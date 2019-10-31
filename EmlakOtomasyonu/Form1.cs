using ClassLibrary;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }   

        private void cb_İl_SelectedValueChanged(object sender, EventArgs e)
        {
            Ev.sehir = (cb_İl.SelectedIndex)+1;
            string dosya_yolu = "../../semtler.txt";
            if (!File.Exists(dosya_yolu))
            {
                MessageBox.Show("Semt Dosyası Bulunmuyor");
                return;
            }
            else
            {
                List<string> semtler = DosyaIslemleri.DosyaOkumaSemt(dosya_yolu, cb_İl.Text);
                cbSemt.Items.Clear();
                foreach (string semt in semtler)
                {
                    cbSemt.Items.Add(semt);
                }
                cbSemt.Enabled = true;
            }
        }

        private void rbSatilik_CheckedChanged(object sender, EventArgs e)
        {
            FormKontrol.SatilikRadioButton(this);
        }

        private void rbKiralik_CheckedChanged(object sender, EventArgs e)
        {
            FormKontrol.KiralikRadioButton(this);
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            bool kontrol = FormKontrol.FormButtonKontrol(this);
            if (kontrol)
            {
                if (rbSatilik.Checked)
                {
                    SatilikEv satilikEv = new SatilikEv(
                        int.Parse(txtOdaSayisi.Text), int.Parse(txtKatNumarasi.Text), cb_İl.Text,
                    cbSemt.Text, int.Parse(txtAlan.Text),cbEvTur.Items.IndexOf(cbEvTur.SelectedItem),"satilik",true, DateTime.Parse(yapim.Text), int.Parse(txtFiyat.Text));
                    Ev.evler.Add(satilikEv);
                    string dosya_yolu = "../../satilik.txt";
                    DosyaIslemleri.DosyaSatilikEvOkuma();
                    DosyaIslemleri.DosyaSatilikYazmak(dosya_yolu,"satilik");
                    MessageBox.Show("Satılık ev eklendi");
                    this.Close();
                }
                else
                {
                    KiralikEv kiralikEv = new KiralikEv(int.Parse(txtOdaSayisi.Text), int.Parse(txtKatNumarasi.Text),cb_İl.Text,
                        cbSemt.Text, int.Parse(txtAlan.Text), cbEvTur.Items.IndexOf(cbEvTur.SelectedItem),"kiralik",true, DateTime.Parse(yapim.Text), decimal.Parse(txtKira.Text), decimal.Parse(txtDepozito.Text));
                    Ev.evler.Add(kiralikEv);
                    string dosya_yolu = "../../kiralik.txt";
                    DosyaIslemleri.DosyaKiralikEvYazmak(dosya_yolu,"kiralik");
                    MessageBox.Show("Kiralık ev eklendi");
                    this.Close();
                }
                Ev.id++;
            }
            else
            {
                MessageBox.Show("Boş yerleri doldurunuz");
            }

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void txtOdaSayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbEvTur_SelectedValueChanged(object sender, EventArgs e)
        {
            if(txtOdaSayisi.Text != "" && cbEvTur.Text != "")
            {
                tahmin.Text = "Önerilen Fiyat : " + (Ev.FiyatHesapla(int.Parse(txtOdaSayisi.Text), cbEvTur.Text).ToString());
            }
        }
    }
}
