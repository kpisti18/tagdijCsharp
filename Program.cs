using System.Net;
using System.Threading.Channels;

namespace Kovacs_Istvan_01_console
{
    internal class Program
    {
        static List<Ugyfel> ugyfelek = new List<Ugyfel>();
        static List<Befizetes> befizetesek = new List<Befizetes>();
        static void Main(string[] args)
        {
            loadingUgyfel();
            loadingBefizetes();
            elso();
            masodik();
            harmadik();
            Console.WriteLine("Program vége!");
            Console.ReadKey();
        }

        private static void harmadik()
        {
            string legfiatalabb = ugyfelek.OrderBy(x => x.Szulev).FirstOrDefault().Nev;
            Console.WriteLine($"3. feladat: A legfiatalabb ügyfél: {legfiatalabb}");
        }

        private static void masodik()
        {
            ugyfelek.Where(x => x.Orsz.Equals("H")).ToList().ForEach(x => Console.WriteLine($"{x.Nev}: {x.Orsz}"));
        }

        private static void elso()
        {
            Console.WriteLine($"1. feladat: Ügyfelek száma: {ugyfelek.Count}");
        }

        private static void loadingBefizetes()
        {
            Database db = new Database();
            befizetesek.AddRange(db.getBefizetes());
        }

        private static void loadingUgyfel()
        {
            Database db = new Database();
            ugyfelek.AddRange(db.getUgyfel());           
        }
    }
}