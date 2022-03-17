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

        /*
         * Erstellen des Spielfeldes. 3x3 großes Feld.
         * Spieler werden gesetzt auf Spielernummer z.B.
         * 
         * { 1, 1, 2 }, 
         * { 2, 1, 1 },     Spieler 1 setzt wert 1 im Array!
         * { 1, 2, 2 }      Spieler 2 setzt wert 2 im Array!
         * 
         */

        int[,] playground = {{ 0, 0, 0 }, 
                             { 0, 0, 0 }, 
                             { 0, 0, 0 }};      


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Dieses Spiel wurde programmiert von:\nSebastian Schindler \nDarkModz-Official\n","About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void githubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/DarkModz-Official");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult exitresult = MessageBox.Show(this, "Möchten Sie das Spiel wirklich beenden?", "Bist du dir WIRKLICH sicher?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exitresult == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
