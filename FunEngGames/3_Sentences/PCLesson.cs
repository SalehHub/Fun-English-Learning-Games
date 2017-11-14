/*
 * Project Name:    Fun English learning Games 
 * File Name:       PCLesson.cs
 * Coded By:        Adriana Escobar
 * Coded On:        Fall 2017
 * About this File: This file handles the paragraph coherence lesson and launches the game
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunEngGames._3_Sentences
{
    public partial class PCLesson : Form
    {
        public PCLesson()
        {
            InitializeComponent();
        }


        CommonFunctions CommonFunctions = new CommonFunctions();
        public sentenceLevels sentenceLevelsForm;
        public mainLevels mainLevelsForm;

        public int page = 0;
        public int lastPage = 3;

        private void PCLesson_Load(object sender, EventArgs e)
        {
            this.FormClosing += this.PCLesson_FormClosing;
        }

        private void PCLesson_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.sentenceLevelsForm.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PC PC = new PC();
            PC.sentenceLevelsForm = this.sentenceLevelsForm;
            PC.mainLevelsForm = this.mainLevelsForm;
            this.Hide();
            PC.Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            page++;
            if (page == 1)
            {
                pictureBox1.Image = FunEngGames.Properties.Resources.ExpressSequence;
                label2.Text = "To Express Sequence";
                pictureBox2.Image = FunEngGames.Properties.Resources.expressResult;
                label3.Text = "To Express Result";
                pictureBox3.Image = FunEngGames.Properties.Resources.addInfo;
                label4.Text = "To Add Information";
                btnNext.Enabled = false;
                btnPrevious.Enabled = true;
            }

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            page--;
            if (page == 1)
            {
                pictureBox1.Image = FunEngGames.Properties.Resources.ExpressSequence;
                label2.Text = "To Express Sequence";
                pictureBox2.Image = FunEngGames.Properties.Resources.expressResult;
                label3.Text = "To Express Result";
                pictureBox3.Image = FunEngGames.Properties.Resources.addInfo;
                label4.Text = "To Add Information";
                btnNext.Enabled = false;
                btnPrevious.Enabled = true;
            }
            else if (page == 0)
            {
                pictureBox1.Image = FunEngGames.Properties.Resources.showContr;
                label2.Text = "To Show Contrast";
                pictureBox2.Image = FunEngGames.Properties.Resources.showSimi;
                label3.Text = "To Show Similarity";
                pictureBox3.Image = FunEngGames.Properties.Resources.clarify;
                label4.Text = "To Clarify/Explain";
                btnNext.Enabled = true;
                btnPrevious.Enabled = false;
            }
        }
    }
}
