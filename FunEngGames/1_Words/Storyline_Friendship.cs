/*
 * Project Name:    Fun English learning Games
 * File Name:       StroyLine_Friendship.cs
 * Coded By:        Saleh Alzahrani & Sarah Aljabri
 * Coded On:        Fall 2017
 * About this File: This file handles displaying a reward to player(Le and Megan are friends now!) after finishing words levels
 */

using System;
using System.Windows.Forms;

namespace FunEngGames._1_Words
{
    public partial class Storyline_Friendship : Form
    {
        public Storyline_Friendship()
        {
            InitializeComponent();
        }

        //Variables wordLevelsForm and mainLevelsForm to store previous forms status        
        public wordsLevel wordLevelsForm;
        public mainLevels mainLevelsForm;

        //Form closed event function: show the words level form
        private void Storyline_Friendship_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

                this.wordLevelsForm.Show();

            }
            catch (Exception ex)
            {

            }
        }
    }
}
