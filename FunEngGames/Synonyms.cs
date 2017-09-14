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

        public wordsLevel mainLevelsForm;

        public Random a = new Random();

        public List<int> randomList = new List<int>();
        public List<string> synonyms = new List<string>();
        public List<string> antonyms = new List<string>();

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
                this.mainLevelsForm.Show();
            }catch(Exception ex)
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

            xmlDoc.Load("questions.xml");
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
                synonyms.Add(synonym);
                lblW1.Text = "1- " + word;






                NewNumber(nodeList.Count);
                random = randomList.Last();

                word = nodeList[random].SelectSingleNode("word").InnerText;
                synonym = nodeList[random].SelectSingleNode("synonym").InnerText;
                synonyms.Add(synonym);
                lblW2.Text = "2- " + word;






                NewNumber(nodeList.Count);
                random = randomList.Last();

                word = nodeList[random].SelectSingleNode("word").InnerText;
                synonym = nodeList[random].SelectSingleNode("synonym").InnerText;
                synonyms.Add(synonym);
                lblW3.Text = "3- " + word;


                //comboBox1.Tag = synonyms[0];
                //comboBox2.Tag = synonyms[1];
                //comboBox3.Tag = synonyms[2];

                lblAns1.Text = synonyms[0];
                lblAns2.Text = synonyms[1];
                lblAns3.Text = synonyms[2];

                Shuffle(synonyms);
                //comboBox1.Items.Add("A-"); comboBox1.Items.Add("B-"); comboBox1.Items.Add("C-");
                comboBox1.Items.Add("A- " + synonyms[0]); comboBox1.Items.Add("B- " + synonyms[1]); comboBox1.Items.Add("C- " + synonyms[2]);
                comboBox2.Items.Add("A- " + synonyms[0]); comboBox2.Items.Add("B- " + synonyms[1]); comboBox2.Items.Add("C- " + synonyms[2]);
                comboBox3.Items.Add("A- " + synonyms[0]); comboBox3.Items.Add("B- " + synonyms[1]); comboBox3.Items.Add("C- " + synonyms[2]);


                // Shuffle(synonyms);
                lblS1.Text = "A- " + synonyms[0];
                lblS2.Text = "B- " + synonyms[1];
                lblS3.Text = "C- " + synonyms[2];


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
    }
}
