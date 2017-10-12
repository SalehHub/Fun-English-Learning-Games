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
    public partial class HomonymsLesson : Form
    {
        public HomonymsLesson()
        {
            InitializeComponent();
        }

        public Random a = new Random();
        public List<int> randomList = new List<int>();

        public wordsLevel wordLevelsForm;
        public mainLevels mainLevelsForm;

        XmlDocument xmlDoc = new XmlDocument();
        XmlNodeList nodeList;

        CommonFunctions CommonFunctions = new CommonFunctions();



        public int page = 0;

        public int lastPage = 0;
        public int nextNode = 0;


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
            homonyms homonyms = new homonyms();
            homonyms.mainLevelsForm = this.mainLevelsForm;
            homonyms.wordLevelsForm = this.wordLevelsForm;
            this.Hide();
            homonyms.Show();
        }

        private void HomonymsLesson_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.wordLevelsForm.Show();
            }
            catch (Exception ex)
            {

            }
        }


        public void GenerateHomonym(Label l1,Label l2,TextBox t,int node)
        {
            dataGridView1.Rows.Add(
                CommonFunctions.UppercaseFirst(nodeList[node].SelectSingleNode("def1").InnerText.Trim()), 
                nodeList[node].SelectSingleNode("answer").InnerText.Trim(),
                CommonFunctions.UppercaseFirst(nodeList[node].SelectSingleNode("def2").InnerText.Trim())
                );
        }


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

                /*
                string def1 = "", def2 = "", ans = "";
                //foreach (XmlNode node in nodeList)

                NewNumber(nodeList.Count);
                int random = randomList.Last();
                lbl1.Text = nodeList[random].SelectSingleNode("def1").InnerText;
                lbl2.Text = nodeList[random].SelectSingleNode("def2").InnerText;
                textBox1.Text = nodeList[random].SelectSingleNode("answer").InnerText;


                NewNumber(nodeList.Count);
                random = randomList.Last();
                lbl3.Text = nodeList[random].SelectSingleNode("def1").InnerText;
                lbl4.Text = nodeList[random].SelectSingleNode("def2").InnerText;
                textBox2.Text = nodeList[random].SelectSingleNode("answer").InnerText;


                NewNumber(nodeList.Count);
                random = randomList.Last();
                lbl5.Text = nodeList[random].SelectSingleNode("def1").InnerText;
                lbl6.Text = nodeList[random].SelectSingleNode("def2").InnerText;
                textBox3.Text = nodeList[random].SelectSingleNode("answer").InnerText;


                NewNumber(nodeList.Count);
                random = randomList.Last();
                lbl7.Text = nodeList[random].SelectSingleNode("def1").InnerText;
                lbl8.Text = nodeList[random].SelectSingleNode("def2").InnerText;
                textBox4.Text = nodeList[random].SelectSingleNode("answer").InnerText;


                NewNumber(nodeList.Count);
                random = randomList.Last();
                lbl9.Text = nodeList[random].SelectSingleNode("def1").InnerText;
                lbl10.Text = nodeList[random].SelectSingleNode("def2").InnerText;
                textBox5.Text = nodeList[random].SelectSingleNode("answer").InnerText;


                NewNumber(nodeList.Count);
                random = randomList.Last();
                lbl11.Text = nodeList[random].SelectSingleNode("def1").InnerText;
                lbl12.Text = nodeList[random].SelectSingleNode("def2").InnerText;
                textBox6.Text = nodeList[random].SelectSingleNode("answer").InnerText;


                NewNumber(nodeList.Count);
                random = randomList.Last();
                lbl13.Text = nodeList[random].SelectSingleNode("def1").InnerText;
                lbl14.Text = nodeList[random].SelectSingleNode("def2").InnerText;
                textBox7.Text = nodeList[random].SelectSingleNode("answer").InnerText;


                NewNumber(nodeList.Count);
                random = randomList.Last();
                lbl15.Text = nodeList[random].SelectSingleNode("def1").InnerText;
                lbl16.Text = nodeList[random].SelectSingleNode("def2").InnerText;
                textBox8.Text = nodeList[random].SelectSingleNode("answer").InnerText;


                NewNumber(nodeList.Count);
                random = randomList.Last();
                lbl17.Text = nodeList[random].SelectSingleNode("def1").InnerText;
                lbl18.Text = nodeList[random].SelectSingleNode("def2").InnerText;
                textBox9.Text = nodeList[random].SelectSingleNode("answer").InnerText;

                 */

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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
