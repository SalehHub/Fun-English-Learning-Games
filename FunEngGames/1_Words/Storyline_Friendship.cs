using System;
using System.Windows.Forms;

namespace FunEngGames._1_Words
{
    public partial class Storyline_Friendship : Form
    {
        public Storyline_Friendship()
        {
            InitializeComponent();
        }

        public wordsLevel wordLevelsForm;
        public mainLevels mainLevelsForm;

        private void Storyline_Friendship_Load(object sender, EventArgs e)
        {

        }

        private void Storyline_Friendship_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

                this.wordLevelsForm.Show();

            }
            catch (Exception ex)
            {

            }
        }
    }
}
