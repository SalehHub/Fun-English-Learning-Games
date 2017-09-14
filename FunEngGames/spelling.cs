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
        public string pic1 = "", ans1 = "";
        public string pic2 = "", ans2 = "";
        public string pic3 = "", ans3 = "";
        public int question=1;
        public int hints = 2;
        public int attempts = 3;
        public int points = 0;


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



        public void RemoveText()
        {
            if (textBox1.Text== "Type your answer here...") {
                
                    textBox1.Text = "";
                }
        }

        public void AddText()
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text)) { 
                textBox1.Text = "Type your answer here...";
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



                //foreach (XmlNode node in nodeList)

                NewNumber(nodeList.Count);
                int random = randomList.Last();

                pic1 = nodeList[random].SelectSingleNode("pic").InnerText;
                ans1 = nodeList[random].SelectSingleNode("answer").InnerText;

                pictureBox1.Image = Image.FromFile(@"Images\" + pic1);
                label1.Text = ans1;


                NewNumber(nodeList.Count);
                random = randomList.Last();

                pic2 = nodeList[random].SelectSingleNode("pic").InnerText;
                ans2 = nodeList[random].SelectSingleNode("answer").InnerText;
                //pictureBox2.Image = Image.FromFile(@"Images\" + pic);
                label2.Text = ans2;


                NewNumber(nodeList.Count);
                random = randomList.Last();

                pic3 = nodeList[random].SelectSingleNode("pic").InnerText;
                ans3 = nodeList[random].SelectSingleNode("answer").InnerText;
               //pictureBox3.Image = Image.FromFile(@"Images\" + pic);
               label3.Text = ans3;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void picCheckAnswers_Click(object sender, EventArgs e)
        {
            lblAttempts.Text = (int.Parse(lblAttempts.Text)-1).ToString();
            if (textBox1.Text.Trim().ToLower() == label1.Text.Trim().ToLower())
            {
                picAns1.BackgroundImage = Properties.Resources.check;
                picAns1.Left = pictureBox1.Left;
                picAns1.Top = pictureBox1.Top;


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

        private void textBox1_Enter(object sender, EventArgs e)
        {

            RemoveText();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            AddText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                lblFeedback.Visible = false;

                if (button3.Text == "Start this level again")
                {

                    spelling_Load(sender, e);
                    randomList.Clear();
                    question = 1;
                    lblPoints.Text = "0";

                    lblAttempts.Text = "3";
                    attempts = 3;

                    picAns1.Visible = false;

                    button3.Text = "Check your answer";
                    label5.Text = "Question " + question + " out of 3";



                }
                else if (button3.Text == "Go to the next level >")
                {
                    S_A S_A = new S_A();
                    S_A.mainLevelsForm = mainLevelsForm;
                    this.Hide();
                    S_A.Show();
                }
                else if (button3.Text == "Next Question")
                {
                    button3.Text = "Check your answer";

                    // question++;

                    lblCorrectAns.Visible = false;
                    label5.Text = "Question " + question + " out of 3";

                    if (question == 2)
                    {
                        pictureBox1.Image = Image.FromFile(@"Images\" + pic2);
                        label1.Text = ans2;
                    }
                    else if (question == 3)
                    {
                        pictureBox1.Image = Image.FromFile(@"Images\" + pic3);
                        label1.Text = ans3;
                    }
                    picAns1.Visible = false;

                    lblAttempts.Text = "3";
                    attempts = 3;

                    textBox1.Text = "Type your answer here...";


                }
                else if (button3.Text == "Try Again")
                {
                    button3.Text = "Check your answer";
                    picAns1.Visible = false;

                }
                else if (button3.Text == "Check your answer")
                {

                    picAns1.Visible = true;

  /*correct*/       if (textBox1.Text.Trim().ToLower() == label1.Text.Trim().ToLower())
                    {
                        question++;

                        picAns1.BackgroundImage = Properties.Resources.check;

                        lblFeedback.Text = "Good job! Keep up the good work";lblFeedback.Visible = true;lblFeedback.ForeColor = Color.Green;
                        button3.Text = "Next Question";

                        points += hints + attempts;
/*calculate points*/    lblPoints.Text = points.ToString();//(int.Parse(lblPoints.Text) + 3).ToString();

                        if (question == 4)
                        {
                            lblFeedback.Text = "Good job! Keep up the good work in the next level"; lblFeedback.Visible = true; lblFeedback.ForeColor = Color.Green;
                            button3.Text = "Go to the next level >";
                        }


                    }
/*incorrect*/         else
                    {
                       
                        attempts--;
                        lblAttempts.Text = attempts.ToString();

                        if (attempts == 0 && question < 3)
                        {
                            question++;
                            lblCorrectAns.Visible = true;
                            picAns1.Visible = false;
                            lblCorrectAns.Text = "The correct answer is " + label1.Text;

                            lblFeedback.Text = "Sorry this is not a correct answer try again in the next question.";
                            lblFeedback.Visible = true;
                            lblFeedback.ForeColor = Color.Red;

                            button3.Text = "Next Question";

                        }
                        else if (attempts == 0 && question == 3)
                        {
                            button3.Text = "Start this level again";
                        }
                        else
                        {
                            lblFeedback.Text = "Sorry this is not a correct answer try again.";
                            lblFeedback.Visible = true;
                            lblFeedback.ForeColor = Color.Red;

                            picAns1.BackgroundImage = Properties.Resources.cross;
                            button3.Text = "Try Again";
                        }
                    }
                }

            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }

        }

        private void picCheckAnswers_MouseHover(object sender, EventArgs e)
        {
            picCheckAnswers.BackgroundImage = Properties.Resources.checkYourAswer_hover;
        }

        private void picCheckAnswers_MouseLeave(object sender, EventArgs e)
        {
            picCheckAnswers.BackgroundImage = Properties.Resources.checkYourAswer;
        }

        private void spelling_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.mainLevelsForm.Show();
            }catch(Exception ex)
            {
                
            }
        }

    }
}
