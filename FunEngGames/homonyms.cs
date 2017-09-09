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
    public partial class homonyms : Form
    {
        public homonyms()
        {
            InitializeComponent();
        }

        public wordsLevel mainLevelsForm;

        public Random a = new Random();

        public List<int> randomList = new List<int>();
        public List<string> answers = new List<string>();

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

        private void homonyms_Load(object sender, EventArgs e)
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

                def1 = nodeList[random].SelectSingleNode("def1").InnerText;
                def2 = nodeList[random].SelectSingleNode("def2").InnerText;
                ans = nodeList[random].SelectSingleNode("answer").InnerText;

                answers.Add(ans);
                //comboBox1.Items.Add(ans); comboBox2.Items.Add(ans); comboBox3.Items.Add(ans);
                lblAns1.Text = ans;
                label1.Text = def1;
                label4.Text = def2;





                NewNumber(nodeList.Count);
                random = randomList.Last();

                def1 = nodeList[random].SelectSingleNode("def1").InnerText;
                def2 = nodeList[random].SelectSingleNode("def2").InnerText;
                ans = nodeList[random].SelectSingleNode("answer").InnerText;

                answers.Add(ans);
                //comboBox1.Items.Add(ans); comboBox2.Items.Add(ans); comboBox3.Items.Add(ans);
                lblAns2.Text = ans;
                label2.Text = def1;
                label5.Text = def2;





                NewNumber(nodeList.Count);
                random = randomList.Last();

                def1 = nodeList[random].SelectSingleNode("def1").InnerText;
                def2 = nodeList[random].SelectSingleNode("def2").InnerText;
                ans = nodeList[random].SelectSingleNode("answer").InnerText;

                answers.Add(ans);
                //comboBox1.Items.Add(ans); comboBox2.Items.Add(ans); comboBox3.Items.Add(ans);
                lblAns3.Text = ans;
                label3.Text = def1;
                label6.Text = def2;

                Shuffle(answers);
                comboBox1.Items.AddRange(answers.ToArray());
                comboBox2.Items.AddRange(answers.ToArray());
                comboBox3.Items.AddRange(answers.ToArray());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void Shuffle(List<string> list)
        {
            int n = list.Count;
            Random rnd = new Random();
            while (n > 1)
            {
                int k = (rnd.Next(0, n) % n);
                n--;
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private void homonyms_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.mainLevelsForm.Show();
        }

        private void picCheckAnswers_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim().ToLower() == lblAns1.Text.Trim().ToLower())
            {
                picAns1.BackgroundImage = Properties.Resources.check;
            }
            else
            {
                picAns1.BackgroundImage = Properties.Resources.cross;
            }




            if (comboBox2.Text.Trim().ToLower() == lblAns2.Text.Trim().ToLower())
            {
                picAns2.BackgroundImage = Properties.Resources.check;
            }
            else
            {
                picAns2.BackgroundImage = Properties.Resources.cross;
            }




            if (comboBox3.Text.Trim().ToLower() == lblAns3.Text.Trim().ToLower())
            {
                picAns3.BackgroundImage = Properties.Resources.check;
            }
            else
            {
                picAns3.BackgroundImage = Properties.Resources.cross;
            }
        }
    }
}
