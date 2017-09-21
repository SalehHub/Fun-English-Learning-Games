using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace FunEngGames
{
    public partial class SynonymsLesson : Form
    {
        public SynonymsLesson()
        {
            InitializeComponent();
        }

        public Random a = new Random();
        public List<int> randomList = new List<int>();
        public wordsLevel mainLevelsForm;
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
            Synonyms S_A = new Synonyms();
            S_A.mainLevelsForm = this.mainLevelsForm;
            this.Hide();
            S_A.Show();
        }

        private void SynonymsLesson_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.mainLevelsForm.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void SynonymsLesson_Load(object sender, EventArgs e)
        {




            xmlDoc.Load("questions.xml");
            nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/synonyms");

            lastPage = nodeList.Count / 9;


            dataGridView1.Rows.Clear();
            GenerateSynonyms(lastNode);
            page++;
            lblPages.Text = "Page " + page + " out of " + lastPage;
            //lastNode = 9;

            /*
            NewNumber(nodeList.Count);
            int random = randomList.Last();
            textBox1.Text = nodeList[random].SelectSingleNode("word").InnerText;
            textBox2.Text = nodeList[random].SelectSingleNode("synonym").InnerText;

            NewNumber(nodeList.Count);
            random = randomList.Last();
            textBox3.Text = nodeList[random].SelectSingleNode("word").InnerText;
            textBox4.Text = nodeList[random].SelectSingleNode("synonym").InnerText;

            NewNumber(nodeList.Count);
            random = randomList.Last();
            textBox5.Text = nodeList[random].SelectSingleNode("word").InnerText;
            textBox6.Text = nodeList[random].SelectSingleNode("synonym").InnerText;

            NewNumber(nodeList.Count);
            random = randomList.Last();
            textBox7.Text = nodeList[random].SelectSingleNode("word").InnerText;
            textBox8.Text = nodeList[random].SelectSingleNode("synonym").InnerText;

            NewNumber(nodeList.Count);
            random = randomList.Last();
            textBox9.Text = nodeList[random].SelectSingleNode("word").InnerText;
            textBox10.Text = nodeList[random].SelectSingleNode("synonym").InnerText;

            NewNumber(nodeList.Count);
            random = randomList.Last();
            textBox11.Text = nodeList[random].SelectSingleNode("word").InnerText;
            textBox12.Text = nodeList[random].SelectSingleNode("synonym").InnerText;

            NewNumber(nodeList.Count);
            random = randomList.Last();
            textBox13.Text = nodeList[random].SelectSingleNode("word").InnerText;
            textBox14.Text = nodeList[random].SelectSingleNode("synonym").InnerText;

            NewNumber(nodeList.Count);
            random = randomList.Last();
            textBox15.Text = nodeList[random].SelectSingleNode("word").InnerText;
            textBox16.Text = nodeList[random].SelectSingleNode("synonym").InnerText;

            NewNumber(nodeList.Count);
            random = randomList.Last();
            textBox17.Text = nodeList[random].SelectSingleNode("word").InnerText;
            textBox18.Text = nodeList[random].SelectSingleNode("synonym").InnerText;
            */
        }



        public void GenerateSynonyms(int start) {

            GenSynonym(start, textBox1, textBox2);//1
            GenSynonym(start+1, textBox3, textBox4);//2
            GenSynonym(start +2, textBox5, textBox6);//3
            GenSynonym(start +3 ,textBox7, textBox8);//4
            GenSynonym(start +4, textBox9, textBox10);//5
            GenSynonym(start +5, textBox11, textBox12);//6
            GenSynonym(start +6, textBox13, textBox14);//7
            GenSynonym(start +7, textBox15, textBox16);//8
            GenSynonym(start +8, textBox17, textBox18);//9

        }


        public void GenSynonym(int start, TextBox t1,TextBox t2)
        {
            //NewNumber(nodeList.Count);
            dataGridView1.Rows.Add(CommonFunctions.UppercaseFirst(nodeList[start].SelectSingleNode("word").InnerText), CommonFunctions.UppercaseFirst(nodeList[start].SelectSingleNode("synonym").InnerText));

            //t1.Text = UppercaseFirst(nodeList[start].SelectSingleNode("word").InnerText);
            //t2.Text = UppercaseFirst(nodeList[start].SelectSingleNode("synonym").InnerText);
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

            }else
            {
            }

            btnPrevious.Enabled = true;

            lblPages.Text = "Page " + page + " out of " + lastPage + " l=" + lastNode;


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
            }else
            {

                //lastNode -= 9;

            }
            lblPages.Text = "Page " + page + " out of " + lastPage + " l=" + lastNode;
        }











        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                var senderGrid = (DataGridView)sender;
                /*
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    string json = GET("https://api.datamuse.com/words?rel_syn=" + senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString().Trim() + "&max=5");
                    var words = JsonConvert.DeserializeObject<List<Word>>(json);

                    string w = "";
                    foreach (var s in words)
                    {
                        if (s.word.Trim().ToLower() != senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString().Trim().ToLower()) {
                            w = w  + UppercaseFirst(s.word) + "\n\n";
                        }
                    }

                    MessageBox.Show(w,"Other synonyms for: "+senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                */


                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    CommonFunctions.GenerateMoreInfo(senderGrid, e, "synonyms");

                }
                else if (e.RowIndex >= 0 && e.ColumnIndex>=0)
                {
                   CommonFunctions.Pronounce(senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim().ToLower());
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
