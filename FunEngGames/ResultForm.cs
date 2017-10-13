/*
 * Project Name:    Fun Englisg learning Games
 * File Name:       ResultForm.cs
 * Coded By:        Saleh Alzahrani
 * Coded On:        Fall 2017
 * About this File: This file handles displaying the details results for the palyer for each levels
 */

using System;
using System.Windows.Forms;

namespace FunEngGames
{
    public partial class ResultForm : Form
    {
        public ResultForm()
        {
            InitializeComponent();
        }

        //Define main levels variable
        public mainLevels mainLevelsForm;

        //Load event here we filling points labels with the palyer's points
        private void Result_Load(object sender, EventArgs e)
        {
            //Spelling Points
            lblWordsResults.Text = 
                    "Spelling:      " + this.mainLevelsForm.CF.spellingPoints 
                + "\nSynonyms:   " + this.mainLevelsForm.CF.synonymsPoints
                + "\nAntonyms:   " + this.mainLevelsForm.CF.antonymsPoints
                + "\nHomonyms: " + this.mainLevelsForm.CF.homonymsPoints;



            //TODO
            
            //Phrases Points

            //Sentences


        }

        //Play again button
        private void btnCheckAnswer_Click(object sender, EventArgs e)
        {
            try
            {
                this.mainLevelsForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {

            }

        }

        //CLose event, just go back to main levels
        private void ResultForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.mainLevelsForm.Show();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
