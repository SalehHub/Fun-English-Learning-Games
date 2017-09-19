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

        public Random a = new Random();
        public List<int> randomList = new List<int>();
        public wordsLevel mainLevelsForm;

        public XmlDocument xmlDoc = new XmlDocument();
        public XmlNodeList nodeList;

        public int page = 0;

        public int lastPage = 0;

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
            GenerateWords(1);
            page++;
            lastPage = nodeList.Count / 9;

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

        public void GenerateWords(int page)
        {

            switch (page)
            {
                case 1:
                    NewNumber(nodeList.Count);
                    int random = randomList.Last();

                    picAns1.Image = Image.FromFile(@"Images\" + nodeList[0].SelectSingleNode("pic").InnerText);
                    textBox1.Text = nodeList[0].SelectSingleNode("answer").InnerText;



                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox1.Image = Image.FromFile(@"Images\" + nodeList[1].SelectSingleNode("pic").InnerText);
                    textBox2.Text = nodeList[1].SelectSingleNode("answer").InnerText;


                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox2.Image = Image.FromFile(@"Images\" + nodeList[2].SelectSingleNode("pic").InnerText);
                    textBox3.Text = nodeList[2].SelectSingleNode("answer").InnerText;


                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox3.Image = Image.FromFile(@"Images\" + nodeList[3].SelectSingleNode("pic").InnerText);
                    textBox4.Text = nodeList[3].SelectSingleNode("answer").InnerText;


                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox4.Image = Image.FromFile(@"Images\" + nodeList[4].SelectSingleNode("pic").InnerText);
                    textBox5.Text = nodeList[4].SelectSingleNode("answer").InnerText;


                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox5.Image = Image.FromFile(@"Images\" + nodeList[5].SelectSingleNode("pic").InnerText);
                    textBox6.Text = nodeList[5].SelectSingleNode("answer").InnerText;


                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox6.Image = Image.FromFile(@"Images\" + nodeList[6].SelectSingleNode("pic").InnerText);
                    textBox7.Text = nodeList[6].SelectSingleNode("answer").InnerText;



                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox7.Image = Image.FromFile(@"Images\" + nodeList[7].SelectSingleNode("pic").InnerText);
                    textBox8.Text = nodeList[7].SelectSingleNode("answer").InnerText;


                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox8.Image = Image.FromFile(@"Images\" + nodeList[8].SelectSingleNode("pic").InnerText);
                    textBox9.Text = nodeList[8].SelectSingleNode("answer").InnerText;

                    break;

                case 2:
                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    picAns1.Image = Image.FromFile(@"Images\" + nodeList[9].SelectSingleNode("pic").InnerText);
                    textBox1.Text = nodeList[9].SelectSingleNode("answer").InnerText;



                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox1.Image = Image.FromFile(@"Images\" + nodeList[10].SelectSingleNode("pic").InnerText);
                    textBox2.Text = nodeList[10].SelectSingleNode("answer").InnerText;


                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox2.Image = Image.FromFile(@"Images\" + nodeList[11].SelectSingleNode("pic").InnerText);
                    textBox3.Text = nodeList[11].SelectSingleNode("answer").InnerText;


                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox3.Image = Image.FromFile(@"Images\" + nodeList[12].SelectSingleNode("pic").InnerText);
                    textBox4.Text = nodeList[12].SelectSingleNode("answer").InnerText;


                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox4.Image = Image.FromFile(@"Images\" + nodeList[13].SelectSingleNode("pic").InnerText);
                    textBox5.Text = nodeList[13].SelectSingleNode("answer").InnerText;


                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox5.Image = Image.FromFile(@"Images\" + nodeList[14].SelectSingleNode("pic").InnerText);
                    textBox6.Text = nodeList[14].SelectSingleNode("answer").InnerText;


                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox6.Image = Image.FromFile(@"Images\" + nodeList[15].SelectSingleNode("pic").InnerText);
                    textBox7.Text = nodeList[15].SelectSingleNode("answer").InnerText;



                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox7.Image = Image.FromFile(@"Images\" + nodeList[16].SelectSingleNode("pic").InnerText);
                    textBox8.Text = nodeList[16].SelectSingleNode("answer").InnerText;


                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox8.Image = Image.FromFile(@"Images\" + nodeList[17].SelectSingleNode("pic").InnerText);
                    textBox9.Text = nodeList[17].SelectSingleNode("answer").InnerText;

                    break;

                case 3:
                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    picAns1.Image = Image.FromFile(@"Images\" + nodeList[18].SelectSingleNode("pic").InnerText);
                    textBox1.Text = nodeList[18].SelectSingleNode("answer").InnerText;



                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox1.Image = Image.FromFile(@"Images\" + nodeList[19].SelectSingleNode("pic").InnerText);
                    textBox2.Text = nodeList[19].SelectSingleNode("answer").InnerText;


                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox2.Image = Image.FromFile(@"Images\" + nodeList[20].SelectSingleNode("pic").InnerText);
                    textBox3.Text = nodeList[20].SelectSingleNode("answer").InnerText;


                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox3.Image = Image.FromFile(@"Images\" + nodeList[21].SelectSingleNode("pic").InnerText);
                    textBox4.Text = nodeList[21].SelectSingleNode("answer").InnerText;


                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox4.Image = Image.FromFile(@"Images\" + nodeList[22].SelectSingleNode("pic").InnerText);
                    textBox5.Text = nodeList[22].SelectSingleNode("answer").InnerText;


                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox5.Image = Image.FromFile(@"Images\" + nodeList[23].SelectSingleNode("pic").InnerText);
                    textBox6.Text = nodeList[23].SelectSingleNode("answer").InnerText;


                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox6.Image = Image.FromFile(@"Images\" + nodeList[24].SelectSingleNode("pic").InnerText);
                    textBox7.Text = nodeList[24].SelectSingleNode("answer").InnerText;



                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox7.Image = Image.FromFile(@"Images\" + nodeList[25].SelectSingleNode("pic").InnerText);
                    textBox8.Text = nodeList[25].SelectSingleNode("answer").InnerText;


                    NewNumber(nodeList.Count);
                    random = randomList.Last();

                    pictureBox8.Image = Image.FromFile(@"Images\" + nodeList[26].SelectSingleNode("pic").InnerText);
                    textBox9.Text = nodeList[26].SelectSingleNode("answer").InnerText;

                    break;

            }
            


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            page++;
            GenerateWords(page);

            if (page == lastPage) {

                btnNext.Enabled = false;

            }

            btnPrevious.Enabled = true;

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            page--;
            GenerateWords(page);

            if (page < lastPage)
            {

                btnNext.Enabled = true;

            }

            if (page == 1)
            {
                btnPrevious.Enabled = false;
            }

        }
    }
}
