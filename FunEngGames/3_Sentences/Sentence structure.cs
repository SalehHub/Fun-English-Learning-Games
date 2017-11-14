/*
 * Project Name:    Fun English learning Games
 * File Name:       Sentence Structure.cs
 * Coded By:        Adriana Escobar
 * Coded On:        Fall 2017
 * About this File: This file handles all questions and logic in the sentence structure level
 */
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

namespace FunEngGames._3_Sentences
{
    public partial class SS : Form
    {
        public SS()
         {
            InitializeComponent();
        }

        //Variables wordLevelsForm and mainLevelsForm to store previous forms status
        public mainLevels mainLevelsForm;
        public sentenceLevels sentenceLevelsForm;
        
        //Storing the xml content
        XmlDocument xmlDoc = new XmlDocument();
        XmlNodeList nodeList = null;
        public Random a = new Random();
        public List<string> sentences = new List<string>();
        public List<string> answers = new List<string>();
        public List<string> optionsA = new List<string>();
        public List<string> optionsB = new List<string>();

        //Set game variables
        String answerNow;
        public int question = 1;
        public int CorrectAnswers = 0;
        public int attempts = 3;
        public int points = 0;
        public List<int> randomList = new List<int>();

        int MyNumber = 0;
        private void NewNumber(int max)
        {   try
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
            catch(Exception ex)
            {

            }
        }

        private void SS_Load(object sender, EventArgs e)
        {
            // Ensure WaitOnLoad is false.
            pictureBox5.WaitOnLoad = false;
            // Load the image asynchronously.
            pictureBox5.LoadAsync(@"https://media.giphy.com/media/Bn6djQ6MgEWZi/giphy.gif");

            xmlDoc.Load("XML/SS.xml");
            this.StartLevelAgain();
        }

        public void StartLevelAgain()
        {
            try
            {
                XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/SS");
                string sentence = "", answer = "", optionA = "", optionB = "";

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

        private void btnCheckAnswer_Click(object sender, EventArgs e)
        {

            if (btnCheckAnswer.Text == "Check your answer")
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
                    points += attempts;
                    /*calculate points*/
                    lblPoints.Text = points.ToString();//(int.Parse(lblPoints.Text) + 3).ToString();
                    SavePoints();
                    btnCheckAnswer.Text = "Next Question";

                    if (question == 6 && CorrectAnswers >=3)
                    {
                        lblFeedback.Text = "Great job! Keep up the good work in the next level"; lblFeedback.Visible = true; lblFeedback.ForeColor = Color.Green;
                        btnCheckAnswer.Text = "Go to the next level >>";
                    }
                    if (question == 6 && CorrectAnswers < 3)
                    {
                        lblFeedback.Text = "You need to answer at least three questions to pass this level"; lblFeedback.Visible = true; lblFeedback.ForeColor = Color.Red;

                        btnCheckAnswer.Text = "Start this level again";
                    }
                }
                else
                {
                    picFeedback.Visible = true;
                    picFeedback.BackgroundImage = Properties.Resources.cross;
                }
            }
            else if (btnCheckAnswer.Text == "Next Question")
            {
                NextQuestion();
            }
            else if (btnCheckAnswer.Text == "Go to the next level >>")
            {
                GoToNextLevel();
            }
            else if (btnCheckAnswer.Text == "Try Again")
            {
                TryAgain();
            }

        }

        public void NextQuestion()
        {
            btnCheckAnswer.Text = "Check your answer";
            lblFeedback.Visible = false;
            picFeedback.Visible = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            lblAttempts.Text = "2";
            attempts = 2;
            label5.Text = "Question " + question + " out of 5";
            StartLevelAgain();

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

                btnCheckAnswer.Text = "Next Question";
            }
            //last attepmt and last question, the correct answers is less than 3
            else if (attempts == 0 && question == 5 && CorrectAnswers < 3)
            {
                question++;
                lblFeedback.Text = "You need to answer at least three questions to pass this level."; lblFeedback.Visible = true; lblFeedback.ForeColor = Color.Red;
                btnCheckAnswer.Text = "Start this level again";
            }

            //last attepmt and last question, the correct answers is more than or = 3
            else if (attempts == 0 && question == 5 && CorrectAnswers >= 3)
            {
                lblCorrectAns.Visible = true;
                picFeedback.Visible = false;
                lblCorrectAns.Text = "The correct answer is " + ans;
                lblFeedback.Text = "Great job! You correctly answered more than two questions, keep up the good work in the next level."; lblFeedback.Visible = true; lblFeedback.ForeColor = Color.Green;
                btnCheckAnswer.Text = "Go to the next level >>";

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
                btnCheckAnswer.Text = "Try Again";
                btnCheckAnswer.Focus();
            }
        
        }

        public void GoToNextLevel()
        {

           // SSLesson SSLesson = new SSLesson();
            //SSLesson.mainLevelsForm = mainLevelsForm;
            //SSLesson.sentenceLevelsForm = sentenceLevelsForm;
            this.Hide();
            sentenceLevelsForm.lblhelp.Text = "Good job, now you have to play Sentence Structure Level to unlock Paragraph Coherence level";
            sentenceLevelsForm.Show();
            //SSLesson.Show();
        }

        public void TryAgain()
        {
            btnCheckAnswer.Text = "Check your answer";
            picFeedback.Visible = false;
        }

        private void Sentence_Structure_Click(object sender, EventArgs e)
        {

        }

        private void SS_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.mainLevelsForm.Show();
            }
            catch(Exception ex) 
            { 
            }
        }

        //Save and pass points between main levels form and words levels form.
        public void SavePoints()
        {
            this.mainLevelsForm.sentenceStructurePoints = points;
            this.sentenceLevelsForm.SentenceStructurePoints = points;

            this.sentenceLevelsForm.label4.Text = points.ToString();
            this.mainLevelsForm.lblSentencesPoints.Text = points.ToString();

            mainLevelsForm.CF.sentenceStructurePoints = points;
        }   
    }
}

