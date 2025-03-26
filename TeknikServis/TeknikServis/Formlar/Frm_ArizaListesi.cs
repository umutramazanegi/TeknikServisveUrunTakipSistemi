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
    public partial class Frm_ArizaListesi : Form
    {
        public Frm_ArizaListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        SqlConnection baglanti = new SqlConnection(@"Data Source = UMUT\SQLEXPRESS; Initial Catalog = DbTeknikServis; Integrated Security = True");

        void listele()
        {
            var degeler = from x in db.TBL_URUNKABUL
                          select new
                          {
                              x.ISLEMID,
                              Cari = x.TBL_CARİ.AD + " " + x.TBL_CARİ.SOYAD,
                              Personel = x.TBL_PERSONEL.AD + " " + x.TBL_PERSONEL.SOYAD,
                              x.GELISTARIH,
                              x.CIKISTARIH,
                              x.URUNSERINO,
                              x.URUNDURUMDETAY
                          };
            gridControl1.DataSource = degeler.ToList();
        }
        private void Frm_ArizaListesi_Load(object sender, EventArgs e)
        {
            listele();
            labelControl3.Text = db.TBL_URUNKABUL.Count(x => x.URUNDURUM == true).ToString();
            labelControl2.Text = db.TBL_URUNKABUL.Count(x => x.URUNDURUM == false).ToString();
            labelControl35.Text = db.TBL_URUN.Count().ToString();
            labelControl20.Text = db.TBL_URUNKABUL.Count(x => x.URUNDURUMDETAY == "Parça Bekliyor").ToString();
            labelControl22.Text = db.TBL_URUNKABUL.Count(x => x.URUNDURUMDETAY == "Mesaj Bekliyor").ToString();
            labelControl37.Text = db.TBL_URUNKABUL.Count(x => x.URUNDURUMDETAY == "İptal Bekliyor").ToString();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select URUNDURUMDETAY,count(*) from TBL_URUNKABUL group by URUNDURUMDETAY", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(dr[0].ToString(), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();
        }


       
        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            var islemid = gridView1.GetFocusedRowCellValue("ISLEMID");
            var urunserino = gridView1.GetFocusedRowCellValue("URUNSERINO");

            if (islemid != null && urunserino != null)
            {
                Frm_ArizaDetaylar fr = new Frm_ArizaDetaylar();
                fr.id = islemid.ToString();
                fr.serino = urunserino.ToString();
                fr.Show();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir satır seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
