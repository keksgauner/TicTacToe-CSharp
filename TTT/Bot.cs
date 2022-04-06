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
        private bool enabled = false; //Speichert ob der Bot aktiviert ist
        private bool easy = false; //Speichert ob easymode genommen worden ist
        private bool normal = false; //Speichert ob normalmode genommen worden ist
        private bool hard = false; //Speichert ob hardmode genommen worden ist


        private IDictionary<string, int> whatToDo = new Dictionary<string, int>(); //Löst anhand dem currentState String was gemacht werden muss // Je nach key wird gesetzt


        private ArrayList buttons; //Braucht alle anfunkbaren Knöpfe

        private Watcher watcher; //Watcher erlaubt das Spielfeld zu analysieren

        public bool getEnabled { get{ return enabled; } } //Von auserhalb sollte darauf nur zugegriffen werden können. Nicht verändert


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
            ArrayList accessibleBtn = new ArrayList();
            foreach (Button button in buttons)
            {
                if (button.Enabled) accessibleBtn.Add(button); //Füge alle Ungenutzten Buttons in eine Arrayliste hinzu
            }

            Random random = new Random();//Randommizer wird erstellt. Um Random ein button auszuwählen
            Button clickButton = (Button)accessibleBtn[random.Next(0, accessibleBtn.Count)];
            clickButton.PerformClick(); //Führt ein Click Event aus
        }
        public void CalcClick()
        {
            watcher.AdditionalText("Calc");
            String currentState = watcher.GetStateString(); //Speichert das aktuelle Spielfeld
            SetBotAI(); // Only a reload
            try
            {
                if (currentState == "000000000")
                    RandomClick();
                else
                {
                    Button performButton = (Button)buttons[whatToDo[currentState]];
                    watcher.AdditionalText("Known");
                    performButton.PerformClick(); //Führt ein Click Event aus
                }
            }
            catch (Exception ex)
            {
                watcher.AdditionalText("Random");
                //MessageBox.Show("Valve plz fix! There is no: " + currentState);
                RandomClick();
            }
        }

        public void choose()
        {
            //Bricht ab wenn es nicht aktiviert ist
            if (!enabled) return;

            if(easy)
            {
                RandomClick(); //Für ein random kick
            }
            if (normal)
            {
                Random random = new Random();//Randommizer wird erstellt. Um Random zwischen easy und hard zu weschlsen
                if(random.Next(0, 10) > 5) RandomClick();//Für ein random kick
                else
                {
                    CalcClick(); //Für ein gezielten klick
                }

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
