using System;
using System.Collections.Generic;
using System.IO;

using ProjektKviz;

namespace TestovaciSandbox
{
    class Sandbox
    {
        // prostor pro testovani podprogramu
        static void Main(string[] args)
        {

            public static List<Vysledek> NacistVysledky(string jmenoSouboruSVysledky)
            {
                NacistVysledky = File.ReadAllLines(jmenoSouboruSVysledky);


            }

            public static bool JeDostatecneVysoke(uint skore, List<Vysledek> vysledky)
            {
                int x;
                x = vysledky.Count;

                int minSkoreVTabulceVysledku = (int)vysledky[x - 1].Skore;

                return minSkoreVTabulceVysledku;


                if MinSkoreVTabulceVysledku < skore do

                        PrecistVysledek = Console.ReadLine(String Prezdivka, uint Skore);



                     ZapsatVysledek = Console.WriteLine(PrecistVysledek, List<Vysledek>);
                // priprava dat
                List<Kviz.Vysledek> testovaciVysledky = new List<Kviz.Vysledek>();

            // vyzkouseni podprogramu
            Kviz.VypsatVysledky(testovaciVysledky, "Hráč");

            // cekani na stisk klavesy
            Console.CursorVisible = false;
            Console.ReadKey(true);
        }
    }
}
