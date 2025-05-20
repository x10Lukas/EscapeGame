using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT32_Escape_Game
{
    static class Menue
    {
        public static void MenueAnzeigen()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Herzlich Willkommen zum U-Bahn Escape Game. Bitte wählen Sie eine Option:");
                Console.WriteLine("\n1. Spiel beginnen");
                Console.WriteLine("2. Spielanleitung");
                Console.WriteLine("3. Beenden");
                Console.Write("\nBitte geben Sie eine Zahl ein: ");
                
                string auswahl = Console.ReadLine();

                switch (auswahl)
                {
                    case "1":
                        Spiel.Spielstart();
                        break;
                    case "2":
                        ZeigeAnleitung();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("\nUngültige Auswahl. Bitte versuchen Sie es erneut.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void ZeigeAnleitung()
        {
            Console.Clear();
            Console.WriteLine("=== Spielanleitung ===");
            Console.WriteLine("Du bist in einer U-Bahn gefangen und musst entkommen!");
            Console.WriteLine("In jeder Bahn sind Buchstaben versteckt, die du finden musst.");
            Console.WriteLine("Wenn du alle Buchstaben gefunden hast, kannst du das Rätsel lösen.");
            Console.WriteLine("Das Rätsel führt dich zur Lösung und damit zur Flucht!");
            Console.WriteLine("\nDrücke Enter zum Fortfahren...");
            Console.ReadLine();
        }
    }
}
