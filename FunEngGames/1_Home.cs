/*
 * Project Name:    Fun Englisg learning Games
 * File Name:       Home.cs
 * Coded By:        Saleh Alzahrani
 * Coded On:        Fall 2017
 * About this File: This file handles first form which is welcome form with one button to start the game
 */

using System;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace FunEngGames
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        //Change image to hover image when mouse hover on the button 
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.b2;
        }

        //Change image bac when mouse leave the button 
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.b1;
        }

        //Start the main levles form
        private void pictureBox1_Click(object sender, EventArgs e)
        {
             //show Main levels form
           // mainLevels ml = new mainLevels();
            //ml.Show();
            //this.Hide();

            _storyline m2 = new _storyline();
            m2.Show();
            m2.home = this;
            this.Hide();

            //_levelUP LevelUP = new _levelUP();
           // LevelUP.Show();
           // this.Hide();
        }

        //Load event just setup speech object
        private void Home_Load(object sender, EventArgs e)
        {
            try
            {
                SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.Volume = 1;  // 0...100
                synthesizer.Rate = -10;     // -10...10
                synthesizer.SpeakAsync("Hello");
            }catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
