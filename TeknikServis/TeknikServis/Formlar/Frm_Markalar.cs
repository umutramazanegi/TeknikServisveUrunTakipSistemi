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
           // labelControl5.Text = db.maksurunmarka().FirstOrDefault();


        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
