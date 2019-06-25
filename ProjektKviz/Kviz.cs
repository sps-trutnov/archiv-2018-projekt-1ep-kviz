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
            public string ZneniOdpovedi { get; set; }
            public bool SpravnostOdpovedi { get; set; }
        }
        public class Otazka
        {
            public string ZneniOtazky { get; set; }
            public List<Odpoved> MozneOdpovedi { get; set; }
        }
        public class Vysledek
        {
            public string Prezdivka { get; set; }
            public uint Skore { get; set; }
        }
        #endregion

        #region Ukazka pomocne funkce
        public static void VypsatVysledky(List<Vysledek> vysledky, string prezdivkaHrace)
        {
            Console.WriteLine();
            Console.WriteLine(" Největší znalci Lakatoše ");
            Console.WriteLine("--------------------------");
            Console.WriteLine();

            foreach (Vysledek vysledek in vysledky)
            {
                string prezdivka = vysledek.Prezdivka;
                string skore = vysledek.Skore.ToString();

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
        public static void ZamichatOtazkamOdpovedi(List<Otazka> otazky)
        {
            foreach (Otazka otazka in otazky)
            {
                Random nahoda = new Random();

                for (int i = 0; i < otazka.MozneOdpovedi.Count; i++)
                {
                    int j = nahoda.Next(otazka.MozneOdpovedi.Count);

                    Odpoved o = otazka.MozneOdpovedi[i];
                    otazka.MozneOdpovedi[i] = otazka.MozneOdpovedi[j];
                    otazka.MozneOdpovedi[j] = o;
                }
            }
        }
        #endregion

        #region Funkce tymu (1) Landspersky + Hnyk + Korcak
        public static List<Otazka> NacistOtazky(string jmenoSouboruSOtazkami)
        {
            Console.WriteLine("Vypisuji soubor:");

            List<Otazka> vysledek = new List<Otazka>();
            Otazka o = new Otazka();

            using (System.IO.StreamReader sr = new System.IO.StreamReader(jmenoSouboruSOtazkami))
            {
                string s;
                Odpoved d;
                while ((s = sr.ReadLine()) != null)
                {

                    if (s.EndsWith("?"))
                    {
                        o = new Otazka();
                        o.ZneniOtazky = s;
                        o.MozneOdpovedi = new List<Odpoved>();

                    }
                    else if (s.EndsWith("*"))
                    {
                        d = new Odpoved();
                        d.ZneniOdpovedi = s.Substring(0, s.Length - 1); 
                        d.SpravnostOdpovedi = true;
                        o.MozneOdpovedi.Add(d);
                        vysledek.Add(o);
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

            return vysledek;
        }
        public static void ZamichatOtazky(List<Otazka> otazky)
        {
            Random nahoda = new Random();

            for (int i = 0; i < otazky.Count; i++)
            {
                int j = nahoda.Next(otazky.Count);

                Otazka o = otazky[i];
                otazky[i] = otazky[j];
                otazky[j] = o;
            }
        }
        #endregion

        #region Funkce tymu (2) Karas + Knizek + Jindra + Dzjubinskij
        public static void PolozitOtazku(Otazka otazka)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(otazka.ZneniOtazky);
            Console.ResetColor();
        }
        public static void NabidnoutOdpovedi(Otazka otazka)
        {
            int moznost = 1;
            foreach (Odpoved odpoved in otazka.MozneOdpovedi)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(moznost + ") " + odpoved.ZneniOdpovedi);
                moznost = moznost + 1;
                Console.ResetColor();
            }
        }
        public static int ZiskatOdpoved()
        {
            int CiselOdpoved;

            do
            {
                // Dokud nezvoli odpoved 1-4, nepusti ho to dal

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Zadej cislo odpovedi: ");
                Console.ResetColor();

                string nakaPromenna = Console.ReadLine();

                CiselOdpoved = Convert.ToInt32(nakaPromenna);

            } while (CiselOdpoved <= 4 && CiselOdpoved > 0);

            return CiselOdpoved;
        }
        public static bool JeSpravnaOdpoved(int cisloOdpovedi, Otazka otazka)
        {
            // udelat funkci na pravdivost odpovedi

            bool jeSpravna = otazka.MozneOdpovedi[cisloOdpovedi - 1].SpravnostOdpovedi;

            if (jeSpravna == true)
                return true;
            else
                return false;
        }
        #endregion

        #region Funkce tymu (3) Lukas + Hepnar + Krejcar
        public static List<Vysledek> NacistVysledky(string cestaSouboru)
        {
            List<Vysledek> seznamVysledku = new List<Vysledek>();
            string[] radkySouboru = File.ReadAllLines(cestaSouboru);

            int i = 0;

            do
            {
                string aktualniRadek = radkySouboru[i];
                int mezeravRadku = aktualniRadek.IndexOf(' ');

                string prezdivka = aktualniRadek.Substring(0, mezeravRadku);
                string skore = aktualniRadek.Substring(mezeravRadku + 1);

                Vysledek V;
                V = new Vysledek();
                V.Prezdivka = prezdivka;
                V.Skore = Convert.ToUInt32(skore);

                seznamVysledku.Add(V);
                i = i + 1;

            } while (i < radkySouboru.Length);

            return seznamVysledku;
        }
        public static bool JeDostatecneVysoke(uint skore, List<Vysledek> vysledky)
        {
            int x;
            x = vysledky.Count;

            int minSkoreVTabulceVysledku = (int)vysledky[x - 1].Skore;

            if (minSkoreVTabulceVysledku < skore)
                return true;
            else
                return false;
        }
        #endregion

        #region Funkce tymu (4) Gaspar + Janus + Janicek + Kabrt
        public static string ZiskatPrezdivku()
        {
            Console.WriteLine("Zadejte přezdívku: ");
            string prezdivka = Console.ReadLine();

            return prezdivka;
        }
        public static void ZaraditDoVysledku(string prezdivka, uint ziskaneSkore, List<Vysledek> vysledky)
        {
            Vysledek v = new Vysledek();
            v.Prezdivka = prezdivka;
            v.Skore = ziskaneSkore;

            int x = 0;
            if (vysledky[x].Skore > ziskaneSkore)
                x = x + 1;
            else
            {
                vysledky.Insert(x, v);
            }

            int p = vysledky.Count();
            vysledky.RemoveAt(p - 1);

        }
        public static void ZapsatVysledky(List<Vysledek> vysledky, string cestaSouboru)
        {
            int x = 0;
            int p = vysledky.Count();
            string zapsat = "";
            do
            {
                zapsat = zapsat + vysledky[x].Prezdivka + " " + vysledky[x].Skore + "\n";
                x += 1;
            }
            while (x < p);

            File.WriteAllText(cestaSouboru, zapsat);
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
            List<Otazka> otazky = NacistOtazky("kviz_data.txt");
            ZamichatOtazky(otazky);
            // -------------------------------------
            ZamichatOtazkamOdpovedi(otazky);

            int pocetLosovanychOtazek = Math.Min(10, otazky.Count);
            uint ziskaneSkore = 0;

            for (int i = 0; i < pocetLosovanychOtazek; i++)
            {
                // ukol tymu (2) Karas + Knizek + Jindra
                PolozitOtazku(otazky[i]);
                NabidnoutOdpovedi(otazky[i]);

                if (JeSpravnaOdpoved(ZiskatOdpoved(), otazky[i]))
                {
                    ziskaneSkore += 1;
                }
                // ---------------------------------
            }

            // ukol tymu (3) Lukas + Hepnar + Krejcar
            List<Vysledek> vysledky = NacistVysledky("kviz_skore.txt");
            bool umistilSe = JeDostatecneVysoke(ziskaneSkore, vysledky);
            // ----------------------------------

            // ukol tymu (4) Gaspar + Janus + Janicek + Kabrt
            string prezdivka = null;

            if (umistilSe)
            {
                prezdivka = ZiskatPrezdivku();
                ZaraditDoVysledku(prezdivka, ziskaneSkore, vysledky);
                ZapsatVysledky(vysledky, "kviz_skore.txt");
            }
            // ----------------------------------

            Console.Clear();
            VypsatVysledky(vysledky, prezdivka);

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
