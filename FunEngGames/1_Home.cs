using NAudio.Wave;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

       

        private  void button1_Click(object sender, EventArgs e)
        {

        }




        private void Home_Load(object sender, EventArgs e)
        {
            try
            {
                SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.Volume = 1;  // 0...100
                synthesizer.Rate = -2;     // -10...10
                synthesizer.Speak("test word");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
