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
    public partial class Frm_FaturaKalemPopUp : Form
    {
        public Frm_FaturaKalemPopUp()
        {
            InitializeComponent();
        }

        public int id;
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void Frm_FaturaKalemPopUp_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBL_FATURADETAY
                                       select new
                                       {
                                           x.FATURADETAYID,
                                           x.URUN,
                                           x.ADET,
                                           x.FIYAT,
                                           x.TUTAR,
                                           x.FATURAID
                                       }).Where(x => x.FATURAID == id).ToList();
            gridControl2.DataSource = (from x in db.TBL_FATURABILGI
                                       select new
                                       {
                                           x.ID,
                                           x.SERI,
                                           x.SIRANO,
                                           x.TARIH,
                                           x.SAAT,
                                           x.VERGIDAIRE,
                                           x.CARI,
                                           x.PERSONEL
                                       }).Where(x => x.ID == id).ToList();
        }


        private void pictureEdit6_Click(object sender, EventArgs e)
        {
            string path = "Dosya1.pdf";
            gridControl1.ExportToPdf(path);
        }

        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            string path = "Dosya1.xls";
            gridControl1.ExportToXls(path);
        }
    }
}
