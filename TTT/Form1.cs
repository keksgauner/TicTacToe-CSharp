using System;
using System.Drawing;
using System.Windows.Forms;

namespace TTT
{
    public partial class Form1 : Form
    {
        //Boolean welcher angibt welcher Spieler am zug ist!
        // Spieler 1 entspricht activePlayer = false
        // Spieler 2 entspricht active Player = true
        // Spieler 1 beginnt!
        bool activePlayer = false;

        //Zähler der Spielzüge
        double spielzug = 0;

        //Gewinner String für die Gewinner MessageBox!
        String Gewinner = "";

        //Strings für Spielerfarben
        Color playerXColor = new Color();
        Color playerYColor = new Color();

        //Aktive Spielerfarbe
        Color activePlayerColor = new Color();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClearPlayground();  //Spielfeld Initialisieren und Bereitstellen!
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e) //Menüpunkt Aktion für Hilfe > About
        {
            // DialogBox mit ausgabe wer das Spiel programmiert hat.
            MessageBox.Show(this, "Dieses Spiel wurde programmiert von:\nSebastian Schindler \nDarkModz-Official\n", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GithubToolStripMenuItem_Click(object sender, EventArgs e)  //Menüpunkt Aktion für Hilfe > Github
        {
            //Offnet in neuem Browserfenster das Github-Profil von mir.
            System.Diagnostics.Process.Start("https://github.com/DarkModz-Official");
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)    //Menüpunkt Aktion Start > Exit
        {
            //Abfrage Ob das Spiel wirklich beendet werden soll. Wenn ja dann Spiel beenden, ansonsten weiter im Programm. 
            DialogResult exitresult = MessageBox.Show(this, "Möchten Sie das Spiel wirklich beenden?", "Bist du dir WIRKLICH sicher?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exitresult == DialogResult.Yes)
            {
                Application.Exit(); //Spiel || Applikation beenden! 
            }
        }

        private void ButtonEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Enabled)
            {
                ColorActive();
                button.BackColor = activePlayerColor;
            }
        }

        private void ButtonLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = activePlayerColor;
            if (button.Text == string.Empty)
            {
                button.BackColor = Color.White;
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            optionenToolStripMenuItem.Enabled = false;
            spielzug++;
            lbl_spielzüge.Text = "Spielzüge gespielt: " + spielzug.ToString();
            //Erstellen des Buttons als Objekt um auf den verwendeten Button zugreifen zu können. 

            Button button = (Button)sender;

            if (activePlayer)   //Abfrage welcher Spieler gerade aktiv ist
            {
                button.Text = "X";  //Button Text ändern zu X da Spieler X Button betätigt hat!
                button.BackColor = playerXColor;    // Hintergrund zu Spielerfarbe ändern
                lbl_player.Text = "Spieler O ist nun am Zug!";  //label ändern um bekannt zu geben welcher Spieler am Zug ist
            }
            else
            {
                button.Text = "O";    //Button Text ändern zu Y da Spieler Y Button betätigt hat!
                button.BackColor = playerYColor;    // Hintergrund zu Spielerfarbe ändern
                lbl_player.Text = "Spieler X ist nun am Zug!";  //label ändern um bekannt zu geben welcher Spieler am Zug ist
            }

            //Wechseln des Aktuellen Spielers
            activePlayer = !activePlayer;

            //Deaktivieren des Buttons nach Spielzug!
            button.Enabled = false; //Button deaktivieren um erneutes Betätigen zu verhindern!

            WinnerCheck();  //Überprüfen ob Spieler gewonnen hat!
        }

        private void WinnerCheck()
        {
            bool winnerAvaible = false; //Sagt aus ob ein Gewinner bekannt ist oder nicht!

            //Horizontale Abfragen

            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))    //erste Zeile abfragen!
            {
                winnerAvaible = true;   //Gewinner ist bekannt!
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled)) //zweite Zeile abfragen!
            {
                winnerAvaible = true;   //Gewinner ist bekannt!
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))  //dritte Zeile abfragen!
            {
                winnerAvaible = true;   //Gewinner ist bekannt!
            }

            // Vertikale Abfragen

            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))   //erste Spalte
            {
                winnerAvaible = true;   //Gewinner ist bekannt!
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled)) //zweite Spalte
            {
                winnerAvaible = true;   //Gewinner ist bekannt!
            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))    //dritte Spalte
            {
                winnerAvaible = true;   //Gewinner ist bekannt!
            }

            //Diagonale Abfragen

            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!B2.Enabled))   //Diagonal von Oben Links nach unten Rechts!
            {
                winnerAvaible = true;   //Gewinner ist bekannt!
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!B2.Enabled)) //Diagonal von Oben Rechts nach unten Links!
            {
                winnerAvaible = true;   //Gewinner ist bekannt!
            }


            //Gewinner Nachricht ausgeben!
            if (winnerAvaible)
            {
                if (activePlayer)
                    Gewinner = "O";
                else
                    Gewinner = "X";

                spielzug /= 2;
                spielzug = Math.Round(spielzug, MidpointRounding.AwayFromZero); //Berechnen wie viele Spielzüge von dem einen Spieler benötigt werden!

                DialogResult winnerRead = MessageBox.Show(this, "Spieler " + Gewinner + " hat das Spiel mit " + spielzug + " Spielzügen gewonnen!", "Gewinner", MessageBoxButtons.OK, MessageBoxIcon.Information);  //Ausgabe der MessageBox
                if (winnerRead == DialogResult.OK)
                {
                    ClearPlayground();  //Spielfeld bereinigen
                    spielzug = 0;   //Spielzüge auf 0 setzen
                }
            }
            else if (((!A1.Enabled) && (!A2.Enabled) && (!A3.Enabled)) && ((!B1.Enabled) && (!B2.Enabled) && (!B3.Enabled)) && ((!C1.Enabled) && (!C2.Enabled) && (!C3.Enabled)))   //Abfragen Ob unentschieden!
            {
                DialogResult winnerRead = MessageBox.Show(this, "Das Spiel ist Unentschieden!", "Unentschieden!", MessageBoxButtons.OK, MessageBoxIcon.Information);    //MessageBox für Unentschieden ausgeben!
                if (winnerRead == DialogResult.OK)
                {
                    ClearPlayground();  //Spielfeld bereinigen
                    spielzug = 0;   //Spielzüge auf 0 setzen
                }
            }
        }

        public void ClearPlayground()   //Spielfeld bereinigen
        {
            optionenToolStripMenuItem.Enabled = true;
            A1.Text = "";       //Button Text zurücksetzen
            A1.Enabled = true;  //Button wieder enablen!
            A1.BackColor = Color.White; //Farbe zurücksetzen

            B1.Text = "";
            B1.Enabled = true;
            B1.BackColor = Color.White;

            C1.Text = "";
            C1.Enabled = true;
            C1.BackColor = Color.White;

            A2.Text = "";
            A2.Enabled = true;
            A2.BackColor = Color.White;

            B2.Text = "";
            B2.Enabled = true;
            B2.BackColor = Color.White;

            C2.Text = "";
            C2.Enabled = true;
            C2.BackColor = Color.White;

            A3.Text = "";
            A3.Enabled = true;
            A3.BackColor = Color.White;

            B3.Text = "";
            B3.Enabled = true;
            B3.BackColor = Color.White;

            C3.Text = "";
            C3.Enabled = true;
            C3.BackColor = Color.White;
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e) //Aktion für MenüPunkt Start > New Game
        {
            ClearPlayground();  //Spielfeld bereinigen
            spielzug = 0;   //Spielzüge zurücksetzen
            activePlayer = false;  //Spieler zurücksetzen!
            playerXColor = Color.White; //Spielerfarbe zurücksetzen!
            playerYColor = Color.White; //Spielerfarbe zurücksetzen!
            toolStripMenuItem2.BackColor = playerXColor;
            toolStripMenuItem3.BackColor = playerYColor;
        }

        private void ColorPickerToolStripMenuItem_Click(object sender, EventArgs e) //Spielerfarbe für Spieler X
        {
            ColorDialog colorDialog = new ColorDialog();    //ColorPicker Objekt erstellen
            colorDialog.SolidColorOnly = true;              //Transparenz in Bildern verbieten
            colorDialog.ShowDialog();                       //Dialog anzeigen
            Color playerColor = colorDialog.Color;          //Farbe setzen!
            toolStripMenuItem2.BackColor = playerColor;   // Menupunkt einfärben
            playerXColor = playerColor;     //Farbe übergeben


        }

        private void SpielerfarbeÄndernToolStripMenuItem_Click(object sender, EventArgs e)  //Spielerfarbe für Spieler Y
        {
            ColorDialog colorDialog = new ColorDialog();    //ColorPicker Objekt erstellen
            colorDialog.SolidColorOnly = true;              //Transparenz in Bildern verbieten
            colorDialog.ShowDialog();                       //Dialog anzeigen
            Color playerColor = colorDialog.Color;          //Farbe setzen!
            toolStripMenuItem3.BackColor = playerColor;   // Menupunkt einfärben
            playerYColor = playerColor;     //Farbe übergeben
        }

        private void ColorActive()      //aktive Farbe abfragen!
        {
            if (activePlayer)
            {
                activePlayerColor = playerXColor;
            }
            else
                activePlayerColor = playerYColor;

        }
    }
}
