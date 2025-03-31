using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity; // Gerekli using ifadesi

namespace TeknikServis.Formlar
{
    public partial class Frm_Personel : Form
    {
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        public Frm_Personel()
        {
            InitializeComponent();

            // !!! ÖNEMLİ: gridView1'in FocusedRowChanged olayını burada bağlıyoruz !!!
            // Eğer Designer üzerinden zaten bağladıysanız bu satırı silebilirsiniz.
            // Bu satır, bir satır seçildiğinde gridView1_FocusedRowChanged metodunun çalışmasını sağlar.
            if (this.gridView1 != null) // gridView1'in null olmadığından emin olalım
            {
                this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            }
            else
            {
                // Eğer gridView1 bu noktada null ise, Load olayında bağlamayı deneyebiliriz
                // veya Designer.cs dosyasında InitializeComponent sonrası bağlanmasını sağlamalıyız.
                // Genellikle InitializeComponent içinde oluşturulduğu için null olmaması gerekir.
                MessageBox.Show("gridView1 henüz başlatılmamış!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // Personel verilerini (ID, Ad, Soyad, Departman) listeleyen metot
        void listele()
        {
            try
            {
                var degerler = from p in db.TBL_PERSONEL
                               select new
                               {
                                   p.ID,
                                   p.AD,
                                   p.SOYAD,
                                   DEPARTMANID = p.DEPARTMAN, // Departman ID'si
                                   DepartmanAdi = p.TBL_DEPARTMAN.AD // Departman Adı
                               };
                gridControl1.DataSource = degerler.ToList();

                // Departmanları LookUpEdit'e yükle (Sadece bir kez yapmak yeterli olabilir - Load olayında)
                lookUpEdit1.Properties.DataSource = (from x in db.TBL_DEPARTMAN
                                                     select new
                                                     {
                                                         x.ID,
                                                         x.AD
                                                     }).ToList();

                lookUpEdit1.Properties.DisplayMember = "AD";
                lookUpEdit1.Properties.ValueMember = "ID";

                TemizleAlanlari(); // Listeleme sonrası alanları temizle
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri listelenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Giriş alanlarını temizleyen metot
        void TemizleAlanlari()
        {
            txtid.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            lookUpEdit1.EditValue = null;
            lookUpEdit1.Properties.NullText = "Bir Değer Seçiniz...";
        }


        // Form Yüklendiğinde çalışan olay
        private void Frm_Personel_Load(object sender, EventArgs e)
        {
            // LookUpEdit ayarlarını burada yapmak daha uygun olabilir
            try
            {
                lookUpEdit1.Properties.DataSource = (from x in db.TBL_DEPARTMAN
                                                     select new
                                                     {
                                                         x.ID,
                                                         x.AD
                                                     }).ToList();
                lookUpEdit1.Properties.DisplayMember = "AD";
                lookUpEdit1.Properties.ValueMember = "ID";
                lookUpEdit1.Properties.NullText = "Bir Değer Seçiniz...";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Departmanlar yüklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            listele(); // Grid'i doldur

            txtid.Properties.ReadOnly = true; // ID değiştirilemez olsun

            // Label'ları dolduran kod (opsiyonel, önceki gibi)
            // ... (Mail ve Telefon olmadan önceki gibi label doldurma kodları buraya gelebilir) ...
            try
            {
                // Label doldurma kodlarınız buraya eklenebilir (MAIL/TELEFON olmadan)
                string ad1, soyad1, ad2, soyad2, ad3, soyad3, ad4, soyad4;

                var p1 = db.TBL_PERSONEL.Include(p => p.TBL_DEPARTMAN).FirstOrDefault(x => x.ID == 1);
                if (p1 != null) { ad1 = p1.AD; soyad1 = p1.SOYAD; labelControl5.Text = p1.TBL_DEPARTMAN?.AD ?? "Yok"; labelControl4.Text = ad1 + " " + soyad1; }
                // ... Diğer personeller için benzer kodlar ...
                var p2 = db.TBL_PERSONEL.Include(p => p.TBL_DEPARTMAN).FirstOrDefault(x => x.ID == 2);
                if (p2 != null) { ad2 = p2.AD; soyad2 = p2.SOYAD; labelControl12.Text = p2.TBL_DEPARTMAN?.AD ?? "Yok"; labelControl14.Text = ad2 + " " + soyad2; }

                var p3 = db.TBL_PERSONEL.Include(p => p.TBL_DEPARTMAN).FirstOrDefault(x => x.ID == 3);
                if (p3 != null) { ad3 = p3.AD; soyad3 = p3.SOYAD; labelControl18.Text = p3.TBL_DEPARTMAN?.AD ?? "Yok"; labelControl20.Text = ad3 + " " + soyad3; }

                var p4 = db.TBL_PERSONEL.Include(p => p.TBL_DEPARTMAN).FirstOrDefault(x => x.ID == 4);
                if (p4 != null) { ad4 = p4.AD; soyad4 = p4.SOYAD; labelControl24.Text = p4.TBL_DEPARTMAN?.AD ?? "Yok"; labelControl26.Text = ad4 + " " + soyad4; }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Personel bilgileri yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Kaydet Butonu
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtad.Text) || string.IsNullOrWhiteSpace(txtsoyad.Text) || lookUpEdit1.EditValue == null)
            {
                MessageBox.Show("Ad, Soyad ve Departman alanları boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                TBL_PERSONEL t = new TBL_PERSONEL();
                t.AD = txtad.Text;
                t.SOYAD = txtsoyad.Text;
                t.DEPARTMAN = byte.Parse(lookUpEdit1.EditValue.ToString()); // Veritabanındaki DEPARTMAN türüne göre Parse edin (byte, int?)
                db.TBL_PERSONEL.Add(t);
                db.SaveChanges();
                MessageBox.Show("Personel başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            catch (FormatException) { MessageBox.Show("Lütfen geçerli bir departman seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex) { MessageBox.Show("Personel eklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // Sil Butonu
        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtid.Text) || !int.TryParse(txtid.Text, out int id))
            {
                MessageBox.Show("Lütfen silmek için geçerli bir personel seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var onay = MessageBox.Show(id + " ID'li personeli silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (onay == DialogResult.Yes)
            {
                try
                {
                    var silinecekPersonel = db.TBL_PERSONEL.Find(id);
                    if (silinecekPersonel != null)
                    {
                        db.TBL_PERSONEL.Remove(silinecekPersonel);
                        db.SaveChanges();
                        MessageBox.Show("Personel başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listele();
                    }
                    else { MessageBox.Show("Silinecek personel bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                catch (Exception ex) { MessageBox.Show("Personel silinirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        // Temizle Butonu
        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TemizleAlanlari();
        }

        // Güncelle Butonu
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtid.Text) || !int.TryParse(txtid.Text, out int id))
            {
                MessageBox.Show("Lütfen güncellemek için geçerli bir personel seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtad.Text) || string.IsNullOrWhiteSpace(txtsoyad.Text) || lookUpEdit1.EditValue == null)
            {
                MessageBox.Show("Ad, Soyad ve Departman alanları boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var guncellenecekPersonel = db.TBL_PERSONEL.Find(id);
                if (guncellenecekPersonel != null)
                {
                    guncellenecekPersonel.AD = txtad.Text;
                    guncellenecekPersonel.SOYAD = txtsoyad.Text;
                    guncellenecekPersonel.DEPARTMAN = byte.Parse(lookUpEdit1.EditValue.ToString()); // Veritabanındaki DEPARTMAN türüne göre Parse edin
                    db.SaveChanges();
                    MessageBox.Show("Personel başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                }
                else { MessageBox.Show("Güncellenecek personel bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            catch (FormatException) { MessageBox.Show("Lütfen geçerli bir departman seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex) { MessageBox.Show("Personel güncellenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // *** GridView'de Seçili Satır Değiştiğinde Çalışacak Metot ***
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // e.FocusedRowHandle seçili satırın indeksini verir. -1 ise seçili satır yoktur.
            if (e.FocusedRowHandle >= 0)
            {
                try
                {
                    // GetFocusedRowCellValue ile seçili satırdan hücre değerlerini al.
                    // Sütun adları ('ID', 'AD', 'SOYAD', 'DEPARTMANID') listele() içindeki adlarla AYNI OLMALI!
                    txtid.Text = gridView1.GetFocusedRowCellValue("ID")?.ToString() ?? "";
                    txtad.Text = gridView1.GetFocusedRowCellValue("AD")?.ToString() ?? "";
                    txtsoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD")?.ToString() ?? "";

                    // LookUpEdit'in değerini DEPARTMANID sütunundan alarak ayarla.
                    lookUpEdit1.EditValue = gridView1.GetFocusedRowCellValue("DEPARTMANID");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Satır bilgileri yüklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TemizleAlanlari(); // Hata durumunda temizle
                }
            }
            else
            {
                // Seçili satır yoksa (örn. grid boşsa) alanları temizle
                TemizleAlanlari();
            }
        }
    }
}