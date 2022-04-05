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
        private bool easy; //Speichert ob easymode genommen worden ist

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
                default: throw new ArgumentException("Dieser Modus ist nicht bekannt!");
            }
        }

        public void choose()
        {
            ArrayList accesibleBtn = new ArrayList();
            foreach(Button button in buttons)
            {
                if(button.Enabled) accesibleBtn.Add(button); //Füge alle Ungenutzten Buttons in eine Arrayliste hinzu
            }

            if(easy)
            {
                Random random = new Random();//Randommizer wird erstellt. Um Random ein button auszuwählen
                Button button = (Button)accesibleBtn[random.Next(0, accesibleBtn.Count)];
                button.PerformClick(); //Führt ein Click Event aus
            }
        }

    }
}
