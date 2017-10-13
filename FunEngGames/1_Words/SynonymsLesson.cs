/*
 * Project Name:    Fun Englisg learning Games
 * File Name:       SynonymsLesson.cs
 * Coded By:        Saleh Alzahrani
 * Coded On:        Fall 2017
 * About this File: This file handles all of Synonym lesson logic, generate words with synonyms and pronunciations
 */

using System;
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

        //Variables wordLevelsForm and mainLevelsForm to store previous forms status        
        public wordsLevel wordLevelsForm;
        public mainLevels mainLevelsForm;

        //Storing XML content
        XmlDocument xmlDoc = new XmlDocument();
        public XmlNodeList nodeList;

        //CommonFunctions object
        CommonFunctions CommonFunctions = new CommonFunctions();

        //Setup lesson pages variables
        public int page = 0;
        public int lastPage = 0;
        public int lastNode = 0;

        //Start synonym level
        private void button1_Click(object sender, EventArgs e)
        {
            Synonyms S_A = new Synonyms();
            S_A.mainLevelsForm = this.mainLevelsForm;
            S_A.wordLevelsForm = this.wordLevelsForm;
            this.Hide();
            S_A.Show();
        }

        //Form closed event function: show the words level form
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

        //Synonym lesson load event load all spelling questions from XML file
        private void SynonymsLesson_Load(object sender, EventArgs e)
        {

            xmlDoc.Load("XML/synonyms.xml");
            nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/synonyms");

            lastPage = nodeList.Count / 9;


            dataGridView1.Rows.Clear();
            GenerateSynonyms(lastNode);
            page++;
            lblPages.Text = "Page " + page + " out of " + lastPage;

            CommonFunctions.SortDataGridColumn(dataGridView1);

            Cursor cur = new Cursor(Properties.Resources.audio.Handle);
        }

        //Generate all questions by calling GenSynonym function;
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

        //Generate word, synonym from Synonym XML file
        public void GenSynonym(int start, TextBox t1, TextBox t2)
        {
            //NewNumber(nodeList.Count);
            dataGridView1.Rows.Add(CommonFunctions.UppercaseFirst(nodeList[start].SelectSingleNode("word").InnerText), CommonFunctions.UppercaseFirst(nodeList[start].SelectSingleNode("synonym").InnerText));

            //t1.Text = UppercaseFirst(nodeList[start].SelectSingleNode("word").InnerText);
            //t2.Text = UppercaseFirst(nodeList[start].SelectSingleNode("synonym").InnerText);
        }

        //Next page event if we have more than on page
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
            else
            {
            }

            btnPrevious.Enabled = true;

            lblPages.Text = "Page " + page + " out of " + lastPage;


        }

        //Previous page event if we have more than on page and next page btn has been clicked
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
            else
            {

                //lastNode -= 9;

            }
            lblPages.Text = "Page " + page + " out of " + lastPage;
        }


        //Pronounce the word after clicking data grid cell
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
                    CommonFunctions.GenerateMoreInfo(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString(), "synonyms");

                }
                else if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    CommonFunctions.Pronounce(senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim().ToLower());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
