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
    public partial class Frm_Kategori : Form
    {
        public Frm_Kategori()
        {
            InitializeComponent();
        }
        void listele()
        {
            var degerler = from k in db.TBL_KATEGORI
                           select new
                           {
                               k.ID,
                               k.AD
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        void temizle()
        {
            txtkategoriad.Text = "";
            txtkategoriid.Text = "";
        }
        Random rast = new Random();
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmKategori_Load(object sender, EventArgs e)
        {
            //ımageSlider1.CurrentImageIndex = rast.Next(0, 24);
           // ımageSlider2.CurrentImageIndex = rast.Next(0, 24);
            //mageSlider3.CurrentImageIndex = rast.Next(0, 24);

            listele();
            temizle();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (txtkategoriad.Text != "" && txtkategoriad.Text.Length <= 30)
            {
                TBL_KATEGORI k = new TBL_KATEGORI();
                k.AD = txtkategoriad.Text;
                db.TBL_KATEGORI.Add(k);
                db.SaveChanges();
                MessageBox.Show("Kategori Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            else
            {
                MessageBox.Show("Kategori ad boş geçilemez ve 30 karakterden fazla olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult secim = new DialogResult();
            secim = MessageBox.Show("Kategori Silinsin Mi?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                int id = int.Parse(txtkategoriid.Text);
                var deger = db.TBL_KATEGORI.Find(id);
                db.TBL_KATEGORI.Remove(deger);
                db.SaveChanges();
                MessageBox.Show("Kategori Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listele();
            }
            else
            {
                listele();
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtkategoriid.Text);
            var deger = db.TBL_KATEGORI.Find(id);
            deger.AD = txtkategoriad.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtkategoriid.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtkategoriad.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
        }
    }
}
