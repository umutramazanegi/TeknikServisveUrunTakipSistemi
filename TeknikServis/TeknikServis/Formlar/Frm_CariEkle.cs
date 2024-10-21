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
    public partial class Frm_CariEkle : Form
    {
        public Frm_CariEkle()
        {
            InitializeComponent();
            pictureEdit12.Click += pictureEdit12_Click;
        }

        private void btnvazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                TBL_CARİ t = new TBL_CARİ();
                t.AD = txtad.Text;
                t.SOYAD = txtsoyad.Text;
                t.BANKA = txtbanka.Text;
                t.IL = lookUpEdit2.Text;
                t.ILCE = lookUpEdit1.Text;
                t.MAIL = txtmail.Text;
                t.STATU = txtstatu.Text;
                t.TELEFON = txttel.Text;
                t.VERGIDAIRESI = txtvergidaire.Text;
                t.VERGINO = txtvergino.Text;
                t.ADRES = txtadres.Text;
                db.TBL_CARİ.Add(t);
                db.SaveChanges();
                MessageBox.Show("Yeni Cari Sisteme Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Hata");
            }
        }

        private void Frm_CariEkle_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.NullText = "Bir Değer Seçiniz...";
            lookUpEdit2.Properties.NullText = "Bir Değer Seçiniz...";
            //lookUpEdit2.Properties.DataSource = (from x in dbo.iller
            //                                     select new
            //                                     {
            //                                         x.id,
            //                                         x.sehir
            //                                     }).ToList();
            
        }

        //private void pictureEdit12_EditValueChanged(object sender, EventArgs e)
        //{
        //    //Form openForm = Application.OpenForms["Frm_CariEkle"];
        ////    if (openForm != null)
        ////    {
        ////        openForm.Close();
        ////    }
        //}

        private void pictureEdit12_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
