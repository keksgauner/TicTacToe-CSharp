using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TTT
{
    public class Watcher
    {
        ArrayList buttons; // Alle Buttons die existieren
        Label label; // Outputfield für einen einfachen Text
        TextBox textBox1; // Outputfield eins
        TextBox textBox2; // Outputfield zwei

        String[] newState = new String[9]; //Um Änderungen verarbeiten zu können
        String[] oldState = new String[9]; //Um Änderungen festellen zu können

        IDictionary<int, string> playerOne = new Dictionary<int, string>(); //Speichert den ablauf des ersten Spielers
        IDictionary<int, string> PlayerTwo = new Dictionary<int, string>(); //Speichert den ablauf des zweiten Spielers

        public Watcher(ref ArrayList buttons, ref Label label, ref TextBox textBox1, ref TextBox textBox2)
        {
            //Überladen von Objekten aus der Form
            this.buttons = buttons;
            this.label = label;
            this.textBox1 = textBox1;
            this.textBox2 = textBox2;
        }

        /**
         * Übersetzer von dem Speilfeld
         */
        public String[] GetState()
        {
            String[] currentState = new String[9]; //Speichert das aktuelle Spielfeld
            int state = 0;
            // Hier werden alle gesetzten buttons und ungenutze buttons in 0, 1 und 2 umgewandelt
            // Ungenutzt ist 0. Spieler 1 ist 1. Spieler 2 ist 2
            foreach (Button button in buttons)
            {

                if (button.Text == "X")
                    currentState[state] = "2";
                if (button.Text == "O")
                    currentState[state] = "1";
                if (button.Enabled) currentState[state] = "0";
                state++;
            }

            //Gibt es im debug feld aus
            textBox2.Text = ConvertStringToNormalString(currentState);

            return currentState;
        }

        public int GetClicked()
        {
            int clicked = 0;
            for (int i = 0; i < 9; i++)
            {
                if (oldState.Length > 0 && oldState[i] != newState[i])
                {
                    clicked = i;
                }
                i++;
            }
            label.Text = clicked;

            return clicked;
        }

        //Boolean activePlayer gibt an welcher Spieler am zug ist!
        // Spieler 1 entspricht activePlayer = false
        // Spieler 2 entspricht active Player = true
        public void SaveState(bool activePlayer)
        {
            oldState = newState; //Speichert das alte. Es ist dazu da zu berrechnen wo geklickt worden war
            newState = GetState(); //Holt sich die neuen daten

            //Wird richtig hinzugefügt
            if (!activePlayer)
            {
                playerOne.Add(GetClicked(), ConvertStringToNormalString(newState));
            }
            if(activePlayer)
            {
                PlayerTwo.Add(GetClicked(), ConvertStringToNormalString(newState));
            }
        }

        //Boolean activePlayer gibt an wer gewonnen hat!
        public void SetToData(bool activePlayer)
        {
            if (!activePlayer)
            {
                File.AppendAllText("botstrings.txt", "//Player One\n");
                foreach (int id in playerOne.Keys)
                {
                    string writeText = "whatToDo.Add(\"" + playerOne[id] + "\", " + id + ");\n";  //Erstellen vom gewünschten string

                    //Diese logik prüft ob dieser string schon vorhanden ist
                    String[] fileAllSearch = File.ReadAllLines("botstrings.txt");
                    foreach (String fileSearch in fileAllSearch)
                    {
                        if (!(writeText == fileSearch))
                            File.AppendAllText("botstrings.txt", writeText);  //Es ist noch nicht vorhanden darum wird es hinzugefügt
                    }
                }
            }
            //Duplicate code
            if (activePlayer)
            {
                File.AppendAllText("botstrings.txt", "//Player Two\n");
                foreach (int id in playerOne.Keys)
                {
                    string writeText = "whatToDo.Add(\"" + playerOne[id] + "\", " + id + ");\n";  //Erstellen vom gewünschten string

                    //Diese logik prüft ob dieser string schon vorhanden ist
                    String[] fileAllSearch = File.ReadAllLines("botstrings.txt");
                    foreach (String fileSearch in fileAllSearch)
                    {
                        if (!(writeText == fileSearch))
                            File.AppendAllText("botstrings.txt", writeText);  //Es ist noch nicht vorhanden darum wird es hinzugefügt
                    }
                }
            }
        }

        public String GetStateString()
        {
            return ConvertStringToNormalString(GetState());
        }

        //Soll nur String[] in String umgewandelt werden
        public String ConvertStringToNormalString(String[] toConvert)
        {
            String result = "";
            foreach (String toAdd in toConvert)
            {
                result += toAdd;
            }
            return result;
        }

        public void Clear()
        {
            //Überschreibt die oben genannten variablen
            newState = new String[9]; //Um Änderungen verarbeiten zu können
            oldState = new String[9]; //Um Änderungen festellen zu können

            playerOne = new Dictionary<int, string>(); //Speichert den ablauf des ersten Spielers
            PlayerTwo = new Dictionary<int, string>(); //Speichert den ablauf des zweiten Spielers
        }
    }
}
