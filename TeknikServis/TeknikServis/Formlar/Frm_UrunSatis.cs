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
    public partial class Frm_UrunSatis : Form
    {
        public Frm_UrunSatis()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void Frm_UrunSatis_Load(object sender, EventArgs e)
        {
            luecari.Properties.NullText = "Cari...";
            luepersonel.Properties.NullText = "Personel...";
            lueuruid.Properties.NullText = "Ürün Id...";
            lueuruid.Properties.DataSource = (from x in db.TBL_URUN
                                              select new
                                              {
                                                  x.ID,
                                                  x.AD
                                              }).ToList();

            luepersonel.Properties.DataSource = (from y in db.TBL_PERSONEL
                                                 select new
                                                 {
                                                     y.ID,
                                                     Ad = y.AD + " " + y.SOYAD
                                                 }).ToList();
            luecari.Properties.DataSource = (from i in db.TBL_CARİ
                                             select new
                                             {
                                                 i.ID,
                                                 Ad = i.AD + " " + i.SOYAD
                                             }).ToList();
        }

        private void btnvazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsatisyap_Click(object sender, EventArgs e)
        {
            TBL_URUNHAREKET u = new TBL_URUNHAREKET();
            u.ADET = short.Parse(txtadet.Text);
            u.FIYAT = decimal.Parse(txtsatisfiyat.Text);
            u.MUSTERI = int.Parse(luecari.EditValue.ToString());
            u.PERSONEL = short.Parse(luepersonel.EditValue.ToString());
            u.TARIH = DateTime.Parse(txttarih.Text);
            u.URUN = int.Parse(lueuruid.EditValue.ToString());
            u.URUNSERINO = txtserino.Text;
            db.TBL_URUNHAREKET.Add(u);
            db.SaveChanges();
            MessageBox.Show("Ürün Satışı Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txttarih_Click(object sender, EventArgs e)
        {
            txttarih.Text = DateTime.Now.ToShortDateString();
        }

        private void txtadet_Click(object sender, EventArgs e)
        {
            txtadet.Text = "";
            txtadet.Focus();
        }

        private void txtsatisfiyat_Click(object sender, EventArgs e)
        {
            txtsatisfiyat.Text = "";
            txtsatisfiyat.Focus();
        }

        private void txtserino_Click(object sender, EventArgs e)
        {
            txtserino.Text = "";
            txtserino.Focus();
        }
    }
}
