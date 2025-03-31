using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// DbUpdateException ve DbEntityValidationException için gerekli using ifadeleri:
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace TeknikServis.Formlar
{
    public partial class Frm_ArizaliUrunKaydi : Form
    {
        // DbContext nesnesini form seviyesinde tanımlama.
        // İşlem bazlı 'using' veya her metotta yeniden oluşturma da alternatiflerdir.
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        public Frm_ArizaliUrunKaydi()
        {
            InitializeComponent();
        }

        private void Frm_ArizaliUrunKaydi_Load(object sender, EventArgs e)
        {
            // Müşteri LookUpEdit Ayarları
            try
            {
                lookUpEdit1.Properties.ValueMember = "ID";       // Seçilen kaydın ID'sini temsil edecek alan
                lookUpEdit1.Properties.DisplayMember = "Ad";     // Kullanıcıya gösterilecek alan (Ad Soyad)
                lookUpEdit1.Properties.NullText = "Bir Müşteri Seçiniz..."; // Seçim yapılmadığında görünecek metin
                // Veri kaynağını ata (Ad+Soyad birleştirilmiş ve sıralanmış)
                lookUpEdit1.Properties.DataSource = (from x in db.TBL_CARİ
                                                     orderby x.AD, x.SOYAD // Ada ve Soyada göre sırala
                                                     select new
                                                     {
                                                         x.ID,
                                                         Ad = x.AD + " " + x.SOYAD
                                                     }).ToList();
            }
            catch (Exception ex)
            {
                // Veritabanı veya başka bir hata olursa kullanıcıyı bilgilendir
                MessageBox.Show("Müşteri listesi yüklenirken bir hata oluştu:\n" + ex.Message,
                                "Veri Yükleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Personel LookUpEdit Ayarları
            try
            {
                lookUpEdit2.Properties.ValueMember = "ID";       // Seçilen kaydın ID'sini temsil edecek alan
                lookUpEdit2.Properties.DisplayMember = "Ad";     // Kullanıcıya gösterilecek alan (Ad Soyad)
                lookUpEdit2.Properties.NullText = "Bir Personel Seçiniz..."; // Seçim yapılmadığında görünecek metin
                // Veri kaynağını ata (Ad+Soyad birleştirilmiş ve sıralanmış)
                lookUpEdit2.Properties.DataSource = (from x in db.TBL_PERSONEL
                                                     orderby x.AD, x.SOYAD // Ada ve Soyada göre sırala
                                                     select new
                                                     {
                                                         x.ID,
                                                         Ad = x.AD + " " + x.SOYAD
                                                     }).ToList();
            }
            catch (Exception ex)
            {
                // Veritabanı veya başka bir hata olursa kullanıcıyı bilgilendir
                MessageBox.Show("Personel listesi yüklenirken bir hata oluştu:\n" + ex.Message,
                                "Veri Yükleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Tarih alanını başlangıçta bugünün tarihiyle doldur
            txttarih_Click(null, null);
        }

        // Vazgeç Butonu
        private void btnvazgec_Click(object sender, EventArgs e)
        {
            // Formu direkt kapat
            this.Close();
        }

        // Kaydet Butonu
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            // 1. Girdi Kontrolleri (Validation)
            if (lookUpEdit1.EditValue == null || string.IsNullOrEmpty(lookUpEdit1.EditValue.ToString()))
            {
                MessageBox.Show("Lütfen bir müşteri seçimi yapınız.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEdit1.Focus(); // Kullanıcının dikkatini ilgili alana çek
                return; // Metodun geri kalanını çalıştırma
            }

            if (lookUpEdit2.EditValue == null || string.IsNullOrEmpty(lookUpEdit2.EditValue.ToString()))
            {
                MessageBox.Show("Lütfen bir personel seçimi yapınız.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEdit2.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtserino.Text))
            {
                MessageBox.Show("Lütfen ürünün seri numarasını giriniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtserino.Focus();
                return;
            }

            // Tarih kontrolü (TryParse ile daha güvenli)
            if (!DateTime.TryParse(txttarih.Text, out DateTime gelisTarihi))
            {
                MessageBox.Show("Lütfen geçerli bir geliş tarihi giriniz (örn: GG.AA.YYYY).", "Geçersiz Tarih Formatı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttarih.Focus();
                return;
            }

            // 2. Veritabanı Kayıt İşlemi (Try-Catch ile Hata Yönetimi)
            try
            {
                // Yeni bir URUNKABUL nesnesi oluştur
                TBL_URUNKABUL t = new TBL_URUNKABUL();

                // Seçilen değerleri nesneye ata (Kontrollerden geçtiği için Parse daha güvenli)
                t.CARI = int.Parse(lookUpEdit1.EditValue.ToString());
                t.PERSONEL = short.Parse(lookUpEdit2.EditValue.ToString()); // Eğer Personel ID short ise
                // Eğer Personel ID int ise: t.PERSONEL = int.Parse(lookUpEdit2.EditValue.ToString());

                t.GELISTARIH = gelisTarihi;
                t.URUNSERINO = txtserino.Text.Trim(); // Başındaki/sonundaki boşlukları temizle

                // --- Otomatik Atanacak Değerler ---
                // Ürünün ilk kayıt durumu (Örn: false = Tamirde/İşlemde)
                // Bu değeri kendi iş mantığınıza göre belirleyin (true='Bekliyor', false='İşlemde' vb.)
                t.URUNDURUM = false;
                // İlk kayıt detay açıklaması
                t.URUNDURUMDETAY = "Kayıt Alındı";

                // CIKISTARIH otomatik olarak NULL olacaktır (DB'de NULL ise ve atanmazsa).

                // Hazırlanan nesneyi veritabanı context'ine ekle (henüz DB'ye gitmedi)
                db.TBL_URUNKABUL.Add(t);

                // Değişiklikleri veritabanına kaydet
                db.SaveChanges();

                // Başarılı mesajı göster
                MessageBox.Show("Arızalı ürün kaydı başarıyla tamamlandı.",
                                "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // İsteğe Bağlı: Formu kapat veya alanları temizle
                this.DialogResult = DialogResult.OK; // Eğer başka formdan çağrıldıysa sonuç döndürür
                this.Close(); // Formu kapat

            }
            // Veritabanı güncelleme hatalarını yakala (Constraint ihlalleri vs.)
            catch (DbUpdateException dbEx)
            {
                var errorMessage = new StringBuilder();
                errorMessage.AppendLine("Veritabanına kayıt sırasında bir hata oluştu!");
                errorMessage.AppendLine("Girilen bilgilerin doğruluğunu (örn: aynı seri no) veya sistem ayarlarını kontrol edin.");
                errorMessage.AppendLine("Hata devam ederse sistem yöneticisine başvurun.");

                // Teknik Hata Detayını Ayıkla (Geliştirici veya Loglama İçin)
                Exception inner = dbEx.InnerException;
                while (inner != null)
                {
                    // InnerException mesajı genellikle SQL Server'dan gelen asıl hatayı içerir
                    errorMessage.AppendLine("--------------------------------"); // Ayraç
                    errorMessage.AppendLine("Teknik Detay: " + inner.Message);
                    inner = inner.InnerException;
                }

                MessageBox.Show(errorMessage.ToString(), "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Geliştirme/Debug için loglama yapılabilir:
                // System.IO.File.AppendAllText("hatalog.txt", DateTime.Now + Environment.NewLine + dbEx.ToString() + Environment.NewLine);
            }
            // Entity Framework veri doğrulama hatalarını yakala (örn: MaxLength aşıldı)
            catch (DbEntityValidationException validationEx)
            {
                var errorMessage = new StringBuilder();
                errorMessage.AppendLine("Veri doğrulama hatası oluştu. Lütfen girdiğiniz değerleri kontrol edin:");

                // Hangi alanda ne hata var detaylı listele
                foreach (var validationErrors in validationEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage.AppendLine($"- Alan: '{validationError.PropertyName}', Hata: '{validationError.ErrorMessage}'");
                    }
                }
                MessageBox.Show(errorMessage.ToString(), "Girdi Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Diğer beklenmedik programlama veya sistem hatalarını yakala
            catch (Exception ex)
            {
                MessageBox.Show("Kaydetme işlemi sırasında beklenmedik bir hata oluştu!\n\nDetay: " + ex.ToString(),
                                "Kritik Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Loglama yapılabilir:
                // System.IO.File.AppendAllText("hatalog.txt", DateTime.Now + Environment.NewLine + ex.ToString() + Environment.NewLine);
            }
        }

        // Tarih alanına tıklandığında bugünün tarihini ata (eğer boşsa)
        private void txttarih_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttarih.Text))
            {
                // Yerel ayara göre kısa tarih formatı (örn: 15.05.2024)
                txttarih.Text = DateTime.Now.ToShortDateString();
            }
        }

        // Form kapanırken DbContext kaynağını serbest bırakmak iyi bir pratiktir
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            db?.Dispose(); // db null değilse Dispose metodunu çağır
            base.OnFormClosing(e);
        }

        // --- İsteğe Bağlı: Kullanıcı Deneyimi İyileştirmeleri ---

        // Tarih alanına girildiğinde metni temizle (eğer placeholder kullanılıyorsa)
        private void txttarih_Enter(object sender, EventArgs e)
        {
            // Örnek bir placeholder metni kontrolü
            // if (txttarih.Text == "Tarih Girin") {
            //     txttarih.Text = "";
            //     txttarih.ForeColor = Color.Black;
            // }
        }

        // Tarih alanından çıkıldığında format kontrolü yap
        private void txttarih_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txttarih.Text))
            {
                // Girilen tarihin geçerli olup olmadığını kontrol et
                if (!DateTime.TryParse(txttarih.Text, out _)) // '_' discard, değere ihtiyacımız yok
                {
                    MessageBox.Show("Girdiğiniz tarih formatı geçersiz görünüyor.\nLütfen GG.AA.YYYY formatını kullanın.",
                                    "Geçersiz Tarih", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // Opsiyonel: Hatalı girişi temizle
                    // txttarih.Text = "";
                }
            }
            // Opsiyonel: Alan boşsa placeholder metni geri koy
            // else {
            //     txttarih.Text = "Tarih Girin";
            //     txttarih.ForeColor = Color.Gray;
            // }
        }
    }
}