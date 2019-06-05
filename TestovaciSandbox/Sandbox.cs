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
