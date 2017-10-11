using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace FunEngGames
{
    public partial class AntonymsLesson : Form
    {
        public AntonymsLesson()
        {
            InitializeComponent();
        }

        public Random a = new Random();
        public List<int> randomList = new List<int>();

        public wordsLevel wordLevelsForm;
        public mainLevels mainLevelsForm;

        XmlDocument xmlDoc = new XmlDocument();
        public XmlNodeList nodeList;


        CommonFunctions CommonFunctions = new CommonFunctions();


        public int page = 0;
        public int lastPage = 0;
        public int lastNode = 0;

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

        private void button1_Click(object sender, EventArgs e)
        {
            Antonyms antonyms = new Antonyms();
            antonyms.mainLevelsForm = this.mainLevelsForm;
            antonyms.wordLevelsForm = this.wordLevelsForm;
            this.Hide();
            antonyms.Show();
        }

        private void SynonymsLesson_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.wordLevelsForm.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void SynonymsLesson_Load(object sender, EventArgs e)
        {

            xmlDoc.Load("XML/antonyms.xml");
            nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/antonyms");

            lastPage = nodeList.Count / 9;


            dataGridView1.Rows.Clear();
            GenerateSynonyms(lastNode);
            page++;
            lblPages.Text = "Page " + page + " out of " + lastPage;

            CommonFunctions.SortDataGridColumn(dataGridView1);

            /*
                        GenAntonym(textBox1,    textBox2,   nodeList);
                        GenAntonym(textBox3,    textBox4,   nodeList);
                        GenAntonym(textBox5,    textBox6,   nodeList);
                        GenAntonym(textBox7,    textBox8,   nodeList);
                        GenAntonym(textBox9,    textBox10,  nodeList);
                        GenAntonym(textBox11,   textBox12,  nodeList);
                        GenAntonym(textBox13,   textBox14,  nodeList);
                        GenAntonym(textBox15,   textBox16,  nodeList);
                        GenAntonym(textBox17,   textBox18,  nodeList);


                        NewNumber(nodeList.Count);
                        int random = randomList.Last();

                        textBox1.Text = nodeList[random].SelectSingleNode("word").InnerText;
                        textBox2.Text = nodeList[random].SelectSingleNode("antonym").InnerText;


                        NewNumber(nodeList.Count);
                        random = randomList.Last();

                        textBox3.Text = nodeList[random].SelectSingleNode("word").InnerText;
                        textBox4.Text = nodeList[random].SelectSingleNode("antonym").InnerText;



                        NewNumber(nodeList.Count);
                        random = randomList.Last();

                        textBox5.Text = nodeList[random].SelectSingleNode("word").InnerText;
                        textBox6.Text = nodeList[random].SelectSingleNode("antonym").InnerText;



                        NewNumber(nodeList.Count);
                        random = randomList.Last();

                        textBox7.Text = nodeList[random].SelectSingleNode("word").InnerText;
                        textBox8.Text = nodeList[random].SelectSingleNode("antonym").InnerText;

                        NewNumber(nodeList.Count);
                        random = randomList.Last();

                        textBox9.Text = nodeList[random].SelectSingleNode("word").InnerText;
                        textBox10.Text = nodeList[random].SelectSingleNode("antonym").InnerText;

                        NewNumber(nodeList.Count);
                        random = randomList.Last();
                        textBox11.Text = nodeList[random].SelectSingleNode("word").InnerText;
                        textBox12.Text = nodeList[random].SelectSingleNode("antonym").InnerText;

                        NewNumber(nodeList.Count);
                        random = randomList.Last();
                        textBox13.Text = nodeList[random].SelectSingleNode("word").InnerText;
                        textBox14.Text = nodeList[random].SelectSingleNode("antonym").InnerText;

                        NewNumber(nodeList.Count);
                        random = randomList.Last();
                        textBox15.Text = nodeList[random].SelectSingleNode("word").InnerText;
                        textBox16.Text = nodeList[random].SelectSingleNode("antonym").InnerText;

                        NewNumber(nodeList.Count);
                        random = randomList.Last();
                        textBox17.Text = nodeList[random].SelectSingleNode("word").InnerText;
                        textBox18.Text = nodeList[random].SelectSingleNode("antonym").InnerText;
                        */
        }

        public void GenAntonym(TextBox t1, TextBox t2, XmlNodeList nodeList)
        {
            NewNumber(nodeList.Count);
            t1.Text = nodeList[randomList.Last()].SelectSingleNode("word").InnerText;
            t2.Text = nodeList[randomList.Last()].SelectSingleNode("antonym").InnerText;
        }





        public void GenerateSynonyms(int start)
        {

            GenSynonym(start, textBox1, textBox2);//1
            GenSynonym(start + 1, textBox3, textBox4);//2
            GenSynonym(start + 2, textBox5, textBox6);//3
            GenSynonym(start + 3, textBox7, textBox8);//4
            GenSynonym(start + 4, textBox9, textBox10);//5
            GenSynonym(start + 5, textBox11, textBox12);//6
            GenSynonym(start + 6, textBox13, textBox14);//7
            GenSynonym(start + 7, textBox15, textBox16);//8
            GenSynonym(start + 8, textBox17, textBox18);//9

        }


        public void GenSynonym(int start, TextBox t1, TextBox t2)
        {
            dataGridView1.Rows.Add(CommonFunctions.UppercaseFirst(nodeList[start].SelectSingleNode("word").InnerText), CommonFunctions.UppercaseFirst(nodeList[start].SelectSingleNode("antonym").InnerText));
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            page++;
            lastNode += 9;
            dataGridView1.Rows.Clear();

            GenerateSynonyms(lastNode);


            if (page == lastPage)
            {

                btnNext.Enabled = false;

            }

            btnPrevious.Enabled = true;

            lblPages.Text = "Page " + page + " out of " + lastPage;


        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            page--;
            lastNode -= 9;
            dataGridView1.Rows.Clear();

            GenerateSynonyms(lastNode);

            if (page < lastPage)
            {

                btnNext.Enabled = true;
                //lastNode -= 9;

            }

            if (page == 1)
            {
                btnPrevious.Enabled = false;
            }

            lblPages.Text = "Page " + page + " out of " + lastPage;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                CommonFunctions.GenerateMoreInfo(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString(),  "antonyms");
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                CommonFunctions.Pronounce(senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim().ToLower());


            }

        }


    }
}
