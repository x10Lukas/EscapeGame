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
        private static int attempts = 0;
        private static bool hasHint = false;

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
            attempts = 0;
            hasHint = false;
        }

        public static void HandleBahn(int roomNumber, List<Lager.Raum> rooms, List<string> foundLetters)
        {
            var selectedRoom = rooms[roomNumber - 1];
            if (!selectedRoom.IstGefunden)
            {
                Console.Clear();
                Console.WriteLine($"═══════════════════════════════════════════════");
                Console.WriteLine($"            U-BAHN {selectedRoom.BahnNummer}");
                Console.WriteLine($"═══════════════════════════════════════════════");
                Console.WriteLine("Die Türen schließen sich hinter dir mit einem metallischen Klang.");
                Console.WriteLine("Geheimnisvolle Symbole leuchten an den Wänden auf...");
                Console.WriteLine($"\n{selectedRoom.Hinweis}");

                Console.WriteLine($"\nRÄTSEL: {selectedRoom.Raetsel}");
                Console.Write("\nDeine Antwort: ");
                
                string userAnswer = Console.ReadLine();

                if (userAnswer.ToLower() == selectedRoom.RaetselAntwort.ToLower())
                {
                    Console.WriteLine("\nRICHTIG!");
                    Console.WriteLine("Ein geheimer Mechanismus aktiviert sich...");
                    System.Threading.Thread.Sleep(1500);
                    
                    Console.WriteLine("Die Wand öffnet sich und gibt ein verstecktes Fach frei!");
                    selectedRoom.IstGefunden = true;
                    foundLetters.Add(selectedRoom.VersteckteBuchstaben);
                    Console.WriteLine($"\nERFOLG! Du hast die Buchstaben '{selectedRoom.VersteckteBuchstaben}' gefunden!");
                    Console.WriteLine("Mystisches Licht umhüllt die Buchstaben...");
                }
                else
                {
                    Console.WriteLine($"\nFalsch! Die richtige Antwort war: {selectedRoom.RaetselAntwort}");
                    Console.WriteLine("Die Buchstaben bleiben weiterhin versteckt...");
                    Console.WriteLine("Du musst diese Bahn später nochmals besuchen!");
                }
            }
            else
            {
                Console.WriteLine($"\nDu durchsuchst U-Bahn {selectedRoom.BahnNummer} erneut...");
                Console.WriteLine("Diese Bahn ist bereits gelöst. Die gefundenen Buchstaben schimmern geheimnisvoll.");
                Console.WriteLine($"Gefundene Buchstaben: '{selectedRoom.VersteckteBuchstaben}'");
            }

            Console.WriteLine("\nDrücke Enter zum Fortfahren...");
            Console.ReadLine();
        }

        public static void HandleLoesungswort(List<string> foundLetters)
        {
            if (foundLetters.Count < 5)
            {
                Console.WriteLine("\nDie Dunkelheit umhüllt dich!");
                Console.WriteLine($"Du hast erst {foundLetters.Count} von 5 Buchstabengruppen gefunden!");
                Console.WriteLine("Das finale Rätsel bleibt verschlossen...");
                Console.WriteLine("Erkunde alle U-Bahnen und löse ihre Rätsel!");
                Console.WriteLine("Drücke Enter zum Fortfahren...");
                Console.ReadLine();
                return;
            }

            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════");
            Console.WriteLine("            DAS FINALE RÄTSEL");
            Console.WriteLine("═══════════════════════════════════════════════");
            Console.WriteLine("\nEin berühmter Physiker, Nobelpreisträger und Genie:");
            Console.WriteLine("• Entwickelte die Relativitätstheorie");
            Console.WriteLine("• Seine Gleichung E=mc² ist weltbekannt");
            Console.WriteLine("• Gilt als größtes Genie des 20. Jahrhunderts");
            Console.WriteLine("• Hatte charakteristisch wilde Haare");
            
            Console.WriteLine($"\nDeine gefundenen Buchstaben: {string.Join(" | ", foundLetters)}");
            Console.WriteLine("Hinweis: Setze sie in der richtigen Reihenfolge zusammen!");

            if (attempts > 2 && !hasHint)
            {
                Console.WriteLine("\nZUSÄTZLICHER HINWEIS:");
                Console.WriteLine("   Vorname: A_____ (6 Buchstaben)");
                Console.WriteLine("   Nachname: E_______ (8 Buchstaben)");
                Console.WriteLine("   Geboren: 1879 in Deutschland");
                hasHint = true;
            }

            while (true)
            {
                Console.Write($"\nVersuch {attempts + 1} - Gib den Namen ein: ");
                var name = Console.ReadLine();
                attempts++;

                if (name.ToLower() == "albert einstein" || name.ToLower() == "alberteinstein")
                {
                    Console.Clear();
                    Console.WriteLine("HERZLICHEN GLÜCKWUNSCH!");
                    Console.WriteLine("═══════════════════════════════════════════════");
                    Console.WriteLine($"'{name}' ist absolut korrekt!");
                    Console.WriteLine("\nDie U-Bahn-Türen öffnen sich mit triumphalen Klängen!");
                    Console.WriteLine("Das Licht der Freiheit durchflutet alle Wagen!");
                    Console.WriteLine("DU BIST ERFOLGREICH ENTKOMMEN!");
                    Console.WriteLine($"\nStatistik: Gelöst in {attempts} Versuchen!");
                    Console.WriteLine("Du bist ein wahrer Rätselmeister!");
                    Console.WriteLine("\nDrücke Enter, um zum Hauptmenü zurückzukehren...");
                    Console.ReadKey();
                    Beenden();
                    return;
                }
                else
                {
                    Console.WriteLine($"\n'{name}' ist leider nicht korrekt!");

                    if (attempts == 1)
                        Console.WriteLine("Die U-Bahn erzittert bedrohlich... versuche es noch einmal!");
                    else if (attempts == 2)
                        Console.WriteLine("Die Lichter flackern wild... konzentriere dich!");
                    else if (attempts >= 3)
                        Console.WriteLine("Die Zeit wird knapp! Denke an einen berühmten Physiker!");

                    Console.WriteLine("Drücke Enter zum Fortfahren...");
                    Console.ReadLine();
                    
                    // Rätsel neu anzeigen
                    Console.Clear();
                    Console.WriteLine("═══════════════════════════════════════════════");
                    Console.WriteLine("            DAS FINALE RÄTSEL");
                    Console.WriteLine("═══════════════════════════════════════════════");
                    Console.WriteLine("\nEin berühmter Physiker, Nobelpreisträger und Genie:");
                    Console.WriteLine("• Entwickelte die Relativitätstheorie");
                    Console.WriteLine("• Seine Gleichung E=mc² ist weltbekannt");
                    Console.WriteLine("• Gilt als größtes Genie des 20. Jahrhunderts");
                    Console.WriteLine("• Hatte charakteristisch wilde Haare");
                    Console.WriteLine($"\nDeine gefundenen Buchstaben: {string.Join(" | ", foundLetters)}");

                    if (attempts > 2 && !hasHint)
                    {
                        Console.WriteLine("\nZUSÄTZLICHER HINWEIS:");
                        Console.WriteLine("   Vorname: A_____ (6 Buchstaben)");
                        Console.WriteLine("   Nachname: E_______ (8 Buchstaben)");
                        Console.WriteLine("   Geboren: 1879 in Deutschland");
                        hasHint = true;
                    }
                }
            }
        }

        public static void Beenden()
        {
            Program.Main();
        }
    }
}