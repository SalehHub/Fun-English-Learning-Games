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
    public partial class _storyline : Form
    {
        private Image _1;
        private Image _2;
        private Image _3;
        private Image _4;

        public _storyline()
        {
            InitializeComponent();

            _1 = Properties.Resources.sl1;
            _2 = Properties.Resources.sl2;
            _3 = Properties.Resources.sl3;
            _4 = Properties.Resources.sl4;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox4.Image == _1)
            {
                pictureBox4.Image = _2;
            }

            else if (pictureBox4.Image == _2)
            {
                pictureBox4.Image = _3;
            }

            else if (pictureBox4.Image == _3)
            {
                label1.Text = "Le decided to join Fun English Learning Games institution to learn English language";
                pictureBox4.Image = _4;
            }
        }

        private void _storyline_Load(object sender, EventArgs e)
        {
            pictureBox4.Image = _1;
        }
    }
}
