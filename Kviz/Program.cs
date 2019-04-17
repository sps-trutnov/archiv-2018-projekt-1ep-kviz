using System;
using System.Collections.Generic;

namespace Kviz
{
    class Program
    {
        struct Odpoved
        {
            public string zneniOdpovedi;
            public bool spravnostOdpovedi;
        }

        struct Otazka
        {
            public string zneniOtazky;
            public List<Odpoved> mozneOdpovedi;
        }

        struct Vysledek
        {
            public string prezdivka;
            public uint skore;
        }

        // funkce tymu (1) Landspersky + Hnyk + Korcak

        // ---------------------------------------


        // funkce tymu (2) Karas + Knizek + Jindra + Dzjubinskij
        static void polozitOtazku(Otazka otazka)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(otazka.zneniOtazky);
            Console.ResetColor();
        }

        static void nabidnoutOdpovedi(Otazka otazka)
        {
           int moznost = 1;
            foreach (Odpoved odpoved in otazka.mozneOdpovedi)
            {
                Console.WriteLine(moznost + ") " + odpoved.zneniOdpovedi);
                moznost = moznost + 1;

                if (jeSpravnaOdpoved(ziskatOdpoved(), otazky[i]))
                {



                    ziskaneSkore += 1;
                }
            }
        }

    // -----------------------------------


    // funkce tymu (3) Lukas + Hepnar + Krejcar

    // ------------------------------------


    // funkce tymu (4) Gaspar + Janus + Janicek

    // ------------------------------------

    static void Main(string[] args)
        {
            Console.WriteLine(" V Í T E J T E   U   L A K A T O Š K V Í Z U ");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();

            // ukol tymu Landspersky + Hnyk + Korcak
            List<Otazka> otazky = nacistOtazky("kviz_data.txt");
            zamichatOtazky(otazky);
            // -------------------------------------

            int pocetLosovanychOtazek = Math.Min(10, otazky.Count);
            uint ziskaneSkore = 0;

            for(int i = 0; i < pocetLosovanychOtazek; i++)
            {
                // ukol tymu Karas + Knizek + Jindra
                polozitOtazku(otazky[i]);
                nabidnoutOdpovedi(otazky[i]);

                if(jeSpravnaOdpoved(ziskatOdpoved(), otazky[i]))
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
            if(umistilSe)
            {
                string prezdivka = ziskatPrezdivku();
                zapsatDoVysledku(prezdivka, ziskaneSkore, vysledky);
                zapsatNaDisk(vysledky);
            }
            // ----------------------------------

            Console.WriteLine();
            Console.WriteLine("Děkujeme za zahrání!");

            Console.CursorVisible = false;
            Console.ReadKey(true);
        }
    }
}
