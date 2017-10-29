/*
 * Project Name:    Fun English learning Games
 * File Name:       Synonyms.cs
 * Coded By:        Saleh Alzahrani & Sarah Aljabri
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
    public partial class Synonyms : Form
    {
        public Synonyms()
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
        public List<string> synonyms = new List<string>();

        //Set game variables
        public int Questions = 5;
        public int attempt = 5;
        public int hints = 5;
        public int points = 0;

        //What answer has been answerd
        public bool fq = false;
        public bool sq = false;
        public bool tq = false;
        public bool foq = false;
        public bool fiq = false;

        //Hints content setup
        public string fHint = "";
        public string sHint = "";
        public string tHint = "";
        public string foHint = "";
        public string fiHint = "";

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
                System.Console.WriteLine(ex.Message);
            }
        }

        //Form load fucntion generate questions
        private void S_A_Load(object sender, EventArgs e)
        {
            // Ensure WaitOnLoad is false.
            pictureBox5.WaitOnLoad = false;

            // Load the image asynchronously.
            pictureBox5.LoadAsync(@"https://media.giphy.com/media/Bn6djQ6MgEWZi/giphy.gif");


            Questions = 5;
            attempt = 5;
            hints = 5;
            points = 0;

            fq = false;
            sq = false;
            tq = false;
            foq = false;
            fiq = false;

            //randomList.Clear();
            synonyms.Clear();
            //antonyms.Clear();




            picAns1.BackgroundImage = null;
            picAns2.BackgroundImage = null;
            picAns3.BackgroundImage = null;
            picAns4.BackgroundImage = null;
            picAns5.BackgroundImage = null;


            btnCheckYourAnswer.Text = "Check your answers";
            lblAttempts.Text = attempt.ToString();
            lblPoints.Text = points.ToString();

            xmlDoc.Load("XML/synonyms.xml");
            nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/synonyms");

            this.GenerateSynonyms();
        }

        //Generate all the Three synonyms questions
        public void GenerateSynonyms()
        {

            //synonyms.Clear();

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

            btnHint4.Enabled = true;
            comboBox4.Enabled = true;
            comboBox4.Items.Clear();
            comboBox4.Text = "";

            btnHint5.Enabled = true;
            comboBox5.Enabled = true;
            comboBox5.Items.Clear();
            comboBox5.Text = "";


            try
            {
                string word = "", synonym = "";

                NewNumber(nodeList.Count);
                int random = randomList.Last();

                word = nodeList[random].SelectSingleNode("word").InnerText.Trim();
                synonym = nodeList[random].SelectSingleNode("synonym").InnerText.Trim();
                fHint = nodeList[random].SelectSingleNode("hint").InnerText.Trim();

                synonyms.Add(synonym.ToLower());
                lblW1.Text = "" + word.ToLower();


                NewNumber(nodeList.Count);
                random = randomList.Last();

                word = nodeList[random].SelectSingleNode("word").InnerText.Trim();
                synonym = nodeList[random].SelectSingleNode("synonym").InnerText.Trim();
                sHint = nodeList[random].SelectSingleNode("hint").InnerText.Trim();

                synonyms.Add(synonym.ToLower());
                lblW2.Text = "" + word.ToLower();


                NewNumber(nodeList.Count);
                random = randomList.Last();

                word = nodeList[random].SelectSingleNode("word").InnerText.Trim();
                synonym = nodeList[random].SelectSingleNode("synonym").InnerText.Trim();
                tHint = nodeList[random].SelectSingleNode("hint").InnerText.Trim();

                synonyms.Add(synonym.ToLower());
                lblW3.Text = "" + word.ToLower();


                NewNumber(nodeList.Count);
                random = randomList.Last();

                word = nodeList[random].SelectSingleNode("word").InnerText.Trim();
                synonym = nodeList[random].SelectSingleNode("synonym").InnerText.Trim();
                foHint = nodeList[random].SelectSingleNode("hint").InnerText.Trim();

                synonyms.Add(synonym.ToLower());
                lblW4.Text = "" + word.ToLower();

                NewNumber(nodeList.Count);
                random = randomList.Last();

                word = nodeList[random].SelectSingleNode("word").InnerText.Trim();
                synonym = nodeList[random].SelectSingleNode("synonym").InnerText.Trim();
                fiHint = nodeList[random].SelectSingleNode("hint").InnerText.Trim();

                synonyms.Add(synonym.ToLower());
                lblW5.Text = "" + word.ToLower();


                lblAns1.Text = synonyms[0];
                lblAns2.Text = synonyms[1];
                lblAns3.Text = synonyms[2];
                lblAns4.Text = synonyms[3];
                lblAns5.Text = synonyms[4];

                Shuffle(synonyms);
                //comboBox1.Items.Add("A-"); comboBox1.Items.Add("B-"); comboBox1.Items.Add("C-");
                comboBox1.Items.Add("" + synonyms[0]); comboBox1.Items.Add("" + synonyms[1]); comboBox1.Items.Add("" + synonyms[2]); comboBox1.Items.Add("" + synonyms[3]); comboBox1.Items.Add("" + synonyms[4]);
                comboBox2.Items.Add("" + synonyms[0]); comboBox2.Items.Add("" + synonyms[1]); comboBox2.Items.Add("" + synonyms[2]); comboBox2.Items.Add("" + synonyms[3]); comboBox2.Items.Add("" + synonyms[4]);
                comboBox3.Items.Add("" + synonyms[0]); comboBox3.Items.Add("" + synonyms[1]); comboBox3.Items.Add("" + synonyms[2]); comboBox3.Items.Add("" + synonyms[3]); comboBox3.Items.Add("" + synonyms[4]);
                comboBox4.Items.Add("" + synonyms[0]); comboBox4.Items.Add("" + synonyms[1]); comboBox4.Items.Add("" + synonyms[2]); comboBox4.Items.Add("" + synonyms[3]); comboBox4.Items.Add("" + synonyms[4]);
                comboBox5.Items.Add("" + synonyms[0]); comboBox5.Items.Add("" + synonyms[1]); comboBox5.Items.Add("" + synonyms[2]); comboBox5.Items.Add("" + synonyms[3]); comboBox5.Items.Add("" + synonyms[4]);


                Shuffle(synonyms);
                lblS1.Text = "" + synonyms[0];
                lblS2.Text = "" + synonyms[1];
                lblS3.Text = "" + synonyms[2];
                lblS4.Text = "" + synonyms[3];
                lblS5.Text = "" + synonyms[4];



                


            }
            catch (Exception ex)
            {
                GenerateSynonyms();
                System.Console.WriteLine(ex.Message);
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

        //Check your answer function
        private void btnCheckYourAnswer_Click(object sender, EventArgs e)
        {
            hideFeedBack();



            if (comboBox1.Text.Trim() == "" || comboBox2.Text.Trim() == "" || comboBox3.Text.Trim() == "" || comboBox4.Text.Trim() == "" || comboBox5.Text.Trim() == "")
            {
                showFeedBack("Please answer all the five questions first.", Color.Red);

            }
            else if (btnCheckYourAnswer.Text == "Restart the level")
            {

                S_A_Load(sender, e);

            }
            else if (btnCheckYourAnswer.Text == "Go to Antonyms lesson")
            {
                AntonymsLesson antonymsLesson = new AntonymsLesson();
                antonymsLesson.mainLevelsForm = this.mainLevelsForm;
                antonymsLesson.wordLevelsForm = this.wordLevelsForm;
                this.Hide();
                antonymsLesson.Show();
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





                if (foq == false && comboBox4.Text.Trim().ToLower().Contains(lblAns4.Text.Trim().ToLower()))
                {
                    picAns4.BackgroundImage = Properties.Resources.check;
                    points++;
                    btnHint4.Enabled = false;
                    comboBox4.Enabled = false;
                    Questions--;
                    foq = true;
                }
                else if (foq == false && !comboBox4.Text.Trim().ToLower().Contains(lblAns4.Text.Trim().ToLower()))
                {
                    picAns4.BackgroundImage = Properties.Resources.cross;
                }




                if (fiq == false && comboBox5.Text.Trim().ToLower().Contains(lblAns5.Text.Trim().ToLower()))
                {
                    picAns5.BackgroundImage = Properties.Resources.check;
                    points++;
                    btnHint5.Enabled = false;
                    comboBox5.Enabled = false;
                    Questions--;
                    fiq = true;
                }
                else if (fiq == false && !comboBox5.Text.Trim().ToLower().Contains(lblAns5.Text.Trim().ToLower()))
                {
                    picAns5.BackgroundImage = Properties.Resources.cross;
                }





                /* if (Questions == 0)
                 {
                     showFeedBack("Good job, keep up the good work in the next level.", Color.Green);

                     lblPoints.Text = (attempt + 1 + hints + points).ToString();

                     SavePoints();
                     btnCheckYourAnswer.Text = "Go to Antonyms lesson";
                 }
                 */

                //solved 3 or more questions
                if ((Questions <= 2 && attempt == 0) || (Questions == 0))
                {
                    showFeedBack("Good job, keep up the good work in the next level.", Color.Green);

                    lblPoints.Text = (attempt + 1 + hints + points).ToString();

                    SavePoints();
                    btnCheckYourAnswer.Text = "Go to Antonyms lesson";
                }


                if (attempt > 0 && Questions > 0)
                {
                    if (attempt == 4)
                    {
                        showFeedBack("Try again you still have four attempts left.", Color.Red);
                    }
                    else if(attempt == 3)
                    {
                        showFeedBack("Try again you still have three attempts left.", Color.Red);
                    }
                    else if(attempt == 2)
                    {
                        showFeedBack("Try again you still have two attempts left.", Color.Red);
                    }
                    else if (attempt == 1)
                    {
                        showFeedBack("Try again you still have one attempt left.", Color.Red);
                    }
                }


                //no more attempts and we still have 2 or more incorrect questions
                if (attempt == 0 && Questions >= 3)
                {
                    lblHint.Visible = false;


                    showFeedBack("Sorry, you need to solve at least three questions to pass this level.", Color.Red);

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
                    if (foq == false)
                    {
                        lblCorrectAns.Visible = true;
                        lblCorrectAns.Text = lblCorrectAns.Text + "\nThe correct answer for the fourth question is " + lblAns4.Text;
                    }
                    if (fiq == false)
                    {
                        lblCorrectAns.Visible = true;
                        lblCorrectAns.Text = lblCorrectAns.Text + "\nThe correct answer for the fifth question is " + lblAns5.Text;
                    }
                }


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
            this.mainLevelsForm.synonymsPoints = attempt + 1 + hints + points;
            this.wordLevelsForm.synonymsPoints = attempt + 1 + hints + points;
            this.mainLevelsForm.CF.synonymsPoints = attempt + 1 + hints + points;


            this.mainLevelsForm.lblWordsPoints.Text = (this.mainLevelsForm.spellingPoints + this.wordLevelsForm.synonymsPoints).ToString();
            this.wordLevelsForm.lblSandAPoints.Text = (this.wordLevelsForm.synonymsPoints + this.wordLevelsForm.antonymsPoints).ToString();


        }

        //Show first question hint
        private void btnHint1_Click(object sender, EventArgs e)
        {
            lblHint.Visible = true;
            lblHint.Text = "\"" + cf.UppercaseFirst(fHint) + "\" is another synonym for the word you're looking for!";
            btnHint1.Enabled = false;
            hints--;
        }

        //Show second question hint
        private void btnHint2_Click(object sender, EventArgs e)
        {
            lblHint.Visible = true;
            lblHint.Text = "\"" + cf.UppercaseFirst(sHint) + "\" is another synonym for the word you're looking for!";
            btnHint2.Enabled = false;
            hints--;
        }

        //Show third question hint
        private void btnHint3_Click(object sender, EventArgs e)
        {
            lblHint.Visible = true;
            lblHint.Text = "\"" + cf.UppercaseFirst(tHint) + "\" is another synonym for the word you're looking for!";
            btnHint3.Enabled = false;
            hints--;
        }

        //Show fourth question hint
        private void btnHint4_Click(object sender, EventArgs e)
        {
            lblHint.Visible = true;
            lblHint.Text ="\""+ cf.UppercaseFirst(foHint) + "\" is another synonym for the word you're looking for!";
            btnHint4.Enabled = false;
            hints--;
        }

        //Show fifth question hint
        private void btnHint5_Click(object sender, EventArgs e)
        {
            lblHint.Visible = true;
            lblHint.Text = "\"" + cf.UppercaseFirst(fiHint) + "\" is another synonym for the word you're looking for!";
            btnHint5.Enabled = false;
            hints--;
        }
    }

}
