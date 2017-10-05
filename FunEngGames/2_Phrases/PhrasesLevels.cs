using System;
using System.Windows.Forms;

namespace FunEngGames
{
    public partial class phrasesLevel : Form
    {

        public phrasesLevel()
        {
            InitializeComponent();
        }

        public mainLevels mainLevelsForm;

        private void picSpelling_MouseHover(object sender, EventArgs e)
        {
            picSpelling.BackgroundImage = Properties.Resources.posTitleHover;
        }

        private void picSpelling_MouseLeave(object sender, EventArgs e)
        {
            picSpelling.BackgroundImage = Properties.Resources.posTitle;
        }


        private void picSentences_MouseHover(object sender, EventArgs e)
        {
            picIdioms.BackgroundImage = Properties.Resources.idiomsTitleHover;
        }

        private void picSentences_MouseLeave(object sender, EventArgs e)
        {
            picIdioms.BackgroundImage = Properties.Resources.idiomsTitle;
        }


        private void picSpelling_Click(object sender, EventArgs e)
        {
            /*
            spelling spelling = new spelling();
            spelling.mainLevelsForm = this;
            this.Hide();
            spelling.Show();
            */
            POSLesson POSLesson = new POSLesson();
            POSLesson.mainLevelsForm = this.mainLevelsForm;
            POSLesson.phrasesLevelForm = this;
            this.Hide();
            POSLesson.Show();
        }

        private void mainLevels_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.mainLevelsForm.Show();
        }

        private void picHomonyms_Click(object sender, EventArgs e)
        {
            /*
            homonyms homonyms = new homonyms();
            homonyms.mainLevelsForm = this;
            this.Hide();
            homonyms.Show();
            */
            IdiomsLesson IdiomsLesson = new IdiomsLesson();
            IdiomsLesson.mainLevelsForm = this.mainLevelsForm;
            IdiomsLesson.phrasesLevelForm = this;
            this.Hide();
            IdiomsLesson.Show();
        }

    }
}
