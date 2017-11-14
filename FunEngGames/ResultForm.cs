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
        public sentenceLevels sentenceLevelsForm;

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




            //Phrases Points

            var phraseTotal = 30;
            var phrasesplayerTotal = this.mainLevelsForm.CF.partsOfSpeechPoints
                + this.mainLevelsForm.CF.idiomsPoints;

            pbPhrases.Maximum = phraseTotal;
            pbPhrases.Value = phrasesplayerTotal;

            //calculating player precent in words levels
            decimal phrasesPrecent = Math.Round(((decimal)phrasesplayerTotal / (decimal)phraseTotal) * 100m, 2);

            lblPrasesPrecent.Text = "You have completed " + phrasesPrecent + "%";


            lblPhrasesResults.Text =
                    "Parts of speech:" + this.mainLevelsForm.CF.partsOfSpeechPoints + " out of 15"
                + "\nIdioms:   " + this.mainLevelsForm.CF.idiomsPoints + " out of 15";


            //Sentences Points

            var sentencesTotal = 30;
            var sentencesPlayerTotal = this.mainLevelsForm.CF.grammarPoints
                + this.mainLevelsForm.CF.sentenceStructurePoints
            +this.mainLevelsForm.CF.ParagraphCoherencePoints;

            pbSentences.Maximum = sentencesTotal;
            pbSentences.Value = sentencesPlayerTotal;

            //calculating player precent in words levels
            decimal sentencesPrecent = Math.Round(((decimal)sentencesPlayerTotal / (decimal)sentencesTotal) * 100m, 2);

            lblSentencesPrecent.Text = "You have completed " + sentencesPrecent + "%";


            lblSentencesResults.Text =
                    "Grammar: " + this.mainLevelsForm.CF.grammarPoints + " out of 15"
                + "\nSentence structure: " + this.mainLevelsForm.CF.sentenceStructurePoints + " out of 15"
                + "\nParagraph coherence: " + this.mainLevelsForm.CF.ParagraphCoherencePoints + " out of 15";


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
                Console.WriteLine(ex.Message);
            }

        }


        //Close event, just go back to main levels
        private void ResultForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.sentenceLevelsForm.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
