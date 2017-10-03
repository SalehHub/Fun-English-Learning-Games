using System;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace FunEngGames
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.b2;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.b1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
             //show Main levels form
            mainLevels ml = new mainLevels();
            ml.Show();
            this.Hide();

            _storyline m2 = new _storyline();
           // m2.Show();
           // this.Hide();

            _levelUP LevelUP = new _levelUP();
           // LevelUP.Show();
           // this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            try
            {
                SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.Volume = 1;  // 0...100
                synthesizer.Rate = -10;     // -10...10
                synthesizer.SpeakAsync("test word");
            }catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void Home_Shown(object sender, EventArgs e)
        {
            //Zoom in animation

            /*
            pictureBox2.Visible = false;
            label1.Visible = false;
            pictureBox1.Visible = false;
            label2.Visible = false;

            animator1.BeginUpdate(panel1);
                pictureBox2.Visible = true;
                label1.Visible = true;
                pictureBox1.Visible = true;
                label2.Visible = true;
            animator1.EndUpdateSync(panel1);
            */
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
