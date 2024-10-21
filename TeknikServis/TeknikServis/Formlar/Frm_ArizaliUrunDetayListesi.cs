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
    public partial class Frm_ArizaliUrunDetayListesi : Form
    {
        public Frm_ArizaliUrunDetayListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void Frm_ArizaliUrunDetayListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBL_URUNTAKIP
                                       select new
                                       {
                                           x.TAKIPID,
                                           x.SERINO,
                                           x.TARIH,
                                           x.ACIKLAMA
                                       }).ToList();
        }
    }
}
