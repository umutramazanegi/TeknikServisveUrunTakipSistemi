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
    public partial class Frm_Markalar : Form
    {
        public Frm_Markalar()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        SqlConnection baglanti = new SqlConnection(@"Data Source=UMUT\SQLEXPRESS;Initial Catalog=DbTeknikServis;Integrated Security=True");
        
        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            var degerler = db.TBL_URUN.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA).Select(z => new
            {
                Marka = z.Key,
                Toplam = z.Count()
        });
            gridControl1.DataSource = degerler.ToList();
            labelControl2.Text = db.TBL_URUN.Count().ToString();
            labelControl3.Text = (from x in db.TBL_URUN
                                  select
            x.MARKA).Distinct().Count().ToString();
            labelControl7.Text = (from x in db.TBL_URUN
                                  orderby x.SATISFIYAT descending
                                  select x.MARKA).FirstOrDefault();
            labelControl5.Text = db.maksurunmarka().FirstOrDefault();

            //chart1
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select MARKA,count(*) from TBL_URUN group by MARKA", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(dr[0].ToString(), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();
            //chart2
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select TBL_KATEGORI.AD,count(*) as 'Sayı' from TBL_URUN inner join TBL_KATEGORI on TBL_KATEGORI.ID=TBL_URUN.KATEGORI group by TBL_KATEGORI.AD ", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Kategoriler"].Points.AddPoint(dr2[0].ToString(), int.Parse(dr2[1].ToString()));
            }
            baglanti.Close();
        }
    }
}
