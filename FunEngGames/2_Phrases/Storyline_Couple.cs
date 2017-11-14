/*
 * Project Name:    Fun English learning Games
 * File Name:       StroyLine_Friendship.cs
 * Coded By:        Saleh Alzahrani & Sarah Aljabri
 * Coded On:        Fall 2017
 * About this File: This file handles displaying a reward to player(Le and Megan are friends now!) after finishing words levels
 */

using System;
using System.Windows.Forms;

namespace FunEngGames._2_Phrases
{
    public partial class Storyline_Couple : Form
    {
        public Storyline_Couple()
        {
            InitializeComponent();
        }

        //Variables wordLevelsForm and mainLevelsForm to store previous forms status        
       // public wordsLevel wordLevelsForm;
        public mainLevels mainLevelsForm;
        public phrasesLevel phrasesLevelForm;


        //Form closed event function: show the words level form
        private void Storyline_Friendship_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

                this.mainLevelsForm.Show();

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sentenceLevels sentenceLevels = new sentenceLevels();
            sentenceLevels.mainLevelsForm = this.mainLevelsForm;
            this.Hide();
            sentenceLevels.Show();
        }

        private void Storyline_Couple_Load(object sender, EventArgs e)
        {

        }
    }
}
