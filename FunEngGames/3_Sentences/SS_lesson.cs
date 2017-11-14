/*
 * Project Name:    Fun English learning Games 
 * File Name:       SS_lesson.cs
 * Coded By:        Adriana Escobar
 * Coded On:        Fall 2017
 * About this File: This file handles the sentence structure lesson and launches the game
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
    public partial class SS_lesson : Form
    {
        public SS_lesson()
        {
            InitializeComponent();
        }

        CommonFunctions CommonFunctions = new CommonFunctions();
        public mainLevels mainLevelsForm;
        public sentenceLevels sentenceLevelsForm;


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

        private void button1_Click(object sender, EventArgs e)
        {
            SS SS = new SS();
            SS.sentenceLevelsForm = this.sentenceLevelsForm;
            SS.mainLevelsForm = this.mainLevelsForm;
            this.Hide();
            SS.Show();
        }
    }
}
