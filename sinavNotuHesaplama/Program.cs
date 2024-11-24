using System;

class Program
{
    static void Main()
    {
        while (true)
        {

            Console.WriteLine("Not hesaplamak için 'H' veya çıkmak için 'E' girin:");
            string secim = Console.ReadLine().Trim().ToUpper();

            if (secim == "E")
            {

                Console.WriteLine("Programdan çıkılıyor...");
                break;
            }
            else if (secim == "H")
            {

                Console.Write("Dersin adı: ");
                string dersAdi = Console.ReadLine().Trim();


                int notSayisi;
                while (true)
                {
                    Console.Write("Kaç adet not gireceksiniz? ");
                    if (int.TryParse(Console.ReadLine(), out notSayisi) && notSayisi > 0)
                        break;
                    else
                        Console.WriteLine("Geçerli bir pozitif tamsayı girin.");
                }

                double toplamNot = 0;
                double toplamYuzde = 0;


                for (int i = 1; i <= notSayisi; i++)
                {
                    double not;
                    double yuzde;


                    while (true)
                    {
                        Console.Write($"Not {i}: ");
                        if (double.TryParse(Console.ReadLine(), out not) && not >= 0 && not <= 100)
                            break;
                        else
                            Console.WriteLine("Geçersiz giriş! Not 0 ile 100 arasında olmalıdır.");
                    }


                    while (true)
                    {
                        Console.Write($"Not {i} için yüzdesi (0 ile 100 arasında): ");
                        if (double.TryParse(Console.ReadLine(), out yuzde) && yuzde >= 0 && yuzde <= 100)
                            break;
                        else
                            Console.WriteLine("Geçersiz giriş! Yüzde 0 ile 100 arasında olmalıdır.");
                    }

                    toplamNot += not * (yuzde / 100);
                    toplamYuzde += yuzde;
                }


                if (toplamYuzde != 100)
                {
                    Console.WriteLine("Yüzdelerin toplamı 100 olmalıdır! Tekrar deneyin.");
                    continue;
                }


                char harfNotu = HesaplaHarfNotu(toplamNot);
                string gecisDurumu = harfNotu == 'F' ? "Kaldı" : "Geçti";


                Console.WriteLine($"\nDersin Adı: {dersAdi}");
                Console.WriteLine($"Not Ortalaması: {toplamNot:F2}");
                Console.WriteLine($"Harf Notu: {harfNotu}");
                Console.WriteLine($"Durum: {gecisDurumu}\n");
            }
            else
            {

                Console.WriteLine("Geçersiz seçim! Lütfen 'H' veya 'E' girin.");
            }
        }
    }


    static char HesaplaHarfNotu(double ortalama)
    {
        if (ortalama >= 90)
            return 'A';
        else if (ortalama >= 80)
            return 'B';
        else if (ortalama >= 70)
            return 'C';
        else if (ortalama >= 60)
            return 'D';
        else
            return 'F';
    }
}
