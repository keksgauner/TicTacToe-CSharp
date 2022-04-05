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


        private IDictionary<string, int> whatToDo = new Dictionary<string, int>(); //Löst anhand dem currentState String was gemacht werden muss // Je nach key wird gesetzt


        private ArrayList buttons; //Braucht alle anfunkbaren Knöpfe

        private Watcher watcher; //Watcher erlaubt das Spielfeld zu analysieren

        public bool getEnabled { get{ return enabled; } } //Von auserhalb sollte darauf nur zugegriffen werden können. Nicht verändert


        public Bot(ref ArrayList buttons)
        {
            this.buttons = buttons;//Übergabe der Knöpfe in den bot
            watcher = new Watcher(ref buttons);
            SetBotAI();
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

        public void choose()
        {
            //Bricht ab wenn es nicht aktiviert ist
            if (!enabled) return;

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
        public void SetBotAI()
        {
            //Player One
            whatToDo.Add("210000000", 0);
            whatToDo.Add("210021000", 4);
            whatToDo.Add("210021021", 7);
            whatToDo.Add("212021121", 2);
            //Player Two
            whatToDo.Add("000000000", 1);
            whatToDo.Add("210001000", 5);
            whatToDo.Add("210021001", 8);
            whatToDo.Add("210021121", 6);
            whatToDo.Add("212121121", 3);
            //Player One
            whatToDo.Add("020002100", 5);
            whatToDo.Add("122002100", 2);
            whatToDo.Add("122022101", 4);
            //Player One
            whatToDo.Add("002000210", 6);
            whatToDo.Add("212000210", 0);
            whatToDo.Add("212102210", 5);
            //Player Two
            whatToDo.Add("000200001", 8);
            whatToDo.Add("010200201", 1);
            whatToDo.Add("112200201", 0);
            whatToDo.Add("112202211", 7);
            //Player Two
            whatToDo.Add("000121000", 3);
            whatToDo.Add("000121012", 7);
            whatToDo.Add("021121012", 2);
            //Player One
            whatToDo.Add("000002100", 5);
            whatToDo.Add("200012100", 0);
            whatToDo.Add("210012120", 7);
            whatToDo.Add("212112120", 2);
            //Player Two
            whatToDo.Add("000012100", 4);
            whatToDo.Add("210012100", 1);
            whatToDo.Add("210112120", 3);
            whatToDo.Add("212112121", 8);
            //Player One
            whatToDo.Add("020000120", 1);
            whatToDo.Add("021002120", 5);
            //Player Two
            whatToDo.Add("000020001", 8);
            whatToDo.Add("000020121", 6);
            //Player Two
            whatToDo.Add("001001020", 5);
            whatToDo.Add("101021020", 0);
            //Player Two
            whatToDo.Add("100120000", 3);
            whatToDo.Add("100120012", 7);
            whatToDo.Add("110120212", 1);
            //Player One
            whatToDo.Add("010002000", 5);
            whatToDo.Add("210012000", 0);
            whatToDo.Add("210012021", 7);
            whatToDo.Add("212112021", 2);
            //Player Two
            whatToDo.Add("010012000", 4);
            whatToDo.Add("210012001", 8);
            whatToDo.Add("210112021", 3);
            //Player One
            whatToDo.Add("200001200", 0);
            whatToDo.Add("212001200", 2);
            whatToDo.Add("212011220", 7);
            //Player Two
            whatToDo.Add("000000120", 6);
            whatToDo.Add("021000120", 2);
            whatToDo.Add("221001120", 5);
            //Player One
            whatToDo.Add("000010002", 8);
            whatToDo.Add("002010012", 2);
            //Player Two
            whatToDo.Add("002000100", 6);
            whatToDo.Add("002012100", 4);
            whatToDo.Add("212012100", 1);
            //Player One
            whatToDo.Add("000000210", 6);
            whatToDo.Add("020001210", 1);
            whatToDo.Add("120021210", 4);
            whatToDo.Add("120121212", 8);
            //Player Two
            whatToDo.Add("000001210", 5);
            whatToDo.Add("120001210", 0);
            whatToDo.Add("120121210", 3);
            whatToDo.Add("121121212", 2);
            //Player Two
            whatToDo.Add("000000102", 6);
            whatToDo.Add("012000102", 1);
            //Player One
            whatToDo.Add("120002100", 1);
            whatToDo.Add("120202101", 3);

        }

    }
}
