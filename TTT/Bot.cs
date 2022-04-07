using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTT
{
    internal class Bot
    {
        public bool Enabled { get { return enabled; } } //Von auserhalb sollte darauf nur zugegriffen werden können. Nicht verändert

        private bool enabled = false; //Speichert ob der Bot aktiviert ist
        private bool easy = false; //Speichert ob easymode genommen worden ist
        private bool normal = false; //Speichert ob normalmode genommen worden ist
        private bool hard = false; //Speichert ob hardmode genommen worden ist


        private IDictionary<string, int> whatToDo = new Dictionary<string, int>(); //Löst anhand dem currentState String was gemacht werden muss // Je nach key wird gesetzt


        private ArrayList buttons; //Braucht alle anfunkbaren Knöpfe

        private Watcher watcher; //Watcher erlaubt das Spielfeld zu analysieren


        public Bot(ref ArrayList buttons, ref Watcher watcher)
        {
            this.buttons = buttons;//Übergabe der Knöpfe in den bot
            this.watcher = watcher;//Watcher erlaubt das Spielfeld zu analysieren
            SetBotAI();//Holt sich die info wie er vorgehen soll.
        }

        public void SetMode(String mode)
        {
            enabled = true; //Weil ein modus angegeben worden ist. Wird der bot aktiviert

            //Reset von den Schwirigkeitstufen
            easy = false; //Speichert ob easymode genommen worden ist
            normal = false; //Speichert ob normalmode genommen worden ist
            hard = false; //Speichert ob hardmode genommen worden ist

            //Setzte das wahr was genutzt werden soll
            switch (mode)
            {
                case "":
                    enabled = false;
                    break;
                case "easy":
                    easy = true;
                    break;
                case "normal":
                    normal = true;
                    break;
                case "hard":
                    hard = true;
                    break;
                default: throw new ArgumentException("Dieser Modus ist nicht bekannt!");
            }
        }

        public void RandomClick()
        {
            try
            {
                ArrayList accessibleBtn = new ArrayList();
                foreach (Button button in buttons)
                {
                    if (button.Enabled) accessibleBtn.Add(button); //Füge alle Ungenutzten Buttons in eine Arrayliste hinzu
                }

                Random random = new Random();//Randommizer wird erstellt. Um Random ein button auszuwählen
                Button clickButton = (Button)accessibleBtn[random.Next(0, accessibleBtn.Count)];
                clickButton.PerformClick(); //Führt ein Click Event aus
            }
            catch (Exception ex)
            {
                MessageBox.Show("Valve plz fix! Code: #00002\n" + ex.Message);
            }
}
        public void CalcClick()
        {
            watcher.AdditionalText("Dontknow");
            String currentState = watcher.GetStateString(); //Speichert das aktuelle Spielfeld
            SetBotAI(); // Only a reload
            try
            {
                if (false && currentState == "000000000")
                    RandomClick();
                else
                {
                    if(whatToDo.ContainsKey(currentState))
                    {
                        Button performButton = (Button)buttons[whatToDo[currentState]]; //Holt sich den button wo er klicken soll
                        watcher.AdditionalText("Known");
                        performButton.PerformClick(); //Führt ein Click Event aus
                    } else
                    {
                        //RandomClick(); //Der bot kennt es noch nicht also random klicken
                        //Horizontale Abfragen
                        if (ForcePreCalculateKlick(new[] { 0, 1, 2 })) return; //Der Bot muss schauen wo er verlieren könnte
                        if (ForcePreCalculateKlick(new[] { 3, 4, 5 })) return;
                        if (ForcePreCalculateKlick(new[] { 6, 7, 8 })) return;

                        //Diagonale Abfragen
                        if (ForcePreCalculateKlick(new[] { 0, 4, 8 })) return;
                        if (ForcePreCalculateKlick(new[] { 6, 4, 2 })) return;

                        //Verticale Abfragen
                        if (ForcePreCalculateKlick(new[] { 0, 3, 6 })) return;
                        if (ForcePreCalculateKlick(new[] { 1, 4, 7 })) return;
                        if (ForcePreCalculateKlick(new[] { 2, 5, 8 })) return;
                        watcher.AdditionalText("Random");
                        RandomClick();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Valve plz fix! There is no: " + currentState + "\n" + ex.Message);
            }
        }

        public bool ForcePreCalculateKlick(int[] take) //Nur auf 3 Buttons ausgelegt
        {
            //Prüfen ob etwas gesetzt werden kann
            int isRow = 0; //Ob alle nutzbar sind
            int isTargetRow = 0; //Wie viele der Gegner hat
            ArrayList toPress = new ArrayList(); //Was dann getrückt werden soll
            for (int i = 0; i < 3; i++) //geht das feld durch
            {
                Button button = (Button)buttons[take[i]]; //Holt sich den aktuellen button
                if (button.Enabled || button.Text == watcher.GetPlayer(!watcher.ActivePlayer)) //prüft ob dieser button klickbar oder das eigene ist
                {
                    if (button.Enabled) //Nur in die liste aufnehmen wenn es klickbar ist
                        toPress.Add(button);
                    isRow++; //Zählt wie viel von start zu stop klickbar oder einem selbst gehört
                }
                else
                    isTargetRow++; //Zählt wie viel von start zu stop nicht klickbar ist
            }
            //if(isRow == 3 || isTargetRow == 2 && toPress.Count >= 1)
            if(isRow == 3 && !(isTargetRow == 2) || isTargetRow == 2 && toPress.Count >= 1)
            {
                watcher.AdditionalText("Calc");
                try
                {
                    //Random eins auswählen
                    Random random = new Random();//Randommizer wird erstellt. Um Random ein button auszuwählen
                    Button clickButton = (Button)toPress[random.Next(0, toPress.Count)];
                    clickButton.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Valve plz fix! Code: #00001\n" + ex.Message);
                }
                return true;
            }
            return false;
        }

        //Klickt nach der AI tabelle und auch Random
        public void RandomCalcClick()
        {
            Random random = new Random();//Randommizer wird erstellt. Um Random zwischen easy und hard zu weschlsen
            if (random.Next(0, 10) > 5) RandomClick();//Für ein random kick
            else
            {
                CalcClick(); //Für ein gezielten klick
            }
        }

        public void Choose()
        {
            //Bricht ab wenn es nicht aktiviert ist
            if (!enabled) return;

            if(easy)
            {
                RandomClick(); //Für ein random kick
            }
            if (normal)
            {
                RandomCalcClick();
            }
            if (hard)
            {
                CalcClick(); //Für ein gezielten klick
            }
        }

        //Es sind neun felder können zwei mal betätigt werden. Das hoch zwei ergibt 6561 kombinationen
        //Also sind es weniger als 6561 kombinationen. Trotzdem viele
        public void SetBotAI()
        {
            whatToDo.Clear(); //Nichts sollte in der Liste sein
            //Falls file nicht existiert. Einmal erstellen
            if (!File.Exists("botstrings.txt"))
                File.AppendAllText("botstrings.txt", "000000000;0\n");

            // Zeile für Zeile in der Datei durchlaufen
            foreach (String fileSearch in File.ReadAllLines("botstrings.txt"))
            {
                //String auseinander bauen
                String[] splitted = fileSearch.Split(';');
                whatToDo.Add(splitted[0], Convert.ToInt32(splitted[1]));
            }
        }

    }
}
