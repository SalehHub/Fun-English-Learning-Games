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

        private void POS_Load(object sender, EventArgs e)
        {
       

            StartLevelAgain();
            
        }

        public Random a = new Random();
        public List<int> randomList = new List<int>();


        public string ques11 = "",ques12="", ans1 = "";
        public string ques21 = "",ques22="", ans2 = "";
        public string ques31 = "",ques32="", ans3 = "";

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

        public void StartLevelAgain()
        {
            //Ensure waitonload is false
            pictureBox5.WaitOnLoad = false;

            // Load the image asynchronously.
            pictureBox5.LoadAsync(@"https://media.giphy.com/media/Bn6djQ6MgEWZi/giphy.gif");

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("XML/questions.xml");

            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/"+ "partOfSpeech");

            NewNumber(nodeList.Count);
            int random = randomList.Last();

            
            ans1 = nodeList[random].SelectSingleNode("answer").InnerText.Trim();
            MessageBox.Show(ans1.ToString());
            label1.Text = ques11;
            label4.Text = ques12;

            randomList.Clear();

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

       
    }
}
