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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(otazka.zneniOtazky);
            Console.ResetColor();
        }

        static void nabidnoutOdpovedi(Otazka otazka)
        {
           int moznost = 1;
            foreach (Odpoved odpoved in otazka.mozneOdpovedi)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(moznost + ") " + odpoved.zneniOdpovedi);
                moznost = moznost + 1;
                Console.ResetColor();
            }
        }
                               //int odkud, int kam
        static int ziskatOdpoved()
        {
            Console.Write("Zadej cislo odpovedi: ");
            string nakaPromenna = Console.ReadLine();

            int CiselOdpoved = Convert.ToInt32(nakaPromenna);

            do
            {
                

            } while (CiselOdpoved <= 4);

            return CiselOdpoved;
        }
        
        static int JeSpravnaOdpoved(CiselOdpoved)
        {
            // udelat promenou na pravnou odpoved
            // pokud zadá neco jinyho nez cislo uvedeny v otazkach, upozornit
            // a zopakovat otazku
            do
            {
                Console.WriteLine("Nenapsal jsi cislo odpovedi");

            } while ();
        }   
        
    // -----------------------------------


    // funkce tymu (3) Lukas + Hepnar + Krejcar

    // ------------------------------------


    // funkce tymu (4) Gaspar + Janus + Janicek

    // ------------------------------------

    static void Main(string[] args)
        {
            // priprava dat
            Otazka ot;
            ot.zneniOtazky = "Je toto funkční cvičná otázka?";
            ot.mozneOdpovedi = new List<Odpoved>();

            Odpoved od1;
            od1.zneniOdpovedi = "První odpověď";
            od1.spravnostOdpovedi = false;

            Odpoved od2;
            od2.zneniOdpovedi = "Druhá odpověď";
            od2.spravnostOdpovedi = true;

            Odpoved od3;
            od3.zneniOdpovedi = "Tretí odpověď";
            od3.spravnostOdpovedi = false;

            ot.mozneOdpovedi.Add(od1);
            ot.mozneOdpovedi.Add(od2);
            ot.mozneOdpovedi.Add(od3);

            // otestovani podprogramu (funkce)
            polozitOtazku(ot);
            nabidnoutOdpovedi(ot);
            ziskatOdpoved();



            Console.ReadKey();

            //// pozastaveni do stisku klavesy (abych videl vypis)
            //Console.ReadKey();

            //Console.WriteLine(" V Í T E J T E   U   L A K A T O Š K V Í Z U ");
            //Console.WriteLine("---------------------------------------------");
            //Console.WriteLine();

            //// ukol tymu Landspersky + Hnyk + Korcak
            //List<Otazka> otazky = nacistOtazky("kviz_data.txt");
            //zamichatOtazky(otazky);

            //// -------------------------------------

            //int pocetLosovanychOtazek = Math.Min(10, otazky.Count);
            //uint ziskaneSkore = 0;

            //for (int i = 0; i < pocetLosovanychOtazek; i++)
            //{
            //    // ukol tymu Karas + Knizek + Jindra
            //    polozitOtazku(otazky[i]);
            //    nabidnoutOdpovedi(otazky[i]);

            //    if (jeSpravnaOdpoved(ziskatOdpoved(), otazky[i]))
            //    {
            //        ziskaneSkore += 1;
            //    }
            //    // ---------------------------------
            //}

            //// ukol tymu Lukas + Hepnar + Krejcar
            //List<Vysledek> vysledky = nacistVysledky("kviz_skore.txt");
            //bool umistilSe = jeDostatecneVysoke(ziskaneSkore, vysledky);
            //// ----------------------------------

            //// ukol tymu Gaspar + Janus + Janicek
            //if (umistilSe)
            //{
            //    string prezdivka = ziskatPrezdivku();
            //    zapsatDoVysledku(prezdivka, ziskaneSkore, vysledky);
            //    zapsatNaDisk(vysledky);
            //}
            //// ----------------------------------

            //Console.WriteLine();
            //Console.WriteLine("Děkujeme za zahrání!");

            //Console.CursorVisible = false;
            //Console.ReadKey(true);
        }
    }
}
