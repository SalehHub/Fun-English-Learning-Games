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
    public partial class IdiomsLesson : Form
    {
        public IdiomsLesson()
        {
            InitializeComponent();
        }


        public Random a = new Random();
        public List<int> randomList = new List<int>();
        public phrasesLevel phrasesLevelForm;
        public mainLevels mainLevelsForm;

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

        private void IdiomsLesson_Load(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("XML/idioms.xml");
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/idioms");

            GenIdiom(label1,label2, nodeList);
            GenIdiom(label3,label4, nodeList);
            GenIdiom(label5,label6, nodeList);
            GenIdiom(label7,label8, nodeList);
            GenIdiom(label9,label10, nodeList);
            GenIdiom(label11,label12, nodeList);
            GenIdiom(label13,label14, nodeList);
            GenIdiom(label15,label16, nodeList);
            GenIdiom(label17,label18, nodeList);
            GenIdiom(label19,label20, nodeList);


        }



        public void GenIdiom(Label t1, Label t2, XmlNodeList nodeList)
        {
            NewNumber(nodeList.Count);
            t1.Text = nodeList[randomList.Last()].SelectSingleNode("idiom").InnerText;
            t2.Text = nodeList[randomList.Last()].SelectSingleNode("meaning").InnerText;


        }


        private void IdiomsLesson_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.phrasesLevelForm.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void lblReady_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Idioms Idioms = new Idioms();
            Idioms.mainLevelsForm = this.mainLevelsForm;
            Idioms.phrasesLevelForm = this.phrasesLevelForm;
            this.Hide();
            Idioms.Show();
        }
    }
}
