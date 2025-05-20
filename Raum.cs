using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT32_Escape_Game
{
    public class Raum { 

        //Liste, um alle Räume zu speichern
        public static List<Raum> alleRaeume = new List<Raum>();
        private static bool alleZahlenGefunden = false;

        //Attribute
        public int Nr;
        public string Name;
        public bool Begehbar;
        private int versteckteZahl;
        private bool zahlGefunden;
        
        //Berechnete Eigenschaft (Charakter anwesend oder nicht?)
        public bool CharakterAnw { 
            get { if (Globals.aktuellerRaum == this)
                return true;
                return false;
            } 
        }

        //Konstruktor
        public Raum(int raumNr, string raumName, bool raumBegehbar, int zahl)
        {
            Nr = raumNr;
            Name = raumName;
            Begehbar = raumBegehbar;
            versteckteZahl = zahl;
            zahlGefunden = false;
        }

        //Statische Methode, um alle Räume zu erstellen
        public static void ErstelleRaeume()
        {
            //Liste leeren, falls sie bereits Räume enthält
            alleRaeume.Clear();
            
            //Erstelle die Bahnen der U-Bahn mit versteckten Zahlen
            alleRaeume.Add(new Raum(1, "Bahn 1", true, 1));
            alleRaeume.Add(new Raum(2, "Bahn 2", true, 2));
            alleRaeume.Add(new Raum(3, "Bahn 3", true, 3));
            alleRaeume.Add(new Raum(4, "Bahn 4", true, 4));
        }

        //Methoden
        public void RaumBetreten()
        {
            Globals.aktuellerRaum = this;
            Globals.ClearAndShowStatus();
        }
    }
}