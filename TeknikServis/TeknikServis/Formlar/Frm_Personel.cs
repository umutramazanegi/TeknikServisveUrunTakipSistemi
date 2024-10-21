using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class Frm_Personel : Form
    {
        public Frm_Personel()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void listele()
        {
            var degerler = from p in db.TBL_PERSONEL
                           select new
                           {
                               p.ID,
                               p.AD,
                               p.SOYAD,
                               p.MAIL,
                               p.TELEFON
                           };
            gridControl1.DataSource = degerler.ToList();

            lookUpEdit1.Properties.DataSource = (from x in db.TBL_DEPARTMAN
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD
                                                 }).ToList();
        }
        private void Frm_Personel_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.NullText = "Bir Değer Seçiniz...";
            listele();
            string ad1, soyad1, ad2, soyad2, ad3, soyad3, ad4, soyad4;
            //1.personel
            ad1 = db.TBL_PERSONEL.First(x => x.ID == 1).AD;
            soyad1 = db.TBL_PERSONEL.First(x => x.ID == 1).SOYAD;
            labelControl5.Text = db.TBL_PERSONEL.First(x => x.ID == 1).TBL_DEPARTMAN.AD;
            labelControl7.Text = db.TBL_PERSONEL.First(x => x.ID == 1).MAIL;
            labelControl4.Text = ad1 + " " + soyad1;
            //2.personel
            ad2 = db.TBL_PERSONEL.First(x => x.ID == 2).AD;
            soyad2 = db.TBL_PERSONEL.First(x => x.ID == 2).SOYAD;
            labelControl12.Text = db.TBL_PERSONEL.First(x => x.ID == 2).TBL_DEPARTMAN.AD;
            labelControl10.Text = db.TBL_PERSONEL.First(x => x.ID == 2).MAIL;
            labelControl14.Text = ad2 + " " + soyad2;
            //3.personel
            ad3 = db.TBL_PERSONEL.First(x => x.ID == 3).AD;
            soyad3 = db.TBL_PERSONEL.First(x => x.ID == 3).SOYAD;
            labelControl18.Text = db.TBL_PERSONEL.First(x => x.ID == 3).TBL_DEPARTMAN.AD;
            labelControl16.Text = db.TBL_PERSONEL.First(x => x.ID == 3).MAIL;
            labelControl20.Text = ad3 + " " + soyad3;
            //4.personel
            ad4 = db.TBL_PERSONEL.First(x => x.ID == 4).AD;
            soyad4 = db.TBL_PERSONEL.First(x => x.ID == 4).SOYAD;
            labelControl24.Text = db.TBL_PERSONEL.First(x => x.ID == 4).TBL_DEPARTMAN.AD;
            labelControl22.Text = db.TBL_PERSONEL.First(x => x.ID == 4).MAIL;
            labelControl26.Text = ad4 + " " + soyad4;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBL_PERSONEL t = new TBL_PERSONEL();
            t.AD = txtad.Text;
            t.SOYAD = txtsoyad.Text;
            t.DEPARTMAN = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.TBL_PERSONEL.Add(t);
            db.SaveChanges();
            MessageBox.Show("Personel Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
    }
}
