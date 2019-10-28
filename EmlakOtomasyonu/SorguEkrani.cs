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
    public partial class SorguEkrani : Form
    {
        public SorguEkrani()
        {
            InitializeComponent();
        }

        private void cb_İl_SelectedValueChanged(object sender, EventArgs e)
        {
            Ev.sehir = (cb_İl.SelectedIndex) + 1;
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
        bool kontrol = true;
        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            string il = "";
            string semt = "";
            if (cb_İl.Text != "")
            {
                il = cb_İl.Text;
            }
            else
            {
                MessageBox.Show("Lütfen ili giriniz");
                return;
            }
            if(cbSemt.Text != "")
            {
                semt = cbSemt.Text;
            }
            else
            {
                MessageBox.Show("Lütfen semt giriniz");
                return;
            }
            if (rbSatilik.Checked)
            {
                List<SatilikEv> evler = DosyaIslemleri.DosyaSatilikEvOkuma();
                foreach (SatilikEv ev in evler)
                {
                    if (semt.Equals(ev.Semt) && il.Equals(ev.il))
                    {
                        dataGridView1.Rows.Add(ev.EmlakNumarasi,ev.OdaSayisi, ev.KatNumarasi, ev.il, ev.Semt, ev.Alan, ev.turuSayi, ev.turu, ev.Aktif, ev.YapimTarihi, ev.Fiyat);
                    }
                }
            }
            else
            {
                List<KiralikEv> evler = DosyaIslemleri.DosyaKiralikEvOkuma();

                if (kontrol)
                {
                    dataGridView1.Columns.Add("Column", "Depozito");
                    kontrol = false;
                }
                foreach (KiralikEv ev in evler)
                {
                    if (semt.Equals(ev.Semt) && il.Equals(ev.il))
                    {
                        dataGridView1.Rows.Add(ev.EmlakNumarasi,ev.OdaSayisi, ev.KatNumarasi, ev.il, ev.Semt, ev.Alan, ev.turuSayi, ev.turu, ev.Aktif, ev.YapimTarihi, ev.Kira, ev.Depozito);
                    }
                }

            }
        }

        private void SorguEkrani_Load(object sender, EventArgs e)
        {
            
        }
    }
}
