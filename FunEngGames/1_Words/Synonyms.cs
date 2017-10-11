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
    public partial class Synonyms : Form
    {
        public Synonyms()
        {
            InitializeComponent();
        }

        XmlDocument xmlDoc = new XmlDocument();

        CommonFunctions cf = new CommonFunctions();

        public mainLevels mainLevelsForm;
        public wordsLevel wordLevelForm;

        public Random a = new Random();

        public List<int> randomList = new List<int>();
        public List<string> synonyms = new List<string>();

        public int attempt = 3;
        public int hints = 3;
        public int points = 0;

        public bool fq = false;
        public bool sq = false;
        public bool tq = false;

        public string fHint = "";
        public string sHint = "";
        public string tHint = "";

        public int Questions = 3;

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


        private void S_A_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.wordLevelForm.Show();
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



            attempt = 3;
            hints = 3;
            points = 0;

            fq = false;
            sq = false;
            tq = false;

            randomList.Clear();
            synonyms.Clear();
            //antonyms.Clear();

            btnHint1.Enabled = true;
            comboBox1.Enabled = true;
            comboBox1.Items.Clear();
            comboBox1.Text="";

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

            xmlDoc.Load("XML/synonyms.xml");
            this.GenerateSynonyms();
        }

        public void GenerateSynonyms()
        {
            try
            {
                XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/synonyms");


                string word = "", synonym = "";

                NewNumber(nodeList.Count);
                int random = randomList.Last();

                word = nodeList[random].SelectSingleNode("word").InnerText;
                synonym = nodeList[random].SelectSingleNode("synonym").InnerText;
                fHint = nodeList[random].SelectSingleNode("hint").InnerText;

                synonyms.Add(cf.UppercaseFirst(synonym));
                lblW1.Text = "" + cf.UppercaseFirst(word);


                NewNumber(nodeList.Count);
                random = randomList.Last();

                word = nodeList[random].SelectSingleNode("word").InnerText;
                synonym = nodeList[random].SelectSingleNode("synonym").InnerText;
                sHint = nodeList[random].SelectSingleNode("hint").InnerText;

                synonyms.Add(cf.UppercaseFirst(synonym));
                lblW2.Text = "" + cf.UppercaseFirst(word);


                NewNumber(nodeList.Count);
                random = randomList.Last();

                word = nodeList[random].SelectSingleNode("word").InnerText;
                synonym = nodeList[random].SelectSingleNode("synonym").InnerText;
                tHint = nodeList[random].SelectSingleNode("hint").InnerText;

                synonyms.Add( cf.UppercaseFirst(synonym));
                lblW3.Text = "" + cf.UppercaseFirst(word);


                //comboBox1.Tag = synonyms[0];
                //comboBox2.Tag = synonyms[1];
                //comboBox3.Tag = synonyms[2];

                lblAns1.Text = synonyms[0];
                lblAns2.Text = synonyms[1];
                lblAns3.Text = synonyms[2];

                 Shuffle(synonyms);
                //comboBox1.Items.Add("A-"); comboBox1.Items.Add("B-"); comboBox1.Items.Add("C-");
                comboBox1.Items.Add("" + synonyms[0]); comboBox1.Items.Add("" + synonyms[1]); comboBox1.Items.Add("" + synonyms[2]);
                comboBox2.Items.Add("" + synonyms[0]); comboBox2.Items.Add("" + synonyms[1]); comboBox2.Items.Add("" + synonyms[2]);
                comboBox3.Items.Add("" + synonyms[0]); comboBox3.Items.Add("" + synonyms[1]); comboBox3.Items.Add("" + synonyms[2]);


                Shuffle(synonyms);
                lblS1.Text = "" + synonyms[0];
                lblS2.Text = "" + synonyms[1];
                lblS3.Text = "" + synonyms[2];


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void picCheckAnswers_Click(object sender, EventArgs e)
        {
            AntonymsLesson at = new AntonymsLesson();
            at.Show();

            //Synonyms check
            if (comboBox1.Text.Trim().ToLower().Contains(lblAns1.Text.Trim().ToLower()))
            {
                picAns1.BackgroundImage = Properties.Resources.check;
            }
            else
            {
                picAns1.BackgroundImage = Properties.Resources.cross;
            }




            if (comboBox2.Text.Trim().ToLower().Contains(lblAns2.Text.Trim().ToLower()))
            {
                picAns2.BackgroundImage = Properties.Resources.check;
            }
            else
            {
                picAns2.BackgroundImage = Properties.Resources.cross;
            }




            if (comboBox3.Text.Trim().ToLower().Contains(lblAns3.Text.Trim().ToLower()))
            {
                picAns3.BackgroundImage = Properties.Resources.check;
            }
            else
            {
                picAns3.BackgroundImage = Properties.Resources.cross;
            }







        }

        private void button1_Click(object sender, EventArgs e)
        {
            AntonymsLesson antonymsLesson = new AntonymsLesson();
            antonymsLesson.mainLevelsForm = this.mainLevelsForm;
            this.Hide();
            antonymsLesson.Show();
        }



        private void btnCheckYourAnswer_Click(object sender, EventArgs e)
        {
            hideFeedBack();



            if (comboBox1.Text.Trim()=="" || comboBox2.Text.Trim()=="" || comboBox3.Text.Trim()=="")
            {
                showFeedBack("Please answer all the three questions first.", Color.Red);

            }else if (btnCheckYourAnswer.Text == "Restart the level")
            {

                S_A_Load(sender,e);

            }
            else if (btnCheckYourAnswer.Text == "Go to Antonyms lesson")
            {
                AntonymsLesson antonymsLesson = new AntonymsLesson();
                antonymsLesson.mainLevelsForm = this.mainLevelsForm;
                antonymsLesson.wordLevelsForm = this.wordLevelForm;
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
                    tq = false;
                }
                else if (tq == false && !comboBox3.Text.Trim().ToLower().Contains(lblAns3.Text.Trim().ToLower()))
                {
                    picAns3.BackgroundImage = Properties.Resources.cross;
                }

                //solved all the questions
                if (Questions == 0 && attempt >= 0)
                {
                    showFeedBack("Good job, keep up the good work in the next level", Color.Green);

                    lblPoints.Text = (hints+points).ToString();

                    SavePoints();
                    btnCheckYourAnswer.Text = "Go to Antonyms lesson";
                }



                if (attempt == 0 && Questions >= 1)
                {
                    showFeedBack("Sorry, you need to solve at least two questions to pass this level", Color.Red);

                    btnCheckYourAnswer.Text = "Restart the level";
                }


            }

        }


        public void showFeedBack(string txt,Color color)
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
            this.mainLevelsForm.synonymsPoints = hints+points;
            this.wordLevelForm.synonymsPoints = hints + points;

            this.mainLevelsForm.lblWordsPoints.Text = (this.mainLevelsForm.synonymsPoints+ hints + points).ToString();
            this.wordLevelForm.lblSandAPoints.Text = (hints + points).ToString();


            this.mainLevelsForm.CF.synonymsPoints = hints + points;
        }

        private void lblFeedback_Click(object sender, EventArgs e)
        {

        }

        private void btnHint1_Click(object sender, EventArgs e)
        {
            lblHint.Visible = true;
            lblHint.Text = cf.UppercaseFirst(fHint) + " is another synonym for the word you're looking for!";
            btnHint1.Enabled = false;
            hints--;
        }

        private void btnHint2_Click(object sender, EventArgs e)
        {
            lblHint.Visible = true;
            lblHint.Text = cf.UppercaseFirst(sHint) + " is another synonym for the word you're looking for!";
            btnHint2.Enabled = false;
            hints--;
        }

        private void btnHint3_Click(object sender, EventArgs e)
        {
            lblHint.Visible = true;
            lblHint.Text = cf.UppercaseFirst(tHint) + " is another synonym for the word you're looking for!";
            btnHint3.Enabled = false;
            hints--;
        }
    }

}
