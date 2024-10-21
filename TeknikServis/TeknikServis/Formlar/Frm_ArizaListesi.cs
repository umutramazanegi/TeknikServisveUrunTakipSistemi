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
                              //x.URUNDURUMDETAY
                          };
            gridControl1.DataSource = degeler.ToList();
        }
        private void Frm_ArizaListesi_Load(object sender, EventArgs e)
        {
            listele();
            //labelControl3.Text = db.TBL_URUNKABUL.Count(x => x.UrunDurum == true).ToString();
            //labelControl5.Text = db.TBL_URUNKABUL.Count(x => x.UrunDurum == false).ToString();
            //labelControl13.Text = db.TBL_URUN.Count().ToString();
            //labelControl7.Text = db.TBL_URUNKABUL.Count(x => x.UrunDurumDetay == "Parça Bekliyor.").ToString();
            //labelControl15.Text = db.TBL_URUNKABUL.Count(x => x.UrunDurumDetay == "Mesaj Bekliyor.").ToString();
            //labelControl11.Text = db.TBL_URUNKABUL.Count(x => x.UrunDurumDetay == "İptal Bekliyor.").ToString();

            //baglanti.Open();
            //SqlCommand komut = new SqlCommand("select UrunDurumDetay,count(*) from Tbl_UrunKabul group by UrunDurumDetay", baglanti);
            //SqlDataReader dr = komut.ExecuteReader();
            //while (dr.Read())
            //{
            //    chartControl1.Series["Series 1"].Points.AddPoint(dr[0].ToString(), int.Parse(dr[1].ToString()));
            //}
            //baglanti.Close();
        }
    }
}
