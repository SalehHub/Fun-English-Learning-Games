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
    public partial class Spelling : Form
    {
        public Spelling()
        {
            InitializeComponent();
        }


        public wordsLevel wordLevelsForm;
        public mainLevels mainLevelsForm;

        public string pic1 = "", ans1 = "";
        public string pic2 = "", ans2 = "";
        public string pic3 = "", ans3 = "";

        public int question=1;
        public int hints = 2;
        public int attempts = 3;
        public int points = 0;

        CommonFunctions CommonFunctions = new CommonFunctions();

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
            if (txtAnswer.Text== "Type your answer here...") {
                
                    txtAnswer.Text = "";
                }
        }



        public void AddText()
        {
            if (String.IsNullOrWhiteSpace(txtAnswer.Text)) { 
                txtAnswer.Text = "Type your answer here...";
            }
        }



        private void spelling_Load(object sender, EventArgs e)
        {
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


            Cursor cur = new Cursor(Properties.Resources.audio.Handle);
            picWord.Cursor = cur;

            StartLevelAgain();

        }

        private void picCheckAnswers_Click(object sender, EventArgs e)
        {
            lblAttempts.Text = (int.Parse(lblAttempts.Text)-1).ToString();
            if (txtAnswer.Text.Trim().ToLower() == lblAnswer.Text.Trim().ToLower())
            {
                picFeedback.BackgroundImage = Properties.Resources.check;
                picFeedback.Left = picWord.Left;
                picFeedback.Top = picWord.Top;


            }
            else
            {
                picFeedback.BackgroundImage = Properties.Resources.cross;
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


        private void txtAnswer_Enter(object sender, EventArgs e)
        {
            RemoveText();
        }

        private void txtAnswer_Leave(object sender, EventArgs e)
        {
            AddText();
        }



        public void StartLevelAgain()
        {
                // Ensure WaitOnLoad is false.
                pictureBox5.WaitOnLoad = false;

                // Load the image asynchronously.
                pictureBox5.LoadAsync(@"https://media.giphy.com/media/Bn6djQ6MgEWZi/giphy.gif");

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("XML/spelling.xml");
                XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/"+ "furniture" + "/spelling");

                NewNumber(nodeList.Count);
                int random = randomList.Last();

                pic1 = nodeList[random].SelectSingleNode("answer").InnerText.Trim()+".png"; 
                ans1 = nodeList[random].SelectSingleNode("answer").InnerText;

                picWord.Image = Image.FromFile(@"Images\" + pic1);
                lblAnswer.Text = ans1;

                 nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/" + "animals" + "/spelling");

                NewNumber(nodeList.Count);
                random = randomList.Last();

                pic2 = nodeList[random].SelectSingleNode("answer").InnerText.Trim() + ".png";
                ans2 = nodeList[random].SelectSingleNode("answer").InnerText;
                //pictureBox2.Image = Image.FromFile(@"Images\" + pic);
                label2.Text = ans2;

                nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/" + "fruits" + "/spelling");

                NewNumber(nodeList.Count);
                random = randomList.Last();

                pic3 = nodeList[random].SelectSingleNode("answer").InnerText.Trim() + ".png";
                ans3 = nodeList[random].SelectSingleNode("answer").InnerText;
                //pictureBox3.Image = Image.FromFile(@"Images\" + pic);
                label3.Text = ans3;

                randomList.Clear();
                question = 1;

                points = 0;
                lblPoints.Text = "0";

                hints = 2;

                lblAttempts.Text = "3";
                attempts = 3;

                picFeedback.Visible = false;

                btnCheckAnswer.Text = "Check your answer";
                label5.Text = "Question " + question + " out of 3";           
        }


        public void GoToNextLevel()
        {
            SynonymsLesson SynonymsLesson = new SynonymsLesson();
            SynonymsLesson.mainLevelsForm = mainLevelsForm;
            SynonymsLesson.wordLevelsForm = wordLevelsForm;
            this.Hide();
            SynonymsLesson.Show();
        }

        public void NextQuestion()
        {
            btnCheckAnswer.Text = "Check your answer";

            //reset hints buttons
            lblFirstHint.Visible = false;
            btnFirstHint.Visible = true;
            picLock.Visible = true;
            btnSecondHint.Enabled = false;
            lblSecondHint.Visible = false;
            btnSecondHint.Visible = true;
            hints = 2;

            // question++;
            lblCorrectAns.Visible = false;
            label5.Text = "Question " + question + " out of 3";

            if (question == 2)
            {
                picWord.Image = Image.FromFile(@"Images\" + pic2);
                lblAnswer.Text = ans2;
            }
            else if (question == 3)
            {
                picWord.Image = Image.FromFile(@"Images\" + pic3);
                lblAnswer.Text = ans3;
            }

            picFeedback.Visible = false;

            lblAttempts.Text = "3";
            attempts = 3;

            txtAnswer.Text = "Type your answer here...";
        }

        public void TryAgain()
        {
            btnCheckAnswer.Text = "Check your answer";
            picFeedback.Visible = false;
        }


        public void CorrectAnswer()
        {
            question++;

            picFeedback.BackgroundImage = Properties.Resources.check;

            lblFeedback.Text = "Good job! Keep up the good work"; lblFeedback.Visible = true; lblFeedback.ForeColor = Color.Green;
            btnCheckAnswer.Text = "Next Question";

            points += hints + attempts;
            /*calculate points*/
            lblPoints.Text = points.ToString();//(int.Parse(lblPoints.Text) + 3).ToString();
            SavePoints();


            if (question == 4)
            {
                lblFeedback.Text = "Great job! Keep up the good work in the next level"; lblFeedback.Visible = true; lblFeedback.ForeColor = Color.Green;

                btnCheckAnswer.Text = "Go to the next level >>";
            }
        }


        public void IncorrectAnswer()
        {
            attempts--;
            lblAttempts.Text = attempts.ToString();

            
            if (attempts == 0 && question < 3)  //No more attempts
            {
                question++;
                lblCorrectAns.Visible = true;
                picFeedback.Visible = false;
                lblCorrectAns.Text = "The correct answer is " + lblAnswer.Text;

                lblFeedback.Text = "Sorry this is incorrect answer try again in the next question";
                lblFeedback.Visible = true;
                lblFeedback.ForeColor = Color.Red;

                btnCheckAnswer.Text = "Next Question";
            }
            else if (attempts == 0 && question == 3)    //last attepmt and last question
            {
                lblFeedback.Text = "Sorry this is incorrect answer try again from begining";
                lblFeedback.Visible = true;
                btnCheckAnswer.Text = "Start this level again";
            }
            else
            {
                lblFeedback.Text = "Sorry this incorrect answer try again";
                lblFeedback.Visible = true;
                lblFeedback.ForeColor = Color.Red;

                picFeedback.BackgroundImage = Properties.Resources.cross;
                btnCheckAnswer.Text = "Try Again";
            }
        }



        public void CheckYourAnswer()
        {
            picFeedback.Visible = true;
           
            if (txtAnswer.Text.Trim().ToLower() == lblAnswer.Text.Trim().ToLower())
            {
                /*correct answer*/
                CorrectAnswer();
            }
           
            else
            { 
                /*incorrect answer*/
                IncorrectAnswer();
            }
        }



        private void btnCheckAnswer_Click(object sender, EventArgs e)
        {
            try
            {
                lblFeedback.Visible = false;

                if (txtAnswer.Text.Trim()=="" || txtAnswer.Text.Trim()== "Type your answer here...")
                {
                    lblFeedback.Visible = true;
                    lblFeedback.ForeColor = Color.Red;
                    lblFeedback.Text = "Type an answer first";
                    timer1.Start();
                }
                else if (btnCheckAnswer.Text == "Start this level again")
                {
                    StartLevelAgain();
                }
                else if (btnCheckAnswer.Text == "Go to the next level >>")
                {
                    GoToNextLevel();
                }
                else if (btnCheckAnswer.Text == "Next Question")
                {
                    NextQuestion();
                }
                else if (btnCheckAnswer.Text == "Try Again")
                {
                    TryAgain();
                }
                else if (btnCheckAnswer.Text == "Check your answer")
                {
                    CheckYourAnswer();
                }

            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void picCheckAnswers_MouseHover(object sender, EventArgs e)
        {
            picCheckAnswers.BackgroundImage = Properties.Resources.checkYourAswer_hover;
        }



        //First hint function
        private void btnFirstHint_Click(object sender, EventArgs e)
        {
            lblFirstHint.Text = "First hint:" + "The number of letters in this word = " + lblAnswer.Text.Length;
            lblFirstHint.Visible = true;
            btnFirstHint.Visible = false;
            picLock.Visible = false;
            btnSecondHint.Enabled = true;
            hints--;
        }


        //Second hint function
        private void btnSecondHint_Click(object sender, EventArgs e)
        {
            lblSecondHint.Text="Second hint: The word start with "+ CommonFunctions.UppercaseFirst(lblAnswer.Text.Substring(0, 1))+" and ends with "+ CommonFunctions.UppercaseFirst(lblAnswer.Text.Substring(lblAnswer.Text.Length - 1, 1));
            lblSecondHint.Visible = true;
            btnSecondHint.Visible = false;
            hints--;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CommonFunctions.Pronounce(lblAnswer.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFeedback.Visible = false;
            timer1.Enabled = false;
        }

        private void picCheckAnswers_MouseLeave(object sender, EventArgs e)
        {
            picCheckAnswers.BackgroundImage = Properties.Resources.checkYourAswer;
        }


        //Form closing function
        private void spelling_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.wordLevelsForm.Show();

            }catch(Exception ex)
            {
                
            }
        }


        public void SavePoints()
        {
            this.mainLevelsForm.spellingPoints = points;
            this.wordLevelsForm.spellingPoints = points;

            this.mainLevelsForm.lblWordsPoints.Text = points.ToString();
            this.wordLevelsForm.lblSpellingPoints.Text = points.ToString();

           mainLevelsForm.CF.spellingPoints = points;
        }

    }
}
