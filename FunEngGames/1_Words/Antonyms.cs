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

        XmlDocument xmlDoc = new XmlDocument();
        XmlNodeList nodeList = null;

        CommonFunctions cf = new CommonFunctions();

        public mainLevels mainLevelsForm;
        public wordsLevel wordLevelsForm;

        public Random a = new Random();

        public List<int> randomList = new List<int>();
        public List<string> antonyms = new List<string>();

        public int Questions = 3;
        public int attempt = 3;
        public int hints = 3;
        public int points = 0;

        public bool fq = false;
        public bool sq = false;
        public bool tq = false;

        public string fHint = "";
        public string sHint = "";
        public string tHint = "";


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

        private void picCheckAnswers_MouseHover(object sender, EventArgs e)
        {
            picCheckAnswers.BackgroundImage = Properties.Resources.checkYourAswers_hover;
        }

        private void picCheckAnswers_MouseLeave(object sender, EventArgs e)
        {
            picCheckAnswers.BackgroundImage = Properties.Resources.checkYourAswers;
        }

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

        public void showFeedBack(string txt, Color color)
        {
            lblFeedback.Visible = true;
            lblFeedback.ForeColor = color;
            lblFeedback.Text = txt;
        }

        public void hideFeedBack()
        {
            lblFeedback.Visible = false;
        }

        public void SavePoints()
        {
            this.mainLevelsForm.antonymsPoints = attempt+1+ hints + points;
            this.wordLevelsForm.antonymsPoints = attempt + 1 + hints + points;
            this.mainLevelsForm.CF.antonymsPoints = attempt + 1 + hints + points;

            this.mainLevelsForm.lblWordsPoints.Text = (this.mainLevelsForm.spellingPoints + this.mainLevelsForm.synonymsPoints + this.mainLevelsForm.antonymsPoints).ToString();
            this.wordLevelsForm.lblSandAPoints.Text = (this.mainLevelsForm.synonymsPoints + this.mainLevelsForm.antonymsPoints).ToString();


        }


        private void btnHint1_Click(object sender, EventArgs e)
        {
            lblHint.Visible = true;
            lblHint.Text = cf.UppercaseFirst(fHint) + " is another antonym for the word you're looking for!";
            btnHint1.Enabled = false;
            hints--;
        }

        private void btnHint2_Click(object sender, EventArgs e)
        {
            lblHint.Visible = true;
            lblHint.Text = cf.UppercaseFirst(sHint) + " is another antonym for the word you're looking for!";
            btnHint2.Enabled = false;
            hints--;
        }

        private void btnHint3_Click(object sender, EventArgs e)
        {
            lblHint.Visible = true;
            lblHint.Text = cf.UppercaseFirst(tHint) + " is another antonym for the word you're looking for!";
            btnHint3.Enabled = false;
            hints--;
        }

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
