using System;
using System.Collections.Generic;
using System.IO;

using ProjektKviz;

namespace TestovaciSandbox
{
    class Program
    {
        // prostor pro testovani pdoprogramu
        static void Main(string[] args)
        {
            // priprava dat

            List<Kviz.Vysledek>mojeVysledky = new List<Kviz.Vysledek>();
            // vyzkouseni podprogramu
            Kviz.vypsatVysledky(mojeVysledky);

            // cekani na stisk klavesy
            Console.CursorVisible = false;
            Console.ReadKey(true);
        }
    }
}
