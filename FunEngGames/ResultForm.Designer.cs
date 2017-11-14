namespace FunEngGames
{
    partial class ResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPhrasesTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblWordsResults = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblPhrasesResults = new System.Windows.Forms.Label();
            this.btnCheckAnswer = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblSentencesResults = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pbSpelling = new System.Windows.Forms.ProgressBar();
            this.lblPrecent = new System.Windows.Forms.Label();
            this.lblPrasesPrecent = new System.Windows.Forms.Label();
            this.pbPhrases = new System.Windows.Forms.ProgressBar();
            this.lblSentencesPrecent = new System.Windows.Forms.Label();
            this.pbSentences = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::FunEngGames.Properties.Resources.resultMainTitle;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Location = new System.Drawing.Point(43, 25);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1296, 103);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Impact", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(352, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(677, 60);
            this.label1.TabIndex = 6;
            this.label1.Text = "Your Results";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::FunEngGames.Properties.Resources.resultTitle2;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lblPhrasesTitle);
            this.panel1.Location = new System.Drawing.Point(461, 231);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 134);
            this.panel1.TabIndex = 15;
            // 
            // lblPhrasesTitle
            // 
            this.lblPhrasesTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPhrasesTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPhrasesTitle.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhrasesTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lblPhrasesTitle.Location = new System.Drawing.Point(52, 46);
            this.lblPhrasesTitle.Name = "lblPhrasesTitle";
            this.lblPhrasesTitle.Size = new System.Drawing.Size(252, 46);
            this.lblPhrasesTitle.TabIndex = 9;
            this.lblPhrasesTitle.Text = "Phrases";
            this.lblPhrasesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(52, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 46);
            this.label2.TabIndex = 9;
            this.label2.Text = "Words";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::FunEngGames.Properties.Resources.resultTitle2;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 231);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(356, 134);
            this.panel2.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BackgroundImage = global::FunEngGames.Properties.Resources.resultPanel;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.lblWordsResults);
            this.panel4.Location = new System.Drawing.Point(12, 372);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(440, 207);
            this.panel4.TabIndex = 17;
            // 
            // lblWordsResults
            // 
            this.lblWordsResults.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblWordsResults.BackColor = System.Drawing.Color.Transparent;
            this.lblWordsResults.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWordsResults.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblWordsResults.Location = new System.Drawing.Point(24, 30);
            this.lblWordsResults.Name = "lblWordsResults";
            this.lblWordsResults.Size = new System.Drawing.Size(307, 155);
            this.lblWordsResults.TabIndex = 9;
            this.lblWordsResults.Text = "Level:0\r\nLevel:0\r\nLevel:0\r\nLevel:0";
            this.lblWordsResults.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BackgroundImage = global::FunEngGames.Properties.Resources.resultPanel;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Controls.Add(this.lblPhrasesResults);
            this.panel5.Location = new System.Drawing.Point(461, 372);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(440, 207);
            this.panel5.TabIndex = 18;
            // 
            // lblPhrasesResults
            // 
            this.lblPhrasesResults.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPhrasesResults.BackColor = System.Drawing.Color.Transparent;
            this.lblPhrasesResults.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhrasesResults.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblPhrasesResults.Location = new System.Drawing.Point(24, 30);
            this.lblPhrasesResults.Name = "lblPhrasesResults";
            this.lblPhrasesResults.Size = new System.Drawing.Size(280, 155);
            this.lblPhrasesResults.TabIndex = 9;
            this.lblPhrasesResults.Text = "Parts of speech:30 out of 30";
            this.lblPhrasesResults.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCheckAnswer
            // 
            this.btnCheckAnswer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCheckAnswer.BackColor = System.Drawing.Color.DarkOrange;
            this.btnCheckAnswer.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckAnswer.ForeColor = System.Drawing.Color.Green;
            this.btnCheckAnswer.Location = new System.Drawing.Point(564, 635);
            this.btnCheckAnswer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCheckAnswer.Name = "btnCheckAnswer";
            this.btnCheckAnswer.Size = new System.Drawing.Size(253, 71);
            this.btnCheckAnswer.TabIndex = 29;
            this.btnCheckAnswer.Text = "Play again";
            this.btnCheckAnswer.UseVisualStyleBackColor = false;
            this.btnCheckAnswer.Click += new System.EventHandler(this.btnCheckAnswer_Click);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BackgroundImage = global::FunEngGames.Properties.Resources.resultPanel;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Controls.Add(this.lblSentencesResults);
            this.panel6.Location = new System.Drawing.Point(908, 372);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(440, 207);
            this.panel6.TabIndex = 33;
            // 
            // lblSentencesResults
            // 
            this.lblSentencesResults.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSentencesResults.BackColor = System.Drawing.Color.Transparent;
            this.lblSentencesResults.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSentencesResults.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblSentencesResults.Location = new System.Drawing.Point(24, 30);
            this.lblSentencesResults.Name = "lblSentencesResults";
            this.lblSentencesResults.Size = new System.Drawing.Size(313, 155);
            this.lblSentencesResults.TabIndex = 9;
            this.lblSentencesResults.Text = "Level:0\r\nLevel:0\r\nLevel:0\r\nLevel:0";
            this.lblSentencesResults.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::FunEngGames.Properties.Resources.resultTitle2;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(908, 231);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(356, 134);
            this.panel3.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(52, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 46);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sentences";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbSpelling
            // 
            this.pbSpelling.Location = new System.Drawing.Point(27, 604);
            this.pbSpelling.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbSpelling.Name = "pbSpelling";
            this.pbSpelling.Size = new System.Drawing.Size(316, 23);
            this.pbSpelling.TabIndex = 34;
            // 
            // lblPrecent
            // 
            this.lblPrecent.AutoSize = true;
            this.lblPrecent.BackColor = System.Drawing.Color.Transparent;
            this.lblPrecent.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecent.Location = new System.Drawing.Point(24, 583);
            this.lblPrecent.Name = "lblPrecent";
            this.lblPrecent.Size = new System.Drawing.Size(104, 17);
            this.lblPrecent.TabIndex = 35;
            this.lblPrecent.Text = "You completed";
            // 
            // lblPrasesPrecent
            // 
            this.lblPrasesPrecent.AutoSize = true;
            this.lblPrasesPrecent.BackColor = System.Drawing.Color.Transparent;
            this.lblPrasesPrecent.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrasesPrecent.Location = new System.Drawing.Point(467, 583);
            this.lblPrasesPrecent.Name = "lblPrasesPrecent";
            this.lblPrasesPrecent.Size = new System.Drawing.Size(104, 17);
            this.lblPrasesPrecent.TabIndex = 37;
            this.lblPrasesPrecent.Text = "You completed";
            // 
            // pbPhrases
            // 
            this.pbPhrases.Location = new System.Drawing.Point(469, 604);
            this.pbPhrases.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbPhrases.Name = "pbPhrases";
            this.pbPhrases.Size = new System.Drawing.Size(316, 23);
            this.pbPhrases.TabIndex = 36;
            // 
            // lblSentencesPrecent
            // 
            this.lblSentencesPrecent.AutoSize = true;
            this.lblSentencesPrecent.BackColor = System.Drawing.Color.Transparent;
            this.lblSentencesPrecent.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSentencesPrecent.Location = new System.Drawing.Point(913, 583);
            this.lblSentencesPrecent.Name = "lblSentencesPrecent";
            this.lblSentencesPrecent.Size = new System.Drawing.Size(104, 17);
            this.lblSentencesPrecent.TabIndex = 39;
            this.lblSentencesPrecent.Text = "You completed";
            // 
            // pbSentences
            // 
            this.pbSentences.Location = new System.Drawing.Point(916, 604);
            this.pbSentences.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbSentences.Name = "pbSentences";
            this.pbSentences.Size = new System.Drawing.Size(316, 23);
            this.pbSentences.TabIndex = 38;
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FunEngGames.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1381, 716);
            this.Controls.Add(this.lblSentencesPrecent);
            this.Controls.Add(this.pbSentences);
            this.Controls.Add(this.lblPrasesPrecent);
            this.Controls.Add(this.pbPhrases);
            this.Controls.Add(this.lblPrecent);
            this.Controls.Add(this.pbSpelling);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnCheckAnswer);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ResultForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fun English Learning Games: Your results";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ResultForm_FormClosed);
            this.Load += new System.EventHandler(this.Result_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblPhrasesTitle;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Label lblWordsResults;
        private System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Label lblPhrasesResults;
        private System.Windows.Forms.Button btnCheckAnswer;
        private System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.Label lblSentencesResults;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar pbSpelling;
        private System.Windows.Forms.Label lblPrecent;
        private System.Windows.Forms.Label lblPrasesPrecent;
        private System.Windows.Forms.ProgressBar pbPhrases;
        private System.Windows.Forms.Label lblSentencesPrecent;
        private System.Windows.Forms.ProgressBar pbSentences;
    }
}