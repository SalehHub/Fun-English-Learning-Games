/*
 * Project Name:    Fun English learning Games
 * File Name:       SynonymsLesson.cs
 * Coded By:        Saleh Alzahrani  & Sarah Aljabri
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
            S_A.Show();
            this.Hide();

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
                System.Console.WriteLine(ex.Message);
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

            lblWordsCount.Text = nodeList.Count + " words";
            CommonFunctions.SortDataGridColumn(dataGridView1);

            Cursor cur = new Cursor(Properties.Resources.audio.Handle);
        }

        //Generate all questions by calling GenSynonym function;
        public void GenerateSynonyms(int start)
        {
            GenSynonym(start);
            GenSynonym(start + 1);
            GenSynonym(start + 2);
            GenSynonym(start + 3);
            GenSynonym(start + 4);
            GenSynonym(start + 5);
            GenSynonym(start + 6);
            GenSynonym(start + 7);
            GenSynonym(start + 8);
        }

        //Generate word, synonym from Synonym XML file
        public void GenSynonym(int start)
        {
            dataGridView1.Rows.Add(
                nodeList[start].SelectSingleNode("word").InnerText.Trim().ToLower(),
                nodeList[start].SelectSingleNode("synonym").InnerText.Trim().ToLower()
            );
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
