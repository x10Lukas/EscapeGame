using System;
using System.Collections.Generic;

namespace BFT32_Escape_Game
{
    public static class Globals
    {
        public static Raum aktuellerRaum;
        public static List<string> gefundeneBuchstaben = new List<string>();
        public static bool gameover = false;

        public static void ClearAndShowStatus()
        {
            Console.Clear();
            Console.WriteLine($"Aktueller Raum: {(aktuellerRaum != null ? aktuellerRaum.Name : "Kein Raum")}");
            Console.WriteLine($"Gefundene Buchstaben: {string.Join("", gefundeneBuchstaben)}");
            Console.WriteLine();
        }
    }
}