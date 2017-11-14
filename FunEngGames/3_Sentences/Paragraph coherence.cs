/*
 * Project Name:    Fun English learning Games
 * File Name:       Paragraph coherence.cs
 * Coded By:        Adriana Escobar
 * Coded On:        Fall 2017
 * About this File: This file handles all questions and logic in paragraph coherence level
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

namespace FunEngGames
{
    public partial class PC : Form
    {
        public PC()
        {
            InitializeComponent();
        }

        //Variables wordLevelsForm and mainLevelsForm to store previous forms status
        public mainLevels mainLevelsForm;
        public sentenceLevels sentenceLevelsForm;

        //Storing the xml content
        XmlDocument xmlDoc = new XmlDocument();
        public Random a = new Random();
        public List<string> one = new List<string>();
        public List<string> two = new List<string>();
        public List<string> three = new List<string>();

        //Set game variables
        public int question = 1;
        public int attempts = 2;
        public int points = 0;
        public int CorrectAnswers = 0;
        public String answer = "";
        public String answerNow = "";
        
        //CommonFunctions object
        CommonFunctions CommonFunctions = new CommonFunctions();

        //Generate random number to avoid questions duplications
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

        //Loads form and calls function to generate a question
        private void POS_Load(object sender, EventArgs e)
        {

            listBox1.AllowDrop = true;



            // Ensure WaitOnLoad is false.
            pictureBox5.WaitOnLoad = false;

            // Load the image asynchronously.
            pictureBox5.LoadAsync(@"https://media.giphy.com/media/Bn6djQ6MgEWZi/giphy.gif");
            
            xmlDoc.Load("XML/PC.xml");



            this.GeneratePC();
        }

        public void GeneratePC(){
            try
            {
                XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/PC");
                string oneS = "", twoS = "", threeS = "";

                NewNumber(nodeList.Count);
                int random = randomList.Last();

                oneS = nodeList[random].SelectSingleNode("one").InnerText;
                twoS = nodeList[random].SelectSingleNode("two").InnerText;
                threeS = nodeList[random].SelectSingleNode("three").InnerText;

                one.Add(oneS);
                two.Add(twoS);
                three.Add(threeS);

                this.listBox2.Items.Insert(0, oneS);
                this.listBox2.Items.Insert(1, twoS);
                this.listBox2.Items.Insert(2, threeS);


                Random r = new Random();
                int rInt = r.Next(1, 3);
                answer = oneS + " " + twoS + " " + threeS;
                if (rInt == 1)
                {
                  //  answer = twoS + " " + threeS + " " + oneS;
                    this.listBox1.Items.Insert(0,twoS);
                    this.listBox1.Items.Insert(1, threeS);
                    this.listBox1.Items.Insert(2, oneS);
              
                }
                else if (rInt == 2)
                {
                    //answer = threeS + " " + oneS + " " + twoS;
                    this.listBox1.Items.Insert(0, threeS);
                    this.listBox1.Items.Insert(1, oneS);
                    this.listBox1.Items.Insert(2, twoS);
                }
                else
                {
                  //  answer = twoS + " " + oneS + " " + threeS;
                    this.listBox1.Items.Insert(0, twoS);
                    this.listBox1.Items.Insert(1, oneS);
                    this.listBox1.Items.Insert(2, threeS);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //drag the item if it is not empty or null 
            if (this.listBox1.SelectedItem == null) return;
            this.listBox1.DoDragDrop(this.listBox1.SelectedItem, DragDropEffects.Move);
        }

        private void listBox1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            //Drop the item = save it first in data variable + remove it + insert it again in th right posistion
            Point point = listBox1.PointToClient(new Point(e.X, e.Y));
            int index = this.listBox1.IndexFromPoint(point);
            if (index < 0) index = this.listBox1.Items.Count - 1;
            object data = e.Data.GetData(typeof(string));
            this.listBox1.Items.Remove(data);
            this.listBox1.Items.Insert(index, data);

            //regenerate the paragraph text
            answerNow = "";
            foreach (var listBoxItem in listBox1.Items)
            {
                answerNow = answerNow + " " + listBoxItem.ToString() ;
            }

        }



        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Check your answer")
            {
                String ans = "";
                answer = answer.Trim();
                answerNow = answerNow.Trim();

                if (answer.Equals(answerNow))
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
                    button3.Text = "Next Question";

                    if (question == 6 &&CorrectAnswers >=3)
                    {
                        lblFeedback.Text = "Great job! Keep up the good work in the next level"; lblFeedback.Visible = true; lblFeedback.ForeColor = Color.Green;
                        button3.Text = "Go to the next level >>";
                    }
                    if (question == 6 && CorrectAnswers < 3)
                    {
                        lblFeedback.Text = "You need to answer at least three questions to pass this level"; lblFeedback.Visible = true; lblFeedback.ForeColor = Color.Red;

                        button3.Text = "Start this level again";
                    }
                } 
                else
                {
                    IncorrectAnswer(ans);
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
            listBox1.Items.RemoveAt(0);
            listBox1.Items.RemoveAt(0);
            listBox1.Items.RemoveAt(0);
            lblAttempts.Text = "3";
            attempts = 3;
            label5.Text = "Question " + question + " out of 5";
            GeneratePC();

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
                lblCorrectAns.Text = "The correct answer is ";
                listBox2.Visible = true;
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

                //this.sentenceLevelsForm.picSS.Enabled = true;
                //this.sentenceLevelsForm.picSSLock.Visible = false;
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
            // mainLevelsForm;
            this.Hide();
            sentenceLevelsForm.Show();
        }

        public void TryAgain()
        {
            button3.Text = "Check your answer";
            picFeedback.Visible = false;
            lblFeedback.Visible = false;
        }

        //Save and pass points between main levels form and words levels form.
        public void SavePoints()
        {
             this.mainLevelsForm.ParagraphCoherencePoints = points;
             this.sentenceLevelsForm.ParagraphCoherencePoints = points;

             this.sentenceLevelsForm.lblPCPts.Text = points.ToString();
             this.mainLevelsForm.lblSentencesPoints.Text = points.ToString();

             mainLevelsForm.CF.ParagraphCoherencePoints = points;
        }

        private void POS_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.mainLevelsForm.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void lbltitle_Click(object sender, EventArgs e)
        {

        }
    }
}
