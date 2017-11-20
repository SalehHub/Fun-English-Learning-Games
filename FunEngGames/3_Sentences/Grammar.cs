using FunEngGames._3_Sentences;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;


namespace FunEngGames
{
    public partial class Grammar : Form
    {
        public Grammar()
        {
            InitializeComponent();
        }

        XmlDocument xmlDoc = new XmlDocument();

        public mainLevels mainLevelsForm;
        
        public sentenceLevels sentenceLevelsForm;

        public Random a = new Random();
        public List<string> sentences  = new List<string>();
        public List<string> answers = new List<string>();
        public List<string> optionsA = new List<string>();
        public List<string> optionsB = new List<string>();

        String answerNow;
        public int question = 1;
        public int CorrectAnswers = 0;
        public int hints = 0;
        public int attempts = 2;
        public int points = 0;
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

        private void POS_Load(object sender, EventArgs e)
        {
            // Ensure WaitOnLoad is false.
            pictureBox5.WaitOnLoad = false;

            // Load the image asynchronously.
            pictureBox5.LoadAsync(@"https://media.giphy.com/media/Bn6djQ6MgEWZi/giphy.gif");

            xmlDoc.Load("XML/Grammar.xml");
            this.GenerateGrammar();
        
        }

        public void GenerateGrammar()
        {
            try
            {
                XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/Grammar");
                string sentence = "", answer = "", optionA ="", optionB ="";

                NewNumber(nodeList.Count);
                int random = randomList.Last();

                sentence = nodeList[random].SelectSingleNode("sentence").InnerText;
                answer = nodeList[random].SelectSingleNode("answer").InnerText;
                answerNow = answer;
                optionA = nodeList[random].SelectSingleNode("optionA").InnerText;
                optionB = nodeList[random].SelectSingleNode("optionB").InnerText;
                
                sentences.Add(sentence);
                label1.Text = sentence;

                Random r = new Random();
                int rInt = r.Next(1, 3);

                if (rInt == 1)
                {
                    answers.Add(answer);
                    radioButton1.Text = answer;
                    optionsA.Add(optionA);
                    radioButton2.Text = optionA;
                    optionsB.Add(optionB);
                    radioButton3.Text = optionB;
                }
                else if (rInt == 2)
                {
                    answers.Add(answer);
                    radioButton2.Text = answer;
                    optionsA.Add(optionA);
                    radioButton3.Text = optionA;
                    optionsB.Add(optionB);
                    radioButton1.Text = optionB;
                }
                else
                {
                    answers.Add(answer);
                    radioButton3.Text = answer;
                    optionsA.Add(optionA);
                    radioButton1.Text = optionA;
                    optionsB.Add(optionB);
                    radioButton2.Text = optionB;
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
            if (button3.Text == "Check your answer")
            {
                String ans = "";
                if (radioButton1.Checked)
                {
                    ans = radioButton1.Text;
                }
                else if (radioButton2.Checked)
                {
                    ans = radioButton2.Text;
                }
                else if (radioButton3.Checked)
                {
                    ans = radioButton3.Text;
                }
                if (answerNow.Equals(ans))
                {
                    question++;
                    lblFeedback.Visible = true;
                    picFeedback.Visible = true;
                    picFeedback.BackgroundImage = Properties.Resources.check;
                    
                    CorrectAnswers++;
                    points += hints + attempts;
                    /*calculate points*/
                    lblPoints.Text = points.ToString();//(int.Parse(lblPoints.Text) + 3).ToString();
                    SavePoints();
                    button3.Text = "Next Question";

                    if (question == 6 && CorrectAnswers >=3)
                    {
                        lblFeedback.Text = "Great job! Keep up the good work in the next level"; lblFeedback.Visible = true; lblFeedback.ForeColor = Color.Green;
                        button3.Text = "Go to the next level >>";
                        this.sentenceLevelsForm.picSS.Enabled = true;
                        this.sentenceLevelsForm.picSSLock.Visible = false;
                    }
                    if (question == 6 && CorrectAnswers < 3)
                    {
                        lblFeedback.Text = "You need to answer at least three questions to pass this level"; lblFeedback.Visible = true; lblFeedback.ForeColor = Color.Red;

                        button3.Text = "Start this level again";
                    }
                }
                else
                {
                   
                    picFeedback.Visible = true;
                    picFeedback.BackgroundImage = Properties.Resources.cross;
                }
            }
            else if (button3.Text == "Next Question")
            {
                NextQuestion();
            }
            else if (button3.Text == "Go to the next level >>")
            {
                GoToNextLevel();
            }
            else if (button3.Text == "Try Again")
            {
                TryAgain();
            }

        }

        public void NextQuestion()
        {
            button3.Text = "Check your answer";
            lblFeedback.Visible = false;
            picFeedback.Visible = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            lblAttempts.Text = "2";
            attempts = 2;
            label5.Text = "Question " + question + " out of 5";
            GenerateGrammar();

        }

        public void IncorrectAnswer(String ans)
        {
            attempts--;
            lblAttempts.Text = attempts.ToString();

            //Not the last question and No more attempts
            if (attempts == 0 && question < 5)  
            {
                question++;
                lblCorrectAns.Visible = true;
                picFeedback.Visible = false;
                lblCorrectAns.Text = "The correct answer is " + ans;
                picFeedback.Visible = false;
                lblFeedback.Text = "Sorry, your answer was incorrect. Try again in the next question.";
                lblFeedback.Visible = true;
                lblFeedback.ForeColor = Color.Red;

                button3.Text = "Next Question";
            }
            //last attepmt and last question, the correct answers is less than 3
            else if (attempts == 0 && question == 5 && CorrectAnswers < 3)
            {
                question++;
                lblFeedback.Text = "You need to answer at least three questions to pass this level."; lblFeedback.Visible = true; lblFeedback.ForeColor = Color.Red;
                button3.Text = "Start this level again";
            }

            //last attepmt and last question, the correct answers is more than or = 3
            else if (attempts == 0 && question == 5 && CorrectAnswers >= 3)
            {
                lblCorrectAns.Visible = true;
                picFeedback.Visible = false;
                lblCorrectAns.Text = "The correct answer is " + ans;
                lblFeedback.Text = "Great job! You correctly answered more than two questions, keep up the good work in the next level."; lblFeedback.Visible = true; lblFeedback.ForeColor = Color.Green;
                button3.Text = "Go to the next level >>";

                this.sentenceLevelsForm.picSS.Enabled = true;
                this.sentenceLevelsForm.picSSLock.Visible = false;
            }
            else
            {

                if (attempts == 4)
                {
                    lblFeedback.Text = "Sorry, your answer was incorrect. Try again you still have four attempts left.";
                }
                else if (attempts == 3)
                {
                    lblFeedback.Text = "Sorry, your answer was incorrect. Try again you still have three attempts left.";
                }
                else if (attempts == 2)
                {
                    lblFeedback.Text = "Sorry, your answer was incorrect. Try again you still have two attempts left.";
                }
                else if (attempts == 1)
                {
                    lblFeedback.Text = "Sorry, your answer was incorrect. Try again you still have one attempt left.";
                }

                lblFeedback.Visible = true;
                lblFeedback.ForeColor = Color.Red;

                picFeedback.BackgroundImage = Properties.Resources.cross;
                button3.Text = "Try Again";
                button3.Focus();
            }
        
        }

        public void GoToNextLevel()
        {

            SS_lesson SSLesson = new SS_lesson();
            SSLesson.mainLevelsForm = mainLevelsForm;
            SSLesson.sentenceLevelsForm = sentenceLevelsForm;
            sentenceLevelsForm.lblhelp.Text = "Good job, now you have to play Sentence Structure Level to unlock Paragraph Coherence level";
            //sentenceLevelsForm.Show();
            SSLesson.Show();
            this.Hide();

            //SSLesson.Show();
        }

        public void TryAgain()
        {
            button3.Text = "Check your answer";
            picFeedback.Visible = false;
        }

        private void POS_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.sentenceLevelsForm.Show();
            }
            catch (Exception ex)
            {
            }
        }

        //Save and pass points between main levels form and words levels form.
        public void SavePoints()
        {
             this.mainLevelsForm.grammarPoints = points;
             this.sentenceLevelsForm.grammarPoints = points;

             this.sentenceLevelsForm.lblGrammarPts.Text = points.ToString();
             this.mainLevelsForm.lblSentencesPoints.Text = points.ToString();

             mainLevelsForm.CF.grammarPoints = points;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void lblFeedback_Click(object sender, EventArgs e)
        {
        }
    }
}
