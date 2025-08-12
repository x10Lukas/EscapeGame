using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExitGame
{
    public class Lager
    {
        public string Name;
        public string Beschreibung;
        public List<Raum> Ausgaenge;
        public List<string> Gegenstaend;
        public class Raum
        {
            public int BahnNummer { get; set; }
            public string VersteckteBuchstaben { get; set; }
            public bool IstGefunden { get; set; }
            public string Hinweis { get; set; }
            public string Raetsel { get; set; }
            public string RaetselAntwort { get; set; }
        }

        public static List<Raum> InitializeRooms()
        {
            return new List<Raum>
            {
                new Raum { 
                    BahnNummer = 1, 
                    VersteckteBuchstaben = "ERT", 
                    Hinweis = "Ein Rätsel versperrt dir den Weg zu den Buchstaben...",
                    Raetsel = "Was ist 15 + 27?",
                    RaetselAntwort = "42",
                    IstGefunden = false
                },
                new Raum { 
                    BahnNummer = 2, 
                    VersteckteBuchstaben = "ALB", 
                    Hinweis = "Die Buchstaben sind hinter einem Zahlencode versteckt...",
                    Raetsel = "Wie viele Minuten hat eine Stunde?",
                    RaetselAntwort = "60",
                    IstGefunden = false
                },
                new Raum { 
                    BahnNummer = 3, 
                    VersteckteBuchstaben = "STE", 
                    Hinweis = "Ein physikalisches Rätsel blockiert deinen Zugang...",
                    Raetsel = "Welche Geschwindigkeit hat Licht? (in km/s, ohne Punkte)",
                    RaetselAntwort = "300000",
                    IstGefunden = false
                },
                new Raum { 
                    BahnNummer = 4, 
                    VersteckteBuchstaben = "EIN", 
                    Hinweis = "Das letzte Rätsel wartet auf dich...",
                    Raetsel = "In welchem Jahr wurde die Relativitätstheorie veröffentlicht?",
                    RaetselAntwort = "1905",
                    IstGefunden = false
                },
                new Raum { 
                    BahnNummer = 5, 
                    VersteckteBuchstaben = "IN", 
                    Hinweis = "Ein mathematisches Rätsel versperrt den Weg...",
                    Raetsel = "Was ist 8 × 7?",
                    RaetselAntwort = "56",
                    IstGefunden = false
                }
            };
        }
    }
}