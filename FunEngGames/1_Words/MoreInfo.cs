/*
 * Project Name:    Fun English learning Games
 * File Name:       MoreInfo.cs
 * Coded By:        Saleh Alzahrani
 * Coded On:        Fall 2017
 * About this File: This file handles More info button in synonyms and antonyms lessons forms
 */

using System;
using System.Windows.Forms;

namespace FunEngGames
{
    public partial class MoreInfo : Form
    {
        public MoreInfo()
        {
            InitializeComponent();
        }


        //Close button just to exit this form
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Open source label url in a browser
        private void lblSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(lblSource.Text);
        }

        private void MoreInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
