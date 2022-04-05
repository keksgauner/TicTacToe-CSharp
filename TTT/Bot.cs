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

        public bool getEnabled { get{ return enabled; } } //Von auserhalb sollte darauf nur zugegriffen werden können. Nicht verändert


        public Bot()
        {
            //Hier gibt es nichts zu tun.
        }

        public Bot(ArrayList buttons, String mode)
        {
            enabled = true; //Weil ein modus angegeben worden ist. Wird der bot aktiviert
            this.buttons = buttons;//Übergabe der Knöpfe in den bot

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
                String currentState = ""; //Speichert das aktuelle Spielfeld
                foreach (Button button in buttons)
                {
                    if (!button.Enabled)
                    {
                        if (button.Text == "O")
                            currentState += "1"; //1 wird für Player 1 genutzt
                        if (button.Text == "X")
                            currentState += "2"; //2 wird für Player 2 genutzt
                    }

                    if (button.Enabled) currentState += "0"; //0 wird für Frei genutzt
                }

                IDictionary<string, int> whatToDo = new Dictionary<string, int>(); //Löst anhand dem currentState String was gemacht werden muss
                // Listen wenn zuerst gesetzt wird
                whatToDo.Add("100000000", 0);
                whatToDo.Add("100000002", 7);
                whatToDo.Add("101000002", 8);
                whatToDo.Add("121000002", 8);
                whatToDo.Add("121000102", 8);
                whatToDo.Add("121200102", 8);
                whatToDo.Add("000000000", 7);
                whatToDo.Add("000000001", 0);
                whatToDo.Add("200000001", 8);
                whatToDo.Add("200000101", 8);
                whatToDo.Add("200200101", 8);
                whatToDo.Add("200201101", 8);
                whatToDo.Add("202201101", 8);
                whatToDo.Add("000000020", 4);
                whatToDo.Add("000000020", 8);
                whatToDo.Add("010000020", 8);
                whatToDo.Add("010002020", 8);
                whatToDo.Add("010002120", 8);
                whatToDo.Add("010202120", 8);
                whatToDo.Add("010212120", 8);
                whatToDo.Add("010212122", 7);
                whatToDo.Add("000000020", 7);
                whatToDo.Add("000000020", 8);




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
