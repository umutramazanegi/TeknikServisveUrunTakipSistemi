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
    public partial class FrmFaturaKalemDetayları : Form
    {
        public FrmFaturaKalemDetayları()
        {
            InitializeComponent();
        }
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
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmFaturaKalemDetayları_Load(object sender, EventArgs e)
        {

        }

        private void btnara_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtfaturaid.Text) && string.IsNullOrEmpty(txtserino.Text) && string.IsNullOrEmpty(txtsirano.Text))
            {
                MessageBox.Show("Lütfen en az bir arama kriteri girin.");
                return;
            }

            if (!string.IsNullOrEmpty(txtfaturaid.Text))
            {
                try
                {
                    int id = Convert.ToInt32(txtfaturaid.Text);
                    var degerler = (from x in db.TBL_FATURADETAY
                                    where x.FATURAID == id
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
                catch (FormatException)
                {
                    MessageBox.Show("Geçersiz Fatura ID formatı. Lütfen bir sayı girin.");
                    return;
                }
            }
            else if (!string.IsNullOrEmpty(txtserino.Text) && !string.IsNullOrEmpty(txtsirano.Text))
            {
                string seriNo = txtserino.Text.Trim();
                string siraNo = txtsirano.Text.Trim();

                var query = db.TBL_FATURADETAY.Where(x => x.TBL_FATURABILGI.SERI == seriNo && x.TBL_FATURABILGI.SIRANO == siraNo);


                gridControl1.DataSource = query.Select(x => new
                {
                    x.FATURADETAYID,
                    x.URUN,
                    x.ADET,
                    x.FIYAT,
                    x.TUTAR,
                    x.FATURAID
                }).ToList();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli arama kriterleri girin. Fatura ID veya hem Seri No hem de Sıra No gereklidir.");
            }
        }
    
    }
}
