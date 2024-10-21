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
    public partial class Frm_CariIller : Form
    {
        public Frm_CariIller()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        SqlConnection baglanti = new SqlConnection(@"Data Source=UMUT\SQLEXPRESS;Initial Catalog=DbTeknikServis;Integrated Security=True");
        private void Frm_CariIller_Load(object sender, EventArgs e)
        {
            chartControl1.Series["Series 1"].Points.AddPoint("Ankara", 22);

            gridControl1.DataSource = db.TBL_CARİ.OrderBy(x => x.IL).GroupBy(y => y.IL).Select(z => new
            {
                Il = z.Key,
                Toplam = z.Count()
            }).ToList();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select IL,count(*) from TBL_CARİ group by IL", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();
        }
    }
}
