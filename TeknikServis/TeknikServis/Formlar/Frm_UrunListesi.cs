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
    public partial class Frm_UrunListesi : Form
    {
        public Frm_UrunListesi()
        {
            InitializeComponent();
        }
        void listele()
        {
            var degerler = from u in db.TBL_URUN
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.MARKA,
                               Kategori = u.TBL_KATEGORI.AD,
                               u.STOK,
                               u.ALISFIYAT,
                               u.SATISFIYAT
                           };
            gridControl1.DataSource = degerler.ToList();
           lookUpEdit1.Properties.DataSource = (from x in db.TBL_KATEGORI
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD
                                                 }).ToList();
        }
        void temizle()
        {
            txtalisfiyat.Text = "";
            txtmarka.Text = "";
            txtsatisfiyat.Text = "";
            txtstok.Text = "";
            txturunad.Text = "";
            txturunid.Text = "";
            lookUpEdit1.EditValue = null;
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void Frm_UrunListesi_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.NullText = "Bir Değer Seçiniz...";
            listele();
            temizle();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            TBL_URUN t = new TBL_URUN();
            t.AD = txturunad.Text;
            t.MARKA = txtmarka.Text;
            t.ALISFIYAT = decimal.Parse(txtalisfiyat.Text);
            t.SATISFIYAT = decimal.Parse(txtsatisfiyat.Text);
            t.STOK = short.Parse(txtstok.Text);
            t.DURUM = false;
            t.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.TBL_URUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txturunid.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                txturunad.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
                txtmarka.Text = gridView1.GetFocusedRowCellValue("MARKA").ToString();
                txtalisfiyat.Text = gridView1.GetFocusedRowCellValue("ALISFIYAT").ToString();
                txtsatisfiyat.Text = gridView1.GetFocusedRowCellValue("SATISFIYAT").ToString();
                txtstok.Text = gridView1.GetFocusedRowCellValue("STOK").ToString();
                lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("Kategori").ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Hata");
            }

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult secim = new DialogResult();
            secim = MessageBox.Show("Ürün Silinsin Mi?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                int id = int.Parse(txturunid.Text);
                var deger = db.TBL_URUN.Find(id);
                db.TBL_URUN.Remove(deger);
                db.SaveChanges();
                MessageBox.Show("Ürün Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listele();
            }
            else
            {
                listele();
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txturunid.Text);
            var deger = db.TBL_URUN.Find(id);
            deger.AD = txturunad.Text;
            deger.STOK = short.Parse(txtstok.Text);
            deger.MARKA = txtmarka.Text;
            deger.ALISFIYAT = decimal.Parse(txtalisfiyat.Text);
            deger.SATISFIYAT = decimal.Parse(txtsatisfiyat.Text);
            deger.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Ürün Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
