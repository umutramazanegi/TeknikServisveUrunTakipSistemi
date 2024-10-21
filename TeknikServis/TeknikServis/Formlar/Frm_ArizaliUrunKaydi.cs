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
    public partial class Frm_ArizaliUrunKaydi : Form
    {
        public Frm_ArizaliUrunKaydi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void Frm_ArizaliUrunKaydi_Load(object sender, EventArgs e)
        {
            //müşteri
            lookUpEdit1.Properties.NullText = "Bir Değer Seçiniz...";
            lookUpEdit1.Properties.DataSource = (from x in db.TBL_CARİ
                                                 select new
                                                 {
                                                     x.ID,
                                                     Ad = x.AD + " " + x.SOYAD
                                                 }).ToList();
            //personel
            lookUpEdit2.Properties.NullText = "Bir Değer Seçiniz...";
            lookUpEdit2.Properties.DataSource = (from x in db.TBL_PERSONEL
                                                 select new
                                                 {
                                                     x.ID,
                                                     Ad = x.AD + " " + x.SOYAD
                                                 }).ToList();
        }

        private void btnvazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            TBL_URUNKABUL t = new TBL_URUNKABUL();
            t.CARI = int.Parse(lookUpEdit1.EditValue.ToString());
            t.GELISTARIH = DateTime.Parse(txttarih.Text);
            t.PERSONEL = short.Parse(lookUpEdit2.EditValue.ToString());
            t.URUNSERINO = txtserino.Text;
           // t. = "Ürün Kaydoldu.";
            db.TBL_URUNKABUL.Add(t);
            db.SaveChanges();
            MessageBox.Show("Arızalı Ürün Kaydı Yapıldı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txttarih_Click(object sender, EventArgs e)
        {
            txttarih.Text = DateTime.Now.ToShortDateString();
        }
    }
}
