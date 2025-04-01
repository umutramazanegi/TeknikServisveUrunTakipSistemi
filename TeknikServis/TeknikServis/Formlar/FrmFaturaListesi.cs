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
            // --- Giriş Doğrulamaları ---
            if (string.IsNullOrWhiteSpace(txtseri.Text))
            {
                MessageBox.Show("Lütfen Fatura Seri numarasını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtseri.Focus();
                return; // İşlemi durdur
            }
            if (string.IsNullOrWhiteSpace(txtsirano.Text))
            {
                MessageBox.Show("Lütfen Fatura Sıra numarasını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsirano.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txttarih.Text))
            {
                MessageBox.Show("Lütfen Tarih giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttarih.Focus();
                return;
            }
            // Tarih formatını kontrol et (DateTimePicker kullanmak daha iyi)
            if (!DateTime.TryParse(txttarih.Text, out DateTime faturaTarihi))
            {
                MessageBox.Show("Lütfen geçerli bir Tarih formatı giriniz (örn: gg.aa.yyyy).", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttarih.Focus();
                return;
            }
            // Saat formatını kontrol et (Eğer veritabanı TimeSpan ise)
            // TimeSpan saat;
            // if (!TimeSpan.TryParse(txtsaat.Text, out saat))
            // {
            //     MessageBox.Show("Lütfen geçerli bir Saat formatı giriniz (örn: ss:dd).", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //     txtsaat.Focus();
            //     return;
            // }

            if (lkucari.EditValue == null)
            {
                MessageBox.Show("Lütfen bir Cari seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lkucari.Focus();
                return;
            }
            if (lkupersonel.EditValue == null)
            {
                MessageBox.Show("Lütfen bir Personel seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lkupersonel.Focus();
                return;
            }

            // LookUpEdit değerlerini güvenli şekilde al
            if (!int.TryParse(lkucari.EditValue.ToString(), out int cariId))
            {
                MessageBox.Show("Cari ID alınırken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!short.TryParse(lkupersonel.EditValue.ToString(), out short personelId))
            {
                MessageBox.Show("Personel ID alınırken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- Veritabanı İşlemleri ---
            try
            {
                TBL_FATURABILGI t = new TBL_FATURABILGI();
                t.SERI = txtseri.Text;
                t.SIRANO = txtsirano.Text;
                t.TARIH = faturaTarihi; // TryParse ile alınan geçerli tarih
                t.SAAT = txtsaat.Text; // Veritabanı türüne göre gerekirse Parse/TryParse kullanın
                                       // t.SAAT = saat; // Eğer TimeSpan kullanıyorsanız
                t.VERGIDAIRE = txtvergid.Text;
                t.CARI = cariId;       // TryParse ile alınan geçerli ID
                t.PERSONEL = personelId; // TryParse ile alınan geçerli ID

                db.TBL_FATURABILGI.Add(t);
                db.SaveChanges(); // Hata burada oluşabilir

                MessageBox.Show("Fatura başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                temizle();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException dbEx) // Entity Framework için daha spesifik hata yakalama
            {
                // InnerException genellikle veritabanından gelen asıl hatayı içerir
                string errorMessage = "Veritabanına kaydederken bir hata oluştu.\n";
                errorMessage += "Detay: " + (dbEx.InnerException?.InnerException?.Message ?? dbEx.InnerException?.Message ?? dbEx.Message);
                MessageBox.Show(errorMessage, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // Diğer beklenmedik hatalar için
            {
                MessageBox.Show("Beklenmedik bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Frm_FaturaKalemPopUp fr = new Frm_FaturaKalemPopUp();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            fr.Show();
        }

        private void txtseri_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {

        }
    }
}
