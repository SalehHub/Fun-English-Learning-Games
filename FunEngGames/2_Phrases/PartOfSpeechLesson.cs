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
    public partial class POSLesson : Form
    {
        public POSLesson()
        {
            InitializeComponent();
        }


        public Random a = new Random();
        public List<int> randomList = new List<int>();
        public phrasesLevel mainLevelsForm;
        XmlDocument xmlDoc = new XmlDocument();
        XmlNodeList nodeList;

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

        private void POSLesson_Load(object sender, EventArgs e)
        {
            xmlDoc.Load("XML/questions.xml");
            nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/partOfSpeech");

            GenPOS(textBox1,  textBox2,  textBox3,  nodeList);
            GenPOS(textBox4,  textBox5,  textBox6,  nodeList);
            GenPOS(textBox7,  textBox8,  textBox9,  nodeList);
            GenPOS(textBox10, textBox11, textBox12, nodeList);
            GenPOS(textBox13, textBox14, textBox15, nodeList);
            GenPOS(textBox16, textBox17, textBox18, nodeList);
            GenPOS(textBox19, textBox20, textBox21, nodeList);
            GenPOS(textBox22, textBox23, textBox24, nodeList);

        }

        private void POSLesson_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.mainLevelsForm.Show();
            }
            catch (Exception ex)
            {

            }
        }


        public void GenPOS(TextBox t1, TextBox t2, TextBox t3, XmlNodeList nodeList)
        {
            NewNumber(nodeList.Count);
            t1.Text = nodeList[randomList.Last()].SelectSingleNode("sentence").InnerText;
            t2.Text = nodeList[randomList.Last()].SelectSingleNode("word").InnerText;
            t3.Text = nodeList[randomList.Last()].SelectSingleNode("answer").InnerText;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            POS POS = new POS();
            POS.mainLevelsForm = this.mainLevelsForm;
            this.Hide();
            POS.Show();
        }
    }
}
