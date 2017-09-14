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

        int MyNumber = 0;
        private void NewNumber(int max)
        {
            MyNumber = a.Next(0, max);
            if (!randomList.Contains(MyNumber))
            {
                randomList.Add(MyNumber);
            }
            else
            {
                NewNumber(max);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            spelling spelling = new spelling();
            spelling.mainLevelsForm = this.mainLevelsForm;
            this.Hide();
            spelling.Show();
        }

        private void spellingLesson_Load(object sender, EventArgs e)
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("questions.xml");
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/spelling");

            NewNumber(nodeList.Count);
            int random = randomList.Last();

            picAns1.Image = Image.FromFile(@"Images\" + nodeList[random].SelectSingleNode("pic").InnerText);
            textBox1.Text = nodeList[random].SelectSingleNode("answer").InnerText;



            NewNumber(nodeList.Count);
             random = randomList.Last();

            pictureBox1.Image = Image.FromFile(@"Images\" + nodeList[random].SelectSingleNode("pic").InnerText);
            textBox2.Text = nodeList[random].SelectSingleNode("answer").InnerText;


            NewNumber(nodeList.Count);
            random = randomList.Last();

            pictureBox2.Image = Image.FromFile(@"Images\" + nodeList[random].SelectSingleNode("pic").InnerText);
            textBox3.Text = nodeList[random].SelectSingleNode("answer").InnerText;


            NewNumber(nodeList.Count);
            random = randomList.Last();

            pictureBox3.Image = Image.FromFile(@"Images\" + nodeList[random].SelectSingleNode("pic").InnerText);
            textBox4.Text = nodeList[random].SelectSingleNode("answer").InnerText;


            NewNumber(nodeList.Count);
            random = randomList.Last();

            pictureBox4.Image = Image.FromFile(@"Images\" + nodeList[random].SelectSingleNode("pic").InnerText);
            textBox5.Text = nodeList[random].SelectSingleNode("answer").InnerText;


            NewNumber(nodeList.Count);
            random = randomList.Last();

            pictureBox5.Image = Image.FromFile(@"Images\" + nodeList[random].SelectSingleNode("pic").InnerText);
            textBox6.Text = nodeList[random].SelectSingleNode("answer").InnerText;


            NewNumber(nodeList.Count);
            random = randomList.Last();

            pictureBox6.Image = Image.FromFile(@"Images\" + nodeList[random].SelectSingleNode("pic").InnerText);
            textBox7.Text = nodeList[random].SelectSingleNode("answer").InnerText;



            NewNumber(nodeList.Count);
            random = randomList.Last();

            pictureBox7.Image = Image.FromFile(@"Images\" + nodeList[random].SelectSingleNode("pic").InnerText);
            textBox8.Text = nodeList[random].SelectSingleNode("answer").InnerText;


            NewNumber(nodeList.Count);
            random = randomList.Last();

            pictureBox8.Image = Image.FromFile(@"Images\" + nodeList[random].SelectSingleNode("pic").InnerText);
            textBox9.Text = nodeList[random].SelectSingleNode("answer").InnerText;
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
    }
}
