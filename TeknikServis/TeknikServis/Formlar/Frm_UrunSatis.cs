using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// using System.Data.SqlClient; // EF kullanılıyorsa gereksiz

namespace TeknikServis.Formlar
{
    public partial class Frm_UrunSatis : Form
    {
        public Frm_UrunSatis()
        {
            InitializeComponent();
        }

        // DbContext'i sınıf seviyesinde tanımlamak yerine using ile kullanacağız.
        // DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void Frm_UrunSatis_Load(object sender, EventArgs e)
        {
            // Kontrol isimlerinin doğru olduğunu varsayıyorum:
            // lueuruid, luepersonel, luecari, txttarih (DateEdit varsayalım)

            luecari.Properties.NullText = "Cari Seçiniz...";
            luepersonel.Properties.NullText = "Personel Seçiniz...";
            lueuruid.Properties.NullText = "Ürün Seçiniz...";

            // Öneri: txttarih yerine bir DateEdit kontrolü kullanın ve varsayılan değeri atayın.
            // Eğer TextEdit ise:
            // txttarih.Text = DateTime.Now.ToShortDateString();
            // Eğer DateEdit ise (örneğin adi dateEditTarih olsun):
            if (dateEditTarih != null) // Eğer DateEdit kullandıysanız
            {
                dateEditTarih.EditValue = DateTime.Now;
            }
            else if (dateEditTarih != null) // Eğer hala TextEdit ise
            {
                dateEditTarih.Text = DateTime.Now.ToShortDateString();
            }


            try
            {
                // Veritabanı işlemlerini using bloğu içinde yapın
                using (DbTeknikServisEntities db = new DbTeknikServisEntities())
                {
                    lueuruid.Properties.DataSource = (from x in db.TBL_URUN
                                                      select new
                                                      {
                                                          x.ID,
                                                          x.AD
                                                      }).ToList();

                    luepersonel.Properties.DataSource = (from y in db.TBL_PERSONEL
                                                         select new
                                                         {
                                                             y.ID,
                                                             Ad = y.AD + " " + y.SOYAD
                                                         }).ToList();

                    luecari.Properties.DataSource = (from i in db.TBL_CARİ
                                                     select new
                                                     {
                                                         i.ID,
                                                         Ad = i.AD + " " + i.SOYAD
                                                     }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // İsteğe bağlı olarak formu kapatabilir veya kontrolleri devre dışı bırakabilirsiniz.
                // this.Close();
            }
        }

        private void btnvazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsatisyap_Click(object sender, EventArgs e)
        {
            try
            {
                // --- Girdi Kontrolleri ---
                if (lueuruid.EditValue == null)
                {
                    MessageBox.Show("Lütfen bir ürün seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lueuruid.Focus();
                    return;
                }
                if (luecari.EditValue == null)
                {
                    MessageBox.Show("Lütfen bir cari (müşteri) seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    luecari.Focus();
                    return;
                }
                if (luepersonel.EditValue == null)
                {
                    MessageBox.Show("Lütfen bir personel seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    luepersonel.Focus();
                    return;
                }

                // Adet Kontrolü
                if (!short.TryParse(txtadet.Text, out short adet) || adet <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir pozitif adet giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtadet.Focus();
                    return;
                }

                // Fiyat Kontrolü
                if (!decimal.TryParse(txtsatisfiyat.Text, out decimal fiyat) || fiyat < 0)
                {
                    MessageBox.Show("Lütfen geçerli bir satış fiyatı giriniz (0 veya pozitif)!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsatisfiyat.Focus();
                    return;
                }

                // Tarih Kontrolü (Eğer DateEdit kullanılıyorsa genellikle EditValue null olmaz ama kontrol iyi olabilir)
                DateTime tarih;
                if (dateEditTarih != null && dateEditTarih.EditValue != null) // DateEdit varsa
                {
                    tarih = (DateTime)dateEditTarih.EditValue;
                }
                else if (dateEditTarih != null && DateTime.TryParse(dateEditTarih.Text, out tarih)) // TextEdit varsa
                {
                    // tarih değişkeni zaten TryParse ile doldu
                }
                else // Geçerli tarih alınamadıysa
                {
                    MessageBox.Show("Lütfen geçerli bir tarih giriniz/seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (dateEditTarih != null) dateEditTarih.Focus(); else if (dateEditTarih != null) dateEditTarih.Focus();
                    return;
                }

                // Seri No Kontrolü (Eğer boş olamazsa)
                if (string.IsNullOrWhiteSpace(txtserino.Text))
                {
                    // Eğer seri no boş olabilirse bu kontrolü kaldırın veya isteğe bağlı yapın.
                    // MessageBox.Show("Lütfen ürün seri numarasını giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // txtserino.Focus();
                    // return;
                }

                // --- Veritabanı İşlemi ---
                using (DbTeknikServisEntities db = new DbTeknikServisEntities())
                {
                    TBL_URUNHAREKET u = new TBL_URUNHAREKET();

                    // ID'leri güvenli bir şekilde alalım (TryParse yapmaya gerek yok, EditValue'dan direkt alınabilir ama tür dönüşümü lazım)
                    u.URUN = (int)lueuruid.EditValue; // LookUpEdit'in ValueMember'ı int olmalı
                    u.MUSTERI = (int)luecari.EditValue; // LookUpEdit'in ValueMember'ı int olmalı

                    // Dikkat: PERSONEL ID'si gerçekten short mu? Genellikle int olur. Emin olun.
                    // Eğer int ise: u.PERSONEL = (int)luepersonel.EditValue;
                    u.PERSONEL = Convert.ToInt16(luepersonel.EditValue); // ValueMember short ise

                    // Diğer değerleri ata
                    u.ADET = adet; // TryParse ile alınan değer
                    u.FIYAT = fiyat; // TryParse ile alınan değer
                    u.TARIH = tarih; // TryParse veya DateEdit'ten alınan değer
                    u.URUNSERINO = txtserino.Text.Trim(); // Başındaki/sonundaki boşlukları temizle

                    db.TBL_URUNHAREKET.Add(u);
                    db.SaveChanges();
                } // using bloğu db nesnesini dispose eder.

                MessageBox.Show("Ürün Satışı Başarıyla Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Başarılı işlem sonrası formu kapat
            }
            catch (FormatException fEx) // Yakalanması zor ama TryParse sonrası olmamalı
            {
                MessageBox.Show("Veri formatı hatası: " + fEx.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidCastException cEx) // EditValue tür dönüşümü hatası
            {
                MessageBox.Show("Seçim kutusu (ID) tür dönüşümü hatası: " + cEx.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // Diğer tüm hatalar (Veritabanı vb.)
            {
                // Hatanın detayını loglamak iyi bir pratik olabilir.
                // LoglamaMekanızması.Logla(ex);
                MessageBox.Show("Satış kaydedilirken beklenmedik bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Öneri: txttarih yerine DateEdit kullanıyorsanız bu metoda gerek kalmaz.
        private void txttarih_Click(object sender, EventArgs e)
        {
            if (dateEditTarih != null) // Kontrol hala varsa
            {
                dateEditTarih.Text = DateTime.Now.ToShortDateString();
                dateEditTarih.SelectAll(); // Kullanıcının kolayca değiştirebilmesi için seçili hale getir
            }
        }

        // Bu Click olayları yerine Enter olayları daha mantıklı olabilir veya hiç kullanılmayabilir.
        private void txtadet_Click(object sender, EventArgs e)
        {
            // txtadet.Text = ""; // Kullanıcı yanlışlıkla tıklarsa veri kaybolur.
            // txtadet.Focus();
            txtadet.SelectAll(); // Tıklanınca mevcut değeri seçili hale getirir, silmek yerine.
        }

        private void txtsatisfiyat_Click(object sender, EventArgs e)
        {
            // txtsatisfiyat.Text = "";
            // txtsatisfiyat.Focus();
            txtsatisfiyat.SelectAll();
        }

        private void txtserino_Click(object sender, EventArgs e)
        {
            // txtserino.Text = "";
            // txtserino.Focus();
            txtserino.SelectAll();
        }
    }
}