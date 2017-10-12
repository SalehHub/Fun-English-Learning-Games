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


        XmlDocument xmlDoc = new XmlDocument();
        XmlNodeList nodeList = null;

        CommonFunctions cf = new CommonFunctions();

        public wordsLevel wordLevelsForm;
        public mainLevels mainLevelsForm;

        public Random a = new Random();

        public List<int> randomList = new List<int>();
        public List<string> answers = new List<string>();



        public int Questions = 3;
        public int attempt = 3;
        //public int hints = 3;
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

        public void GenerateNewQuestion()
        {



            try
            {


                string def1 = "", def2 = "", ans = "";
                //foreach (XmlNode node in nodeList)

                NewNumber(nodeList.Count);
                int random = randomList.Last();

                def1 = nodeList[random].SelectSingleNode("def1").InnerText;
                def2 = nodeList[random].SelectSingleNode("def2").InnerText;
                ans = nodeList[random].SelectSingleNode("answer").InnerText;

                answers.Add(ans);
                //comboBox1.Items.Add(ans); comboBox2.Items.Add(ans); comboBox3.Items.Add(ans);
                lblAns1.Text = ans;
                label1.Text = def1;
                label4.Text = def2;





                NewNumber(nodeList.Count);
                random = randomList.Last();

                def1 = nodeList[random].SelectSingleNode("def1").InnerText;
                def2 = nodeList[random].SelectSingleNode("def2").InnerText;
                ans = nodeList[random].SelectSingleNode("answer").InnerText;

                answers.Add(ans);

                lblAns2.Text = ans;
                label2.Text = def1;
                label5.Text = def2;



                NewNumber(nodeList.Count);
                random = randomList.Last();

                def1 = nodeList[random].SelectSingleNode("def1").InnerText;
                def2 = nodeList[random].SelectSingleNode("def2").InnerText;
                ans = nodeList[random].SelectSingleNode("answer").InnerText;

                answers.Add(ans);

                lblAns3.Text = ans;
                label3.Text = def1;
                label6.Text = def2;

                Shuffle(answers);
                comboBox1.Items.AddRange(answers.ToArray());
                comboBox2.Items.AddRange(answers.ToArray());
                comboBox3.Items.AddRange(answers.ToArray());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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

        private void homonyms_Load(object sender, EventArgs e)
        {
            // Ensure WaitOnLoad is false.
            pictureBox5.WaitOnLoad = false;

            // Load the image asynchronously.
            pictureBox5.LoadAsync(@"https://media.giphy.com/media/Bn6djQ6MgEWZi/giphy.gif");

            Questions = 3;
            attempt = 3;
            //hints = 3;
            points = 0;

            fq = false;
            sq = false;
            tq = false;

            fHint = "";
            sHint = "";
            tHint = "";


            xmlDoc.Load("XML/homonyms.xml");
            nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/homonyms");


            GenerateNewQuestion();

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

        private void homonyms_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

                this.wordLevelsForm.Show();

            }
            catch (Exception ex)
            {

            }
        }

        private void picCheckAnswers_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim().ToLower() == lblAns1.Text.Trim().ToLower())
            {
                picAns1.BackgroundImage = Properties.Resources.check;
            }
            else
            {
                picAns1.BackgroundImage = Properties.Resources.cross;
            }




            if (comboBox2.Text.Trim().ToLower() == lblAns2.Text.Trim().ToLower())
            {
                picAns2.BackgroundImage = Properties.Resources.check;
            }
            else
            {
                picAns2.BackgroundImage = Properties.Resources.cross;
            }




            if (comboBox3.Text.Trim().ToLower() == lblAns3.Text.Trim().ToLower())
            {
                picAns3.BackgroundImage = Properties.Resources.check;
            }
            else
            {
                picAns3.BackgroundImage = Properties.Resources.cross;
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



        public void unlockPhrases()
        {
            this.mainLevelsForm.picPhrases.Enabled = true;
            this.mainLevelsForm.picPhrasesLock.Visible = false;
            this.mainLevelsForm.lbltitle.Text = "Now you need to play all the Phrases levels to unlock Sentences levels";

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
                    //btnHint1.Enabled = false;
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
                   // btnHint2.Enabled = false;
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
                   // btnHint3.Enabled = false;
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

                    lblPoints.Text = (attempt+1 + points).ToString();

                    SavePoints();
                    btnCheckYourAnswer.Text = "View your reward";
                    unlockPhrases();
                }

                //solved 2 questions
                if (Questions >= 1 && attempt == 0)
                {
                    showFeedBack("Good job, keep up the good work in the next level", Color.Green);

                    lblPoints.Text = (attempt + 1 + points).ToString();

                    SavePoints();
                    btnCheckYourAnswer.Text = "View your reward";
                    unlockPhrases();


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
