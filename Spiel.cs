using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExitGame;

namespace BFT32_Escape_Game
{
    static class Spiel
    {
        private static List<string> foundLetters = new List<string>();
        private static List<Lager.Raum> rooms;

        public static List<string> GetFoundLetters() => foundLetters;
        public static List<Lager.Raum> GetRooms() => rooms;

        public static void Spielstart()
        {
            InitializeGame();
            
            while (true)
            {
                Navigation.ShowGameMenu(foundLetters, rooms);
                var choice = Console.ReadLine();
                Navigation.HandleChoice(choice, rooms, foundLetters);
            }
        }

        private static void InitializeGame()
        {
            rooms = Lager.InitializeRooms();
            foundLetters = new List<string>();
        }

        public static void HandleBahn(int roomNumber, List<Lager.Raum> rooms, List<string> foundLetters)
        {
            var selectedRoom = rooms[roomNumber - 1];
            if (!selectedRoom.IstGefunden)
            {
                Console.WriteLine($"\nDu bist in U-Bahn {selectedRoom.BahnNummer}");
                Console.WriteLine(selectedRoom.Hinweis);
                Console.WriteLine("\nMöchtest du nach den Buchstaben suchen? (j/n)");
                
                if (Console.ReadLine().ToLower() == "j")
                {
                    selectedRoom.IstGefunden = true;
                    foundLetters.Add(selectedRoom.VersteckteBuchstaben);
                    Console.WriteLine($"\nDu hast die Buchstaben {selectedRoom.VersteckteBuchstaben} gefunden!");
                }
            }
            else
            {
                Console.WriteLine("\nDu hast die Buchstaben in dieser Bahn bereits gefunden!");
            }
            
            Console.WriteLine("\nDrücke Enter zum Fortfahren...");
            Console.ReadLine();
        }

        public static void HandleLoesungswort(List<string> foundLetters)
        {
            if (foundLetters.Count < 4)
            {
                Console.WriteLine("\nDu musst erst alle Buchstaben finden, bevor du das Rätsel lösen kannst!");
                Console.WriteLine("Drücke Enter zum Fortfahren...");
                Console.ReadLine();
                return;
            }

            Console.Clear();
            Console.WriteLine("\nEr revolutionierte Elektroautos, eroberte den Weltraum und kaufte ein soziales Netzwerk." +
                            "\nTipp: Gesucht ist sein Bekannter Name.");
            Console.WriteLine("Die gefundenen Buchstaben sind: " + string.Join("", foundLetters));
            
            while (true)
            {
                Console.Write("\nLösungswort: ");
                var name = Console.ReadLine();
                
                if (name.ToLower() == "Elon Musk".ToLower())
                {
                    Console.WriteLine("\nGratulation! Du hast den richtigen Namen gefunden!");
                    Console.WriteLine("Du bist entkommen!");
                    Console.WriteLine("\nDrücke Enter, um zum Hauptmenü zurückzukehren...");
                    Console.ReadKey();
                    Beenden();
                    return;
                }
                else
                {
                    Console.WriteLine("\nFalscher Name! Versuche es noch einmal!");
                    Console.WriteLine("Drücke Enter zum Fortfahren...");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("\nEr revolutionierte Elektroautos, eroberte den Weltraum und kaufte ein soziales Netzwerk." +
                                    "\nTipp: Gesucht ist sein Bekannter Name.");
                    Console.WriteLine("Die gefundenen Buchstaben sind: " + string.Join("", foundLetters));
                }
            }
        }

        public static void Beenden()
        {
            Program.Main();
        }
    }
}
