// Copyright (c) 2011 rubicon IT GmbH

/*
 * Project Name:    Fun English learning Games
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

            var total = 25 + 15 + 15 + 15;
            var playerTotal = this.mainLevelsForm.CF.spellingPoints
                + this.mainLevelsForm.CF.synonymsPoints
                + this.mainLevelsForm.CF.antonymsPoints
                + this.mainLevelsForm.CF.homonymsPoints;

            pbSpelling.Maximum = total;
            pbSpelling.Value = playerTotal;

            //calculating player precent in words levels
            decimal precent = Math.Round(((decimal)playerTotal / (decimal)total)* 100m,2);

            lblPrecent.Text = "You have completed " + precent + "%";


            lblWordsResults.Text =
                    "Spelling:      " + this.mainLevelsForm.CF.spellingPoints + " out of 25"
                + "\nSynonyms:   " + this.mainLevelsForm.CF.synonymsPoints + " out of 15"
                + "\nAntonyms:   " + this.mainLevelsForm.CF.antonymsPoints + " out of 15"
                + "\nHomonyms: " + this.mainLevelsForm.CF.homonymsPoints + " out of 15";



            //TODO//

            //1-Phrases Points

            //2-Sentences Points


        }


        //Play again button jsut close this form and go back to main levles form.
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



        //Close event, just go back to main levels
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
