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
    public partial class HomonymsLesson : Form
    {
        public HomonymsLesson()
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
            homonyms homonyms = new homonyms();
            homonyms.mainLevelsForm = this.mainLevelsForm;
            this.Hide();
            homonyms.Show();
        }

        private void HomonymsLesson_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.mainLevelsForm.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void HomonymsLesson_Load(object sender, EventArgs e)
        {
            try
            {

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("questions.xml");
                XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/homonyms");


                string def1 = "", def2 = "", ans = "";
                //foreach (XmlNode node in nodeList)

                NewNumber(nodeList.Count);
                int random = randomList.Last();
                lbl1.Text = nodeList[random].SelectSingleNode("def1").InnerText;
                lbl2.Text = nodeList[random].SelectSingleNode("def2").InnerText;
                textBox1.Text = nodeList[random].SelectSingleNode("answer").InnerText;


                NewNumber(nodeList.Count);
                random = randomList.Last();
                lbl3.Text = nodeList[random].SelectSingleNode("def1").InnerText;
                lbl4.Text = nodeList[random].SelectSingleNode("def2").InnerText;
                textBox2.Text = nodeList[random].SelectSingleNode("answer").InnerText;


                NewNumber(nodeList.Count);
                random = randomList.Last();
                lbl5.Text = nodeList[random].SelectSingleNode("def1").InnerText;
                lbl6.Text = nodeList[random].SelectSingleNode("def2").InnerText;
                textBox3.Text = nodeList[random].SelectSingleNode("answer").InnerText;


                NewNumber(nodeList.Count);
                random = randomList.Last();
                lbl7.Text = nodeList[random].SelectSingleNode("def1").InnerText;
                lbl8.Text = nodeList[random].SelectSingleNode("def2").InnerText;
                textBox4.Text = nodeList[random].SelectSingleNode("answer").InnerText;


                NewNumber(nodeList.Count);
                random = randomList.Last();
                lbl9.Text = nodeList[random].SelectSingleNode("def1").InnerText;
                lbl10.Text = nodeList[random].SelectSingleNode("def2").InnerText;
                textBox5.Text = nodeList[random].SelectSingleNode("answer").InnerText;


                NewNumber(nodeList.Count);
                random = randomList.Last();
                lbl11.Text = nodeList[random].SelectSingleNode("def1").InnerText;
                lbl12.Text = nodeList[random].SelectSingleNode("def2").InnerText;
                textBox6.Text = nodeList[random].SelectSingleNode("answer").InnerText;


                NewNumber(nodeList.Count);
                random = randomList.Last();
                lbl13.Text = nodeList[random].SelectSingleNode("def1").InnerText;
                lbl14.Text = nodeList[random].SelectSingleNode("def2").InnerText;
                textBox7.Text = nodeList[random].SelectSingleNode("answer").InnerText;


                NewNumber(nodeList.Count);
                random = randomList.Last();
                lbl15.Text = nodeList[random].SelectSingleNode("def1").InnerText;
                lbl16.Text = nodeList[random].SelectSingleNode("def2").InnerText;
                textBox8.Text = nodeList[random].SelectSingleNode("answer").InnerText;


                NewNumber(nodeList.Count);
                random = randomList.Last();
                lbl17.Text = nodeList[random].SelectSingleNode("def1").InnerText;
                lbl18.Text = nodeList[random].SelectSingleNode("def2").InnerText;
                textBox9.Text = nodeList[random].SelectSingleNode("answer").InnerText;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
