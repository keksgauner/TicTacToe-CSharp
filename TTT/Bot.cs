using System;
using System.Collections;
using System.Collections.Generic;
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

        private ArrayList buttons; //Braucht alle anfunkbaren Knöpfe

        private Watcher watcher; //Watcher erlaubt das Spielfeld zu analysieren

        public bool getEnabled { get{ return enabled; } } //Von auserhalb sollte darauf nur zugegriffen werden können. Nicht verändert


        public Bot()
        {
            //Hier gibt es nichts zu tun.
        }

        public Bot(ref ArrayList buttons, ref Watcher watcher, String mode)
        {
            enabled = true; //Weil ein modus angegeben worden ist. Wird der bot aktiviert
            this.buttons = buttons;//Übergabe der Knöpfe in den bot
            this.watcher = watcher;

            //Setzte das wahr was genutzt werden soll
            switch (mode)
            {
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

        public void choose()
        {

            if(easy)
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
            if (normal)
            {
                //Nothing there :(
            }
            if (hard)
            {
                String currentState = watcher.GetStateString(); //Speichert das aktuelle Spielfeld

                IDictionary<string, int> whatToDo = new Dictionary<string, int>(); //Löst anhand dem currentState String was gemacht werden muss
                // Je nach key wird gesetzt
                whatToDo.Add("000000000", 0);




                try
                {
                    Button performButton = (Button)buttons[whatToDo[currentState]];
                    performButton.PerformClick(); //Führt ein Click Event aus
                } catch (Exception ex)
                {
                    MessageBox.Show("Valve plz fix! There is no: " + currentState);
                }
            }
        }

    }
}
