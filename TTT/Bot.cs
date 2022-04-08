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
    public class Bot
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
                        /* Bot, bleibe dumm!
                        ArrayList checkQuere = new ArrayList();
                        //Horizontale Abfragen
                        checkQuere.Add(new[] { 0, 1, 2 });
                        checkQuere.Add(new[] { 3, 4, 5 });
                        checkQuere.Add(new[] { 6, 7, 8 });

                        //Diagonale Abfragen
                        checkQuere.Add(new[] { 0, 4, 8 });
                        checkQuere.Add(new[] { 6, 4, 2 });

                        //Verticale Abfragen
                        checkQuere.Add(new[] { 0, 3, 6 });
                        checkQuere.Add(new[] { 1, 4, 7 });
                        checkQuere.Add(new[] { 2, 5, 8 });
                        ForcePreCalculateKlick(checkQuere);*/
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

        public void ForcePreCalculateKlick(ArrayList checkQuere) //Nur auf 3 Buttons ausgelegt
        {
            bool defent = false;
            ArrayList toPress = new ArrayList(); //Was dann getrückt werden kann
            foreach (int[] check in checkQuere)
            {
                //Prüfen ob etwas gesetzt werden kann
                int isRow = 0; //Wie viel der bot haben kann
                int isTargetRow = 0; //Wie viel der gegner hat

                for (int i = 0; i < 3; i++) //geht das feld durch
                {
                    if (!defent)
                        toPress.Clear(); //Soll es dann löschen

                    Button button = (Button)buttons[check[i]]; //Holt sich den aktuellen button
                    if (button.Enabled || button.Text == watcher.GetPlayer(!Form1.ActivePlayer)) //prüft ob dieser button klickbar oder das eigene ist
                    {
                        if (button.Enabled) //Nur in die liste aufnehmen wenn es klickbar ist
                            toPress.Add(button);
                        isRow++; //Zählt wie viel von start zu stop klickbar oder einem selbst gehört
                    }
                    else
                        isTargetRow++; //Zählt wie viel klickbar ist
                }

                if (isTargetRow == 2)
                    defent = true; //Wenn er sich verteidigen muss
                if (isRow == 3 && !defent)
                    continue;
            }
            
            if(toPress.Count >= 1)
            {
                if(defent)
                {
                    try
                    {
                        watcher.AdditionalText("Defent");
                        //Random eins auswählen
                        Random random = new Random();
                        Button clickButton = (Button)toPress[random.Next(0, toPress.Count)];
                        clickButton.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Valve plz fix! Code: #00003\n" + ex.Message);
                    }
                } else
                {
                    try
                    {
                        watcher.AdditionalText("Fight");
                        //Random eins auswählen
                        Random random = new Random();//Randommizer wird erstellt. Um Random ein button auszuwählen
                        Button clickButton = (Button)toPress[random.Next(0, toPress.Count)];
                        clickButton.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Valve plz fix! Code: #00001\n" + ex.Message);
                    }
                }
            } else
            {
                watcher.AdditionalText("Random");
                RandomClick();
            }
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
