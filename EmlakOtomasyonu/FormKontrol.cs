using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakOtomasyonu
{
    class FormKontrol
    {
        public static void SatilikRadioButton(Form1 form)
        {
            form.txtDepozito.Visible = false;
            form.label8.Visible = false;
            form.txtKira.Visible = false;
            form.label9.Text = "Fiyatı :";
            form.label9.Visible = true;
            form.txtFiyat.Visible = true;
        }

        public static void KiralikRadioButton(Form1 form)
        {
            form.txtFiyat.Visible = false;
            form.label9.Visible = true;
            form.label9.Text = "Depozito :";
            form.txtDepozito.Visible = true;
            form.label8.Visible = true;
            form.txtKira.Visible = true;
        }

        public static void SatilikRadioButton(EvDuzenleme form)
        {
            form.txtDepozito.Visible = false;
            form.label8.Visible = false;
            form.txtKira.Visible = false;
            form.label9.Text = "Fiyatı :";
            form.label9.Visible = true;
            form.txtFiyat.Visible = true;
        }

        public static void KiralikRadioButton(EvDuzenleme form)
        {
            form.txtFiyat.Visible = false;
            form.label9.Visible = true;
            form.label9.Text = "Depozito :";
            form.txtDepozito.Visible = true;
            form.label8.Visible = true;
            form.txtKira.Visible = true;
        }

        public static bool FormButtonKontrol(Form1 form)
        {
            if(form.cb_İl.Text == "")
            {
                return false;
            }
            if(form.cbSemt.Text == "")
            {
                return false;
            }
            if(!(form.rbKiralik.Checked || form.rbSatilik.Checked))
            {
                return false;
            }
            if (form.rbSatilik.Checked)
            {
                if(form.txtFiyat.Text == "")
                {
                    return false;
                }
            }
            if (form.rbKiralik.Checked)
            {
                if(form.txtDepozito.Text == "")
                {
                    return false;
                }
                if(form.txtKira.Text == "")
                {
                    return false;
                }
            }
            if(form.txtAlan.Text == "")
            {
                return false;
            }
            if (form.txtOdaSayisi.Text == "")
            {
                return false;
            }
            if (form.txtKatNumarasi.Text == "")
            {
                return false;
            }
            if (form.cbEvTur.Text == "")
            {
                return false;
            }
            return true;
        }
    }
}
