/*
 * Project Name:    Fun Englisg learning Games
 * File Name:       WordsLevels.cs
 * Coded By:        Saleh Alzahrani
 * Coded On:        Fall 2017
 * About this File: This file handles opening words levels and displaying words levels points
 */

using System;
using System.Windows.Forms;

namespace FunEngGames
{
    public partial class wordsLevel : Form
    {
        //Store mainlevels form
        public mainLevels mainLevelsForm;

        //Store all words levels points
        public int spellingPoints = 0;
        public int synonymsPoints = 0;
        public int antonymsPoints = 0;
        public int homonymsPoints = 0;

        public wordsLevel()
        {
            InitializeComponent();
        }

        //Change image to hover image when mouse hover on the button 
        private void picSpelling_MouseHover(object sender, EventArgs e)
        {
            picSpelling.BackgroundImage = Properties.Resources.spellingMainPicHover;
        }

        //Change image bac when mouse leave the button 
        private void picSpelling_MouseLeave(object sender, EventArgs e)
        {
            picSpelling.BackgroundImage = Properties.Resources.spellingMainPic;
        }

        //Open Spelling lesson form
        private void picSpelling_Click(object sender, EventArgs e)
        {
            spellingLesson spellingLesson = new spellingLesson();
            spellingLesson.wordLevelsForm = this;
            spellingLesson.mainLevelsForm = this.mainLevelsForm;
            this.Hide();
            spellingLesson.Show();
        }

        //Open Synonyms lesson form
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SynonymsLesson SynonymsLesson = new SynonymsLesson();
            SynonymsLesson.wordLevelsForm = this;
            SynonymsLesson.mainLevelsForm = this.mainLevelsForm;
            this.Hide();
            SynonymsLesson.Show();
        }

        //Open Homonyms lesson form
        private void picHomonyms_Click(object sender, EventArgs e)
        {
            HomonymsLesson HomonymsLesson = new HomonymsLesson();
            HomonymsLesson.wordLevelsForm = this;
            HomonymsLesson.mainLevelsForm = this.mainLevelsForm;
            this.Hide();
            HomonymsLesson.Show();
        }

        //Show main levels form after closing this form
        private void mainLevels_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.mainLevelsForm.Show();
            }
            catch (Exception ex)
            {

            }
        }
        
        //Change image to hover image when mouse hover on the button 
        private void picPhrases_MouseHover(object sender, EventArgs e)
        {
            picSA.BackgroundImage = Properties.Resources.S_AMainPicHover;
        }

        //Change image bac when mouse leave the button 
        private void picPhrases_MouseLeave(object sender, EventArgs e)
        {
            picSA.BackgroundImage = Properties.Resources.S_AMainPic;
        }

        //Form Load event // enable synonyms button if splleing points != 0 and enable homonyms level if antonyms points != 0 
        private void mainLevels_Load(object sender, EventArgs e)
        {
            if (this.mainLevelsForm.CF.spellingPoints != 0)
            {
                picSA.Enabled = true;
                picSALock.Visible = false;
            }

            if (this.mainLevelsForm.CF.synonymsPoints!= 0 && this.mainLevelsForm.CF.antonymsPoints != 0)
            {
                picHomonyms.Enabled = true;
                picHomonymsLock.Visible = false;
            }
        }

        //Change image to hover image when mouse hover on the button 
        private void picSentences_MouseHover(object sender, EventArgs e)
        {
            picHomonyms.BackgroundImage = Properties.Resources.HomonomysPicHover;
        }

        //Change image bac when mouse leave the button 
        private void picSentences_MouseLeave(object sender, EventArgs e)
        {
            picHomonyms.BackgroundImage = Properties.Resources.HomonomysPic;
        }

    }
}
