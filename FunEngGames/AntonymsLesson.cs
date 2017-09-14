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

            GenAntonym(textBox1,    textBox2,   nodeList);
            GenAntonym(textBox3,    textBox4,   nodeList);
            GenAntonym(textBox5,    textBox6,   nodeList);
            GenAntonym(textBox7,    textBox8,   nodeList);
            GenAntonym(textBox9,    textBox10,  nodeList);
            GenAntonym(textBox11,   textBox12,  nodeList);
            GenAntonym(textBox13,   textBox14,  nodeList);
            GenAntonym(textBox15,   textBox16,  nodeList);
            GenAntonym(textBox17,   textBox18,  nodeList);

            /*
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

            NewNumber(nodeList.Count);
            random = randomList.Last();
            textBox13.Text = nodeList[random].SelectSingleNode("word").InnerText;
            textBox14.Text = nodeList[random].SelectSingleNode("antonym").InnerText;

            NewNumber(nodeList.Count);
            random = randomList.Last();
            textBox15.Text = nodeList[random].SelectSingleNode("word").InnerText;
            textBox16.Text = nodeList[random].SelectSingleNode("antonym").InnerText;

            NewNumber(nodeList.Count);
            random = randomList.Last();
            textBox17.Text = nodeList[random].SelectSingleNode("word").InnerText;
            textBox18.Text = nodeList[random].SelectSingleNode("antonym").InnerText;
            */
        }

        public void GenAntonym(TextBox t1, TextBox t2, XmlNodeList nodeList)
        {
            NewNumber(nodeList.Count);
            t1.Text = nodeList[randomList.Last()].SelectSingleNode("word").InnerText;
            t2.Text = nodeList[randomList.Last()].SelectSingleNode("antonym").InnerText;
        }
    }
}
