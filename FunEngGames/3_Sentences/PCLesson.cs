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

        

       
    }
}
