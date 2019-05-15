using System;
using System.Collections.Generic;
using System.IO;

namespace ProjektKviz
{
    public class Kviz
    {
        #region Pouzite pomocne datove struktury (pro vetsi pohodlnost psane jako class)
        public class Odpoved
        {
            public string zneniOdpovedi { get; set; }
            public bool spravnostOdpovedi { get; set; }
        }
        public class Otazka
        {
            public string zneniOtazky { get; set; }
            public List<Odpoved> mozneOdpovedi { get; set; }
        }
        public class Vysledek
        {
            public string prezdivka { get; set; }
            public uint skore { get; set; }
        }
        #endregion

        #region Ukazka pomocne funkce
        public static void vypsatVysledky(List<Vysledek> vysledky)
        {
            Console.WriteLine();
            Console.WriteLine(" Největší znalci Lakatoše ");
            Console.WriteLine("--------------------------");
            Console.WriteLine();

            foreach (Vysledek vysledek in vysledky)
            {
                string prezdivka = vysledek.prezdivka;
                string skore = vysledek.skore.ToString();

                string vyplnPrezdivky = Enumerable.Repeat<string>(" ", 15 + 1 - prezdivka.Length).Aggregate((skladanka, dalsi) => skladanka + dalsi);
                string vyplnSkore = Enumerable.Repeat<string>(" ", 1000.ToString().Length + 1 - skore.ToString().Length).Aggregate<string>((skladanka, dalsi) => skladanka + dalsi);

                string normovanaPrezdivka = prezdivka + vyplnPrezdivky;
                string normovaneSkore = vyplnSkore + skore;


                Console.WriteLine(" " + normovanaPrezdivka + "   " + normovaneSkore);
            }

            Console.CursorVisible = false;
            Console.ReadKey();
        }
        #endregion

        #region Funkce tymu (1) Landspersky + Hnyk + Korcak

        #endregion

        #region Funkce tymu (2) Karas + Knizek + Jindra + Dzjubinskij

        #endregion

        #region Funkce tymu (3) Lukas + Hepnar + Krejcar + Kabrt

        #endregion

        #region Funkce tymu (4) Gaspar + Janus + Janicek

        #endregion

        #region Hlavni program
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine(" V Í T E J T E   U   L A K A T O Š K V Í Z U ");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();

            // ukol tymu Landspersky + Hnyk + Korcak
            List<Otazka> otazky = nacistOtazky("kviz_data.txt");
            zamichatOtazky(otazky);
            // -------------------------------------

            int pocetLosovanychOtazek = Math.Min(10, otazky.Count);
            uint ziskaneSkore = 0;

            for (int i = 0; i < pocetLosovanychOtazek; i++)
            {
                // ukol tymu Karas + Knizek + Jindra
                polozitOtazku(otazky[i]);
                nabidnoutOdpovedi(otazky[i]);

                if (jeSpravnaOdpoved(ziskatOdpoved(), otazky[i]))
                {
                    ziskaneSkore += 1;
                }
                // ---------------------------------
            }

            // ukol tymu Lukas + Hepnar + Krejcar
            List<Vysledek> vysledky = nacistVysledky("kviz_skore.txt");
            bool umistilSe = jeDostatecneVysoke(ziskaneSkore, vysledky);
            // ----------------------------------

            // ukol tymu Gaspar + Janus + Janicek
            if (umistilSe)
            {
                string prezdivka = ziskatPrezdivku();
                zaraditDoVysledku(prezdivka, ziskaneSkore, vysledky);
                zapsatVysledky(vysledky, "kviz_skore.txt");
            }
            // ----------------------------------

            Console.Clear();
            vypsatVysledky(vysledky);

            Console.WriteLine();
            Console.WriteLine(" Děkujeme za zahrání!");

            Console.CursorVisible = false;
            Console.ReadKey(true);
        }
        #endregion
    }
}
