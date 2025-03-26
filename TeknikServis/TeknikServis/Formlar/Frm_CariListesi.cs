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
    public partial class Frm_CariListesi : Form
    {
        public Frm_CariListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void listele()
        {
            var deglerler = from c in db.TBL_CARİ
                            select new
                            {
                                c.ID,
                                c.AD,
                                c.SOYAD,
                                c.TELEFON,
                                c.MAIL,
                                c.IL,
                                c.ILCE
                            };
            gridControl1.DataSource = deglerler.ToList();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=UMUT\SQLEXPRESS;Initial Catalog=DbTeknikServis;Integrated Security=True");
        private void Frm_CariListesi_Load(object sender, EventArgs e)
        {
           // listele();
           // labelControl8.Text = db.TBL_CARİ.Count().ToString();
           // lueil.Properties.NullText = "Bir Değer Seçiniz...";
           // lueilce.Properties.NullText = "Bir Değer Seçiniz...";
           //// lueil.Properties.DataSource = (from x in db.TBL_ILLER
           //                                select new
           //                                {
           //                                    x.ID,
           //                                    x.SEHIR
           //                                }).ToList();
            labelControl9.Text = db.TBL_CARİ.Select(x => x.IL).Distinct().Count().ToString();
            labelControl12.Text = db.TBL_CARİ.Select(x => x.ILCE).Distinct().Count().ToString();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select top 1 IL from TBL_CARİ group by IL order by count(*) desc", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                labelControl10.Text = dr[0].ToString();
            }
            baglanti.Close();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            TBL_CARİ t = new TBL_CARİ();
            t.AD = txtcariad.Text;
            t.SOYAD = txtsoyad.Text;
            t.ADRES = txtadres.Text;
            t.MAIL = txtmail.Text;
            t.STATU = txtstatu.Text;
            t.TELEFON = txttelefon.Text;
            t.VERGIDAIRESI = txtvergid.Text;
            t.VERGINO = txtvergino.Text;
            t.IL = lueil.Text;
            t.ILCE = lueilce.Text;
            db.TBL_CARİ.Add(t);
            db.SaveChanges();
            MessageBox.Show("Yeni Cari Sisteme Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult secim = new DialogResult();
            secim = MessageBox.Show("Cari Silinsin Mi?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                int id = int.Parse(txtcariid.Text);
                var deger = db.TBL_CARİ.Find(id);
                db.TBL_CARİ.Remove(deger);
                db.SaveChanges();
                MessageBox.Show("Cari Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listele();
            }
            else
            {
                listele();
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtcariid.Text);
            var deger = db.TBL_CARİ.Find(id);
            deger.AD = txtcariad.Text;
            deger.SOYAD = txtsoyad.Text;
            deger.ADRES = txtadres.Text;
            deger.BANKA = txtbanka.Text;
            deger.IL = lueil.Text;
            deger.ILCE = lueilce.Text;
            deger.MAIL = txtmail.Text;
            deger.STATU = txtstatu.Text;
            deger.TELEFON = txttelefon.Text;
            deger.VERGIDAIRESI = txtvergid.Text;
            deger.VERGINO = txtvergino.Text;
            db.SaveChanges();
            MessageBox.Show("Cari Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            txtcariad.Text = "";
            txtsoyad.Text = "";
            txtadres.Text = "";
            txtmail.Text = "";
            txtstatu.Text = "";
            txttelefon.Text = "";
            txtvergid.Text = "";
            txtvergino.Text = "";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtcariid.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtcariad.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            txtsoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
        }
        //int secilen;

    }
}
