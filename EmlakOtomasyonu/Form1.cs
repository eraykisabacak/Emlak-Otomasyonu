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
            string dosya_yolu = "../../semtler.txt";
            if (!File.Exists(dosya_yolu))
            {
                MessageBox.Show("Semt Dosyası Bulunmuyor");
                return;
            }
            else
            {
                List<string> semtler = DosyaIslemleri.DosyaOkumaSemt(dosya_yolu, cb_İl.Text);
                foreach(string semt in semtler)
                {
                    cbSemt.Items.Add(semt);
                }
                cbSemt.Enabled = true;
            }
            

        }

        private void rbSatilik_CheckedChanged(object sender, EventArgs e)
        {
            label8.Visible = false;
            txtKira.Visible = false;
            
            label9.Visible = true;
            txtFiyat.Visible = true;
           
        }

        private void rbKiralik_CheckedChanged(object sender, EventArgs e)
        {
            label9.Visible = true;
            label9.Text = "Depozito";
            txtFiyat.Name = "txtDepozito";
            
        }
    }
}
