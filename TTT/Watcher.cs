using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TTT
{
    public class Watcher
    {
        static int fail = 0; //Speichern fehlerhaft
        static int success = 0; //Speichern erfolgreich
        static int won = 0; //Only statistic wie oft er gewinnt
        static int loose = 0; //Only statistic wie oft er verliert

        bool debug = false;

        int clicked; //Wo etwas geklickt worden ist
        int spielzug; //Was der letzte spielzug war

        ArrayList buttons; // Alle Buttons die existieren
        Label label; // Outputfield für einen einfachen Text
        TextBox textBox1; // Outputfield eins
        TextBox textBox2; // Outputfield zwei
        TextBox textBox3; // Outputfield drei

        string additionalText = "";

        String[] newState = new String[9]; //Um Änderungen verarbeiten zu können
        String[] oldState = new String[9]; //Um Änderungen festellen zu können

        IDictionary<int, string> playerOne = new Dictionary<int, string>(); //Speichert den ablauf des ersten Spielers
        IDictionary<int, string> playerTwo = new Dictionary<int, string>(); //Speichert den ablauf des zweiten Spielers
        public Watcher(ref ArrayList buttons)
        {
            this.buttons = buttons;

            // Fülle inhalt mit 0 damit ein unterschied erkennbar ist
            for (int i = 0; i < 9; i++)
            {
                oldState[i] = "0";
                newState[i] = "0";
            }
        }

        public Watcher(ref ArrayList buttons, ref Label label, ref TextBox textBox1, ref TextBox textBox2, ref TextBox textBox3)
        {
            debug = true;
            //Überladen von Objekten aus der Form
            this.buttons = buttons;
            this.label = label;
            this.textBox1 = textBox1;
            this.textBox2 = textBox2;
            this.textBox3 = textBox3;

            // Fülle inhalt mit 0 damit ein unterschied erkennbar ist
            for (int i = 0; i < 9; i++)
            {
                oldState[i] = "0";
                newState[i] = "0";
            }
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
            return currentState;
        }

        public int GetClicked()
        {
            int clicked = -1;
            for (int i = 0; i < 9; i++)
            {
                if (oldState[i] != newState[i])
                {
                    clicked = i;
                }
            }

            // Es darf nicht unter null sein
            if (clicked < 0) throw new IndexOutOfRangeException();

            return clicked;
        }

        //Boolean activePlayer gibt an welcher Spieler am zug ist!
        // Spieler 1 entspricht activePlayer = false
        // Spieler 2 entspricht active Player = true
        public void SaveState(bool activePlayer)
        {
            spielzug++; //Ein spieolzug muss getätigt worden sein

            oldState = newState; //Speichert das alte. Es ist dazu da zu berrechnen wo geklickt worden war
            newState = GetState(); //Holt sich die neuen daten
            clicked = GetClicked(); //Aktualiseirt das geklickte

            UpdateDebug(); //Aktualisert das Debug feld


           //Wird richtig hinzugefügt
           if (activePlayer)
                playerOne.Add(clicked, ConvertStringToNormalString(oldState));
            else
                playerTwo.Add(clicked, ConvertStringToNormalString(oldState));

        }

        //Boolean activePlayer gibt an wer gewonnen hat!
        public void SetToData(bool activePlayer)
        {
            String fileName = "botstrings.txt";

            //Falls file nicht existiert. Einmal erstellen
            if (!File.Exists(fileName))
                File.AppendAllText(fileName, "//Auto generation\n");

            if (!activePlayer) //Wenn der bot gewinnt. Die schritte speichern
            {
                won++;//Only statistic wie oft er gewinnt
                foreach (int id in playerTwo.Keys)
                {
                    string writeText = playerTwo[id] + ";" + id + "\n";  //Erstellen vom gewünschten string

                    //Diese logik prüft ob dieser string schon vorhanden ist
                    bool nothing = true; //Wird auf false gestellt falls es vorhanden ist
                    String[] fileAllSearch = File.ReadAllLines(fileName);
                    foreach (String fileSearch in fileAllSearch)
                    {
                        if (fileSearch.Contains(playerTwo[id]))
                            nothing = false;
                    }
                    if (nothing)
                    {
                        success++;//Only statistic ob er ein neuen weg speichern konnte
                        File.AppendAllText(fileName, writeText);  //Es ist noch nicht vorhanden darum wird es hinzugefügt
                    }
                    else 
                        fail++;//Only statistic ob er ein weg nicht speichern konnte
                }
            }
            else //Wenn der bot verliert. Letzten schritt löschen
            {
                loose++;//Only statistic wie oft er verliert

                //Bekomme String was zuletzt hinzugefügt worden ist
                int lastAdded = 0;
                foreach (int id in playerTwo.Keys)
                {
                    lastAdded = id; //Setzt bis zum letzten key neu
                }

                StringBuilder newStrings = new StringBuilder();
                // Zeile für Zeile in der Datei durchlaufen
                foreach (String fileSearch in File.ReadAllLines(fileName))
                {
                    //String auseinander bauen
                    String[] splitted = fileSearch.Split(';');
                    //Wenn der letzte string gefunden wurde nicht in den Stringbuilder aufnehmen
                    if (splitted[0] == playerTwo[lastAdded]) //Suche nach key
                        newStrings.AppendLine(fileSearch); //Zeile zum StringBuilder hinzufügen
                }

                // mit Hilfe des StringBuilder Inhalts, die vorhandene Datei ersetzen
                File.WriteAllText(fileName, newStrings.ToString(), Encoding.Default);

            }
            //Duplicate code
            /*if (activePlayer)
            {
                foreach (int id in playerTwo.Keys)
                {
                    string writeText = "whatToDo.Add(\"" + playerTwo[id] + "\", " + id + ");\n";  //Erstellen vom gewünschten string

                    //Diese logik prüft ob dieser string schon vorhanden ist
                    bool nothing = true; //Wird auf false gestellt falls es vorhanden ist
                    String[] fileAllSearch = File.ReadAllLines("botstrings.txt");
                    foreach (String fileSearch in fileAllSearch)
                    {
                        if (fileSearch.Contains(playerTwo[id]))
                            nothing = false;
                    }
                    if (nothing)
                        File.AppendAllText("botstrings.txt", writeText);  //Es ist noch nicht vorhanden darum wird es hinzugefügt
                }
            }*/
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
            spielzug = 0; //Spielzug fängt wieder bei 0 an

            //Überschreibt die oben genannten variablen
            newState = new String[9]; //Um Änderungen verarbeiten zu können
            oldState = new String[9]; //Um Änderungen festellen zu können

            // Fülle inhalt mit 0 damit ein unterschied erkennbar ist
            for (int i = 0; i < 9; i++)
            {
                oldState[i] = "0";
                newState[i] = "0";
            }

            playerOne = new Dictionary<int, string>(); //Speichert den ablauf des ersten Spielers
            playerTwo = new Dictionary<int, string>(); //Speichert den ablauf des zweiten Spielers
        }

        public void UpdateDebug()
        {
            if (!debug) return; //Falls kein debug nötig ist

            textBox1.Text = "";

            textBox1.Text += "Success" + success + Environment.NewLine;
            textBox1.Text += "Fail" + fail + Environment.NewLine;
            textBox1.Text += "Won" + won + Environment.NewLine;
            textBox1.Text += "Loose" + loose + Environment.NewLine;

            textBox1.Text += Environment.NewLine + "Player One:" + Environment.NewLine;
            foreach (int key in playerOne.Keys)
            {
                textBox1.Text += "[" + key + " <= " + playerOne[key] + Environment.NewLine;
            }

            textBox1.Text += Environment.NewLine + "Player Two:" + Environment.NewLine;
            foreach (int key in playerTwo.Keys)
            {
                textBox1.Text += "[" + key + " <= " + playerTwo[key] + Environment.NewLine;
            }

            //Gibt den string im debug feld aus
            textBox2.Text = ConvertStringToNormalString(oldState);
            textBox3.Text = ConvertStringToNormalString(newState);

            //Gibt den int im debug label aus
            label.Text = additionalText + "/" + clicked.ToString();
        }

        public void AdditionalText(String outside)
        {
            this.additionalText = outside;
        }
    }
}
