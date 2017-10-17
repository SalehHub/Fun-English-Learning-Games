/*
 * Project Name:    Fun English learning Games
 * File Name:       mainLevels.cs
 * Coded By:        Saleh Alzahrani
 * Coded On:        Fall 2017
 * About this File: This file handles main levels form display three button to start game levels
 */

using System;
using System.Windows.Forms;

namespace FunEngGames
{
    public partial class mainLevels : Form
    {
        public mainLevels()
        {
            InitializeComponent();
        }


        //Words Levels Points
        public int spellingPoints = 0;
        public int synonymsPoints = 0;
        public int antonymsPoints = 0;
        public int homonymsPoints = 0;


        //Phrases Levels Points
        public int idiomsPoints = 0;
        public int partsOfSpeechPoints = 0;


        //Sentences Levels Points
        public int grammerPoints = 0;
        public int sentenceStructurePoints = 0;
        public int ParagraphCoherencePoints = 0;

        //CommonFunctions object
        public CommonFunctions CF = new CommonFunctions();

        //Change image to hover image when mouse hover on the button 
        private void picWords_MouseHover(object sender, EventArgs e)
        {
            picWords.BackgroundImage = Properties.Resources.wordsTitleHover;
        }

        //Change image bac when mouse leave the button 
        private void picWords_MouseLeave(object sender, EventArgs e)
        {
            picWords.BackgroundImage = Properties.Resources.wordsTitle;
        }

        //Start Words levels form
        private void picWords_Click(object sender, EventArgs e)
        {

            wordsLevel wordLevel = new wordsLevel();
            wordLevel.mainLevelsForm = this;

            wordLevel.lblSpellingPoints.Text = this.spellingPoints.ToString();
            wordLevel.lblSandAPoints.Text = (this.synonymsPoints + this.antonymsPoints).ToString();
            wordLevel.lblHomonymsPoints.Text = this.homonymsPoints.ToString();

            wordLevel.spellingPoints = this.spellingPoints;
            wordLevel.synonymsPoints = this.synonymsPoints;
            wordLevel.antonymsPoints =this.antonymsPoints;
            wordLevel.antonymsPoints = this.homonymsPoints;

            this.Hide();
            wordLevel.Show();

        }

        //Exit the application when closing this form
        private void mainLevels_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Change image to hover image when mouse hover on the button 
        private void picPhrases_MouseHover(object sender, EventArgs e)
        {
            picPhrases.BackgroundImage = Properties.Resources.phrasesTitleHover;
        }

        //Change image bac when mouse leave the button 
        private void picPhrases_MouseLeave(object sender, EventArgs e)
        {
            picPhrases.BackgroundImage = Properties.Resources.phrasesTitle;
        }

        //Change image to hover image when mouse hover on the button 
        private void picSentences_MouseHover(object sender, EventArgs e)
        {
            picSentences.BackgroundImage = Properties.Resources.sentencesTitleHover;
        }

        //Change image bac when mouse leave the button 
        private void picSentences_MouseLeave(object sender, EventArgs e)
        {
            picSentences.BackgroundImage = Properties.Resources.sentencesTitle;
        }

        //Start Phrases levels form
        private void picPhrases_Click(object sender, EventArgs e)
        {
            phrasesLevel phrasesLevel = new phrasesLevel();
            phrasesLevel.mainLevelsForm = this;
            this.Hide();
            phrasesLevel.Show();
        }

        //Start Sentences levels form
        private void picSentences_Click(object sender, EventArgs e)
        {
            sentenceLevels sentenceLevels = new sentenceLevels();
            sentenceLevels.mainLevelsForm = this;
            this.Hide();
            sentenceLevels.Show();
        }

        //Update points labels
        private void mainLevels_Shown(object sender, EventArgs e)
        {
            lblWordsPoints.Text = (CF.spellingPoints+CF.synonymsPoints+CF.antonymsPoints).ToString();
        }

        //Open result form
        private void lbltitle_Click(object sender, EventArgs e)
        {
            ResultForm rf = new ResultForm();
            rf.mainLevelsForm = this;
            rf.Show();
            this.Hide();
        }

        private void mainLevels_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            phrasesLevel ph = new phrasesLevel();
            ph.mainLevelsForm = this;

            ph.Show();
            this.Hide();
        }
    }
}
