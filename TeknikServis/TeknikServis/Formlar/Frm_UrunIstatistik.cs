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
    public partial class Frm_UrunIstatistik : Form
    {
        public Frm_UrunIstatistik()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmUrunIstatistik_Load(object sender, EventArgs e)
        {
            labelControl2.Text = db.TBL_URUN.Count().ToString();
            labelControl3.Text = db.TBL_KATEGORI.Count().ToString();
            labelControl5.Text = db.TBL_URUN.Sum(x => x.STOK).ToString();
            labelControl19.Text = (from x in db.TBL_URUN
                                   orderby x.STOK descending
                                   select x.AD).FirstOrDefault();
            labelControl17.Text = (from x in db.TBL_URUN
                                   orderby x.STOK ascending
                                   select x.AD).FirstOrDefault();
            labelControl7.Text = "10";
            labelControl13.Text = (from x in db.TBL_URUN
                                   orderby x.SATISFIYAT descending
                                   select x.AD).FirstOrDefault();
            labelControl11.Text = (from x in db.TBL_URUN
                                   orderby x.SATISFIYAT ascending
                                   select x.AD).FirstOrDefault();
            labelControl35.Text = db.TBL_URUN.Count(x => x.KATEGORI == 4).ToString();
            labelControl33.Text = db.TBL_URUN.Count(x => x.KATEGORI == 1).ToString();
            labelControl31.Text = db.TBL_URUN.Count(x => x.KATEGORI == 3).ToString();
            labelControl29.Text = (from x in db.TBL_URUN
                                   select
             x.MARKA).Distinct().Count().ToString();
           // labelControl5.Text = "Arçelik";
            labelControl25.Text = db.TBL_URUNKABUL.Count().ToString();
            labelControl15.Text = db.makskategoriurunu().FirstOrDefault();
        }
    }
}
