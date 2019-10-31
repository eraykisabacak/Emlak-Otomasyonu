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
            Ev.evler.Clear();
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
                    if (semt.Equals(ev.Semt) && il.Equals(ev.il) && ev.Aktif == true)
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
                    if (semt.Equals(ev.Semt) && il.Equals(ev.il) && ev.Aktif == true)
                    {
                        dataGridView1.Rows.Add(ev.EmlakNumarasi,ev.OdaSayisi, ev.KatNumarasi, ev.il, ev.Semt, ev.Alan, ev.turuSayi, ev.turu, ev.Aktif, ev.YapimTarihi, ev.Kira, ev.Depozito);
                    }
                }

            }
        }

        private void SorguEkrani_Load(object sender, EventArgs e)
        {
            
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            // Düzenle tuşu basıldığında eğer datagridviewdan bir şey seçili değilse hata veriyor
            
            string deger = dataGridView1.CurrentRow.Cells["Column11"].Value.ToString();
            string satKira = dataGridView1.CurrentRow.Cells["Column7"].Value.ToString();
            Console.WriteLine(satKira);

            if (satKira.Equals("satilik"))
            {
                foreach (SatilikEv ev in Ev.evler)
                {
                    if (ev.EmlakNumarasi == decimal.Parse(deger))
                    {
                        Console.WriteLine("Emlak Numarası " + ev.EmlakNumarasi);
                        Console.WriteLine("Semt " + ev.Semt);

                        EvDuzenleme evDuzenleme = new EvDuzenleme(ev.OdaSayisi, ev.KatNumarasi, ev.il, ev.Semt, ev.Alan,
                        ev.turuSayi, ev.turu, ev.Aktif, ev.YapimTarihi, ev.Fiyat,ev.EmlakNumarasi);

                        evDuzenleme.Visible = true;
                        return;
                    }
                }
            }
            else
            {
                foreach (KiralikEv ev in Ev.evler)
                {
                    if (ev.EmlakNumarasi == decimal.Parse(deger))
                    {
                        Console.WriteLine("Emlak Numarası " + ev.EmlakNumarasi);
                        Console.WriteLine("Semt " + ev.Semt);

                        EvDuzenleme evDuzenleme = new EvDuzenleme(ev.OdaSayisi, ev.KatNumarasi, ev.il, ev.Semt, ev.Alan,
                        ev.turuSayi, ev.turu, ev.Aktif, ev.YapimTarihi, ev.Kira, ev.Depozito,ev.EmlakNumarasi);

                        evDuzenleme.Visible = true;
                    }
                }
            }
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string deger = dataGridView1.CurrentRow.Cells["Column11"].Value.ToString();
            int i = 0;
            foreach (Ev ev in Ev.evler)
            {
                if (ev.EmlakNumarasi == decimal.Parse(deger))
                {
                    break;
                }
                i++;
            }
            Ev.evler.RemoveAt(i);
            foreach (Ev ev in Ev.evler)
            {
                if (ev.turu.Equals("satilik"))
                {
                    DosyaIslemleri.DosyaSatilikYazmak("../../satilik.txt", "satilik");
                }
                else
                {
                    DosyaIslemleri.DosyaKiralikEvYazmak("../../kiralik.txt", "kiralik");
                }
            }
            dataGridView1.Refresh();
            MessageBox.Show("Silindi");
        }

        private void btnAktifPasif_Click(object sender, EventArgs e)
        {
            Ev.evler.Clear();
            if (rbKiralik.Checked)
            {
                DosyaIslemleri.DosyaKiralikEvOkuma();
            }
            else
            {
                DosyaIslemleri.DosyaSatilikEvOkuma();
            }
            string deger = dataGridView1.CurrentRow.Cells["Column11"].Value.ToString();
            string satKira = dataGridView1.CurrentRow.Cells["Column7"].Value.ToString();
            int i = 0;
            foreach (Ev ev in Ev.evler)
            {
                if (ev.EmlakNumarasi == decimal.Parse(deger))
                {
                    if (ev.Aktif)
                    {
                        ev.Aktif = false;
                        break;
                    }
                    else
                    {
                        ev.Aktif = true;
                        break;
                    }
                }
                i++;
            }
            foreach (Ev ev in Ev.evler)
            {
                if (ev.turu.Equals("satilik"))
                {
                    DosyaIslemleri.DosyaAkifPasif("../../satilik.txt","satilik");
                }
                else
                {
                    DosyaIslemleri.DosyaAkifPasif("../../kiralik.txt","kiralik");
                }
            }
            MessageBox.Show("İşleminiz Gerçekleştirildi");
        }
    }
}
