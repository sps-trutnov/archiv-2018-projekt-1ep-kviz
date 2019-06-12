using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kviz
{
    class Program
    {
        #region Pouzite pomocne datove struktury (pro vetsi pohodlnost psane jako class
        class Odpoved
        {
            public string ZneniOdpovedi { get; set; }
            public bool SpravnostOdpovedi { get; set; }
        }
        class Otazka
        {
            public string ZneniOtazky { get; set; }
            public List<Odpoved> MozneOdpovedi { get; set; }
        }
        class Vysledek
        {
            public string Prezdivka { get; set; }
            public uint Skore { get; set; }
        }
        #endregion

        #region Ukazka pomocne funkce
        static void vypsatVysledky(List<Vysledek> vysledky)
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
        static List<Otazka> NacistOtazky(string jmenoSouboruSOtazkami)
        {
            Console.WriteLine("Vypisuji soubor:");
            Otazka o  = new Otazka();



            using (System.IO.StreamReader sr = new System.IO.StreamReader(jmenoSouboruSOtazkami))
            {
                string s;
                Otazka O = new Otazka(); // otazka se vytvari "zbytecne"
                Odpoved d;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                    if (s.EndsWith("?"))
                    {
                        o = new Otazka();
                        o.ZneniOtazky = s;
                        o.MozneOdpovedi = new List<Odpoved>();

                    }
                    else if (s.EndsWith("*"))
                    {
                        d = new Odpoved();
                        d.ZneniOdpovedi = s;
                        d.SpravnostOdpovedi = true;
                        o.MozneOdpovedi.Add(d);
                    }
                    else
                    {
                        d = new Odpoved();
                        d.ZneniOdpovedi = s;
                        d.SpravnostOdpovedi = false;
                        o.MozneOdpovedi.Add(d);
                    }
                }
            }
            Console.ReadKey();

            return new List<Otazka>();
        }

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
            List<Otazka> otazky = NacistOtazky("kviz_data.txt");
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
