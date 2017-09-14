using System;
using System.Windows.Forms;

namespace FunEngGames
{
    public partial class wordsLevel : Form
    {
        public Form mainLevelsForm;

        public wordsLevel()
        {
            InitializeComponent();
        }

        private void picSpelling_MouseHover(object sender, EventArgs e)
        {
            picSpelling.BackgroundImage = Properties.Resources.spellingMainPicHover;
        }

        private void picSpelling_MouseLeave(object sender, EventArgs e)
        {
            picSpelling.BackgroundImage = Properties.Resources.spellingMainPic;
        }

        private void picSpelling_Click(object sender, EventArgs e)
        {
            /*
            spelling spelling = new spelling();
            spelling.mainLevelsForm = this;
            this.Hide();
            spelling.Show();
            */
            spellingLesson spellingLesson = new spellingLesson();
            spellingLesson.mainLevelsForm = this;
            this.Hide();
            spellingLesson.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            S_A S_A = new S_A();
            S_A.mainLevelsForm = this;
            this.Hide();
            S_A.Show();
        }

        private void mainLevels_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.mainLevelsForm.Show();
        }

        private void picPhrases_MouseHover(object sender, EventArgs e)
        {
            picSA.BackgroundImage = Properties.Resources.S_AMainPicHover;
        }

        private void picPhrases_MouseLeave(object sender, EventArgs e)
        {
            picSA.BackgroundImage = Properties.Resources.S_AMainPic;
        }

        private void picSentences_MouseHover(object sender, EventArgs e)
        {
            picHomonyms.BackgroundImage = Properties.Resources.HomonomysPicHover;
        }

        private void picSentences_MouseLeave(object sender, EventArgs e)
        {
            picHomonyms.BackgroundImage = Properties.Resources.HomonomysPic;
        }

        private void mainLevels_Load(object sender, EventArgs e)
        {

        }

        private void picHomonyms_Click(object sender, EventArgs e)
        {
            homonyms homonyms = new homonyms();
            homonyms.mainLevelsForm = this;
            this.Hide();
            homonyms.Show();
        }
    }
}
