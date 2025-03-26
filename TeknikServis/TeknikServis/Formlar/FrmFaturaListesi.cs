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
    public partial class FrmFaturaListesi : Form
    {
        public FrmFaturaListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        void listele()
        {
            var degerler = from x in db.TBL_FATURABILGI
                           select new
                           {
                               x.ID,
                               x.SERI,
                               x.SIRANO,
                               x.TARIH,
                               x.SAAT,
                               x.VERGIDAIRE,
                               Cari = x.TBL_CARİ.AD + " " + x.TBL_CARİ.SOYAD,
                               Personel = x.TBL_PERSONEL.AD + " " + x.TBL_PERSONEL.SOYAD
                           };
            gridControl1.DataSource = degerler.ToList();
            lkupersonel.Properties.DataSource = (from x in db.TBL_PERSONEL
                                                 select new
                                                 {
                                                     x.ID,
                                                     Ad = x.AD + " " + x.SOYAD
                                                 }).ToList();

            lkucari.Properties.DataSource = (from z in db.TBL_CARİ
                                             select new
                                             {
                                                 z.ID,
                                                 Ad = z.AD + " " + z.SOYAD
                                             }).ToList();
        }
        void temizle()
        {
            txtid.Text = "";
            txtsaat.Text = "";
            txtseri.Text = "";
            txtsirano.Text = "";
            txttarih.Text = "";
            txtvergid.Text = "";
            lkucari.EditValue = null;
            lkupersonel.EditValue = null;
        }
        private void FrmFaturaListesi_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
            lkucari.Properties.NullText = "Bir Değer Seçiniz...";
            lkupersonel.Properties.NullText = "Bir Değer Seçiniz...";
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            TBL_FATURABILGI t = new TBL_FATURABILGI();
            t.SAAT = txtsaat.Text;
            t.TARIH = Convert.ToDateTime(txttarih.Text);
            t.VERGIDAIRE = txtvergid.Text;
            t.SIRANO = txtsirano.Text;
            t.SERI = txtseri.Text;
            t.CARI = int.Parse(lkucari.EditValue.ToString());
            t.PERSONEL = short.Parse(lkupersonel.EditValue.ToString());
            db.TBL_FATURABILGI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Fatura Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //FrmFaturaKalemPopUp fr = new FrmFaturaKalemPopUp();
            //fr.id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
            //fr.Show();
        }

        private void txtseri_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {

        }
    }
}
