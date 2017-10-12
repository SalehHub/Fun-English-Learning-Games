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


        public mainLevels mainLevelsForm;


        private void Result_Load(object sender, EventArgs e)
        {
            //Spelling Points
            lblWordsResults.Text = 
                    "Spelling:      " + this.mainLevelsForm.CF.spellingPoints 
                + "\nSynonyms:   " + this.mainLevelsForm.CF.synonymsPoints
                + "\nAntonyms:   " + this.mainLevelsForm.CF.antonymsPoints
                + "\nHomonyms: " + this.mainLevelsForm.CF.homonymsPoints;



            //TODO
            
            //Phrases Points

            //Sentences


        }

        private void btnCheckAnswer_Click(object sender, EventArgs e)
        {
            try
            {
                this.mainLevelsForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {

            }

        }

        private void ResultForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.mainLevelsForm.Show();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
