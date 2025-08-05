
namespace Patikafy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Şarkıcı listesi
            List<Singer> singers = new List<Singer>
            {
                new Singer { FullName = "Ajda Pekkan", MusicType = "Pop", DebutYear = 1968, AlbumSalesInMillions = 20 },
                new Singer { FullName = "Sezen Aksu", MusicType = "Türk Halk Müziği / Pop", DebutYear = 1971, AlbumSalesInMillions = 9 },
                new Singer { FullName = "Funda Arar", MusicType = "Pop", DebutYear = 1999, AlbumSalesInMillions = 3 },
                new Singer { FullName = "Sertab Erener", MusicType = "Pop", DebutYear = 1994, AlbumSalesInMillions = 4 },
                new Singer { FullName = "Sıla", MusicType = "Pop", DebutYear = 2009, AlbumSalesInMillions = 3 },
                new Singer { FullName = "Serdar Ortaç", MusicType = "Pop", DebutYear = 1994, AlbumSalesInMillions = 10 },
                new Singer { FullName = "Tarkan", MusicType = "Pop", DebutYear = 1992, AlbumSalesInMillions = 40 },
                new Singer { FullName = "Hande Yener", MusicType = "Pop", DebutYear = 2000, AlbumSalesInMillions = 7 },
                new Singer { FullName = "Hadise", MusicType = "Pop", DebutYear = 2005, AlbumSalesInMillions = 1 },
                new Singer { FullName = "Gülben Ergen", MusicType = "Pop / Türk Halk Müziği", DebutYear = 1997, AlbumSalesInMillions = 5 },
                new Singer { FullName = "Neşet Ertaş", MusicType = "Türk Halk Müziği / Türk Sanat Müziği", DebutYear = 1960, AlbumSalesInMillions = 2 },
            };

            // 'S' ile başlayan şarkıcılar
            var startsWithS = singers.Where(s => s.FullName.StartsWith("S"));
            Console.WriteLine("Adı 'S' ile başlayan şarkıcılar:");
            foreach (var s in startsWithS)
                Console.WriteLine(s.FullName);
            Console.WriteLine("-----------------------------");

            // Albüm satışı 10 milyondan fazla olanlar
            var salesOver10M = singers.Where(s => s.AlbumSalesInMillions > 10);
            Console.WriteLine("10 milyondan fazla satan şarkıcılar:");
            foreach (var s in salesOver10M)
                Console.WriteLine(s.FullName);
            Console.WriteLine("-----------------------------");

            // 2000'den önce çıkış yapmış ve pop müzik yapanlar
            var before2000AndPop = singers
                .Where(s => s.DebutYear < 2000 && s.MusicType.ToLower().Contains("pop"));
            Console.WriteLine("2000 öncesi çıkış yapmış ve pop müzik yapanlar:");
            foreach (var s in before2000AndPop)
                Console.WriteLine(s.FullName);
            Console.WriteLine("-----------------------------");

            // Çıkış yılına göre gruplama ve alfabetik sıralama
            var groupedByYear = singers
                .GroupBy(s => s.DebutYear)
                .OrderBy(g => g.Key);

            Console.WriteLine("Çıkış yılına göre gruplama:");
            foreach (var group in groupedByYear)
            {
                Console.WriteLine($"Yıl: {group.Key}");
                foreach (var s in group.OrderBy(x => x.FullName))
                    Console.WriteLine(" - " + s.FullName);
            }
            Console.WriteLine("-----------------------------");

            // En çok albüm satan şarkıcı
            var topSeller = singers.OrderByDescending(s => s.AlbumSalesInMillions).First();
            Console.WriteLine($"En çok satan şarkıcı: {topSeller.FullName} - {topSeller.AlbumSalesInMillions} milyon");
            Console.WriteLine("-----------------------------");

            // En yeni ve en eski çıkan şarkıcı
            var newest = singers.OrderByDescending(s => s.DebutYear).First();
            var oldest = singers.OrderBy(s => s.DebutYear).First();
            Console.WriteLine($"En yeni çıkan: {newest.FullName} ({newest.DebutYear})");
            Console.WriteLine($"En eski çıkan: {oldest.FullName} ({oldest.DebutYear})");
        }
    }
}
