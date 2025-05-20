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
            Console.WriteLine("\nDu bist in der U-Bahn gefangen!");
            Console.WriteLine("Gefundene Buchstaben: " + string.Join("", foundLetters));
            Console.WriteLine("\nVerfügbare Bahnen:");
            
            for (int i = 0; i < rooms.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Bahn {rooms[i].BahnNummer}" + 
                    (rooms[i].IstGefunden ? " (Buchstaben bereits gefunden)" : ""));
            }
            
            if (foundLetters.Count == 4)
            {
                Console.WriteLine("\n5. Rätsel lösen");
            }
            else
            {
                Console.WriteLine("\n5. Rätsel lösen (noch nicht verfügbar)");
            }
            Console.WriteLine("6. Zurück zum Hauptmenü");
            
            Console.Write("\nWähle eine Option: ");
        }

        public static void HandleChoice(string choice, List<Lager.Raum> rooms, List<string> foundLetters)
        {
            switch (choice)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                    Spiel.HandleBahn(int.Parse(choice), rooms, foundLetters);
                    break;
                case "5":
                    Spiel.HandleLoesungswort(foundLetters);
                    break;
                case "6":
                    Spiel.Beenden();
                    break;
                default:
                    Console.WriteLine("\nUngültige Auswahl. Bitte versuchen Sie es erneut.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
