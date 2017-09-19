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
    public partial class Antonyms : Form
    {
        public Antonyms()
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
            this.mainLevelsForm.Show();
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

            xmlDoc.Load("questions.xml");
            //this.Synonyms();
            this.GenAntonyms();
        }

       

        public void GenAntonyms() {

            try
            {
                XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/antonyms");


                string word = "", antonym = "";
                //foreach (XmlNode node in nodeList)

                NewNumber(nodeList.Count);
                int random = randomList.Last();

                word = nodeList[random].SelectSingleNode("word").InnerText;
                antonym = nodeList[random].SelectSingleNode("antonym").InnerText;
                antonyms.Add(antonym);
                lblW4.Text = "1- " + word;






                NewNumber(nodeList.Count);
                random = randomList.Last();

                word = nodeList[random].SelectSingleNode("word").InnerText;
                antonym = nodeList[random].SelectSingleNode("antonym").InnerText;
                antonyms.Add(antonym);
                lblW5.Text = "2- " + word;






                NewNumber(nodeList.Count);
                random = randomList.Last();

                word = nodeList[random].SelectSingleNode("word").InnerText;
                antonym = nodeList[random].SelectSingleNode("antonym").InnerText;
                antonyms.Add(antonym);
                lblW6.Text = "3- " + word;


                lblAns4.Text = antonyms[0];
                lblAns5.Text = antonyms[1];
                lblAns6.Text = antonyms[2];



                Shuffle(antonyms);
                comboBox4.Items.Add("A- " + antonyms[0]); comboBox4.Items.Add("B- " + antonyms[1]); comboBox4.Items.Add("C- " + antonyms[2]);
                comboBox5.Items.Add("A- " + antonyms[0]); comboBox5.Items.Add("B- " + antonyms[1]); comboBox5.Items.Add("C- " + antonyms[2]);
                comboBox6.Items.Add("A- " + antonyms[0]); comboBox6.Items.Add("B- " + antonyms[1]); comboBox6.Items.Add("C- " + antonyms[2]);


                lblA1.Text = "A- " + antonyms[0];
                lblA2.Text = "B- " + antonyms[1];
                lblA3.Text = "C- " + antonyms[2];



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

            //Antonyms check
            if (comboBox4.Text.Trim().ToLower().Contains(lblAns4.Text.Trim().ToLower()))
            {
                picAns4.BackgroundImage = Properties.Resources.check;
            }
            else
            {
                picAns4.BackgroundImage = Properties.Resources.cross;
            }


            if (comboBox5.Text.Trim().ToLower().Contains(lblAns5.Text.Trim().ToLower()))
            {
                picAns5.BackgroundImage = Properties.Resources.check;
            }
            else
            {
                picAns5.BackgroundImage = Properties.Resources.cross;
            }




            if (comboBox6.Text.Trim().ToLower().Contains(lblAns6.Text.Trim().ToLower()))
            {
                picAns6.BackgroundImage = Properties.Resources.check;
            }
            else
            {
                picAns6.BackgroundImage = Properties.Resources.cross;
            }
        }
    }
}
