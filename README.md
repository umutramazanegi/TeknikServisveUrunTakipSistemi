# 🛠️ C# & DevExpress Teknik Servis ve Ürün Takip Sistemi 💻

Herkese merhaba! 👋 Bu repo, C# programlama dili ve DevExpress arayüz kontrolleri kullanılarak geliştirilen kapsamlı bir **Teknik Servis ve Ürün Takip Sistemi** projesini içermektedir. Proje, hem güçlü bir masaüstü yönetim paneli hem de kullanıcı dostu bir web arayüzü sunar.

Bu projenin geliştirilmesinde **Murat Yücedağ** hocamızın eğitimlerinden büyük ölçüde faydalanılmıştır. Kendisine değerli katkıları için teşekkürlerimi sunarım. 🙏

## 📸 Ekran Görüntüleri

*(Buraya projenizden birkaç etkileyici ekran görüntüsü eklemeyi unutmayın! Örneğin: Login Ekranı, Ana Modül, Ürün Listesi, Fatura Detayı, Web Anasayfası vb.)*

![Login Ekranı](link_ekran_goruntusu_1.png)
![Ana Modül](link_ekran_goruntusu_2.png)
![Ürün Listesi](link_ekran_goruntusu_3.png)
![Web Arayüzü](link_ekran_goruntusu_4.png)

## ✨ Temel Özellikler

### 🖥️ Masaüstü Uygulaması (Yönetim Paneli)

*   **🔑 Güvenli Giriş:** Yetkisiz erişimi engellemek için kullanıcı adı ve şifre ile giriş ekranı.
*   **📊 Ana Modül (Dashboard):**
    *   📉 **Kritik Stok Seviyesi:** Stoğu azalan ürünlerin hızlı takibi.
    *   📊 **Kategori-Ürün Sayıları:** Kategorilere göre ürün dağılımı özeti.
    *   📖 **Fihrist:** Sık kullanılan cari/personel iletişim bilgilerine hızlı erişim.
    *   📅 **Bugün Yapılacaklar (Ajanda):** Günlük görev ve hatırlatmaların dinamik listesi.
    *   📨 **Son Mesajlar Özeti:** Gelen iletişim mesajlarının hızlı görünümü.
*   **📦 Ürün Yönetimi:**
    *   🏷️ **Kategori Yönetimi:** Kategori ekleme, silme, güncelleme, listeleme.
    *   🖼️ **Marka Logoları:** Görsel marka gösterimi.
    *   🛍️ **Ürün Listesi:** Ürün adı, marka, kategori, stok, fiyat gibi detaylarla listeleme.
    *   ➕➖ **Ürün İşlemleri:** Yeni ürün ekleme, silme, güncelleme.
*   **👥 Cari Yönetimi:** Müşteri ve tedarikçi bilgilerini ekleme, düzenleme, listeleme.
*   **🧾 Fatura ve Hareketler:**
    *   📄 **Fatura Listesi:** Kayıtlı faturaların özet görünümü.
    *   ➕ **Yeni Fatura Oluşturma:** Seri/Sıra No, Tarih, Cari, Personel gibi başlık bilgileriyle fatura kaydı.
    *   🖱️ **Fatura Detayları:** Faturaya çift tıklayarak içeriğindeki ürün/hizmet kalemlerini görme.
    *   ➕ **Fatura Kalemi Ekleme:** Faturaya ürün/hizmet, adet, fiyat bilgisiyle kalem ekleme.
    *   🔍 **Detaylı Fatura Sorgulama:** Fatura ID, Seri/Sıra No ile spesifik faturaları bulma.
    *   📄 **Excel/PDF Aktarma (Opsiyonel):** Fatura listesini veya detayını dışa aktarma.
*   **🧑‍💼 Personel Yönetimi:** Sistemdeki personellerin bilgilerini yönetme.
*   **🛠️ Araçlar (Opsiyonel):** Hesap makinesi, not defteri gibi ek yardımcı modüller.
*   **📈 Raporlama:**
    *   🪄 **Rapor Sihirbazı:** Verilerden özel raporlar oluşturma aracı.
*   **📧 İletişim:**
    *   📒 **Rehber:** Kayıtlı carilerin (müşteri/tedarikçi) iletişim bilgilerine hızlı erişim.
    *   📥 **Gelen Mesajlar:** Sistem üzerinden gelen mesajların özeti (Teşekkür, Rica, Şikayet vb. sayaçlar).
    *   📊 **Genel İstatistikler:** Toplam personel, cari, kategori, ürün sayıları gibi özet bilgiler.
    *   ✉️ **Yeni Mail Gönderme:** Uygulama içinden e-posta gönderme fonksiyonu.

### 🌐 Web Uygulaması (Kullanıcı Arayüzü)

*   **🏠 Anasayfa:** Karşılama mesajları, genel tanıtım ve sloganlar.
*   **ℹ️ Hakkımda:** Proje ve geliştirici hakkında bilgiler, iletişim detayları.
*   **🛒 Ürünler:** Satışa sunulan ürünlerin listesi (Ad, Marka, Fiyat).
*   **🔍 Ürün Takibi / Teknik Servis:**
    *   📜 Servis garantisi ve koşulları hakkında bilgilendirme (Örn: 2 yıl ücretsiz onarım).
    *   ✅ Servis Avantajları: Hızlı servis, arıza sorgulama, güvenilir teslimat, garanti, memnuniyet oranı vb.
*   **📞 İletişim:**
    *   📝 **Bize Ulaşın Formu:** Kullanıcıların Ad, E-posta, Konu ve Mesaj girerek iletişim kurabileceği form (Mesajlar masaüstü uygulamasına düşer).

## 🚀 Kullanılan Teknolojiler

*   **💻 Programlama Dili:** C# (.NET Framework)
*   **🎨 Arayüz:** DevExpress WinForms Kontrolleri
*   **💾 Veritabanı Erişimi:** Entity Framework (Code First veya Database First - belirtilmemişse genel yazılabilir)
*   **🌐 Web Teknolojileri (Tahmini):** ASP.NET (MVC veya Web Forms - belirtilmemişse genel yazılabilir), HTML, CSS, JavaScript
*   **🗄️ Veritabanı Sunucusu (Tahmini):** Microsoft SQL Server

## ⚙️ Kurulum ve Çalıştırma

1.  **Repository'yi Klonlayın:**
    ```bash
    git clone https://github.com/kullanici-adiniz/proje-repo-adi.git
    ```
2.  **Veritabanı Kurulumu:**
    *   Proje muhtemelen Microsoft SQL Server kullanmaktadır.
    *   `app.config` (masaüstü) veya `web.config` (web) dosyalarındaki `connectionString`'i kendi SQL Server yapılandırmanıza göre güncelleyin.
    *   Entity Framework Migrations kullanılıyorsa:
        *   Visual Studio'da Paket Yöneticisi Konsolu'nu (Package Manager Console) açın.
        *   `Update-Database` komutunu çalıştırarak veritabanını oluşturun/güncelleyin.
    *   Eğer veritabanı yedeği (`.bak`) varsa, SQL Server Management Studio (SSMS) kullanarak yedeği geri yükleyin.
3.  **Projeyi Derleyin:**
    *   `*.sln` dosyasını Visual Studio ile açın.
    *   Gerekli NuGet paketlerinin yüklendiğinden emin olun (Restore NuGet Packages).
    *   Projeyi derleyin (Build Solution - F6 veya Ctrl+Shift+B).
4.  **Uygulamayı Çalıştırın:**
    *   Masaüstü uygulamasını başlatmak için derlenen `.exe` dosyasını çalıştırın veya Visual Studio üzerinden Start (F5) yapın.
    *   **Varsayılan Giriş Bilgileri:** Kullanıcı Adı: `admin`, Şifre: `1234`
    *   Web uygulamasını çalıştırmak için web projesini Visual Studio üzerinden başlatın (IIS Express veya yerel IIS üzerinde çalışacaktır). Tarayıcınızda belirtilen `localhost` adresi açılacaktır.

## 🙏 Teşekkür

Bu projenin geliştirilmesinde yol gösterici olan **Murat Yücedağ**'ın eğitimlerine tekrar teşekkür ederim.

## 📧 İletişim

Proje ile ilgili soru veya geri bildirimleriniz için benimle iletişime geçebilirsiniz: [E-posta Adresiniz] veya [GitHub Profil Linkiniz]

---

Umarım bu README.md taslağı işinize yarar! Kendi bilgilerinizi (ekran görüntüleri, GitHub linkleri, e-posta) eklemeyi unutmayın. Başarılar! 🎉
