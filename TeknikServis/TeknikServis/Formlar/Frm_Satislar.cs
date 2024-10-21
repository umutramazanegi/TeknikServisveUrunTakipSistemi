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
    public partial class Frm_Satislar : Form
    {
        public Frm_Satislar()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void Frm_Satislar_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.TBL_URUNHAREKET
                           select new
                           {
                               x.HAREKETID,
                               x.TBL_URUN.AD,
                               Musteri = x.TBL_CARİ.AD + " " + x.TBL_CARİ.SOYAD,
                               Personel = x.TBL_PERSONEL.AD + " " + x.TBL_PERSONEL.SOYAD,
                               x.TARIH,
                               x.ADET,
                               x.FIYAT,
                               x.URUNSERINO
                           };
            gridControl1.DataSource = degerler.ToList();
        }
    }
}
