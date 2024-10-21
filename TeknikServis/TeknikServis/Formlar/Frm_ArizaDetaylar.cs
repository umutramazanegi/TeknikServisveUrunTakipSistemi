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
    public partial class Frm_ArizaDetaylar : Form
    {
        public Frm_ArizaDetaylar()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        public string id, serino;

        private void btnvazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textEdit1_Click(object sender, EventArgs e)
        {
            txtserino.Text = "";
            txtserino.Focus();
        }

        private void textEdit2_Click(object sender, EventArgs e)
        {
            txttarih.Text = DateTime.Now.ToShortDateString();
        }

        private void Frm_ArizaDetaylar_Load(object sender, EventArgs e)
        {
            txtserino.Text = serino;
        }


        private void btnguncelle_Click(object sender, EventArgs e)
        {
            TBL_URUNTAKIP t = new TBL_URUNTAKIP();
            t.ACIKLAMA = richTextBox1.Text;
            t.SERINO = txtserino.Text;
            t.TARIH = DateTime.Parse(txttarih.Text);
            db.TBL_URUNTAKIP.Add(t);

            //2.güncelleme
            TBL_URUNKABUL tb = new TBL_URUNKABUL();
            int urunid = int.Parse(id.ToString());
            var deger = db.TBL_URUNKABUL.Find(urunid);
          //  deger.UrunDurumDetay = comboBox1.Text;
            db.SaveChanges();
            MessageBox.Show("Ürün Arıza Detayları Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
