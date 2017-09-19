using System;
using System.Windows.Forms;

namespace FunEngGames
{
    public partial class sentenceLevels : Form
    {
        public Form mainLevelsForm;

        public sentenceLevels()
        {
            InitializeComponent();
        }

        private void picSpelling_MouseHover(object sender, EventArgs e)
        {
            picSpelling.BackgroundImage = Properties.Resources.GrammerTitleHover;
        }

        private void picSpelling_MouseLeave(object sender, EventArgs e)
        {
            picSpelling.BackgroundImage = Properties.Resources.GrammerTitle;
        }

        private void picSpelling_Click(object sender, EventArgs e)
        {
            /*
            spelling spelling = new spelling();
            spelling.mainLevelsForm = this;
            this.Hide();
            spelling.Show();
            
            spellingLesson spellingLesson = new spellingLesson();
            spellingLesson.mainLevelsForm = this;
            this.Hide();
            spellingLesson.Show();*/

            Grammar Grammar = new Grammar();
            Grammar.mainLevelsForm = this;
            this.Hide();
            Grammar.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            /*
            S_A S_A = new S_A();
            S_A.mainLevelsForm = this;
            this.Hide();
            S_A.Show();
           
            SynonymsLesson SynonymsLesson = new SynonymsLesson();
            SynonymsLesson.mainLevelsForm = this;
            this.Hide();
            SynonymsLesson.Show(); */

            SS SS = new SS();
            SS.mainLevelsForm = this;
            this.Hide();
            SS.Show();
        }

        private void mainLevels_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.mainLevelsForm.Show();
        }

        private void picPhrases_MouseHover(object sender, EventArgs e)
        {
            picSA.BackgroundImage = Properties.Resources.SSTitleHover;
        }

        private void picPhrases_MouseLeave(object sender, EventArgs e)
        {
            picSA.BackgroundImage = Properties.Resources.SSTitle;
        }

        private void picSentences_MouseHover(object sender, EventArgs e)
        {
            picHomonyms.BackgroundImage = Properties.Resources.PCTitleHover;
        }

        private void picSentences_MouseLeave(object sender, EventArgs e)
        {
            picHomonyms.BackgroundImage = Properties.Resources.PCTitle;
        }

        private void mainLevels_Load(object sender, EventArgs e)
        {

        }

        private void picHomonyms_Click(object sender, EventArgs e)
        {
            /*
            homonyms homonyms = new homonyms();
            homonyms.mainLevelsForm = this;
            this.Hide();
            homonyms.Show();
           
            HomonymsLesson HomonymsLesson = new HomonymsLesson();
            HomonymsLesson.mainLevelsForm = this;
            this.Hide();
            HomonymsLesson.Show(); */

            PC PC = new PC();
            PC.mainLevelsForm = this;
            this.Hide();
            PC.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
