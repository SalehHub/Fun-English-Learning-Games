/*
 * Project Name:    Fun English learning Games
 * File Name:       StroyLine_Friendship.cs
 * Coded By:        Saleh Alzahrani & Sarah Aljabri
 * Coded On:        Fall 2017
 * About this File: This file handles displaying a reward to player(Le and Megan are friends now!) after finishing words levels
 */

using System;
using System.Windows.Forms;

namespace FunEngGames._3_Sentences
{
    public partial class Storyline_Married : Form
    {
        public Storyline_Married()
        {
            InitializeComponent();
        }

        //Variables wordLevelsForm and mainLevelsForm to store previous forms status        
        //public wordsLevel wordLevelsForm;
        public mainLevels mainLevelsForm;
        public sentenceLevels sentenceLevelsForm;
        //public phrasesLevel phrasesLevelForm;


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

            ResultForm rf = new ResultForm();
            rf.mainLevelsForm = this.mainLevelsForm;
            rf.Show();
            this.Hide();


            //phrasesLevel phrasesLevel = new phrasesLevel();
            //phrasesLevel.mainLevelsForm = this.mainLevelsForm;
            //this.Hide();
            //phrasesLevel.Show();
        }

        private void Storyline_Married_Load(object sender, EventArgs e)
        {

        }
    }
}
