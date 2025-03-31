using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.İletisim
{
    public partial class FrmGelenMesajlar : Form
    {
        public FrmGelenMesajlar()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmGelenMesajlar_Load(object sender, EventArgs e)
        {
            labelControl8.Text = db.TBL_ILETISIM.Count().ToString();
            labelControl10.Text = db.TBL_ILETISIM.Where(z => z.KONU == "Teşekkür").Count().ToString();
            labelControl9.Text = db.TBL_ILETISIM.Where(z => z.KONU == "Rica").Count().ToString();
            labelControl13.Text = db.TBL_ILETISIM.Where(z => z.KONU == "Şikayet").Count().ToString();
            labelControl1.Text = db.TBL_PERSONEL.Count().ToString();
            labelControl3.Text = db.TBL_CARİ.Count().ToString();
            labelControl5.Text = db.TBL_KATEGORI.Count().ToString();
            labelControl7.Text = db.TBL_URUN.Count().ToString();
            gridControl1.DataSource = (from x in db.TBL_ILETISIM
                                       select new
                                       {
                                           x.ID,
                                           x.ADSOYAD,
                                           x.KONU,
                                           x.MAIL,
                                           x.MESAJ
                                       }).ToList();
        }
    }
}
