using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace TeknikServis.Formlar
{
    public partial class Frm_Departman : Form
    {
        public Frm_Departman()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        SqlConnection baglanti = new SqlConnection(@"Data Source=UMUT\SQLEXPRESS;Initial Catalog=DbTeknikServis;Integrated Security=True");

        void listele()
        {
            var degerler = from d in db.TBL_DEPARTMAN
                           select new
                           {
                               d.ID,
                               d.AD,

                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            listele();
            labelControl8.Text = db.TBL_DEPARTMAN.Count().ToString();
            labelControl10.Text = db.TBL_DEPARTMAN.Count().ToString();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select top 1 Departman from TBL_PERSONEL group by TBL_PERSONEL.Departman order by count(*) desc", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                labelControl12.Text = dr[0].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select top 1 Departman from TBL_PERSONEL group by TBL_PERSONEL.Departman order by count(*) asc", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                labelControl14.Text = dr2[0].ToString();
            }
            baglanti.Close();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (txtad.Text.Length <= 50 && txtad.Text != "")
            {
                TBL_DEPARTMAN d = new TBL_DEPARTMAN();
                d.AD = txtad.Text;

                db.TBL_DEPARTMAN.Add(d);
                db.SaveChanges();
                MessageBox.Show("Departman Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            else
            {
                MessageBox.Show("Kayıt Yapılamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult secim = new DialogResult();
            secim = MessageBox.Show("Cari Silinsin Mi?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                int id = int.Parse(txtid.Text);
                var deger = db.TBL_DEPARTMAN.Find(id);
                db.TBL_DEPARTMAN.Remove(deger);
                db.SaveChanges();
                MessageBox.Show("Departman Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listele();
            }
            else
            {
                listele();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtid.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtad.Text = gridView1.GetFocusedRowCellValue("AD").ToString();

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            var deger = db.TBL_DEPARTMAN.Find(id);
            deger.AD = txtad.Text;
            db.SaveChanges();
            MessageBox.Show("Departman Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {

            txtid.Text = "";
            txtad.Text = "";
        }
    }
}
