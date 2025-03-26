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
    public partial class FrmFaturaKalem : Form
    {
        public FrmFaturaKalem()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        void listele()
        {
            var degerler = (from x in db.TBL_FATURADETAY
                            select new
                            {
                                x.FATURADETAYID,
                                x.URUN,
                                x.ADET,
                                x.FIYAT,
                                x.TUTAR,
                                x.FATURAID
                            });
            gridControl1.DataSource = degerler.ToList();
        }
        void temizle()
        {
            txtadet.Text = "";
            txtdetayid.Text = "";
            txtfaturaid.Text = "";
            txtfiyat.Text = "";
            txttutar.Text = "";
            txturun.Text = "";
        }
        private void FrmFaturaKalem_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            TBL_FATURADETAY t = new TBL_FATURADETAY();
            t.ADET = short.Parse(txtadet.Text);
            t.FIYAT = decimal.Parse(txtfiyat.Text);
            t.TUTAR = decimal.Parse(txttutar.Text);
            t.URUN = txturun.Text;
            t.FATURAID = int.Parse(txtfaturaid.Text);
            db.TBL_FATURADETAY.Add(t);
            db.SaveChanges();
            MessageBox.Show("Fatura Kalem İşlemi Gerçekleştirildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }
    }
}
