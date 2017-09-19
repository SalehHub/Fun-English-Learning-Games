using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunEngGames
{
    public partial class LevelUP : Form
    {
        public LevelUP()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "Le and Megan are boyfriend and girlfriend now";
            pictureBox4.Image = Properties.Resources.sl6;
            this.Text = "Fun English Learning Games: Boyfriend";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label1.Text = "She said YES!, Lee and Megan are engaged now";
            pictureBox4.Image = Properties.Resources.sl7;
            this.Text = "Fun English Learning Games: She Said YES";
            label2.Text = "Click next to see your results and collect point in each level";
        }

        private void LevelUP_Load(object sender, EventArgs e)
        {

        }
    }
}
