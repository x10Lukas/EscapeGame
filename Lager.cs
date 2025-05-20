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
        }

        public static List<Raum> InitializeRooms()
        {
            return new List<Raum>
            {
                new Raum { 
                    BahnNummer = 1, 
                    VersteckteBuchstaben = "km", 
                    Hinweis = "Schaue unter dem Sitz in der ersten Reihe.",
                    IstGefunden = false
                },
                new Raum { 
                    BahnNummer = 2, 
                    VersteckteBuchstaben = "us", 
                    Hinweis = "Die Buchstaben sind an der Decke versteckt.",
                    IstGefunden = false
                },
                new Raum { 
                    BahnNummer = 3, 
                    VersteckteBuchstaben = "ln", 
                    Hinweis = "Überprüfe die Notbremse.",
                    IstGefunden = false
                },
                new Raum { 
                    BahnNummer = 4, 
                    VersteckteBuchstaben = "eo", 
                    Hinweis = "Sieh durch das letzte Fenster.",
                    IstGefunden = false
                }
            };
        }
    }
}
