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

        private void picWords_MouseHover(object sender, EventArgs e)
        {
            picWords.BackgroundImage = Properties.Resources.wordsTitleHover;
        }

        private void picWords_MouseLeave(object sender, EventArgs e)
        {
            picWords.BackgroundImage = Properties.Resources.wordsTitle;
        }

        private void picWords_Click(object sender, EventArgs e)
        {
            //spelling s = new spelling();
            //s.Show();
            //Hide();

            wordsLevel wordLevel = new wordsLevel();
            wordLevel.mainLevelsForm = this;
            this.Hide();
            wordLevel.Show();

        }


        private void mainLevels_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void picPhrases_MouseHover(object sender, EventArgs e)
        {
            picPhrases.BackgroundImage = Properties.Resources.phrasesTitleHover;
        }

        private void picPhrases_MouseLeave(object sender, EventArgs e)
        {
            picPhrases.BackgroundImage = Properties.Resources.phrasesTitle;
        }

        private void picSentences_MouseHover(object sender, EventArgs e)
        {
            picSentences.BackgroundImage = Properties.Resources.sentencesTitleHover;
        }

        private void picSentences_MouseLeave(object sender, EventArgs e)
        {
            picSentences.BackgroundImage = Properties.Resources.sentencesTitle;
        }

        private void mainLevels_Load(object sender, EventArgs e)
        {
            //pictureBox1.ImageLocation = "Images\\circle.gif";
        }
    }
}
