# Cinemagnesia

Sistem 3 Rol üzerinden ilerleyecektir .

# **Roller**

- User
- Productor
- Admin

# Yetkinlikler

- **User yetkinlikleri**:
    - Yayımlanan filmlere yorum yapabilir, 1-10 arasında puan verebilir. Yorum yaptığı ve oy verdiği filmler profilinde listelenebilir.
    - İzlediği veya izlemek istediği filmleri işaretleyebilir. Bunlar da listelenebilir. (istenirse kullanıcı profili düzenlenebilir).
    - User kayıt gerçekleştirden sonra isterse Productor olmak için sisteme istek yollayabilir. Admin bu isteği onaylar ise User artık bir Productor'dır.
- **Productor Yetkinlikleri**:
    - User'ın sahip olduğu tüm yetkinliklere sahiptir. Harici olarak sisteme film ekleme isteği gönderebilir. Admin onaylar ise film artık sistemde yayımlanabilir. Imdb' Id si üzerinden inputları direkt doldurarak da isterse üzerinde düzenlemeler yaparak ekleme isteği gönderebilir.
    - Düzenleme ve silme işlemleri içinde admine istek atabilir.
- **Admin Yetkininlikleri:**
    - Bütün onaylama mekanizması admindedir.
    - Gelen istekleri inceleyip onaylayabilir.
    - Kullanıcılar için kısıtlamalar kullanabilir.
    - Admin istenen her yetkiye sahiptir.

# Sayfalar

### Rolsüzlerin görebileceği sayfalar:

- Anasayfa
- Film Detay Sayfası
- Login/Register sayfası

### User'ın görebileceği sayfalar:

- Anasayfa
- Film Detay Sayfası
- Profil Sayfası
- Productor'e başvuru sayfası

### Prodoctur'un görebileceği sayfalar:

- Yukarıdakilerin hepsi (Productor'e başvuru hariç)
- Film ekleme/silme/güncelleme isteği sayfası
- Profil Sayfası (Eklediği Filmler Listesi)

### Admin'in görebileceği sayfalar:

- Anasayfa
- Film Detay Sayfası
- Profil Sayfası
- Admin Panel

# Sayfaların içerikleri

**Navbar**  ( Login/Register, Film arama, Anasayfa, Oyuncular, Yönetmenler)

- **Anasayfa**
    
    Sidebar (  Kategoriler, Yıllar, vb.)
    
    Image Slider (Rastgele film afişleri)
    
    Öne Çıkan Film Cards
    
    En Sevilen Film Cards
    
    En Çok Yorum Alan Film Cards
    
    Filmlerin Listesi
    
- **Film Detay Sayfası**
    
    Filmin Afişi
    
    Filmin Bilgileri (adı, puanı, yönetmeni vs.)
    
    Yorumlar
    
    Filmi Puanlama
    
    İzlemek istiyorum, İzledim Butonları
    
    Sosyal Medyada Paylaşma Butonları
    
- **Login/Register Sayfası**
    
    Default Identity Sayfası
    
    UI Düzenlenebilir
    
- **Profil Sayfası**
    
    Identity Default User Sayfasına ek olarak component eklenebilir.
    
    User, Productor ve Admin(?) sayfaları birbirinden ayrı özelliklere sahip olacak (Productor ise Filmlerinin listesini görebilecek)
    
- **Productor'a başvuru sayfası**
    
    Productor'un şirketine ait bilgileri girebileceği inputlar.
    
- **Film ekleme/silme/güncelleme isteği sayfası**
    
    CRUD işlemlerinin yapılabileceği sayfa (Ekstra olarak IMDb ID girişi yaparak film bilgilerini inputlara doldurma özelliği)
    
- **Admin Panel**
    
    Uygulamadaki tüm istatistikler.
    
    Kullanıcı/Film/Yorum'larin listelendiği ve düzenlenebildiği sayfa.
    
    Yorum istekleri.
    
    Productor başvuruları.
    
    Productor'dan gelen film ekleme/silme/güncelleme istekleri.
    
    Log kayıtlarının görüneceği sayfa.
    
    Sistemin UI'ını güncelleyebileceği sayfa.
    
    Excel/PDF export sayfası.
    
    Mail gönderebileceği sayfa.
    

**Footer** (Hakkımızda, İletişim, vs.)

# Geliştiriciler

- **Berke Erdeniz**
- **Berna Bayraktar**
- **Emirhan Altuntaş**
