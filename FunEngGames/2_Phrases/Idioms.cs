/*
 * Project Name:    Fun English learning Games
 * File Name:       Idiom.cs
 * Coded By:        Venkata Sandeep Reddy 
 * Coded On:        Fall 2017
 * About this File: This file handles all questions and gameplay logic in Idiom level
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
    public partial class Idioms : Form
    {
        public Idioms()
        {
            InitializeComponent();
        }

        //Variables wordLevelsForm and mainLevelsForm to store previous forms status    
        public phrasesLevel phrasesLevelForm;
        public mainLevels mainLevelsForm;

        //Storing the xml content
        XmlDocument xmlDoc = new XmlDocument();

        //Storing questions pictures and answers
        public string sentence = "", word = "", ans1 = "", ans2 = "", ans3 = "";

        //Set game variables
        public int attempts = 3;
        public int question = 1;

        string playerAnswer = "";
        public Random a = new Random();
        public int points = 0;
        public int noOfCorrectAns = 0;

        //Random integer variable
        public List<int> randomList = new List<int>();
        public List<string> answers = new List<string>();

        //Generate random node function to avoid questions duplications
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

        //When the form gets loaded
        private void Idioms_Load(object sender, EventArgs e)
        {

            radioButton1.Checked = false;

            noOfCorrectAns = 0;
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
            xmlDoc.Load("XML/idioms.xml");
            //this.Synonyms();
            this.GenIdioms();
        }

        public void GenIdioms()
        {
            try
            {
                XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/idioms");



                //foreach (XmlNode node in nodeList)


                NewNumber(nodeList.Count);
                int random = randomList.Last();

                sentence = nodeList[random].SelectSingleNode("sentence").InnerText;
                //  word = nodeList[random].SelectSingleNode("word").InnerText;
                ans1 = nodeList[random].SelectSingleNode("answer1").InnerText;
                ans2 = nodeList[random].SelectSingleNode("answer2").InnerText;
                ans3 = nodeList[random].SelectSingleNode("answer3").InnerText;

                answers.Add(ans1);
                answers.Add(ans2);
                answers.Add(ans3);


                Shuffle(answers);
                sentenceLable.Text = sentence;
                //wordLabel.Text = word;

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

        // This will take to next level
        public void GoToNextLevel()
        {

           // Storyline_Friendship Storyline_Friendship = new Storyline_Friendship();
            //Storyline_Friendship.mainLevelsForm = this.mainLevelsForm;
            //Storyline_Friendship.wordLevelsForm = this.wordLevelsForm;
            //this.Hide();
            //Storyline_Friendship.Show();


            //sentenceLevels sl = new sentenceLevels();
            //sl.Show();
            //IdiomsLesson IdiomsLesson = new IdiomsLesson();
            //IdiomsLesson.phrasesLevelForm = this.phrasesLevelForm;
            //IdiomsLesson.Show();
            //this.Hide(); 


        }

        private void Idioms_FormClosing(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.phrasesLevelForm.Show();
            }
            catch (Exception ex)
            {

            }
        }

        // It shuffles the options available
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

        private void lblAttempts_Click(object sender, EventArgs e)
        {

        }

        //If answer is incorrect following should be done
        public void IncorrectAnswer()
        {
            attempts--;
            lblAttempts.Text = attempts.ToString();

            // if question number is less than 5
            if (attempts == 0 && question < 5)  //No more attempts
            {
                question++;
                lblCorrectAns.Visible = true;
                picFeedback.Visible = false;
                lblCorrectAns.Text = "The correct answer is " + ans1;

                lblFeedback.Text = "Sorry this is incorrect answer try the next question";
                lblFeedback.Visible = true;
                lblFeedback.ForeColor = Color.Red;
                lblNoOfQuestion.Text = "Question " + question.ToString() + " of 5";

                //attempts = 3;
                lblAttempts.Text = attempts.ToString();
                lblFeedback.Visible = false;
                btnCheckAnswer.Text = "Next Question";
                colorRadiobuttons(ans1.Trim());
            }

            //if question number is 5
            else if (attempts == 0 && question == 5 && noOfCorrectAns < 3)    //last attepmt and last question
            {
                attempts = 3;
                //question = 3;
                lblFeedback.Text = "Sorry this is incorrect answer try again from begining. You have to answer atleast 3 out 5 question correctly to go to next level";
                lblFeedback.Visible = true;
                btnCheckAnswer.Text = "Start this level again";
                colorRadiobuttons(ans1.Trim());
            }
            else if (attempts == 0 && question == 5 && noOfCorrectAns >= 3)    //last attepmt and last question
            {
                // colorRadiobuttons();
                attempts = 3;
                //question = 3;
                lblCorrectAns.Text = "The correct answer is " + ans1;
                lblCorrectAns.Visible = true;
                lblFeedback.Text = "Sorry this is incorrect answer.You have finished this level successfully";
                lblFeedback.Visible = true;
                btnCheckAnswer.Text = "Go to idioms level";
                colorRadiobuttons(ans1.Trim());
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

        //if it is the correct answer
        public void CorrectAnswer()
        {
            colorRadiobuttons(playerAnswer.Trim());
            question++;

            noOfCorrectAns++;
            picFeedback.BackgroundImage = Properties.Resources.check;

            lblFeedback.Text = "Good job! Keep up the good work"; lblFeedback.Visible = true; lblFeedback.ForeColor = Color.Green;
            btnCheckAnswer.Text = "Next Question";

            points += attempts + 0;
            /*calculate points*/
            lblPoints.Text = points.ToString();//(int.Parse(lblPoints.Text) + 3).ToString();
                                               // SavePoints();

            //if question number is 6
            if (question == 6 && noOfCorrectAns >= 3)
            {
                lblFeedback.Text = "Great job! Keep up the good work in the next level";
                lblFeedback.Visible = true;
                lblFeedback.ForeColor = Color.Green;

                btnCheckAnswer.Text = "Go to Sentence level";
            }
            else if (question == 6 && noOfCorrectAns < 3)
            {
                attempts = 3;
                //question = 3;
                lblFeedback.Text = "Sorry this is incorrect answer try again from begining. You have to answer atleast 3 out 5 question correctly to go to next level";
                lblFeedback.Visible = true;
                lblFeedback.ForeColor = Color.Red;
                btnCheckAnswer.Text = "Start this level again";
            }

            SavePoints();
        }

        //Save and pass points between main levels form and words levels form.
        public void SavePoints()
        {
            this.mainLevelsForm.idiomsPoints = points;
            this.phrasesLevelForm.idiomsPoints = points;

            this.mainLevelsForm.lblPhrasesPoints.Text = points.ToString();
            this.phrasesLevelForm.lblIdiomsPoints.Text = points.ToString();

            mainLevelsForm.CF.idiomsPoints = points;
        }

        private void btnCheckAnswer_Click(object sender, EventArgs e)
        {
            radioButton1.ForeColor = Color.Black;
            radioButton2.ForeColor = Color.Black;
            radioButton3.ForeColor = Color.Black;

            lblFeedback.Visible = false;
            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
            {
                lblFeedback.Visible = true;
                lblFeedback.ForeColor = Color.Red;
                lblFeedback.Text = "Please select atleast one answer";
            }
            else if (btnCheckAnswer.Text == "Try Again")
            {
                //panel1.Enabled = true;
                btnCheckAnswer.Text = "Check your answer";

                picFeedback.Visible = false;
                //lblFeedback.Visible = false;
                //lblCorrectAns.Visible = false;

            }
            else if (btnCheckAnswer.Text == "Next Question")

            {
                int z = Convert.ToInt32(question.ToString());
                if (z <= 5)
                {
                    //panel1.Enabled = true;

                    attempts = 3;
                    lblAttempts.Text = attempts.ToString();
                    lblCorrectAns.Visible = false;
                    // question++;
                    picFeedback.Visible = false;
                    //lblFeedback.Visible = false;

                    GenIdioms();

                    lblNoOfQuestion.Text = "Question " + question.ToString() + " of 5";

                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;


                    btnCheckAnswer.Text = "Check your answer";
                }
                else
                {
                    sentenceLevels sl = new sentenceLevels();
                    sl.Show();
                }
            }
            else if (btnCheckAnswer.Text == "Go to Sentences level")
            {
                GoToNextLevel();


            }
            else if (btnCheckAnswer.Text == "Start this level again")
            {
                //panel1.Enabled = true;

                Idioms_Load(sender, e);
            }
            else
            {
                //  panel1.Enabled = false;

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
                    CorrectAnswer();
                }
                else
                {
                    IncorrectAnswer();

                }
            }
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

        public void colorRadiobuttons(string correctAns)
        {

            if (radioButton1.Text == correctAns)
            {

                radioButton1.ForeColor = Color.Green;
                radioButton2.ForeColor = Color.Red;
                radioButton3.ForeColor = Color.Red;
            }
            else if (radioButton2.Text == correctAns)
            {
                radioButton1.ForeColor = Color.Red;
                radioButton2.ForeColor = Color.Green;
                radioButton3.ForeColor = Color.Red;
            }
            else if (radioButton3.Text == correctAns)
            {
                radioButton1.ForeColor = Color.Red;
                radioButton2.ForeColor = Color.Red;
                radioButton3.ForeColor = Color.Green;
            }

        }
    }
}
