using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        public static void vypsatVysledky(List<Vysledek> vysledky, string prezdivkaHrace)
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

                if (prezdivkaHrace != null && prezdivkaHrace == prezdivka)
                    Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine(" " + normovanaPrezdivka + "   " + normovaneSkore);

                if (prezdivkaHrace != null && prezdivkaHrace == prezdivka)
                    Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        #endregion

        #region Funkce tymu (1) Landspersky + Hnyk + Korcak
        public static List<Otazka> nacistOtazky(string cestaSouboru)
        {
            throw new NotImplementedException();
        }
        public static void zamichatOtazky(List<Otazka> otazky)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Funkce tymu (2) Karas + Knizek + Jindra + Dzjubinskij
        public static bool jeSpravnaOdpoved(int cisloOdpovedi, Otazka otazka)
        {
            throw new NotImplementedException();
        }
        public static void nabidnoutOdpovedi(Otazka otazka)
        {
            throw new NotImplementedException();
        }
        public static void polozitOtazku(Otazka otazka)
        {
            throw new NotImplementedException();
        }
        public static int ziskatOdpoved()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Funkce tymu (3) Lukas + Hepnar + Krejcar
        public static bool jeDostatecneVysoke(uint ziskaneSkore, List<Vysledek> vysledky)
        {
            throw new NotImplementedException();
        }
        public static List<Vysledek> nacistVysledky(string cestaSouboru)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Funkce tymu (4) Gaspar + Janus + Janicek + Kabrt
        public static void zapsatVysledky(List<Vysledek> vysledky, string cestaSouboru)
        {
            throw new NotImplementedException();
        }
        public static void zaraditDoVysledku(string prezdivka, uint ziskaneSkore, List<Vysledek> vysledky)
        {
            throw new NotImplementedException();
        }
        public static string ziskatPrezdivku()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Hlavni program
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine(" V Í T E J T E   U   L A K A T O Š K V Í Z U ");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();

            // ukol tymu (1) Landspersky + Hnyk + Korcak
            List<Otazka> otazky = nacistOtazky("kviz_data.txt");
            zamichatOtazky(otazky);
            // -------------------------------------

            int pocetLosovanychOtazek = Math.Min(10, otazky.Count);
            uint ziskaneSkore = 0;

            for (int i = 0; i < pocetLosovanychOtazek; i++)
            {
                // ukol tymu (2) Karas + Knizek + Jindra
                polozitOtazku(otazky[i]);
                nabidnoutOdpovedi(otazky[i]);

                if (jeSpravnaOdpoved(ziskatOdpoved(), otazky[i]))
                {
                    ziskaneSkore += 1;
                }
                // ---------------------------------
            }

            // ukol tymu (3) Lukas + Hepnar + Krejcar
            List<Vysledek> vysledky = nacistVysledky("kviz_skore.txt");
            bool umistilSe = jeDostatecneVysoke(ziskaneSkore, vysledky);
            // ----------------------------------

            // ukol tymu (4) Gaspar + Janus + Janicek + Kabrt
            string prezdivka = null;

            if (umistilSe)
            {
                prezdivka = ziskatPrezdivku();
                zaraditDoVysledku(prezdivka, ziskaneSkore, vysledky);
                zapsatVysledky(vysledky, "kviz_skore.txt");
            }
            // ----------------------------------

            Console.Clear();
            vypsatVysledky(vysledky, prezdivka);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" (C) Ikonu vytvořil Freepik z webu www.flaticon.com");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine(" Děkujeme za zahrání!");

            Console.CursorVisible = false;
            Console.ReadKey(true);
        }
        #endregion
    }
}
