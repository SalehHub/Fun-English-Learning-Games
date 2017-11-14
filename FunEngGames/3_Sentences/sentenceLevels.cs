/*
 * Project Name:    Fun English learning Games 
 * File Name:       SentenceLevels.cs
 * Coded By:        Adriana Escobar
 * Coded On:        Fall 2017
 * About this File: This file handles the sentences levels and displays the points
 */

using FunEngGames._3_Sentences;
using System;
using System.Windows.Forms;

namespace FunEngGames
{
    public partial class sentenceLevels : Form
    {
        //Store mainlevels form
        public mainLevels mainLevelsForm;

        //Store all words levels points
        public int grammarPoints = 0;
        public int ParagraphCoherencePoints = 0;
        public int SentenceStructurePoints = 0;

        public sentenceLevels()
        {
            InitializeComponent();
        }

        //Change image to hover image when mouse hover on the button 
        private void picGrammar_MouseHover(object sender, EventArgs e)
        {
            picGrammar.BackgroundImage = Properties.Resources.GrammerTitleHover;
        }

        private void picGrammar_MouseLeave(object sender, EventArgs e)
        {
            picGrammar.BackgroundImage = Properties.Resources.GrammerTitle;
        }

        private void picSS_MouseHover(object sender, EventArgs e)
        {
            picSS.BackgroundImage = Properties.Resources.SSTitleHover;
        }

        private void picSS_MouseLeave(object sender, EventArgs e)
        {
            picSS.BackgroundImage = Properties.Resources.SSTitle;
        }

        private void picPC_MouseHover(object sender, EventArgs e)
        {
            picPC.BackgroundImage = Properties.Resources.PCTitleHover;
        }

        private void picPC_MouseLeave(object sender, EventArgs e)
        {
            picPC.BackgroundImage = Properties.Resources.PCTitle;
        }

        //Open the Grammar Lesson form
        private void picGrammar_Click(object sender, EventArgs e)
        {
            GrammarLesson GrammarLesson = new GrammarLesson();
            GrammarLesson.sentenceLevelsForm = this;
            GrammarLesson.mainLevelsForm = this.mainLevelsForm;
            this.Hide();
            GrammarLesson.Show();
        }

        //Open the Sentence Structure Lesson Form
        private void picSS_Click(object sender, EventArgs e)
        {
            SS_lesson SS_lesson = new SS_lesson();
            SS_lesson.sentenceLevelsForm = this;
            SS_lesson.mainLevelsForm = this.mainLevelsForm;
            this.Hide();
            SS_lesson.Show();
        }

        //Open the paragraph coherence lesson form
        private void picPC_Click(object sender, EventArgs e)
        {
            PCLesson PCLesson = new PCLesson();
            PCLesson.sentenceLevelsForm = this;
            PCLesson.mainLevelsForm = this.mainLevelsForm;
            this.Hide();
            PCLesson.Show();
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
                System.Console.WriteLine(ex.Message);
            }
        }

        /*Form Load event: 
         * enable sentence button if grammar points != 0 and 
         * enable paragraph level if sentence points != 0 
         */
        private void mainLevels_Load(object sender, EventArgs e)
        {

            if (this.mainLevelsForm.CF.grammarPoints != 0)
            {
                picSS.Enabled = true;
                picSSLock.Visible = false;
                lblhelp.Text = "Good job, now you have to play Sentence Structure Level to unlock Paragraph Coherence level";
            }

            if (this.mainLevelsForm.CF.sentenceStructurePoints != 0 && this.mainLevelsForm.CF.antonymsPoints != 0)
            {
                picPC.Enabled = true;
                picPCLock.Visible = false;
                lblhelp.Text = "You successfully unlocked all the levels";

            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
