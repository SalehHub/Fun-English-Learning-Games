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
    public partial class POS : Form
    {
        public POS()
        {
            InitializeComponent();
        }


        public phrasesLevel phrasesLevelForm;
        public mainLevels mainLevelsForm;

        XmlDocument xmlDoc = new XmlDocument();
        public string sentence = "", word = "", ans1 = "", ans2 = "", ans3 = "";
        public int attempts = 3;
        public int question = 1;
        string playerAnswer = "";
        public Random a = new Random();
        public int points = 0;
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
        private void POS_Load(object sender, EventArgs e)
        {

            radioButton1.Checked = false;

            attempts = 3;
            picFeedback.Visible = false;
            lblNoOfQuestion.Text = "Question 1 of 5";
            question = 1;
            lblAttempts.Text = attempts.ToString();
            points = 0;
            lblPoints.Text = points.ToString();
            picFeedback.Image = null;
            btnCheckAnswer.Text = "Check your answer";

            // Ensure WaitOnLoad is false.
            pictureBox5.WaitOnLoad = false;

            // Load the image asynchronously.
            pictureBox5.LoadAsync(@"https://media.giphy.com/media/Bn6djQ6MgEWZi/giphy.gif");
            xmlDoc.Load("XML/PartOfSpeech.xml");
            //this.Synonyms();
            this.GenPartsOfSpeech();
        }

        public void GenPartsOfSpeech()
        {
            try
            {
                XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/partOfSpeech");



                //foreach (XmlNode node in nodeList)


                NewNumber(nodeList.Count);
                int random = randomList.Last();

                sentence = nodeList[random].SelectSingleNode("sentence").InnerText;
                word = nodeList[random].SelectSingleNode("word").InnerText;
                ans1 = nodeList[random].SelectSingleNode("answer1").InnerText;
                ans2 = nodeList[random].SelectSingleNode("answer2").InnerText;
                ans3 = nodeList[random].SelectSingleNode("answer3").InnerText;

                answers.Add(ans1);
                answers.Add(ans2);
                answers.Add(ans3);


                Shuffle(answers);
                sentenceLable.Text = sentence;
                wordLabel.Text = word;

                int r = a.Next(1, 3);
                if (r == 1)
                {
                    radioButton1.Text = ans1;
                    radioButton2.Text = ans2;
                    radioButton3.Text = ans3;
                }
                else if (r == 2)
                {
                    radioButton2.Text = ans1;
                    radioButton1.Text = ans2;
                    radioButton3.Text = ans3;

                }
                else
                {
                    radioButton1.Text = ans2;
                    radioButton3.Text = ans1;
                    radioButton2.Text = ans3;


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            lblFeedback.Visible = false;

            if (btnCheckAnswer.Text == "Try Again")
            {
                btnCheckAnswer.Text = "Check your answer";

                picFeedback.Visible = false;
                //lblFeedback.Visible = false;
                //lblCorrectAns.Visible = false;

            }
            else if (btnCheckAnswer.Text == "Next Question")

            {
                attempts = 3;
                lblAttempts.Text = attempts.ToString();
                lblCorrectAns.Visible = false;
                // question++;
                picFeedback.Visible = false;
                //lblFeedback.Visible = false;

                GenPartsOfSpeech();

                lblNoOfQuestion.Text = "Question " + question.ToString() + " of 5";

                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;


                btnCheckAnswer.Text = "Check your answer";


            }
            else if (btnCheckAnswer.Text == "Go to the next level >>")
            {
                GoToNextLevel();
            }
            else if (btnCheckAnswer.Text == "Start this level again")
            {

                POS_Load(sender, e);
            }
            else
            {
                if (radioButton1.Checked)
                {
                    playerAnswer = radioButton1.Text;
                }
                if (radioButton2.Checked)
                {
                    playerAnswer = radioButton2.Text;
                }
                if (radioButton3.Checked)
                {
                    playerAnswer = radioButton3.Text;
                }

                picFeedback.Visible = true;


                if (playerAnswer.Trim() == ans1.Trim())
                {

                    /* points += attempts + 2;
                     lblPoints.Text = points.ToString();
                     attempts = 3;
                     lblAttempts.Text = attempts.ToString();
                     picFeedback.BackgroundImage = Properties.Resources.check;
                     lblFeedback.Visible = true;
                     lblFeedback.Text = "Good job! Keep up the good work";
                     lblFeedback.ForeColor = Color.Green;
                     picFeedback.Visible = true;

                     btnCheckAnswer.Text = "Next Question";
                     //lblFeedback.Visible = false;
                     */

                    CorrectAnswer();
                }
                else
                {
                    IncorrectAnswer();
                }
            }
        }

        public void GoToNextLevel()
        {
            IdiomsLesson IdiomsLesson = new IdiomsLesson();
            IdiomsLesson.phrasesLevelForm = this.phrasesLevelForm;
            this.Hide();
            IdiomsLesson.Show();
        }

        private void POS_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.phrasesLevelForm.Show();
            }
            catch (Exception ex)
            {

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

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void lblAttempts_Click(object sender, EventArgs e)
        {

        }

        private void lblFeedback_Click(object sender, EventArgs e)
        {

        }

        public void IncorrectAnswer()
        {
            attempts--;
            lblAttempts.Text = attempts.ToString();


            if (attempts == 0 && question < 5)  //No more attempts
            {
                question++;
                lblCorrectAns.Visible = true;
                picFeedback.Visible = false;
                lblCorrectAns.Text = "The correct answer is " + ans1;

                lblFeedback.Text = "Sorry this is incorrect answer try again in the next question";
                lblFeedback.Visible = true;
                lblFeedback.ForeColor = Color.Red;
                lblNoOfQuestion.Text = "Question " + question.ToString() + " of 3";

                //attempts = 3;
                lblAttempts.Text = attempts.ToString();
                lblFeedback.Visible = false;
                btnCheckAnswer.Text = "Next Question";
            }
            else if (attempts == 0 && question == 5)    //last attepmt and last question
            {
                attempts = 3;
                //question = 3;
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


        public void CorrectAnswer()
        {
            question++;


            picFeedback.BackgroundImage = Properties.Resources.check;

            lblFeedback.Text = "Good job! Keep up the good work"; lblFeedback.Visible = true; lblFeedback.ForeColor = Color.Green;
            btnCheckAnswer.Text = "Next Question";

            points += attempts + 0;
            /*calculate points*/
            lblPoints.Text = points.ToString();//(int.Parse(lblPoints.Text) + 3).ToString();
                                               // SavePoints();


            if (question == 6)
            {
                lblFeedback.Text = "Great job! Keep up the good work in the next level"; lblFeedback.Visible = true; lblFeedback.ForeColor = Color.Green;

                btnCheckAnswer.Text = "Go to the next level >>";
            }

            SavePoints();
        }

        //Save and pass points between main levels form and words levels form.
        public void SavePoints()
        {
            this.mainLevelsForm.partsOfSpeechPoints = points;
            this.phrasesLevelForm.partsOfSpeechPoints = points;

            this.mainLevelsForm.lblPhrasesPoints.Text = points.ToString();
            this.phrasesLevelForm.lblPartOfSpeechPoints.Text = points.ToString();

            mainLevelsForm.CF.partsOfSpeechPoints = points;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
