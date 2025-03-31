using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace TeknikServis.Formlar
{
    public partial class Frm_CariListesi : Form
    {
        public Frm_CariListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        int secilen;


        void listele()
        {
            // Her listelemede yeni bir DbContext oluşturun
            using (DbTeknikServisEntities context = new DbTeknikServisEntities())
            {
                var deglerler = from c in context.TBL_CARİ
                                select new
                                {
                                    c.ID,
                                    c.AD,
                                    c.SOYAD,
                                    c.TELEFON,
                                    c.MAIL,
                                    c.IL,
                                    c.ILCE
                                    // Eksik kalan diğer alanları da göstermek isterseniz buraya ekleyebilirsiniz.
                                    // Örneğin: c.BANKA, c.STATU, c.VERGIDAIRESI, c.VERGINO, c.ADRES
                                };
                gridControl1.DataSource = deglerler.ToList();
                labelControl9.Text = context.TBL_CARİ.Count().ToString(); // Toplam cari sayısını da güncelleyelim.
            }
            gridView1.BestFitColumns(); // İsteğe bağlı: Sütun genişliklerini otomatik ayarlar
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=UMUT\SQLEXPRESS;Initial Catalog=DbTeknikServis;Integrated Security=True");
        private void Frm_CariListesi_Load(object sender, EventArgs e)
        {

            listele();
            using (DbTeknikServisEntities context = new DbTeknikServisEntities())
            {
                lookUpEdit1.Properties.DataSource = (from x in context.iller
                                                     select new
                                                     {
                                                         x.id,
                                                         x.sehir
                                                     }).ToList();
            }
            lookUpEdit1.Properties.NullText = "Bir İl Seçiniz..."; // NullText ataması
            lookUpEdit2.Properties.NullText = "Önce İl Seçiniz..."; // NullText ataması
            labelControl18.Text = db.TBL_CARİ.Select(x => x.IL).Distinct().Count().ToString();
            labelControl16.Text = db.TBL_CARİ.Select(x => x.ILCE).Distinct().Count().ToString();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select top 1 IL from TBL_CARİ group by IL order by count(*) desc", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                labelControl11.Text = dr[0].ToString();
            }
            baglanti.Close();
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit1.EditValue != null) // Null kontrolü ekleyin
            {
                if (int.TryParse(lookUpEdit1.EditValue.ToString(), out secilen)) // Güvenli dönüşüm
                {
                    using (DbTeknikServisEntities context = new DbTeknikServisEntities())
                    {
                        lookUpEdit2.Properties.DataSource = (from y in context.ilceler
                                                             select new
                                                             {
                                                                 y.id,
                                                                 y.ilce,
                                                                 y.sehir
                                                             }).Where(z => z.sehir == secilen).ToList();
                        lookUpEdit2.Properties.NullText = "Bir İlçe Seçiniz..."; // İl seçilince metni değiştir
                        lookUpEdit2.EditValue = null; // Önceki ilçe seçimini temizle
                    }
                }
                else
                {
                    // Eğer EditValue integer'a çevrilemezse (beklenmedik bir durum)
                    lookUpEdit2.Properties.DataSource = null;
                    lookUpEdit2.Properties.NullText = "Geçersiz İl Seçimi";
                    lookUpEdit2.EditValue = null;
                }
            }
            else
            {
                // İl seçimi kaldırılırsa ilçe listesini ve seçimini temizle
                lookUpEdit2.Properties.DataSource = null;
                lookUpEdit2.Properties.NullText = "Önce İl Seçiniz...";
                lookUpEdit2.EditValue = null;
            }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (txtcariad.Text != "" & txtsoyad.Text != "" & txtcariad.Text.Length <= 20)
            {
                TBL_CARİ t = new TBL_CARİ();
                t.AD = txtcariad.Text;
                t.SOYAD = txtsoyad.Text;
                t.ADRES = txtadres.Text;
                t.MAIL = txtmail.Text;
                t.STATU = txtstatu.Text;
                t.TELEFON = txttelefon.Text;
                t.VERGIDAIRESI = txtvergid.Text;
                t.VERGINO = txtvergino.Text;
                t.IL = lookUpEdit1.Text;
                t.ILCE = lookUpEdit2.Text;
                db.TBL_CARİ.Add(t);
                db.SaveChanges();
                MessageBox.Show("Yeni Cari Sisteme Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yeniden Deneyiniz.");
            }

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult secim = new DialogResult();
            secim = MessageBox.Show("Cari Silinsin Mi?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                int id = int.Parse(txtcariid.Text);
                var deger = db.TBL_CARİ.Find(id);
                db.TBL_CARİ.Remove(deger);
                db.SaveChanges();
                MessageBox.Show("Cari Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listele();
            }
            else
            {
                listele();
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtcariid.Text, out int id) && id > 0) // ID'nin geçerli ve pozitif olduğundan emin ol
            {
                // Gerekli alan kontrolleri
                if (string.IsNullOrWhiteSpace(txtcariad.Text) || string.IsNullOrWhiteSpace(txtsoyad.Text))
                {
                    MessageBox.Show("Ad ve Soyad alanları boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (lookUpEdit1.EditValue == null || lookUpEdit2.EditValue == null)
                {
                    MessageBox.Show("Lütfen İl ve İlçe seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    using (DbTeknikServisEntities context = new DbTeknikServisEntities())
                    {
                        var deger = context.TBL_CARİ.Find(id);
                        if (deger != null)
                        {
                            deger.AD = txtcariad.Text.Trim();
                            deger.SOYAD = txtsoyad.Text.Trim();
                            deger.ADRES = txtadres.Text.Trim();
                            deger.BANKA = txtbanka.Text.Trim();
                            deger.IL = lookUpEdit1.Text; // Text kullanmak daha basit olabilir
                            deger.ILCE = lookUpEdit2.Text;
                            deger.MAIL = txtmail.Text.Trim();
                            deger.STATU = txtstatu.Text.Trim();
                            deger.TELEFON = txttelefon.Text.Trim();
                            deger.VERGIDAIRESI = txtvergid.Text.Trim();
                            deger.VERGINO = txtvergino.Text.Trim();

                            context.SaveChanges();
                            MessageBox.Show("Cari başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            listele(); // Listeyi yenile
                        }
                        else
                        {
                            MessageBox.Show("Güncellenecek Cari Bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme işlemi sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek için listeden geçerli bir cari seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            txtcariid.Text = "";
            txtcariad.Text = "";
            txtsoyad.Text = "";
            txtadres.Text = "";
            txtmail.Text = "";
            txtstatu.Text = "";
            txttelefon.Text = "";
            txtvergid.Text = "";
            txtvergino.Text = "";
            txtbanka.Text = "";
            lookUpEdit1.EditValue = null; // Seçimi kaldırır ve NullText'i gösterir
            lookUpEdit2.EditValue = null;
            lookUpEdit2.Properties.DataSource = null; // İlçe listesini temizler
            lookUpEdit2.Properties.NullText = "Önce İl Seçiniz...";
            txtcariad.Focus(); // İmleci Ad alanına getirir
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                try
                {
                    // Önce temel bilgileri grid'den al (null kontrolü yaparak)
                    txtcariid.Text = gridView1.GetFocusedRowCellValue("ID")?.ToString() ?? "";
                    txtcariad.Text = gridView1.GetFocusedRowCellValue("AD")?.ToString() ?? "";
                    txtsoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD")?.ToString() ?? "";
                    txttelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON")?.ToString() ?? "";
                    txtmail.Text = gridView1.GetFocusedRowCellValue("MAIL")?.ToString() ?? "";

                    // Grid'de olmayan diğer detayları (Adres, Banka vb.) ve LookUpEdit'leri
                    // doldurmak için veritabanından tam kaydı çekelim.
                    if (int.TryParse(txtcariid.Text, out int seciliId))
                    {
                        using (DbTeknikServisEntities context = new DbTeknikServisEntities())
                        {
                            var cariDetay = context.TBL_CARİ.Find(seciliId);
                            if (cariDetay != null)
                            {
                                txtadres.Text = cariDetay.ADRES;
                                txtbanka.Text = cariDetay.BANKA;
                                txtstatu.Text = cariDetay.STATU;
                                txtvergid.Text = cariDetay.VERGIDAIRESI;
                                txtvergino.Text = cariDetay.VERGINO;

                                // İl ve İlçe LookUpEdit'lerini ayarlama:
                                // 1. İl'i ayarla (ID bazlı yapmak daha sağlam)
                                var il = context.iller.FirstOrDefault(i => i.sehir == cariDetay.IL);
                                if (il != null)
                                {
                                    lookUpEdit1.EditValue = il.id; // ID'yi ata (Bu EditValueChanged'ı tetikler)

                                    // EditValueChanged ilçe listesini doldurduktan sonra ilçeyi seçebiliriz.
                                    // Ancak bu anlık olmayabilir. Doğrudan ilçe ID'sini de bulup atamak daha garanti.
                                    var ilce = context.ilceler.FirstOrDefault(ic => ic.ilce == cariDetay.ILCE && ic.sehir == il.id);
                                    if (ilce != null)
                                    {
                                        // lookUpEdit1_EditValueChanged'ın bitmesini beklemek yerine doğrudan atama deneyebiliriz.
                                        // Eğer sorun olursa, ilçe atamasını küçük bir gecikmeyle yapmak gerekebilir.
                                        lookUpEdit2.EditValue = ilce.id;
                                    }
                                    else
                                    {
                                        lookUpEdit2.EditValue = null; // Kayıtlı ilçe bulunamazsa temizle
                                    }
                                }
                                else
                                {
                                    lookUpEdit1.EditValue = null; // Kayıtlı il bulunamazsa temizle
                                    lookUpEdit2.EditValue = null;
                                }
                            }
                            else
                            {
                                // ID'ye sahip cari bulunamadı (nadiren olmalı), formu temizle
                                btntemizle_Click(sender, e);
                            }
                        }
                    }
                    else if (!string.IsNullOrEmpty(txtcariid.Text))
                    {
                        // ID alanı dolu ama sayıya çevrilemiyor (beklenmedik durum), formu temizle
                        btntemizle_Click(sender, e);
                    }
                    // Eğer ID boşsa, yeni kayıt giriliyor demektir, temizlemeye gerek yok.

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cari bilgileri yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btntemizle_Click(sender, e); // Hata durumunda formu temizle
                }
            }
            else
            {
                // Geçerli bir satır seçili değilse (örn. filtreleme sonucu liste boşsa) formu temizle
                btntemizle_Click(sender, e);
            }
        }

        private void Frm_CariListesi_Activated(object sender, EventArgs e)
        {
            listele();
        }
    }
}
