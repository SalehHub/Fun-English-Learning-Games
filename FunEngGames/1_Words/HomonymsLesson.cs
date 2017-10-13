/*
 * Project Name:    Fun English learning Games
 * File Name:       HomonymsLesson.cs
 * Coded By:        Saleh Alzahrani & Sarah Aljabri
 * Coded On:        Fall 2017
 * About this File: This file handles all of Homonyms lesson logic, generate words with definitions and pronunciations
 */

using System;
using System.Windows.Forms;
using System.Xml;

namespace FunEngGames
{
    public partial class HomonymsLesson : Form
    {
        public HomonymsLesson()
        {
            InitializeComponent();
        }

        //Variables wordLevelsForm and mainLevelsForm to store previous forms status        
        public wordsLevel wordLevelsForm;
        public mainLevels mainLevelsForm;

        //Storing XML content
        XmlDocument xmlDoc = new XmlDocument();
        XmlNodeList nodeList;

        //CommonFunctions object
        CommonFunctions CommonFunctions = new CommonFunctions();


        //Setup lesson pages variables
        public int page = 0;
        public int lastPage = 0;
        public int nextNode = 0;

        //Start Homonyms level
        private void button1_Click(object sender, EventArgs e)
        {
            homonyms homonyms = new homonyms();
            homonyms.mainLevelsForm = this.mainLevelsForm;
            homonyms.wordLevelsForm = this.wordLevelsForm;
            this.Hide();
            homonyms.Show();
        }

        //Form closed event function: show the words level form
        private void HomonymsLesson_FormClosed(object sender, FormClosedEventArgs e)
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

        //Generate word, synonym from Homonym XML file
        public void GenerateHomonym(Label l1,Label l2,TextBox t,int node)
        {
            dataGridView1.Rows.Add(
                CommonFunctions.UppercaseFirst(nodeList[node].SelectSingleNode("def1").InnerText.Trim()), 
                nodeList[node].SelectSingleNode("answer").InnerText.Trim(),
                CommonFunctions.UppercaseFirst(nodeList[node].SelectSingleNode("def2").InnerText.Trim())
                );
        }

        //Generate all questions by calling GenerateHomonym function;
        public void GenerateHomonyms(int nextNode)
        {
            GenerateHomonym(lbl1, lbl2, textBox1, nextNode);
            nextNode++;
            GenerateHomonym(lbl3, lbl4, textBox2, nextNode);
            nextNode++;
            GenerateHomonym(lbl5, lbl6, textBox3, nextNode);
            nextNode++;
            GenerateHomonym(lbl7, lbl8, textBox4, nextNode);
            nextNode++;
            GenerateHomonym(lbl9, lbl10, textBox5, nextNode);
            nextNode++;
            GenerateHomonym(lbl11, lbl12, textBox6, nextNode);
            nextNode++;
            GenerateHomonym(lbl13, lbl14, textBox7, nextNode);
            nextNode++;
            GenerateHomonym(lbl15, lbl16, textBox8, nextNode);
            nextNode++;
            GenerateHomonym(lbl17, lbl18, textBox9, nextNode);
            nextNode++;

        }

        //Form closed event function: show the words level form
        private void HomonymsLesson_Load(object sender, EventArgs e)
        {
            try
            {
                xmlDoc.Load("XML/homonyms.xml");
                nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/homonyms");


                dataGridView1.Rows.Clear();
                GenerateHomonyms(0);
                page++;
                lastPage = nodeList.Count / 9;
                lblPages.Text = "Page " + page + " out of " + lastPage;

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        //Next page event if we have more than on page
        private void btnNext_Click(object sender, EventArgs e)
        {
            page++;
            nextNode += 9;
            dataGridView1.Rows.Clear();
            GenerateHomonyms(nextNode);

            if (page == lastPage)
            {

                btnNext.Enabled = false;

            }

            btnPrevious.Enabled = true;

            lblPages.Text = "Page " + page + " out of " + lastPage;


        }

        //Previous page event if we have more than on page and next page btn has been clicked
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            page--;
            nextNode -= 9;
            dataGridView1.Rows.Clear();
            GenerateHomonyms(nextNode);

            if (page < lastPage)
            {

                btnNext.Enabled = true;

            }

            if (page == 1)
            {
                btnPrevious.Enabled = false;
            }
            lblPages.Text = "Page " + page + " out of " + lastPage;
        }

        //Pronounce the word after clicking data grid cell
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                CommonFunctions.GenerateMoreInfo(senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString(), "antonyms");
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                CommonFunctions.Pronounce(senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim().ToLower());


            }

        }

    }
}
