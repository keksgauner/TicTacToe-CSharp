using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) //Menüpunkt Aktion für Hilfe > About
        {
            // DialogBox mit ausgabe wer das Spiel programmiert hat.

            MessageBox.Show(this, "Dieses Spiel wurde programmiert von:\nSebastian Schindler \nDarkModz-Official\n","About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void githubToolStripMenuItem_Click(object sender, EventArgs e)  //Menüpunkt Aktion für Hilfe > Github
        {
            //Offnet in neuem Browserfenster das Github-Profil von mir.
            System.Diagnostics.Process.Start("https://github.com/DarkModz-Official");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)    //Menüpunkt Aktion Start > Exit
        {
            //Abfrage Ob das Spiel wirklich beendet werden soll. Wenn ja dann Spiel beenden, ansonsten weiter im Programm. 
            DialogResult exitresult = MessageBox.Show(this, "Möchten Sie das Spiel wirklich beenden?", "Bist du dir WIRKLICH sicher?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exitresult == DialogResult.Yes)
            {
                Application.Exit(); //Spiel || Applikation beenden! 
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            spielzug = spielzug + 1;
            //Erstellen des Buttons als Objekt um auf den verwendeten Button zugreifen zu können. 

            Button button = (Button)sender;
            
            if (activePlayer)   //Abfrage welcher Spieler gerade aktiv ist
            {
                button.Text = "X";  //Button Text ändern zu X da Spieler X Button betätigt hat!
                lbl_player.Text = "Spieler O ist nun am Zug!";  //label ändern um bekannt zu geben welcher Spieler am Zug ist
            }
            else
            {
                button.Text="O";    //Button Text ändern zu Y da Spieler Y Button betätigt hat!
                lbl_player.Text = "Spieler X ist nun am Zug!";  //label ändern um bekannt zu geben welcher Spieler am Zug ist
            }

            //Wechseln des Aktuellen Spielers
            activePlayer = !activePlayer;

            //Deaktivieren des Buttons nach Spielzug!
            button.Enabled = false; //Button deaktivieren um erneutes Betätigen zu verhindern!

            winnerCheck();  //Überprüfen ob Spieler gewonnen hat!
        }

        private void winnerCheck()
        {
            bool winnerAvaible = false; //Sagt aus ob ein Gewinner bekannt ist oder nicht!

            //Horizontale Abfragen

            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))    //erste Zeile abfragen!
            {
                winnerAvaible = true;   //Gewinner ist bekannt!
            }else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled)) //zweite Zeile abfragen!
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
            }else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))    //dritte Spalte
            {
                winnerAvaible = true;   //Gewinner ist bekannt!
            }

            //Diagonale Abfragen

            if((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!B2.Enabled))   //Diagonal von Oben Links nach unten Rechts!
            {
                winnerAvaible = true;   //Gewinner ist bekannt!
            }else if((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!B2.Enabled)) //Diagonal von Oben Rechts nach unten Links!
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

                spielzug = spielzug / 2;
                spielzug = Math.Round(spielzug, MidpointRounding.AwayFromZero);

                DialogResult winnerRead = MessageBox.Show(this, "Spieler " + Gewinner + " hat das Spiel mit "+spielzug+" Spielzügen gewonnen!", "Gewinner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(winnerRead == DialogResult.OK)
                {
                    clearPlayground();
                    spielzug = 0;
                }
            }else if(((!A1.Enabled) && (!A2.Enabled) && (!A3.Enabled)) && ((!B1.Enabled) && (!B2.Enabled) && (!B3.Enabled)) && ((!C1.Enabled) && (!C2.Enabled) && (!C3.Enabled)))
            {
                DialogResult winnerRead = MessageBox.Show(this, "Das Spiel ist Unentschieden!", "Unentschieden!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (winnerRead == DialogResult.OK)
                {
                    clearPlayground();
                    spielzug = 0;
                }
            }
        }

        public void clearPlayground()
        {
            A1.Text = "";
            A1.Enabled = true;

            B1.Text = "";
            B1.Enabled = true;

            C1.Text = "";
            C1.Enabled = true;

            A2.Text = "";
            A2.Enabled = true;

            B2.Text = "";
            B2.Enabled = true;

            C2.Text = "";
            C2.Enabled = true;

            A3.Text = "";
            A3.Enabled = true;

            B3.Text = "";
            B3.Enabled = true;

            C3.Text = "";
            C3.Enabled = true;
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearPlayground();
            spielzug = 0;
            bool activePlayer = false;
        }
    }
}
