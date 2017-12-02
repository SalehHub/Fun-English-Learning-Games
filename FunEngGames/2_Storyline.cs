using System;
using System.Drawing;
using System.Windows.Forms;

namespace FunEngGames
{
    public partial class _storyline : Form
    {
        private Image _1;
        private Image _2;
        private Image _3;
        private Image _4;
        public Home home;

        public _storyline()
        {
            InitializeComponent();

            _1 = Properties.Resources.sl_start;
            _2 = Properties.Resources.sl_sad;
            _3 = Properties.Resources.sl_learn1;
            _4 = Properties.Resources.sl_learn2;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox4.Image == _1)
            {
                pictureBox4.Image = _2;
            }

            else if (pictureBox4.Image == _2)
            {
                label1.Text = "Lee decided to join Fun English Learning Games institution to learn English language";

                pictureBox4.Image = _3;
            }

            else if (pictureBox4.Image == _3)
            {
                button3.Text = "Start learning English and playing fun games";


                label1.Text = "Lee decided to join Fun English Learning Games institution to learn English language";
                pictureBox4.Image = _4;
                label2.Visible = false;

            }else if(pictureBox4.Image == _4)
            {
                mainLevels mainLevels = new mainLevels();
                mainLevels.Show();
                this.Hide();
            }
        }

        private void _storyline_Load(object sender, EventArgs e)
        {
            pictureBox4.Image = _1;
        }

        private void _storyline_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Application.Exit();
           //Home home = new Home();
            this.home.Show();
            //this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainLevels mainLevels = new mainLevels();
            mainLevels.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
