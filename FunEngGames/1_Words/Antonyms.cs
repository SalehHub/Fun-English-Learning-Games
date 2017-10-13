/*
 * Project Name:    Fun English learning Games
 * File Name:       Antonyms.cs
 * Coded By:        Saleh Alzahrani
 * Coded On:        Fall 2017
 * About this File: This file handles all of Synonym level gameplay logic
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace FunEngGames
{
    public partial class Antonyms : Form
    {
        public Antonyms()
        {
            InitializeComponent();
        }

        //Storing the xml content
        XmlDocument xmlDoc = new XmlDocument();
        XmlNodeList nodeList = null;

        //CommonFunctions object
        CommonFunctions cf = new CommonFunctions();

        //Variables wordLevelsForm and mainLevelsForm to store previous forms status        
        public mainLevels mainLevelsForm;
        public wordsLevel wordLevelsForm;

        //Random integer variable
        public Random a = new Random();

        //Lists to store XML nodes and generated synonyms
        public List<int> randomList = new List<int>();
        public List<string> antonyms = new List<string>();

        //Set game variables
        public int Questions = 3;
        public int attempt = 3;
        public int hints = 3;
        public int points = 0;

        //What answer has been answerd
        public bool fq = false;
        public bool sq = false;
        public bool tq = false;

        //Hints content setup
        public string fHint = "";
        public string sHint = "";
        public string tHint = "";

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

        //Form closing function: show the words level form
        private void S_A_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.wordLevelsForm.Show();
            }
            catch (Exception ex)
            {

            }
        }

        //Form load fucntion generate questions
        private void S_A_Load(object sender, EventArgs e)
        {
            // Ensure WaitOnLoad is false.
            pictureBox5.WaitOnLoad = false;

            // Load the image asynchronously.
            pictureBox5.LoadAsync(@"https://media.giphy.com/media/Bn6djQ6MgEWZi/giphy.gif");


            Questions = 3;
            attempt = 3;
            hints = 3;
            points = 0;

            fq = false;
            sq = false;
            tq = false;

            //randomList.Clear();
            antonyms.Clear();
            //antonyms.Clear();


            lblCorrectAns.Visible = false;
            lblHint.Visible = false;

            btnHint1.Enabled = true;
            comboBox1.Enabled = true;
            comboBox1.Items.Clear();
            comboBox1.Text = "";

            btnHint2.Enabled = true;
            comboBox2.Enabled = true;
            comboBox2.Items.Clear();
            comboBox2.Text = "";

            btnHint3.Enabled = true;
            comboBox3.Enabled = true;
            comboBox3.Items.Clear();
            comboBox3.Text = "";

            picAns1.BackgroundImage = null;
            picAns2.BackgroundImage = null;
            picAns3.BackgroundImage = null;


            btnCheckYourAnswer.Text = "Check your answers";
            lblAttempts.Text = attempt.ToString();
            lblPoints.Text = points.ToString();

            xmlDoc.Load("XML/antonyms.xml");
            nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/antonyms");

            this.GenerateAntonyms();
        }

        //Generate all the Three antonyms questions
        public void GenerateAntonyms()
        {
            try
            {


                string word = "", antonym = "";

                NewNumber(nodeList.Count);
                int random = randomList.Last();

                word = nodeList[random].SelectSingleNode("word").InnerText.Trim();
                antonym = nodeList[random].SelectSingleNode("antonym").InnerText.Trim();
                fHint = nodeList[random].SelectSingleNode("hint").InnerText.Trim();

                antonyms.Add(cf.UppercaseFirst(antonym));
                lblW1.Text = "" + cf.UppercaseFirst(word);


                NewNumber(nodeList.Count);
                random = randomList.Last();

                word = nodeList[random].SelectSingleNode("word").InnerText.Trim();
                antonym = nodeList[random].SelectSingleNode("antonym").InnerText.Trim();
                sHint = nodeList[random].SelectSingleNode("hint").InnerText.Trim();

                antonyms.Add(cf.UppercaseFirst(antonym));
                lblW2.Text = "" + cf.UppercaseFirst(word);


                NewNumber(nodeList.Count);
                random = randomList.Last();

                word = nodeList[random].SelectSingleNode("word").InnerText.Trim();
                antonym = nodeList[random].SelectSingleNode("antonym").InnerText.Trim();
                tHint = nodeList[random].SelectSingleNode("hint").InnerText.Trim();

                antonyms.Add(cf.UppercaseFirst(antonym));
                lblW3.Text = "" + cf.UppercaseFirst(word);


                //comboBox1.Tag = antonyms[0];
                //comboBox2.Tag = antonyms[1];
                //comboBox3.Tag = antonyms[2];

                lblAns1.Text = antonyms[0];
                lblAns2.Text = antonyms[1];
                lblAns3.Text = antonyms[2];

                Shuffle(antonyms);
                //comboBox1.Items.Add("A-"); comboBox1.Items.Add("B-"); comboBox1.Items.Add("C-");
                comboBox1.Items.Add("" + antonyms[0]); comboBox1.Items.Add("" + antonyms[1]); comboBox1.Items.Add("" + antonyms[2]);
                comboBox2.Items.Add("" + antonyms[0]); comboBox2.Items.Add("" + antonyms[1]); comboBox2.Items.Add("" + antonyms[2]);
                comboBox3.Items.Add("" + antonyms[0]); comboBox3.Items.Add("" + antonyms[1]); comboBox3.Items.Add("" + antonyms[2]);


                Shuffle(antonyms);
                lblS1.Text = "" + antonyms[0];
                lblS2.Text = "" + antonyms[1];
                lblS3.Text = "" + antonyms[2];


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message+"Error while loading antonyms");
                GenerateAntonyms();
            }
        }

        //This function will shuffle any given list I use it to shuffle the answers
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

        //Show feedback label 
        public void showFeedBack(string txt, Color color)
        {
            lblFeedback.Visible = true;
            lblFeedback.ForeColor = color;
            lblFeedback.Text = txt;
        }

        //Hide feedback label
        public void hideFeedBack()
        {
            lblFeedback.Visible = false;
        }

        //Save and pass points between main levels form and words levels form.
        public void SavePoints()
        {
            this.mainLevelsForm.antonymsPoints = attempt+1+ hints + points;
            this.wordLevelsForm.antonymsPoints = attempt + 1 + hints + points;
            this.mainLevelsForm.CF.antonymsPoints = attempt + 1 + hints + points;

            this.mainLevelsForm.lblWordsPoints.Text = (this.mainLevelsForm.spellingPoints + this.mainLevelsForm.synonymsPoints + this.mainLevelsForm.antonymsPoints).ToString();
            this.wordLevelsForm.lblSandAPoints.Text = (this.mainLevelsForm.synonymsPoints + this.mainLevelsForm.antonymsPoints).ToString();


        }

        //Show first question hint
        private void btnHint1_Click(object sender, EventArgs e)
        {
            lblHint.Visible = true;
            lblHint.Text = cf.UppercaseFirst(fHint) + " is another antonym for the word you're looking for!";
            btnHint1.Enabled = false;
            hints--;
        }

        //Show second question hint
        private void btnHint2_Click(object sender, EventArgs e)
        {
            lblHint.Visible = true;
            lblHint.Text = cf.UppercaseFirst(sHint) + " is another antonym for the word you're looking for!";
            btnHint2.Enabled = false;
            hints--;
        }

        //Show third question hint
        private void btnHint3_Click(object sender, EventArgs e)
        {
            lblHint.Visible = true;
            lblHint.Text = cf.UppercaseFirst(tHint) + " is another antonym for the word you're looking for!";
            btnHint3.Enabled = false;
            hints--;
        }

        //Check your answer function
        private void btnCheckYourAnswer_Click(object sender, EventArgs e)
        {

            hideFeedBack();



            if (comboBox1.Text.Trim() == "" || comboBox2.Text.Trim() == "" || comboBox3.Text.Trim() == "")
            {
                showFeedBack("Please answer all the three questions first", Color.Red);

            }
            else if (btnCheckYourAnswer.Text == "Restart the level")
            {

                S_A_Load(sender, e);

            }
            else if (btnCheckYourAnswer.Text == "Go to Homonyms lesson")
            {
                HomonymsLesson HomonymsLesson = new HomonymsLesson();
                HomonymsLesson.mainLevelsForm = this.mainLevelsForm;
                HomonymsLesson.wordLevelsForm = this.wordLevelsForm;
                this.Hide();
                HomonymsLesson.Show();
            }
            else
            {


                attempt--;
                lblAttempts.Text = attempt.ToString();

                //Correct answer (fq: first question)
                if (fq == false && comboBox1.Text.Trim().ToLower().Contains(lblAns1.Text.Trim().ToLower()))
                {
                    picAns1.BackgroundImage = Properties.Resources.check;
                    points++;
                    btnHint1.Enabled = false;
                    comboBox1.Enabled = false;
                    Questions--;
                    fq = true;

                }//incorrect answer
                else if (fq == false && !comboBox1.Text.Trim().ToLower().Contains(lblAns1.Text.Trim().ToLower()))
                {
                    picAns1.BackgroundImage = Properties.Resources.cross;
                }




                if (sq == false && comboBox2.Text.Trim().ToLower().Contains(lblAns2.Text.Trim().ToLower()))
                {
                    picAns2.BackgroundImage = Properties.Resources.check;
                    points++;
                    btnHint2.Enabled = false;
                    comboBox2.Enabled = false;
                    Questions--;
                    sq = true;
                }
                else if (sq == false && !comboBox2.Text.Trim().ToLower().Contains(lblAns2.Text.Trim().ToLower()))
                {
                    picAns2.BackgroundImage = Properties.Resources.cross;
                }




                if (tq == false && comboBox3.Text.Trim().ToLower().Contains(lblAns3.Text.Trim().ToLower()))
                {
                    picAns3.BackgroundImage = Properties.Resources.check;
                    points++;
                    btnHint3.Enabled = false;
                    comboBox3.Enabled = false;
                    Questions--;
                    tq = true;
                }
                else if (tq == false && !comboBox3.Text.Trim().ToLower().Contains(lblAns3.Text.Trim().ToLower()))
                {
                    picAns3.BackgroundImage = Properties.Resources.cross;
                }

                if (Questions == 0)
                {
                    showFeedBack("Good job, keep up the good work in the next level", Color.Green);

                    lblPoints.Text = (attempt + 1 + hints + points).ToString();

                    SavePoints();
                    btnCheckYourAnswer.Text = "Go to Homonyms lesson";

                    this.wordLevelsForm.picHomonyms.Enabled = true;
                    this.wordLevelsForm.picHomonymsLock.Visible = false;
                }


                //solved 2 questions
                if (Questions >= 1 && attempt == 0)
                {
                    showFeedBack("Good job, keep up the good work in the next level", Color.Green);

                    lblPoints.Text = (attempt + 1 + hints + points).ToString();

                    SavePoints();
                    btnCheckYourAnswer.Text = "Go to Homonyms lesson";

                    this.wordLevelsForm.picHomonyms.Enabled = true;
                    this.wordLevelsForm.picHomonymsLock.Visible = false;
                }


                if (attempt > 0 && Questions > 0)
                {
                    if (attempt == 2)
                    {
                        showFeedBack("Try again you still have two attempts left", Color.Red);
                    }
                    else if (attempt == 1)
                    {
                        showFeedBack("Try again you still have one attempt left", Color.Red);
                    }
                }



                if (attempt == 0 && Questions >= 2)
                {
                    lblHint.Visible = false;


                    showFeedBack("Sorry, you need to solve at least two questions to pass this level", Color.Red);

                    btnCheckYourAnswer.Text = "Restart the level";
                }


                if (attempt == 0 && Questions > 0)
                {
                    lblCorrectAns.Text = "";

                    if (fq == false)
                    {
                        lblCorrectAns.Visible = true;
                        lblCorrectAns.Text = "The correct answer for the first question is " + lblAns1.Text;
                    }
                    if (sq == false)
                    {
                        lblCorrectAns.Visible = true;
                        lblCorrectAns.Text = lblCorrectAns.Text + "\nThe correct answer for the second question is " + lblAns2.Text;
                    }
                    if (tq == false)
                    {
                        lblCorrectAns.Visible = true;
                        lblCorrectAns.Text = lblCorrectAns.Text + "\nThe correct answer for the third question is " + lblAns3.Text;
                    }
                }

            }

        }
    }
}
