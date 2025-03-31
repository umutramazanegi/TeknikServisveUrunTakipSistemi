using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace TeknikServis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Formlar.Frm_UrunListesi fr1;
        private void BtnUrunListesiFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr1 == null || fr1.IsDisposed)
            {
                fr1 = new Formlar.Frm_UrunListesi();
                fr1.MdiParent = this;
                fr1.Show();
            }
        }
        Formlar.FrmYeniUrun frr2;
        private void BtnYeniUrun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frr2 == null || frr2.IsDisposed)
            {
                frr2 = new Formlar.FrmYeniUrun();
                frr2.Show();
            }
        }
        Formlar.Frm_Kategori fr2;
        private void BtnKategoriListe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new Formlar.Frm_Kategori();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }
        Formlar.Frm_YeniKategori frr;

        private void btnkategori_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frr == null || frr.IsDisposed)
            {
                frr = new Formlar.Frm_YeniKategori();
                frr.Show();
            }
        }
        Formlar.Frm_UrunIstatistik fr3;
        private void Btnistatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3 == null || fr3.IsDisposed)
            {
                fr3 = new Formlar.Frm_UrunIstatistik();
                fr3.MdiParent = this;
                fr3.Show();
            }
        }
        Formlar.Frm_Markalar fr4;
        private void BtnMarkalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null || fr4.IsDisposed)
            {
                fr4 = new Formlar.Frm_Markalar();
                fr4.MdiParent = this;
                fr4.Show();
            }
        }
        Formlar.Frm_CariListesi fr5;

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null || fr5.IsDisposed)
            {
                fr5 = new Formlar.Frm_CariListesi();
                fr5.MdiParent = this;
                fr5.Show();
            }
        }
        Formlar.Frm_CariIller fr6;
        private void BtnCariiler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new Formlar.Frm_CariIller();
                fr6.MdiParent = this;
                fr6.Show();
            }
        }
        Formlar.Frm_CariEkle frr3;
        private void Frm_CariEkle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frr3 == null || frr3.IsDisposed)
            {
                frr3 = new Formlar.Frm_CariEkle();
                frr3.Show();
            }
        }
        Formlar.Frm_Departman fr7;
        private void btndepartmanlistesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7 == null || fr7.IsDisposed)
            {
                fr7 = new Formlar.Frm_Departman();
                fr7.MdiParent = this;
                fr7.Show();
            }
        }
        Formlar.Frm_YeniDepartman frr4;
        private void btnyenidepartman_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frr4 == null || frr4.IsDisposed)
            {
                frr4 = new Formlar.Frm_YeniDepartman();
                frr4.Show();
            }
        }
        Formlar.Frm_Personel fr8;
        private void btnpersonellistesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8 == null || fr8.IsDisposed)
            {
                fr8 = new Formlar.Frm_Personel();
                fr8.MdiParent = this;
                fr8.Show();
            }
        }

        private void btnhesapmakinesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }
        Formlar.Frm_Kurlar fr9;
        private void btndovizkurlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9 == null || fr9.IsDisposed)
            {
                fr9 = new Formlar.Frm_Kurlar();
                fr9.MdiParent = this;
                fr9.Show();
            }
        }

        private void btnword_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        private void btnexcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("excel");
        }
        Formlar.Frm_Notlar fr11;
        private void BtnNotListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr11 == null || fr11.IsDisposed)
            {
                fr11 = new Formlar.Frm_Notlar();
                fr11.MdiParent = this;
                fr11.Show();
            }
        }
        Formlar.Frm_ArizaListesi fr12;
        private void btnarizaliurunlistesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr12 == null || fr12.IsDisposed)
            {
                fr12 = new Formlar.Frm_ArizaListesi();
                fr12.MdiParent = this;
                fr12.Show();
            }
        }
        Formlar.Frm_UrunSatis frr5;
        private void btnurunsatisi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frr5 == null || frr5.IsDisposed)
            {
                frr5 = new Formlar.Frm_UrunSatis();
                frr5.Show();
            }
        }
        Formlar.Frm_Satislar fr13;
        private void btnsatislistesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr13 == null || fr13.IsDisposed)
            {
                fr13 = new Formlar.Frm_Satislar();
                fr13.MdiParent = this;
                fr13.Show();
            }
        }
        Formlar.Frm_ArizaliUrunKaydi frr8;
        private void btnyeniarizaliurun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frr8 == null || frr8.IsDisposed)
            {
                frr8 = new Formlar.Frm_ArizaliUrunKaydi();
                frr8.Show();
            }
        }
        Formlar.Frm_ArizaDetaylar frr6;
        private void btnurunaciklama_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frr6 == null || frr6.IsDisposed)
            {
                frr6 = new Formlar.Frm_ArizaDetaylar();
                frr6.Show();
            }
        }
        Formlar.Frm_ArizaliUrunDetayListesi fr14;
        private void btnarizaliurundetaylari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr14 == null || fr14.IsDisposed)
            {
                fr14 = new Formlar.Frm_ArizaliUrunDetayListesi();
                fr14.MdiParent = this;
                fr14.Show();
            }
        }
        Formlar.FrmQrKod fr15;
        private void BtnQRCode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr15 == null || fr15.IsDisposed)
            {
                fr15 = new Formlar.FrmQrKod();
                fr15.Show();
            }
        }
        Formlar.FrmFaturaListesi fr16;
        private void FrmFaturaListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr16 == null || fr16.IsDisposed)
            {
                fr16 = new Formlar.FrmFaturaListesi();
                fr16.MdiParent = this;
                fr16.Show();
            }
        }
        Formlar.FrmFaturaKalem fr17;
        private void FrmFaturaKalem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr17 == null || fr17.IsDisposed)
            {
                fr17 = new Formlar.FrmFaturaKalem();
                fr17.MdiParent = this;
                fr17.Show();
            }
        }
        Formlar.FrmFaturaKalemDetayları fr18;
        private void FrmFaturaKalemDetayları_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr18 == null || fr18.IsDisposed)
            {
                fr18 = new Formlar.FrmFaturaKalemDetayları();
                fr18.MdiParent = this;
                fr18.Show();
            }
        }

        Formlar.FrmGauge fr19;
        private void BtnHakkimizda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr19 == null || fr19.IsDisposed)
            {
                fr19 = new Formlar.FrmGauge();
                fr19.MdiParent = this;
                fr19.Show();
            }
        }

        private void BtnRaporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmRapor frm = new Formlar.FrmRapor();
            frm.Show();
        }
        Formlar.FrmAnaSayfa fra;
        private void Form1_Load(object sender, EventArgs e)
        {

            if (fra == null || fra.IsDisposed)
            {
                fra = new Formlar.FrmAnaSayfa();
                fra.MdiParent = this;
                fra.Show();
            }
        }

        private void btnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fra == null || fra.IsDisposed)
            {
                fra = new Formlar.FrmAnaSayfa();
                fra.MdiParent = this;
                fra.Show();
            }
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    } 
}
