/*
 * Project Name:    Fun English learning Games
 * File Name:       SpellingLessons.cs
 * Coded By:        Saleh Alzahrani & Sarah Aljabri
 * Coded On:        Fall 2017
 * About this File: This file display and organize all spelling lesson questions, images, pagination and pronunciation 
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace FunEngGames
{
    public partial class spellingLesson : Form
    {
        public spellingLesson()
        {
            InitializeComponent();
        }

        //CommonFunctions object
        CommonFunctions CommonFunctions = new CommonFunctions();

        //Random integer variable
        public Random a = new Random();

        //Variables wordLevelsForm and mainLevelsForm to store previous forms status        
        public wordsLevel wordLevelsForm;
        public mainLevels mainLevelsForm;

        //Storing the xml content
        public XmlDocument xmlDoc = new XmlDocument();
        public XmlNodeList nodeList;

        //setup lesson pages variables
        public int page = 0;
        public int lastPage = 0;
        public int nextNode = 0;


       //Start spelling level
        private void button1_Click(object sender, EventArgs e)
        {
            Spelling Spelling = new Spelling();
            Spelling.wordLevelsForm = this.wordLevelsForm;
            Spelling.mainLevelsForm = this.mainLevelsForm;
            Spelling.Show();

            this.Hide();
        }


        //This function get all components by specific type. I use it to set audio cursor to all pictures
        public IEnumerable<Control> GetSelfAndChildrenRecursive(Control parent)
        {
            List<Control> controls = new List<Control>();

            foreach (Control child in parent.Controls)
            {
                controls.AddRange(GetSelfAndChildrenRecursive(child));
            }

            controls.Add(parent);

            return controls;
        }


        //Spelling lesson load event load all spelling questions from XML file
        private void spellingLesson_Load(object sender, EventArgs e)
        {
            try
            {
                //panel1.Parent = this;
                xmlDoc.Load("XML/spelling.xml");

                nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/animals/spelling");
                page = 0;
                nextNode = 0;
                btnPrevious.Enabled = false;

                GenerateWords(0);
                page++;
                lastPage = nodeList.Count / 6;
                if (lastPage == 0) { lastPage = 1; }
                lblPages.Text = "Page " + page + " out of " + lastPage;

                if (lastPage > 1)
                {
                    btnNext.Enabled = true;
                }
                else
                {
                    btnNext.Enabled = false;
                }

                //Change the cursor for each picture to an audio icon
                Cursor cur = new Cursor(Properties.Resources.audio.Handle);
                GetSelfAndChildrenRecursive(this).OfType<PictureBox>().ToList().ForEach(b => b.Cursor = cur);
                GetSelfAndChildrenRecursive(this).OfType<PictureBox>().ToList().ForEach(b => b.Click += Picture_Click);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Form closed event function: show the words level form
        private void spellingLesson_FormClosed(object sender, FormClosedEventArgs e)
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


        //Generate word, picture and answer from spelling XML file
        public void GenerateWord(PictureBox p, TextBox t, int next)
        {
            if (nodeList[next] != null && nodeList[next].SelectSingleNode("answer").InnerText.Trim() != "")
            {
                // p.Visible = false;
                //animator1.BeginUpdate(p, false);
                p.Image = Image.FromFile(@"Images\" + nodeList[next].SelectSingleNode("answer").InnerText.Trim()+".png");
                t.Text = CommonFunctions.UppercaseFirst(nodeList[next].SelectSingleNode("answer").InnerText);
                p.Tag = nodeList[next].SelectSingleNode("answer").InnerText; // for pronounce
                //animator1.EndUpdateSync(p);
                // p.Click -= new System.EventHandler(this.picAns1_Click);
                //p.Visible = true;
            }
            else
            {
                p.Image = null;
                t.Text = "";
                p.Tag = "";
            }
        }


        //Generate all questions by calling GenerateWord function;
        public void GenerateWords(int next)
        {


            GenerateWord(picAns1, textBox1, next);
            next++;
            GenerateWord(pictureBox1, textBox2, next);
            next++;
            GenerateWord(pictureBox2, textBox3, next);
            next++;
            GenerateWord(pictureBox3, textBox4, next);
            next++;
            GenerateWord(pictureBox4, textBox5, next);
            next++;
            GenerateWord(pictureBox5, textBox6, next);
            next++;
        }


        //Next page event if we have more than on page
        private void btnNext_Click(object sender, EventArgs e)
        {
            page++;
            nextNode += 6;
            GenerateWords(nextNode);

            if (page == lastPage) {
                btnNext.Enabled = false;
            }

            btnPrevious.Enabled = true;

            lblPages.Text = "Page " + page + " out of " + lastPage;
        }


        //Previous page event if we have more than on page and next page btn has been clicked
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            page--;
            nextNode -= 6;
            GenerateWords(nextNode);

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


        //pronounce the word after clicking on the picture
        private void Picture_Click(object sender, EventArgs e)
        {
            var pic = (PictureBox)sender;
            CommonFunctions.Pronounce(pic.Tag.ToString());

            //CommonFunctions.GenerateMoreInfo(pic.Tag.ToString(),"");
        }


        //Load specific category when clicking on any category button
        public void loadCategory(string XMLTag)
        {
            try
            {
               // animator1.AnimationType = AnimatorNS.AnimationType.Scale;
                //animator1.BeginUpdate(panel1, false);

                nodeList = xmlDoc.DocumentElement.SelectNodes("/Questions/" + XMLTag + "/spelling");
                page = 0;
                nextNode = 0;
                btnPrevious.Enabled = false;
                

                GenerateWords(0);                

                page++;
                lastPage = nodeList.Count / 6;


                lblWordsCount.Text = nodeList.Count+" words";


                if (lastPage == 0) { lastPage = 1; }
                lblPages.Text = "Page " + page + " out of " + lastPage;

                if (lastPage > 1)
                {
                    btnNext.Enabled = true;
                }
                else
                {
                    btnNext.Enabled = false;
                }

                //Change the cursor for each picture to an audio icon
                Cursor cur = new Cursor(Properties.Resources.audio.Handle);
                GetSelfAndChildrenRecursive(this).OfType<PictureBox>().ToList().ForEach(b => b.Cursor = cur);

                //animator1.EndUpdateSync(panel1);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Change category event for all caegory buttons
        private void ChangeCategory_Click(object sender, EventArgs e)
        {
            var RB = (RadioButton)sender;
            if (RB.Checked == true)
            {
                loadCategory(RB.Text.ToLower().Trim().Replace(" ", ""));
                //CommonFunctions.Pronounce(RB.Text.ToLower().Trim().Replace(" ","_"));
            }
        }
    }
}
