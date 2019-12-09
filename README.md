# Emlak-Otomasyonu
C# - Emlak Otomasyonu - Real Estate Automation

<!-- wp:heading -->
<h2>Bu yazımda sadece emlak otomasyonunda istenilenler vardır. Bazı yanlışlarım veya kod tekrarlarım olabilir.</h2>
Giriş Bilgileri => Kullanıcı Adı: eray Şifre: 123
<!-- /wp:heading -->

<!-- wp:paragraph -->
<p>Kurumsal bir emlak ofisi için istenen otomasyonun çekirdeğini oluşturacak bir yazılım geliştirmeniz istenmektedir. Bu nedenle nesneye yönelik programlama ilkelerine bağlı kalarak gerekli sınıfları bir sınıf kütüphanesi içinde kodlamanız istenmektedir. Oluşturacağınız Solution içinde iki ayrı proje açmalısınız. Birincisi ClassLibrary projesi, ikincisi otomasyonun arayüzünü oluşturacak Windows Forms Application projesi olmalıdır. Tasarlayacağınız sınıfları; windows uygulamasına kütüphane projesini import ederek veya derleme sonucu elde edeceğiniz dll dosyasını import ederek kullanmalısınız. Tek bir proje içinde geliştirilen uygulama geçersiz sayılacaktır. </p>
<!-- /wp:paragraph -->

<!-- wp:heading {"level":3} -->
<h3>CLASS LIBRARY PROJESİ </h3>
<!-- /wp:heading -->

<!-- wp:paragraph -->
<p>Ev Sınıfı Alanlar ( Fields ) OdaSayısı, KatNumarası, Semti, Alanı, Yapım Tarihi, Türü, aktif, emlak numarası, vb. Kiralık ev için Depozitosu, Kirası Satılık ev için Fiyatı Türü bilgisini enum olarak tanımlayın: Daire, Bahçeli, Dubleks, Müstakil, vb. Emlak numarası alanı her ev nesnesi için farklı olmalıdır. aktif alanı evin işlem sürecini göstermek için kullanılacaktır. Yani ev için halen müşteri aranıp aranmadığını gösterir. </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Özellikler ( Properties ) Tüm alanlar için uygun olarak property tanımlamalarını yazın. Set ve Get blokları içinde gerekli kontrolleri yazın. </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Örneğin:  Oda Sayısı alanı için negatif değer girilmemelidir. Böyle bir kullanım durumunda oda sayısı sıfır olarak atanmalı ve işlemin yapıldığı zaman ve girilmek istenen negatif değer LOG kaydı olarak bir metin dosyasına kaydedilsin. Pozitif geçerli bir değer ataması için de aynı loglama işlemi yapılsın. </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Yapım Tarihi bilgisini kullanarak evin yaşını hesaplayan bir property tanımlayın. </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Kurucu Metot ( Constructor ) Oda Sayısı, Kat Numarası, Semti, Alanı alanlarına ilk değer atamalarını yaparak Ev nesnesini oluşturan kurucu metot tanımlaması ekleyin. Ayrıca Kurucu metodu aşırı yükleyin ve farklı versiyonlarını da yazmalısınız. </p>
<!-- /wp:paragraph -->

<!-- wp:heading {"level":3} -->
<h3>Metotlar EvBilgileri  </h3>
<!-- /wp:heading -->

<!-- wp:paragraph -->
<p><br> Ev sınıfından türetilen bir nesneye ait olan bilgileri görüntüleyecek şekilde biçimlendirip geri döndürmelidir. Biçimlendirme işlemi için string.Format() metodunu kullanın. </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>FiyatHesapla room_cost.txt isimli dosyadan okunacak katsayı ile oda sayısını çarparak evin olası kira fiyatını hesaplayıp geri döndüren bir metot yazın. Eğer room_cost dosyası yoksa kullanılacak katsayı sabit 200 olarak kullanılsın. </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Kiralık Ev Sınıfı Kiralık Ev ve Ev sınıfları arasında  yani  ilişkisi vardır. Dolayısıyla Ev nesnesinin sahip olduğu tüm özelliklere Kiralık Ev nesnesi de sahip olmalıdır. </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>EvBilgileri Metodunu override edin ve kiralık ev bilgilerini geri döndürecek şekilde güncelleyin. Uygun kurucu metot tanımlamalarını yapın. </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Satılık Ev Sınıfı Satılık Ev ve Ev sınıfları arasında  yani  ilişkisi vardır. Dolayısıyla Ev nesnesinin sahip olduğu tüm özelliklere Satılık Ev nesnesi de sahip olmalıdır. </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>EvBilgileri Metodunu override edin ve satılık ev bilgilerini geri döndürecek şekilde güncelleyin. Uygun kurucu metot tanımlamalarını yapın. </p>
<!-- /wp:paragraph -->

<!-- wp:heading {"level":3} -->
<h3>WINDOWS FORMS APPLICATION PROJESİ </h3>
<!-- /wp:heading -->

<!-- wp:paragraph -->
<p>Emlakçının  • Yeni ev ekleme,  • Silme,  • Düzenleme ve  • Sorgulama-listeleme (en önemlisi) işlemlerinin yapılacağı ara-yüzleri içermelidir. Form tasarımları sizin yaratıcılığınıza bırakılmış olup özgün tasarımlar olmak zorundadır.  </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Program çalıştırıldığında ilk olarak Login Penceresi gelecek ve Kullanıcı Adı – Şifre eşleşmelerini “users.txt” dosyasından kontrol edilecektir. Yetkili bilinen bir kullanıcı ise Login formu kapatılarak; Ana Form açılacaktır. </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Kayıt Ekranı: Yeni eklenecek evle ilgili bilgiler bu form üzerinden gerekli kontroller yapılarak alınmalıdır. Burada kullanılacak kontroller ve tasarım olabildiğince kullanıcının işini kolaylaştırıcı şekilde ve hatayı en aza indirgeyecek şekilde seçilmelidir.  <br> Örneğin semt bilgisi seçilecek ile göre ilgili bir metin dosyasından okunarak doldurulacak bir combobox-tan seçilmelidir. Böylece kullanıcının manuel girişinde yapılacak hatalar önlenmiş olur. Kayıtlar 1000 sabit boyutlu ve türü Ev olan bir dizi içinde tutulmalıdır. Aynı zamanda sizin belirleyeceğiniz bir formatta kayıtlar “satilik.txt” ve “kiralik.txt” olmak üzere iki dosyada saklanmalı ve program kapatılıp yeniden açıldıktan sonra kayıtlara ulaşılabilmelidir. Format sizin tarafınızdan belirleneceği için başka projelerle benzerlik gösteremez. </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Sorgulama Ekranı: Emlakçının işini kolaylaştıran en önemli arayüzdür. Müşterinin isteklerine göre sorgulama yaparak; kayıtlar arasında uygun evleri arayıp bulan formdur. Sonuçlar bu form üzerinde listelenecek ve detaylarına ulaşmak için Kayıt Ekranına benzer bir form üzerinde kolay bir şekilde görüntülenebilmesi sağlanacaktır. Sorgulama esnasında sadece aktif durumda olan evler varsayılan olarak taranacaktır. Ancak opsiyonel olarak daha önce emlakçının elinde olan ama işlemi tamamlanmış evler de taranabilmelidir. </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Sorgulama Ekranından bulunan bir evin detaylarının görüntüleneceği Listeleme formu üzerinden düzenleme, silme ve arşivleme işlemeleri yapılabilmedir. Arşivleme işlemi ev nesnesini tamamen silmek yerine  değişkenin değerini true-dan false-a çekmek demektir. Tersi de mümkün olmalıdır. </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Listeleme Ekranından evin görüntülerine de ulaşılabilir olmalıdır. İlgili eve ait görüntülerin bulunduğu Windows klasörü, program içinden bir buton ile açılabilmelidir. </p>
<!-- /wp:paragraph -->
