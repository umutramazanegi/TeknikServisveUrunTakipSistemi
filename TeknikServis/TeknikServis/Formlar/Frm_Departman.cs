using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// using System.Data.SqlClient; // Artık ADO.NET kullanmayacağımız için buna gerek yok

namespace TeknikServis.Formlar
{
    public partial class Frm_Departman : Form
    {
        public Frm_Departman()
        {
            InitializeComponent();
            // GridView olayını constructor içinde veya Designer'dan bağladığınızdan emin olun
            if (this.gridView1 != null)
            {
                this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            }
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        // SqlConnection baglanti = new SqlConnection(...); // Artık gerekli değil

        void listele()
        {
            try // Veritabanı işlemleri hata verebilir
            {
                var degerler = from d in db.TBL_DEPARTMAN
                               select new
                               {
                                   d.ID,
                                   d.AD,
                               };
                gridControl1.DataSource = degerler.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Departmanlar listelenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // İstatistikleri hesaplayan ve label'lara yazan metot
        void IstatistikleriYukle()
        {
            try
            {
                // 1. Toplam Departman Sayısı
                labelControl8.Text = db.TBL_DEPARTMAN.Count().ToString();

                // 2. Toplam Personel Sayısı
                labelControl10.Text = db.TBL_PERSONEL.Count().ToString();

                // 3. En Fazla Çalışanı Olan Departman Adı
                var enFazlaCalisanliGrup = db.TBL_PERSONEL
                                            .GroupBy(p => p.DEPARTMAN) // Departman ID'sine göre grupla
                                            .OrderByDescending(g => g.Count()) // Grubu eleman sayısına göre azalan sırala
                                            .Select(g => new { DepartmanID = g.Key, CalisanSayisi = g.Count() }) // ID ve sayıyı al
                                            .FirstOrDefault(); // İlk sıradakini (en yükseği) al

                if (enFazlaCalisanliGrup != null)
                {
                    // Bulunan Departman ID'sine göre Departman Adını bul
                    // TBL_PERSONEL.DEPARTMAN ve TBL_DEPARTMAN.ID tipleri eşleşmeli (genellikle byte veya int)
                    byte depId = (byte)enFazlaCalisanliGrup.DepartmanID; // Tipi byte varsayıyorum, int ise (int) yapın
                    labelControl9.Text = db.TBL_DEPARTMAN
                                            .Where(d => d.ID == depId)
                                            .Select(d => d.AD) // Sadece Adını seç
                                            .FirstOrDefault() ?? "Bilinmiyor"; // Bulamazsa "Bilinmiyor" yaz
                }
                else
                {
                    labelControl9.Text = "Personel Yok"; // Hiç personel yoksa
                }

                // 4. En Az Çalışanı Olan Departman Adı
                var enAzCalisanliGrup = db.TBL_PERSONEL
                                           .GroupBy(p => p.DEPARTMAN)
                                           .OrderBy(g => g.Count()) // Grubu eleman sayısına göre artan sırala
                                           .Select(g => new { DepartmanID = g.Key, CalisanSayisi = g.Count() })
                                           .FirstOrDefault(); // İlk sıradakini (en azı) al

                if (enAzCalisanliGrup != null)
                {
                    byte depId = (byte)enAzCalisanliGrup.DepartmanID; // Tipi byte varsayıyorum, int ise (int) yapın
                    labelControl13.Text = db.TBL_DEPARTMAN
                                             .Where(d => d.ID == depId)
                                             .Select(d => d.AD)
                                             .FirstOrDefault() ?? "Bilinmiyor";
                }
                else
                {
                    labelControl13.Text = "Personel Yok"; // Hiç personel yoksa
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("İstatistikler yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Hata durumunda label'ları temizleyebiliriz
                labelControl8.Text = "-";
                labelControl10.Text = "-";
                labelControl9.Text = "-";
                labelControl13.Text = "-";
            }
        }


        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            listele(); // Departman listesini grid'e yükle
            IstatistikleriYukle(); // İstatistikleri hesapla ve label'lara yaz

            // ID alanı genellikle değiştirilmemeli
            txtid.Properties.ReadOnly = true;
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            // Ad alanı boş olmamalı ve makul uzunlukta olmalı
            if (!string.IsNullOrWhiteSpace(txtad.Text) && txtad.Text.Length <= 50)
            {
                try
                {
                    TBL_DEPARTMAN d = new TBL_DEPARTMAN();
                    d.AD = txtad.Text.Trim(); // Başındaki/sonundaki boşlukları temizle

                    db.TBL_DEPARTMAN.Add(d);
                    db.SaveChanges();
                    MessageBox.Show("Departman başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele(); // Listeyi yenile
                    IstatistikleriYukle(); // İstatistikleri de yenile
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kaydetme sırasında hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Departman adı boş olamaz veya 50 karakterden uzun olamaz!", "Geçersiz Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            // Önce bir departman seçili mi kontrol et
            if (string.IsNullOrWhiteSpace(txtid.Text))
            {
                MessageBox.Show("Lütfen silmek için bir departman seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ID'yi güvenli bir şekilde al
            if (int.TryParse(txtid.Text, out int id))
            {
                DialogResult secim = MessageBox.Show(id + " ID'li departmanı silmek istediğinize emin misiniz?\n(Bu departmana bağlı personeller varsa silme işlemi başarısız olabilir.)",
                                                     "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (secim == DialogResult.Yes)
                {
                    try
                    {
                        var deger = db.TBL_DEPARTMAN.Find(id);
                        if (deger != null)
                        {
                            db.TBL_DEPARTMAN.Remove(deger);
                            db.SaveChanges();
                            MessageBox.Show("Departman başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information); // Warning yerine Information
                            listele();
                            IstatistikleriYukle(); // İstatistikleri yenile
                        }
                        else
                        {
                            MessageBox.Show("Silinecek departman bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    // Foreign Key hatasını yakalamak için DbUpdateException kontrolü eklenebilir
                    catch (System.Data.Entity.Infrastructure.DbUpdateException dbEx)
                    {
                        MessageBox.Show("Departman silinemedi. Bu departmana atanmış personeller olabilir.\nHata Detayı: " + dbEx.InnerException?.Message, "Silme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        db.Entry(db.TBL_DEPARTMAN.Find(id)).State = System.Data.Entity.EntityState.Unchanged; // Context'i temizle
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Silme sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Geçersiz Departman ID'si.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Kullanıcı hayır derse veya ID geçersizse listeyi yenilemeye gerek yok.
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Seçili satır değiştiğinde ID ve Ad alanlarını doldur
            if (e.FocusedRowHandle >= 0) // Geçerli bir satır seçiliyse
            {
                // GetFocusedRowCellValue null dönebilir, kontrol ekleyelim
                txtid.Text = gridView1.GetFocusedRowCellValue("ID")?.ToString() ?? "";
                txtad.Text = gridView1.GetFocusedRowCellValue("AD")?.ToString() ?? "";
            }
            else // Seçili satır yoksa (Grid boşsa vs.)
            {
                txtid.Text = "";
                txtad.Text = "";
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            // Önce bir departman seçili mi kontrol et
            if (string.IsNullOrWhiteSpace(txtid.Text))
            {
                MessageBox.Show("Lütfen güncellemek için bir departman seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ad alanı boş olamaz
            if (string.IsNullOrWhiteSpace(txtad.Text) || txtad.Text.Length > 50)
            {
                MessageBox.Show("Departman adı boş olamaz veya 50 karakterden uzun olamaz!", "Geçersiz Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.TryParse(txtid.Text, out int id))
            {
                try
                {
                    var deger = db.TBL_DEPARTMAN.Find(id);
                    if (deger != null)
                    {
                        deger.AD = txtad.Text.Trim(); // Yeni adı ata (boşlukları temizleyerek)
                        db.SaveChanges();
                        MessageBox.Show("Departman başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listele(); // Listeyi yenile
                        IstatistikleriYukle(); // İstatistikleri yenile (Adı değişmiş olabilir)
                    }
                    else
                    {
                        MessageBox.Show("Güncellenecek departman bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Geçersiz Departman ID'si.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            // Sadece Ad ve ID alanlarını temizle (ID zaten ReadOnly)
            txtid.Text = "";
            txtad.Text = "";
        }
    }
}