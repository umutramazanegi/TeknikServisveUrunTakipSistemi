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
    public partial class Frm_Notlar : Form
    {
        public Frm_Notlar()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        void temizle()
        {
            txticerik.Text = "";
            txtnotid.Text = "";
            txtbaslik.Text = "";
        }
        void okunmayan()
        {
            gridControl1.DataSource = db.TBL_NOTLARIM.Where(x => x.DURUM == false).ToList();
        }
        void okunan()
        {
            gridControl2.DataSource = db.TBL_NOTLARIM.Where(y => y.DURUM == true).ToList();
        }
        private void Frm_Notlar_Load(object sender, EventArgs e)
        {
            okunan();
            okunmayan();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBL_NOTLARIM t = new TBL_NOTLARIM();
            t.BASLIK = txtbaslik.Text;
            t.ICERIK = txticerik.Text;
            t.DURUM = false;
            //t.TARIH = DateTime.Parse(txttarih.Text);
            db.TBL_NOTLARIM.Add(t);
            db.SaveChanges();
            MessageBox.Show("Not Başarıyla Keydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            okunan();
            okunmayan();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                int id = int.Parse(txtnotid.Text);
                var deger = db.TBL_NOTLARIM.Find(id);
                deger.DURUM = true;
                db.SaveChanges();
                MessageBox.Show("Not Durumu Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                okunan();
                okunmayan();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtnotid.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
        }
    }
}
