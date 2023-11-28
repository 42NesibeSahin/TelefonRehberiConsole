using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta_1
{
    class Kisi
    {
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string TelefonNumarasi { get; set; }
        public Kisi(string isim, string soyisim, string telefon)
        {
            Isim = isim;
            Soyisim = soyisim;
            TelefonNumarasi = telefon;
        }
    }
    class Program
	{
        static List<Kisi> rehber = new List<Kisi>
        {
            new Kisi("Ahmet", "Yılmaz", "1234567890"),
            new Kisi("Ayşe", "Demir", "2345678901"),
            new Kisi("Mehmet", "Kara", "3456789012"),
            new Kisi("Fatma", "Aydın", "4567890123"),
            new Kisi("Ali", "Çelik", "5678901234")
        };

        static void Main(string[] args)
		{
            while (true)
            {
                
                Console.WriteLine("*******************************************");
                Console.WriteLine("(1) Yeni Numara Kaydetmek");
                Console.WriteLine("(2) Varolan Numarayı Silmek");
                Console.WriteLine("(3) Varolan Numarayı Güncelleme");
                Console.WriteLine("(4) Rehberi Listelemek");
                Console.WriteLine("(5) Rehberde Arama Yapmak");
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        YeniNumaraKaydet();
                        break;
                    case "2":
                        NumaraSil();
                        break;
                    case "3":
                        NumaraGuncelle();
                        break;
                    case "4":
                        RehberiListele();
                        break;
                    case "5":
                        RehberdeAramaYap();
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                        break;
                }
            }

        }

       
        static void YeniNumaraKaydet()
        {
            Console.Write("Lütfen isim giriniz: ");
            string isim = Console.ReadLine();

            Console.Write("Lütfen soyisim giriniz: ");
            string soyisim = Console.ReadLine();

            Console.Write("Lütfen telefon numarası giriniz: ");
            string telefonNumarasi = Console.ReadLine();

            rehber.Add(new Kisi(isim, soyisim, telefonNumarasi));
            Console.WriteLine("Numara başarıyla kaydedildi.");
        }

        static void NumaraSil()
        {
            Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string aramaKelimesi = Console.ReadLine();

            var bulunanKisiler = rehber.Where(kisi => kisi.Isim.Contains(aramaKelimesi) || kisi.Soyisim.Contains(aramaKelimesi)).ToList();

            if (bulunanKisiler.Count == 0)
            {
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("(1) Silmeyi sonlandırmak için");
                Console.WriteLine("(2) Yeniden denemek için");
                string secim = Console.ReadLine();

                if (secim == "1")
                    return;
            }
            else
            {
                Kisi silinecekKisi = bulunanKisiler.First();
                Console.Write($"{silinecekKisi.Isim} isimli kişi rehberden silinmek üzere, onaylıyor musunuz? (y/n): ");
                string onay = Console.ReadLine();

                if (onay.ToLower() == "y")
                {
                    rehber.Remove(silinecekKisi);
                    Console.WriteLine($"{silinecekKisi.Isim} isimli kişi rehberden silindi.");
                }
                else
                    Console.WriteLine("Silme işlemi iptal edildi.");
            }
        }

       
        static void NumaraGuncelle()
        {
            Console.Write("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string aramaKelimesi = Console.ReadLine();

            var bulunanKisiler = rehber.Where(kisi => kisi.Isim.Contains(aramaKelimesi) || kisi.Soyisim.Contains(aramaKelimesi)).ToList();

            if (bulunanKisiler.Count == 0)
            {
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("(1) Güncellemeyi sonlandırmak için");
                Console.WriteLine("(2) Yeniden denemek için");
                string secim = Console.ReadLine();

                if (secim == "1")
                    return;
            }
            else
            {
                Kisi guncellenecekKisi = bulunanKisiler.First();

                Console.WriteLine("Yeni bilgileri giriniz:");

                Console.Write("Lütfen isim giriniz: ");
                string yeniIsim = Console.ReadLine();

                Console.Write("Lütfen soyisim giriniz: ");
                string yeniSoyisim = Console.ReadLine();

                Console.Write("Lütfen telefon numarası giriniz: ");
                string yeniTelefonNumarasi = Console.ReadLine();

                // Güncelleme işlemi
                guncellenecekKisi.Isim = yeniIsim;
                guncellenecekKisi.Soyisim = yeniSoyisim;
                guncellenecekKisi.TelefonNumarasi = yeniTelefonNumarasi;

                Console.WriteLine($"{guncellenecekKisi.Isim} isimli kişi başarıyla güncellendi.");
            }
        }


        static void RehberiListele()
        {
            Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("**********************************************");

            foreach (var kisi in rehber)
                Console.WriteLine($"isim: {kisi.Isim}, Soyisim: {kisi.Soyisim}, Telefon Numarası: {kisi.TelefonNumarasi}");
        }

        static void RehberdeAramaYap()
        {
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
            Console.WriteLine("**********************************************");
            Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
            Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");

            string aramaSecim = Console.ReadLine();

            switch (aramaSecim)
            {
                case "1":
                    IsimSoyisimArama();
                    break;
                case "2":
                    TelefonNumarasiArama();
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim. Program sonlandırılıyor.");
                    break;
            }
        }

        static void IsimSoyisimArama()
        {
            Console.WriteLine("Lütfen isim veya soyisim giriniz:");
            string aramaKelimesi = Console.ReadLine();

            var bulunanKisiler = rehber.Where(kisi => kisi.Isim.Contains(aramaKelimesi) || kisi.Soyisim.Contains(aramaKelimesi)).ToList();

            if (bulunanKisiler.Count == 0)
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı.");
            else
            {
                Console.WriteLine("Arama Sonuçlarınız:");
                Console.WriteLine("**********************************************");

                foreach (var kisi in bulunanKisiler)
                    Console.WriteLine($"isim: {kisi.Isim} Soyisim: {kisi.Soyisim} Telefon Numarası: {kisi.TelefonNumarasi}");

                Console.WriteLine("**********************************************");
            }
        }

        static void TelefonNumarasiArama()
        {
            Console.WriteLine("Lütfen telefon numarası giriniz:");
            string aramaKelimesi = Console.ReadLine();

            var bulunanKisiler = rehber.Where(kisi => kisi.TelefonNumarasi.Contains(aramaKelimesi)).ToList();

            if (bulunanKisiler.Count == 0)
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı.");
            else
            {
                Console.WriteLine("Arama Sonuçlarınız:");
                Console.WriteLine("**********************************************");

                foreach (var kisi in bulunanKisiler)
                    Console.WriteLine($"isim: {kisi.Isim} Soyisim: {kisi.Soyisim} Telefon Numarası: {kisi.TelefonNumarasi}");
                Console.WriteLine("**********************************************");
            }
        }

    }
}

