
# MvcCarRental2

MvcCarRental2, araç kiralama işlemleri için geliştirilmiş bir ASP.NET Core MVC uygulamasıdır. Bu proje, araç markalarından araç modellerine, araç kiralama işlemlerine kadar birçok bileşen içerir. Kullanıcıların araçları kiralayabilmesi için gerekli altyapıyı sağlayan ve Admin paneli üzerinden araç yönetimi, marka, model ve kiralama gibi işlemleri gerçekleştirebilen bir sistemdir.

## Kullanılan Teknolojiler
- **ASP.NET Core MVC**
- **Entity Framework Core** (Veritabanı işlemleri)
- **SQL Server** (Veritabanı yönetim sistemi)
- **C#**
- **HTML5, CSS3**

## Kurulum

### Gereksinimler
- **.NET 6.0** veya daha yeni bir sürümü
- **SQL Server** (ya da tercih ettiğiniz başka bir veritabanı)

### Kurulum Adımları

1. Projeyi GitHub'dan veya bu repo'dan bilgisayarınıza indirin:
   ```bash
   git clone https://github.com/yourusername/MvcCarRental2.git
   ```

2. **Visual Studio** veya **Visual Studio Code** kullanarak projeyi açın.

3. `appsettings.json` dosyasındaki veritabanı bağlantı dizesini uygun şekilde düzenleyin.

4. Veritabanı migrasyonlarını uygulamak için terminalden aşağıdaki komutları çalıştırın:
   ```bash
   dotnet ef database update
   ```

5. Projeyi başlatın:
   ```bash
   dotnet run
   ```

### Proje Yapısı
Proje, aşağıdaki ana bileşenleri içerir:

- **Controllers**: Web sayfaları için gerekli iş mantığını barındırır.
  - `HomeController`: Ana sayfa, iletişim, gizlilik gibi genel sayfaların kontrolü.
  - `CarsController`: Araçların listelenmesi ve yönetilmesi.
  - `BookingController`: Araç kiralama işlemlerinin yönetilmesi.
  - `AccountController`: Admin girişi ve yönetimi.
  - `BrandController`, `CarController`, `CarTypeController`, `ModelController`, `RentController`: Admin paneli araç yönetimi.

- **Models**: Araç, Marka, Model, Araç Türü, Kiralama vb. sınıfları içerir.
- **Data**: Veritabanı bağlantıları ve modelleri.
- **Views**: Uygulama arayüzünü barındırır.

### Modeller

#### 1. **Brand (Marka)**
   - `Id`: Marka kimliği
   - `Name`: Marka adı
   - `ImageAdress`: Markaya ait görsel adresi
   - `Models`: İlişkili araç modelleri

#### 2. **Car (Araç)**
   - `Id`: Araç kimliği
   - `PlateNumber`: Plaka numarası
   - `Year`: Araç yılı
   - `ModelId`: İlişkili modelin kimliği
   - `Price`: Günlük kira ücreti
   - `TransmissionType`: Vites türü (Manuel, Otomatik, Yarı Otomatik)
   - `IsAvailable`: Araç mevcut mu
   - `ImageAdress`: Araç görseli
   - `Rents`: İlişkili kiralamalar

#### 3. **CarType (Araç Türü)**
   - `Id`: Araç türü kimliği
   - `Name`: Araç türü adı
   - `Models`: İlişkili araç modelleri

#### 4. **Model (Model)**
   - `Id`: Model kimliği
   - `Name`: Model adı
   - `BrandId`: İlişkili marka kimliği
   - `CarTypeId`: İlişkili araç türü kimliği
   - `EngineType`: Motor türü (LPG, Dizel, Benzinli, Elektrikli)
   - `Brand`: İlişkili marka
   - `CarType`: İlişkili araç türü
   - `Cars`: İlişkili araçlar

#### 5. **Rent (Kiralama)**
   - `Id`: Kiralama kimliği
   - `CarId`: İlişkili araç kimliği
   - `StartDate`: Kiralama başlangıç tarihi
   - `EndDate`: Kiralama bitiş tarihi
   - `Car`: İlişkili araç

## Admin Paneli
Uygulama, admin kullanıcıları için bir yönetim paneline sahiptir. Admin kullanıcılar şu işlemleri gerçekleştirebilir:
- Araçlar, markalar, modeller ve araç türleri üzerinde CRUD (Create, Read, Update, Delete) işlemleri.
- Araç kiralama işlemlerini görüntüleme ve yönetme.

Admin girişi için **Kullanıcı Adı: admin** ve **Şifre: Admin123** kullanılabilir.


