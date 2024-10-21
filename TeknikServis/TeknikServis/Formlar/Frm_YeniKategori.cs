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
    public partial class Frm_YeniKategori : Form
    {
        public Frm_YeniKategori()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (txtkategoriad.Text != "" && txtkategoriad.Text.Length <= 30)
            {
                TBL_KATEGORI k = new TBL_KATEGORI();
                k.AD = txtkategoriad.Text;
                db.TBL_KATEGORI.Add(k);
                db.SaveChanges();
                MessageBox.Show("Kategori Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kategori ad boş geçilemez ve 30 karakterden fazla olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnvazgec_Click(object sender, EventArgs e)
        {
            DialogResult vazgec = MessageBox.Show("Ürün ekleme işleminden vazgeçmek istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (vazgec == System.Windows.Forms.DialogResult.Yes)

            {

                this.Close();

            }
        }

        private void Frm_YeniKategori_Load(object sender, EventArgs e)
        {

        }
    }
}
