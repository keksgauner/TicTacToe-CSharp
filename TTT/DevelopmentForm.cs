using System;
using System.Collections;
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
    public partial class DevelopmentForm : Form
    {

        //Watcher erlaubt das Spielfeld zu analysieren
        Watcher watcher;

        Bot bot;

        public DevelopmentForm(ref Watcher watcher, ref Bot bot, ref ArrayList buttons)
        {
            InitializeComponent();
            //Bot aus der Main funktion übernehmen
            this.bot = bot;
            //Watcher wird aus der Main funktion übernommen
            this.watcher = watcher;
            watcher.SetDebug(new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7 });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Klickt Random und auch mit der AI-Tabelle
            if (!watcher.ActivePlayer)
                bot.RandomCalcClick();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Form1.DialogFeld = !checkBox1.Checked;
            timer1.Enabled = checkBox1.Checked;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt32(textBox8.Text);
        }
    }
}
