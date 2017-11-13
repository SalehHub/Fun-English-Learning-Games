/*
 * Project Name:    Fun English learning Games
 * File Name:       Homonyms.cs
 * Coded By:        Saleh Alzahrani & Sarah Aljabri
 * Coded On:        Fall 2017
 * About this File: This file handles all of Homonyms level gameplay logic, Generating homonyms with definitions and calculating points
 */

using FunEngGames._1_Words;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace FunEngGames
{
    public partial class homonyms : Form
    {
        public homonyms()
        {
            InitializeComponent();
        }

        //Storing the xml content
        XmlDocument xmlDoc = new XmlDocument();
        XmlNodeList nodeList = null;

        //CommonFunctions object
        CommonFunctions cf = new CommonFunctions();

        //Variables wordLevelsForm and mainLevelsForm to store previous forms status        
        public wordsLevel wordLevelsForm;
        public mainLevels mainLevelsForm;
        //public HomonymsLesson HomonymsLesson;

        //Random integer variable
        public Random a = new Random();

        //Lists to store XML nodes and generated synonyms
        public List<int> randomList = new List<int>();
        public List<string> answers = new List<string>();


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

        //Genearte new questions if the player needs to play again
        public void GenerateNewQuestions()
        {
            try
            {
                string def1 = "", def2 = "", ans = "";
                //foreach (XmlNode node in nodeList)

                NewNumber(nodeList.Count);
                int random = randomList.Last();

                def1 = cf.UppercaseFirst(nodeList[random].SelectSingleNode("def1").InnerText.Trim());
                def2 = cf.UppercaseFirst(nodeList[random].SelectSingleNode("def2").InnerText.Trim());
                ans = nodeList[random].SelectSingleNode("answer").InnerText.Trim();

                answers.Add(ans);
                lblAns1.Text = ans;
                lblDef1_1.Text = def1;
                lblDef1_2.Text = def2;





                NewNumber(nodeList.Count);
                random = randomList.Last();

                def1 = cf.UppercaseFirst(nodeList[random].SelectSingleNode("def1").InnerText.Trim());
                def2 = cf.UppercaseFirst(nodeList[random].SelectSingleNode("def2").InnerText.Trim());
                ans = nodeList[random].SelectSingleNode("answer").InnerText.Trim();

                answers.Add(ans);

                lblAns2.Text = ans;
                lblDef2_1.Text = def1;
                lblDef2_2.Text = def2;



                NewNumber(nodeList.Count);
                random = randomList.Last();

                def1 = cf.UppercaseFirst(nodeList[random].SelectSingleNode("def1").InnerText.Trim());
                def2 = cf.UppercaseFirst(nodeList[random].SelectSingleNode("def2").InnerText.Trim());
                ans = nodeList[random].SelectSingleNode("answer").InnerText.Trim();

                answers.Add(ans);

                lblAns3.Text = ans;
                lblDef3_1.Text = def1;
                lblDef3_2.Text = def2;





                NewNumber(nodeList.Count);
                random = randomList.Last();

                def1 = cf.UppercaseFirst(nodeList[random].SelectSingleNode("def1").InnerText.Trim());
                def2 = cf.UppercaseFirst(nodeList[random].SelectSingleNode("def2").InnerText.Trim());
                ans = nodeList[random].SelectSingleNode("answer").InnerText.Trim();

                answers.Add(ans);

                lblAns4.Text = ans;
                lblDef4_1.Text = def1;
                lblDef4_2.Text = def2;



                NewNumber(nodeList.Count);
                random = randomList.Last();

                def1 = cf.UppercaseFirst(nodeList[random].SelectSingleNode("def1").InnerText.Trim());
                def2 = cf.UppercaseFirst(nodeList[random].SelectSingleNode("def2").InnerText.Trim());
                ans = nodeList[random].SelectSingleNode("answer").InnerText.Trim();

                answers.Add(ans);

                lblAns5.Text = ans;
                lblDef5_1.Text = def1;
                lblDef5_2.Text = def2;



                Shuffle(answers);
                Shuffle(answers);
                comboBox1.Items.AddRange(answers.ToArray());
                Shuffle(answers);
                comboBox2.Items.AddRange(answers.ToArray());
                Shuffle(answers);
                comboBox3.Items.AddRange(answers.ToArray());
                comboBox4.Items.AddRange(answers.ToArray());
                comboBox5.Items.AddRange(answers.ToArray());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Save and pass points between main levels form and words levels form.
        public void SavePoints()
        {
            this.mainLevelsForm.homonymsPoints = attempt+1 + points;
            this.wordLevelsForm.homonymsPoints = attempt+1 + points;

            this.mainLevelsForm.lblWordsPoints.Text = (this.mainLevelsForm.spellingPoints +
                                                        this.mainLevelsForm.synonymsPoints +
                                                        this.mainLevelsForm.antonymsPoints +
                                                        attempt+1 + points).ToString();

            this.wordLevelsForm.lblHomonymsPoints.Text = (attempt+1 + points).ToString();


            this.mainLevelsForm.CF.homonymsPoints = attempt+1 + points;
        }

        //Form load fucntion generate questions
        private void homonyms_Load(object sender, EventArgs e)
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

            fHint = "";
            sHint = "";
            tHint = "";

            btnHint1.Enabled = true;
            btnHint2.Enabled = true;
            btnHint3.Enabled = true;
            btnHint4.Enabled = true;
            btnHint5.Enabled = true;
            lblHint.Visible = false;

            lblCorrectAns.Visible = false;
            lblCorrectAns.Text = "";

            comboBox1.Enabled = true;
            comboBox1.Items.Clear();
            comboBox1.Text = "";

            comboBox2.Enabled = true;
            comboBox2.Items.Clear();
            comboBox2.Text = "";

            comboBox3.Enabled = true;
            comboBox3.Items.Clear();
            comboBox3.Text = "";

            comboBox4.Enabled = true;
            comboBox4.Items.Clear();
            comboBox4.Text = "";

            comboBox5.Enabled = true;
            comboBox5.Items.Clear();
            comboBox5.Text = "";

            picAns1.BackgroundImage = null;
            picAns2.BackgroundImage = null;
            picAns3.BackgroundImage = null;
            picAns4.BackgroundImage = null;
            picAns5.BackgroundImage = null;

            //randomList.Clear();
            answers.Clear();

            btnCheckYourAnswer.Text = "Check your answers";
            lblAttempts.Text = attempt.ToString();
            lblPoints.Text = points.ToString();


            xmlDoc.Load("XML/homonyms.xml");
            nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/homonyms");


            GenerateNewQuestions();

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

        //Form closing function: show the words level form
        private void homonyms_FormClosed(object sender, FormClosedEventArgs e)
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
            lblHint.Visible = false;
        }

        //Unlock phrases level
        public void unlockPhrases()
        {
            this.mainLevelsForm.picPhrases.Enabled = true;
            this.mainLevelsForm.picPhrasesLock.Visible = false;
            this.mainLevelsForm.lbltitle.Text = "Now you need to play all the Phrases levels to unlock Sentences levels";

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
                homonyms_Load(sender, e);
            }
            else if (btnCheckYourAnswer.Text == "View your reward")
            {
                Storyline_Friendship Storyline_Friendship = new Storyline_Friendship();
                Storyline_Friendship.mainLevelsForm = this.mainLevelsForm;
                Storyline_Friendship.wordLevelsForm = this.wordLevelsForm;
                this.Hide();
                Storyline_Friendship.Show();
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



                //solved 3 questions or all questions and no more attempts
                if ((Questions <= 2 && attempt == 0) || (Questions == 0))
                {
                    showFeedBack("Good job, keep up the good work in the next levels.", Color.Green);

                    lblPoints.Text = (attempt + 1 + points).ToString();

                    SavePoints();
                    btnCheckYourAnswer.Text = "View your reward";
                    unlockPhrases();


                }


                if (attempt > 0 && Questions > 0)
                {
                    if (attempt == 4)
                    {

                        showFeedBack("Try again you still have four attempts left.", Color.Red);
                    }
                    else if (attempt == 3)
                    {
                        showFeedBack("Try again you still have three attempts left.", Color.Red);
                    }
                    else if (attempt == 2)
                    {
                        showFeedBack("Try again you still have two attempts left", Color.Red);
                    }
                    else if (attempt == 1)
                    {
                        showFeedBack("Try again you still have one attempt left", Color.Red);
                    }
                }



                //no more attempts and we still have 3 or more incorrect questions
                if (attempt == 0 && Questions >= 3)
                {
                    lblHint.Visible = false;
                    
                    showFeedBack("Sorry, you need to solve at least three questions to pass this level", Color.Red);

                    btnCheckYourAnswer.Text = "Restart the level";
                }



                //no more attempts show the correct answers
                if (attempt == 0 && Questions > 0)
                {
                    lblCorrectAns.Text = "";


                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                    comboBox3.Enabled = false;
                    comboBox4.Enabled = false;
                    comboBox5.Enabled = false;


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

        private void homonyms_Shown(object sender, EventArgs e)
        {
            //HomonymsLesson.Hide();
        }

        private void hint(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var text = " is not a correct answer!";
            if (btn.Name == "btnHint1")
            {
                btnHint1.Enabled = false;
                if (lblAns1.Text != comboBox1.Items[0].ToString())
                {
                    lblHint.Text = comboBox1.Items[0] + text;
                }
                else if (lblAns1.Text != comboBox1.Items[1].ToString())
                {
                    lblHint.Text = comboBox1.Items[1] + text;
                }
                else if (lblAns1.Text != comboBox1.Items[2].ToString())
                {
                    lblHint.Text = comboBox1.Items[2] + text;
                }
                else if (lblAns1.Text != comboBox1.Items[3].ToString())
                {
                    lblHint.Text = comboBox1.Items[3] + text;
                }
                else if (lblAns1.Text != comboBox1.Items[4].ToString())
                {
                    lblHint.Text = comboBox1.Items[4] + text;
                }
            }

            if (btn.Name == "btnHint2")
            {
                btnHint2.Enabled = false;
                if (lblAns2.Text != comboBox2.Items[0].ToString())
                {
                    lblHint.Text = comboBox2.Items[0] + text;
                }
                else if (lblAns2.Text != comboBox2.Items[1].ToString())
                {
                    lblHint.Text = comboBox2.Items[1] + text;
                }
                else if (lblAns2.Text != comboBox2.Items[2].ToString())
                {
                    lblHint.Text = comboBox2.Items[2] + text;
                }
                else if (lblAns2.Text != comboBox2.Items[3].ToString())
                {
                    lblHint.Text = comboBox2.Items[3] + text;
                }
                else if (lblAns2.Text != comboBox2.Items[4].ToString())
                {
                    lblHint.Text = comboBox2.Items[4] + text;
                }
            }

            if (btn.Name == "btnHint3")
            {
                btnHint3.Enabled = false;
                if (lblAns3.Text != comboBox3.Items[0].ToString())
                {
                    lblHint.Text = comboBox3.Items[0] + text;
                }
                else if (lblAns3.Text != comboBox3.Items[1].ToString())
                {
                    lblHint.Text = comboBox3.Items[1] + text;
                }
                else if (lblAns3.Text != comboBox3.Items[2].ToString())
                {
                    lblHint.Text = comboBox3.Items[2] + text;
                }
                else if (lblAns3.Text != comboBox3.Items[3].ToString())
                {
                    lblHint.Text = comboBox3.Items[3] + text;
                }
                else if (lblAns3.Text != comboBox3.Items[4].ToString())
                {
                    lblHint.Text = comboBox3.Items[4] + text;
                }
            }

            if (btn.Name == "btnHint4")
            {
                btnHint4.Enabled = false;
                if (lblAns4.Text != comboBox4.Items[0].ToString())
                {
                    lblHint.Text = comboBox4.Items[0] + text;
                }
                else if (lblAns4.Text != comboBox4.Items[1].ToString())
                {
                    lblHint.Text = comboBox4.Items[1] + text;
                }
                else if (lblAns4.Text != comboBox4.Items[2].ToString())
                {
                    lblHint.Text = comboBox4.Items[2] + text;
                }
                else if (lblAns4.Text != comboBox4.Items[3].ToString())
                {
                    lblHint.Text = comboBox4.Items[3] + text;
                }
                else if (lblAns4.Text != comboBox4.Items[4].ToString())
                {
                    lblHint.Text = comboBox4.Items[4] + text;
                }
            }
            if (btn.Name == "btnHint5")
            {
                btnHint5.Enabled = false;
                if (lblAns5.Text != comboBox5.Items[0].ToString())
                {
                    lblHint.Text = comboBox5.Items[0] + text;
                }
                else if (lblAns5.Text != comboBox5.Items[1].ToString())
                {
                    lblHint.Text = comboBox5.Items[1] + text;
                }
                else if (lblAns5.Text != comboBox5.Items[2].ToString())
                {
                    lblHint.Text = comboBox5.Items[2] + text;
                }
                else if (lblAns5.Text != comboBox5.Items[3].ToString())
                {
                    lblHint.Text = comboBox5.Items[3] + text;
                }
                else if (lblAns5.Text != comboBox5.Items[4].ToString())
                {
                    lblHint.Text = comboBox5.Items[4] + text;
                }
            }


            lblHint.Visible = true;
            hints--;
        }
    }
}
