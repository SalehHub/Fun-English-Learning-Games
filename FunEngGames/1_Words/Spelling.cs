/*
 * Project Name:    Fun English learning Games
 * File Name:       Spelling.cs
 * Coded By:        Saleh Alzahrani & Sarah Aljabri
 * Coded On:        Fall 2017
 * About this File: This file handles all questions and gameplay logic in spelling level
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        //Variables wordLevelsForm and mainLevelsForm to store previous forms status        
        public wordsLevel wordLevelsForm;
        public mainLevels mainLevelsForm;

        //Storing the xml content
        XmlDocument xmlDoc = new XmlDocument();
        XmlNodeList nodeList = null;

        //Storing questions pictures and answers
        public string pic1 = "", ans1 = "";
        public string pic2 = "", ans2 = "";
        public string pic3 = "", ans3 = "";

        //Set game variables
        public int question = 1;
        public int CorrectAnswers = 0;
        public int hints = 2;
        public int attempts = 3;
        public int points = 0;

        //CommonFunctions object
        CommonFunctions CommonFunctions = new CommonFunctions();

        //Random integer variable
        public Random a = new Random();
        public List<int> randomList = new List<int>();


        //Generate random node function to avoid questions duplications
        int MyNumber = 0;
        private void NewNumber(int max)
        {

            if (randomList.Count >= nodeList.Count)
            {
                randomList.Clear();
            }

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


        //hide "Type your answer here..." text when textbox is fouced
        public void RemoveText()
        {
            if (txtAnswer.Text == "Type your answer here...")
            {

                txtAnswer.Text = "";
            }
        }


        //show "Type your answer here..." text when textbox not fouced and empty
        public void AddText()
        {
            if (String.IsNullOrWhiteSpace(txtAnswer.Text))
            {
                txtAnswer.Text = "Type your answer here...";
            }
        }


        //Random categry function choose random spelling category
        public void randomCatogary()
        {
            int rand = a.Next(8);

            if (rand == 0)
            {
                nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/" + "animals" + "/spelling");

            }
            else if (rand == 1)
            {
                nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/" + "furniture" + "/spelling");
            }
            else if (rand == 2)
            {
                nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/" + "sports" + "/spelling");

            }
            else if (rand == 3)
            {
                nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/" + "fruits" + "/spelling");
            }
            else if (rand == 4)
            {
                nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/" + "vegetables" + "/spelling");
            }
            else if (rand == 5)
            {
                nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/" + "transportation" + "/spelling");
            }
            else if (rand == 6)
            {
                nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/" + "bodyparts" + "/spelling");
            }
            else if (rand == 7)
            {
                nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/" + "others" + "/spelling");
            }
            else
            {
                nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/" + "nature" + "/spelling");
            }
        }


        //Form load fucntion generate first question
        private void spelling_Load(object sender, EventArgs e)
        {
            // Ensure WaitOnLoad is false.
            pictureBox5.WaitOnLoad = false;

            // Load the image asynchronously.
            pictureBox5.LoadAsync(@"https://media.giphy.com/media/Bn6djQ6MgEWZi/giphy.gif");


            Cursor cur = new Cursor(Properties.Resources.audio.Handle);
            picWord.Cursor = cur;


            xmlDoc.Load("XML/spelling.xml");


           // randomCatogary();

            StartLevelAgain();

        }


        //hide "Type your answer here..." text when textbox is fouced
        private void txtAnswer_Enter(object sender, EventArgs e)
        {
            RemoveText();
        }


        //show "Type your answer here..." text when textbox not fouced and empty
        private void txtAnswer_Leave(object sender, EventArgs e)
        {
            AddText();
        }


        //Start the level again function: when the player did not answer at least two questions
        public void StartLevelAgain()
        {


            randomCatogary();


            NewNumber(nodeList.Count);
            int random = randomList.Last();

            pic1 = nodeList[random].SelectSingleNode("answer").InnerText.Trim() + ".png";
            ans1 = nodeList[random].SelectSingleNode("answer").InnerText.Trim();

            picWord.Image = Image.FromFile(@"Images\" + pic1);
            lblAnswer.Text = ans1;

            //nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/" + "animals" + "/spelling");


            randomCatogary();

            NewNumber(nodeList.Count);
            random = randomList.Last();

            pic2 = nodeList[random].SelectSingleNode("answer").InnerText.Trim() + ".png";
            ans2 = nodeList[random].SelectSingleNode("answer").InnerText.Trim();
            //pictureBox2.Image = Image.FromFile(@"Images\" + pic);
            label2.Text = ans2;

            //nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/" + "fruits" + "/spelling");
            randomCatogary();

            NewNumber(nodeList.Count);
            random = randomList.Last();

            pic3 = nodeList[random].SelectSingleNode("answer").InnerText.Trim() + ".png";
            ans3 = nodeList[random].SelectSingleNode("answer").InnerText.Trim();
            //pictureBox3.Image = Image.FromFile(@"Images\" + pic);
            label3.Text = ans3;

            //randomList.Clear();

            CorrectAnswers = 0;
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


        //Done with all the questions go to next level
        public void GoToNextLevel()
        {
            SynonymsLesson SynonymsLesson = new SynonymsLesson();
            SynonymsLesson.mainLevelsForm = mainLevelsForm;
            SynonymsLesson.wordLevelsForm = wordLevelsForm;
            this.Hide();
            SynonymsLesson.Show();
        }


        //Correct answer go to the next question function
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


        //Try again function we still have attempts
        public void TryAgain()
        {
            btnCheckAnswer.Text = "Check your answer";
            picFeedback.Visible = false;
        }


        //if the answer was correct function
        public void CorrectAnswer()
        {
            question++;
            CorrectAnswers++;
            picFeedback.BackgroundImage = Properties.Resources.check;

            lblFeedback.Text = "Good job! Keep up the good work"; lblFeedback.Visible = true; lblFeedback.ForeColor = Color.Green;
            btnCheckAnswer.Text = "Next Question";

            points += hints + attempts;
            /*calculate points*/
            lblPoints.Text = points.ToString();//(int.Parse(lblPoints.Text) + 3).ToString();
            SavePoints();


            if (question == 4 && CorrectAnswers >= 2)
            {
                lblFeedback.Text = "Great job! Keep up the good work in the next level"; lblFeedback.Visible = true; lblFeedback.ForeColor = Color.Green;

                btnCheckAnswer.Text = "Go to the next level >>";

                this.wordLevelsForm.picSA.Enabled = true;
                this.wordLevelsForm.picSALock.Visible = false;
            }


            if (question == 4 && CorrectAnswers < 2)
            {
                lblFeedback.Text = "You need to answer atleast two questions to pass this level"; lblFeedback.Visible = true; lblFeedback.ForeColor = Color.Red;

                btnCheckAnswer.Text = "Start this level again";

                // this.wordLevelsForm.picSA.Enabled = true;
                // this.wordLevelsForm.picSALock.Visible = false;
            }

        }


        //if the answer was incorrect function
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
            else if (attempts == 0 && question == 3 && CorrectAnswers < 2)    //last attepmt and last question
            {
                lblFeedback.Text = "You need to answer atleast two questions to pass this level"; lblFeedback.Visible = true; lblFeedback.ForeColor = Color.Red;
                btnCheckAnswer.Text = "Start this level again";
            }
            else if (attempts == 0 && question == 3 && CorrectAnswers >= 2)    //last attepmt and last question
            {
                lblCorrectAns.Visible = true;
                lblCorrectAns.Text = "The correct answer is " + lblAnswer.Text;

                lblFeedback.Text = "Great job! You correctly answered two questions, keep up the good work in the next level"; lblFeedback.Visible = true; lblFeedback.ForeColor = Color.Green;

                btnCheckAnswer.Text = "Go to the next level >>";

                this.wordLevelsForm.picSA.Enabled = true;
                this.wordLevelsForm.picSALock.Visible = false;
            }
            else
            {
                lblFeedback.Text = "Sorry this is not a correct answer try again";
                lblFeedback.Visible = true;
                lblFeedback.ForeColor = Color.Red;

                picFeedback.BackgroundImage = Properties.Resources.cross;
                btnCheckAnswer.Text = "Try Again";
            }
        }


        //check your answer function
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


        //check your answer button click function: checking all the possible cases
        private void btnCheckAnswer_Click(object sender, EventArgs e)
        {
            try
            {
                lblFeedback.Visible = false;

                if (txtAnswer.Text.Trim() == "" || txtAnswer.Text.Trim() == "Type your answer here...")
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
                    btnCheckAnswer.Focus();
                    NextQuestion();
                    txtAnswer.Focus();
                }
                else if (btnCheckAnswer.Text == "Try Again")
                {
                    TryAgain();
                }
                else if (btnCheckAnswer.Text == "Check your answer")
                {
                    CheckYourAnswer();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //First hint function : show the hint text and decrement the hints variable
        private void btnFirstHint_Click(object sender, EventArgs e)
        {
            lblFirstHint.Text = "First hint:" + "The number of letters in this word = " + lblAnswer.Text.Length;
            lblFirstHint.Visible = true;
            btnFirstHint.Visible = false;
            picLock.Visible = false;
            btnSecondHint.Enabled = true;
            hints--;
        }


        //Second hint function : show the hint text and decrement the hints variable
        private void btnSecondHint_Click(object sender, EventArgs e)
        {
            lblSecondHint.Text = "Second hint: The word start with " + CommonFunctions.UppercaseFirst(lblAnswer.Text.Substring(0, 1)) + " and ends with " + CommonFunctions.UppercaseFirst(lblAnswer.Text.Substring(lblAnswer.Text.Length - 1, 1));
            lblSecondHint.Visible = true;
            btnSecondHint.Visible = false;
            hints--;
        }


        //pronounce the word after click on the picture
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CommonFunctions.Pronounce(lblAnswer.Text);
        }


        //Timer to hide feedback lable
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFeedback.Visible = false;
            timer1.Enabled = false;
        }


        //when player hits enter on answer textbox call check answr function
        private void txtAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCheckAnswer_Click(sender, e);
                e.SuppressKeyPress = true;

            }
        }


        //Form closing function: show the words level form
        private void spelling_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.wordLevelsForm.Show();

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }


        //Save and pass points between main levels form and words levels form.
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
