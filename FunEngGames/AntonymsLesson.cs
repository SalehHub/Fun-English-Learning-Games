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
    public partial class AntonymsLesson : Form
    {
        public AntonymsLesson()
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
            Antonyms antonyms = new Antonyms();
            antonyms.mainLevelsForm = this.mainLevelsForm;
            this.Hide();
            antonyms.Show();
        }

        private void SynonymsLesson_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.mainLevelsForm.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void SynonymsLesson_Load(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("questions.xml");
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/antonyms");

            NewNumber(nodeList.Count);
            int random = randomList.Last();

            textBox1.Text = nodeList[random].SelectSingleNode("word").InnerText;
            textBox2.Text = nodeList[random].SelectSingleNode("antonym").InnerText;


            NewNumber(nodeList.Count);
            random = randomList.Last();

            textBox3.Text = nodeList[random].SelectSingleNode("word").InnerText;
            textBox4.Text = nodeList[random].SelectSingleNode("antonym").InnerText;



            NewNumber(nodeList.Count);
            random = randomList.Last();

            textBox5.Text = nodeList[random].SelectSingleNode("word").InnerText;
            textBox6.Text = nodeList[random].SelectSingleNode("antonym").InnerText;



            NewNumber(nodeList.Count);
            random = randomList.Last();

            textBox7.Text = nodeList[random].SelectSingleNode("word").InnerText;
            textBox8.Text = nodeList[random].SelectSingleNode("antonym").InnerText;

            NewNumber(nodeList.Count);
            random = randomList.Last();

            textBox9.Text = nodeList[random].SelectSingleNode("word").InnerText;
            textBox10.Text = nodeList[random].SelectSingleNode("antonym").InnerText;

            NewNumber(nodeList.Count);
            random = randomList.Last();

            textBox11.Text = nodeList[random].SelectSingleNode("word").InnerText;
            textBox12.Text = nodeList[random].SelectSingleNode("antonym").InnerText;
        }
    }
}
