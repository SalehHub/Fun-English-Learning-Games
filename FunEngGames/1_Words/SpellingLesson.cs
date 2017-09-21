using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FunEngGames
{
    public partial class spellingLesson : Form
    {
        public spellingLesson()
        {
            InitializeComponent();
        }

        CommonFunctions CommonFunctions = new CommonFunctions();

        public Random a = new Random();
        public List<int> randomList = new List<int>();
        public wordsLevel mainLevelsForm;

        public XmlDocument xmlDoc = new XmlDocument();
        public XmlNodeList nodeList;

        public int page = 0;

        public int lastPage = 0;
        public int nextNode = 0;


        int MyNumber = 0;
        private void NewNumber(int max)
        {
            
            MyNumber = a.Next(0, max);
           // if (!randomList.Contains(MyNumber))
           // {
                randomList.Add(MyNumber);
          //  }
          //  else
          //  {
          //      NewNumber(max);
          //  }
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Spelling Spelling = new Spelling();
            Spelling.mainLevelsForm = this.mainLevelsForm;
            this.Hide();
            Spelling.Show();
        }

        private void spellingLesson_Load(object sender, EventArgs e)
        {

            //XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("questions.xml");
            nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/spelling");
            GenerateWords(0);
            page++;
            lastPage = nodeList.Count / 9;


            lblPages.Text = "Page "+page+" out of "+lastPage;
            //MessageBox.Show(lastPage.ToString());

        }

        private void spellingLesson_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.mainLevelsForm.Show();
            }
            catch (Exception ex)
            {

            }
        }


        public void GenerateWord(PictureBox p, TextBox t,int next)
        {
            p.Image = Image.FromFile(@"Images\" + nodeList[next].SelectSingleNode("pic").InnerText);
            t.Text = CommonFunctions.UppercaseFirst(nodeList[next].SelectSingleNode("answer").InnerText);
            p.Tag = nodeList[next].SelectSingleNode("answer").InnerText;
        }

        public void GenerateWords(int next)
        {
            GenerateWord(picAns1, textBox1, next);
            next++;
            GenerateWord(pictureBox1, textBox2, next);
            next++;
            GenerateWord(pictureBox2, textBox3, next);
            next++;
            GenerateWord(pictureBox3, textBox4, next);
            next++;
            GenerateWord(pictureBox4, textBox5, next);
            next++;
            GenerateWord(pictureBox5, textBox6, next);
            next++;
            GenerateWord(pictureBox6, textBox7, next);
            next++;
            GenerateWord(pictureBox7, textBox8, next);
            next++;
            GenerateWord(pictureBox8, textBox9, next);
            next++;
    }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            page++;
            nextNode += 9;
            GenerateWords(nextNode);
            
            if (page == lastPage) {

                btnNext.Enabled = false;

            }

            btnPrevious.Enabled = true;

            lblPages.Text = "Page " + page + " out of " + lastPage;


        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            page--;
            nextNode -= 9;
            GenerateWords(nextNode);

            if (page < lastPage)
            {

                btnNext.Enabled = true;

            }

            if (page == 1)
            {
                btnPrevious.Enabled = false;
            }
            lblPages.Text = "Page " + page + " out of " + lastPage;
        }

        private void picAns1_Click(object sender, EventArgs e)
        {
            var pic = (PictureBox)sender;
            CommonFunctions.Pronounce(pic.Tag.ToString());

        }
    }
}
