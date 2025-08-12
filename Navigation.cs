using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExitGame;

namespace BFT32_Escape_Game
{
    static class Navigation
    {
        public static void ShowGameMenu(List<string> foundLetters, List<Lager.Raum> rooms)
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════");
            Console.WriteLine("            U-BAHN ESCAPE GAME");
            Console.WriteLine("═══════════════════════════════════════════════");
            Console.WriteLine("\nDu bist in der U-Bahn gefangen!");
            Console.WriteLine($"Gefundene Buchstaben: {string.Join(" | ", foundLetters)}");
            Console.WriteLine($"Fortschritt: {foundLetters.Count}/5 Buchstabengruppen");
            Console.WriteLine("\nVerfügbare Bahnen:");
            
            for (int i = 0; i < rooms.Count; i++)
            {
                string status = rooms[i].IstGefunden ? "(Buchstaben gefunden)" : "(Rätsel ungelöst)";
                Console.WriteLine($"{i + 1}. Bahn {rooms[i].BahnNummer} {status}");
            }
            
            Console.WriteLine();
            if (foundLetters.Count == 5)
            {
                Console.WriteLine("6. FINALES RÄTSEL LÖSEN (Alle Buchstaben gefunden!)");
            }
            else
            {
                Console.WriteLine($"6. Finales Rätsel (Noch {5 - foundLetters.Count} Buchstabengruppen fehlen)");
            }
            Console.WriteLine("7. Zurück zum Hauptmenü");
            
            Console.Write("\nWähle eine Option (1-7): ");
        }

        public static void HandleChoice(string choice, List<Lager.Raum> rooms, List<string> foundLetters)
        {
            switch (choice)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                    int roomIndex = int.Parse(choice) - 1;
                    if (roomIndex < rooms.Count)
                    {
                        Spiel.HandleBahn(int.Parse(choice), rooms, foundLetters);
                    }
                    else
                    {
                        Console.WriteLine("\nUngültige Bahn-Nummer!");
                        Console.ReadKey();
                    }
                    break;
                case "6":
                    Spiel.HandleLoesungswort(foundLetters);
                    break;
                case "7":
                    Spiel.Beenden();
                    break;
                default:
                    Console.WriteLine("\nUngültige Auswahl. Bitte wähle eine Zahl zwischen 1 und 7.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}