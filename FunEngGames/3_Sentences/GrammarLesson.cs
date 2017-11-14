using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunEngGames._3_Sentences
{
    public partial class GrammarLesson : Form
    {
        public GrammarLesson()
        {
            
            InitializeComponent();
            
            this.dataGridView2.Rows.Add("here", "this", "these");
            this.dataGridView2.Rows.Add("there", "that", "those");

        }

        CommonFunctions CommonFunctions = new CommonFunctions();
        public sentenceLevels sentenceLevelsForm;
        public mainLevels mainLevelsForm;

        public int page = 0;
        public int lastPage = 3;



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Grammar Grammar = new Grammar();
            Grammar.sentenceLevelsForm = this.sentenceLevelsForm;
            Grammar.mainLevelsForm = this.mainLevelsForm;
            this.Hide();
            Grammar.Show();       
        }

        private void GrammarLesson_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.sentenceLevelsForm.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {  
            page++;
            if (page == 1)
            {
                this.dataGridView2.Visible = false;
                Size size = new Size(345, 400);
                pictureBox1.Size = size;
                pictureBox1.Image = FunEngGames.Properties.Resources.theirthere;
                label1.Text = "Difference between There - Their - They're";
                btnNext.Enabled = false;
                btnPrevious.Enabled = true;
            }
         
            
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            page--;
            if (page == 1)
            {
                this.dataGridView2.Visible = false;
                Size size = new Size(345, 400);
                pictureBox1.Size = size;
                pictureBox1.Image = FunEngGames.Properties.Resources.theirthere;
                label1.Text = "Difference between There - Their - They're";
                btnNext.Enabled = false;
                btnPrevious.Enabled = true;
            }
            else if (page == 0)
            {
                this.dataGridView2.Visible = true;
                Size size = new Size(676, 184);
                pictureBox1.Size = size;
                pictureBox1.Image = FunEngGames.Properties.Resources.this_that_these_those;
                label1.Text = "Difference between This - These - That - Those";
                btnNext.Enabled = true;
                btnPrevious.Enabled = false;
            }
      
         
        }

        private void GrammarLesson_Load(object sender, EventArgs e)
        {
            this.FormClosing += this.GrammarLesson_FormClosing;
        }

    }
}
