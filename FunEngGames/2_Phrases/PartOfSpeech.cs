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
    public partial class POS : Form
    {
        public POS()
        {
            InitializeComponent();
        }

        public phrasesLevel mainLevelsForm;

        XmlDocument xmlDoc = new XmlDocument();



        public Random a = new Random();

        public List<int> randomList = new List<int>();
        public List<string> answers = new List<string>();


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
        private void POS_Load(object sender, EventArgs e)
        {
            // Ensure WaitOnLoad is false.
            pictureBox5.WaitOnLoad = false;

            // Load the image asynchronously.
            pictureBox5.LoadAsync(@"https://media.giphy.com/media/Bn6djQ6MgEWZi/giphy.gif");
            xmlDoc.Load("XML/partsofspeech.xml");
            //this.Synonyms();
            this.GenPartsOfSpeech();
        }

        public void GenPartsOfSpeech()
        {
            try
            { 
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/partOfSpeech");


                string sentence = "", word = "", ans1 = "",ans2="", ans3="";
                //foreach (XmlNode node in nodeList)

               
                NewNumber(nodeList.Count);
                int random = randomList.Last();

                sentence = nodeList[random].SelectSingleNode("sentence").InnerText;
                word = nodeList[random].SelectSingleNode("word").InnerText;
                ans1 = nodeList[random].SelectSingleNode("answer1").InnerText;
                ans2 = nodeList[random].SelectSingleNode("answer2").InnerText;
                ans3 = nodeList[random].SelectSingleNode("answer3").InnerText;

                answers.Add(ans1);
                answers.Add(ans2);
                answers.Add(ans3);

                //comboBox1.Items.Add(ans); comboBox2.Items.Add(ans); comboBox3.Items.Add(ans);
                // sentenceLable.Text = sentence;
                //wordLabel.Text = word;
                //wordLabel.Text = ans;





                //NewNumber(nodeList.Count);
                //random = randomList.Last();

                //sentence = nodeList[random].SelectSingleNode("def1").InnerText;
                //word = nodeList[random].SelectSingleNode("def2").InnerText;
                //ans = nodeList[random].SelectSingleNode("answer").InnerText;

                //answers.Add(ans);
                ////comboBox1.Items.Add(ans); comboBox2.Items.Add(ans); comboBox3.Items.Add(ans);
                //lblAns2.Text = ans;
                //senLbl.Text = def1;
                //label5.Text = def2;





                //NewNumber(nodeList.Count);
                //random = randomList.Last();

                //def1 = nodeList[random].SelectSingleNode("def1").InnerText;
                //def2 = nodeList[random].SelectSingleNode("def2").InnerText;
                //ans = nodeList[random].SelectSingleNode("answer").InnerText;

                //answers.Add(ans);
                ////comboBox1.Items.Add(ans); comboBox2.Items.Add(ans); comboBox3.Items.Add(ans);
                //lblAns3.Text = ans;
                //label3.Text = def1;
                //label6.Text = def2;

                Shuffle(answers);
                sentenceLable.Text = sentence;
                wordLabel.Text = word;

                int r = a.Next(1, 3);
                if (r == 1)
                {
                    radioButton1.Text = ans1;
                    radioButton2.Text = ans2;
                    radioButton3.Text = ans3;
                }
                else if(r == 2)
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

        private void button3_Click(object sender, EventArgs e)
        {
            
                
        }

        private void POS_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.mainLevelsForm.Show();
            }
            catch (Exception ex)
            {

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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenPartsOfSpeech();
        }
    }
}
