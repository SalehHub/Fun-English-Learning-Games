using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Xml;

namespace FunEngGames
{
    public partial class spelling : Form
    {
        public spelling()
        {
            InitializeComponent();
        }


        public wordsLevel mainLevelsForm;


        public Random a = new Random();
        public List<int> randomList = new List<int>();
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


        private void spelling_Load(object sender, EventArgs e)
        {
            try
            {

                // Ensure WaitOnLoad is false.
                pictureBox5.WaitOnLoad = false;

                // Load the image asynchronously.
                pictureBox5.LoadAsync(@"https://media.giphy.com/media/Bn6djQ6MgEWZi/giphy.gif");

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("questions.xml");
                XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/spelling");

                /*
                XmlNode xmlquestions= xmlDoc.SelectSingleNode("/Questions");
                XmlNode xmlRecordNo = xmlDoc.CreateNode(XmlNodeType.Element, "spelling", null);
                XmlNode xmlpic      = xmlDoc.CreateNode(XmlNodeType.Element, "pic", null);
                XmlNode xmlans      = xmlDoc.CreateNode(XmlNodeType.Element, "answer", null);

                xmlpic.InnerText    = "7.png";
                xmlans.InnerText    = "Spoon";

                xmlRecordNo.AppendChild(xmlpic);
                xmlRecordNo.AppendChild(xmlans);

                xmlquestions.AppendChild(xmlRecordNo);
                xmlDoc.Save("output.xml");
                */

                string pic = "", ans = "";
                //foreach (XmlNode node in nodeList)

                NewNumber(nodeList.Count);
                int random = randomList.Last();

                pic = nodeList[random].SelectSingleNode("pic").InnerText;
                ans = nodeList[random].SelectSingleNode("answer").InnerText;

                pictureBox1.Image = Image.FromFile(@"Images\" + pic);
                label1.Text = ans;


                NewNumber(nodeList.Count);
                random = randomList.Last();

                pic = nodeList[random].SelectSingleNode("pic").InnerText;
                ans = nodeList[random].SelectSingleNode("answer").InnerText;
                pictureBox2.Image = Image.FromFile(@"Images\" + pic);
                label2.Text = ans;


                NewNumber(nodeList.Count);
                random = randomList.Last();

                pic = nodeList[random].SelectSingleNode("pic").InnerText;
                ans = nodeList[random].SelectSingleNode("answer").InnerText;
                pictureBox3.Image = Image.FromFile(@"Images\" + pic);
                label3.Text = ans;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void picCheckAnswers_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().ToLower() == label1.Text.Trim().ToLower())
            {
                picAns1.BackgroundImage = Properties.Resources.check;
            }
            else
            {
                picAns1.BackgroundImage = Properties.Resources.cross;
            }




            if (textBox2.Text.Trim().ToLower() == label2.Text.Trim().ToLower())
            {
                picAns2.BackgroundImage = Properties.Resources.check;
            }
            else
            {
                picAns2.BackgroundImage = Properties.Resources.cross;
            }




            if (textBox3.Text.Trim().ToLower() == label3.Text.Trim().ToLower())
            {
                picAns3.BackgroundImage = Properties.Resources.check;
            }
            else
            {
                picAns3.BackgroundImage = Properties.Resources.cross;
            }

        }

        private void picCheckAnswers_MouseHover(object sender, EventArgs e)
        {
            picCheckAnswers.BackgroundImage = Properties.Resources.checkYourAswers_hover;
        }

        private void picCheckAnswers_MouseLeave(object sender, EventArgs e)
        {
            picCheckAnswers.BackgroundImage = Properties.Resources.checkYourAswers;
        }

        private void spelling_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.mainLevelsForm.Show();
        }

    }
}
