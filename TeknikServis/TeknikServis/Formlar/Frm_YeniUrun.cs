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
    public partial class FrmYeniUrun : Form
    {
        public FrmYeniUrun()
        {
            InitializeComponent();
        }

       
        DbTeknikServisEntities db = new DbTeknikServisEntities();
       
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            TBL_URUN t = new TBL_URUN();
            t.AD = txturunad.Text;
            t.ALISFIYAT = decimal.Parse(txtalisfiyat.Text);
            t.SATISFIYAT = decimal.Parse(txtsatisfiyat.Text);
            t.STOK = short.Parse(txtstok.Text);
            t.MARKA = txtmarka.Text;
            t.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.TBL_URUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnvazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txturunad_MouseClick(object sender, MouseEventArgs e)
        {
            txturunad.Text = "";
            txturunad.Focus();
        }

        private void txtmarka_MouseClick(object sender, MouseEventArgs e)
        {
            txtmarka.Text = "";
            txtmarka.Focus();
        }

        private void txtalisfiyat_MouseClick(object sender, MouseEventArgs e)
        {
            txtalisfiyat.Text = "";
            txtalisfiyat.Focus();
        }

        private void txtsatisfiyat_MouseClick(object sender, MouseEventArgs e)
        {
            txtsatisfiyat.Text = "";
            txtsatisfiyat.Focus();
        }

        private void txtstok_MouseClick(object sender, MouseEventArgs e)
        {
            txtstok.Text = "";
            txtstok.Focus();
        }

        private void FrmYeniUrun_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.NullText = "Bir Değer Seçiniz...";
            lookUpEdit1.Properties.DataSource = (from x in db.TBL_KATEGORI
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD
                                                 }).ToList();
        }
    }
}
