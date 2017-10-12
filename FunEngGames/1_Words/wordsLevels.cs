using System;
using System.Windows.Forms;

namespace FunEngGames
{
    public partial class wordsLevel : Form
    {
        public mainLevels mainLevelsForm;

        public int spellingPoints = 0;
        public int synonymsPoints = 0;
        public int antonymsPoints = 0;
        public int homonymsPoints = 0;

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
            spellingLesson.wordLevelsForm = this;
            spellingLesson.mainLevelsForm = this.mainLevelsForm;
            this.Hide();
            spellingLesson.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            /*
            S_A S_A = new S_A();
            S_A.mainLevelsForm = this;
            this.Hide();
            S_A.Show();
            */
            SynonymsLesson SynonymsLesson = new SynonymsLesson();
            SynonymsLesson.wordLevelsForm = this;
            SynonymsLesson.mainLevelsForm = this.mainLevelsForm;
            this.Hide();
            SynonymsLesson.Show();
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
            if (this.spellingPoints != 0)
            {
                picSA.Enabled = true;
                picSALock.Visible = false;
            }

            if (this.antonymsPoints != 0)
            {
                picHomonyms.Enabled = true;
                picHomonymsLock.Visible = false;
            }
        }

        private void picHomonyms_Click(object sender, EventArgs e)
        {
            /*
            homonyms homonyms = new homonyms();
            homonyms.mainLevelsForm = this;
            this.Hide();
            homonyms.Show();
            */
            HomonymsLesson HomonymsLesson = new HomonymsLesson();
            HomonymsLesson.wordLevelsForm = this;
            HomonymsLesson.mainLevelsForm = this.mainLevelsForm;
            this.Hide();
            HomonymsLesson.Show();
        }
    }
}
