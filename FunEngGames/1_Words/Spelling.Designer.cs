namespace FunEngGames
{
    partial class Spelling
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
            this.components = new System.ComponentModel.Container();
            this.picWord = new System.Windows.Forms.PictureBox();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAttempts = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.btnFirstHint = new System.Windows.Forms.Button();
            this.btnSecondHint = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.btnCheckAnswer = new System.Windows.Forms.Button();
            this.lblCorrectAns = new System.Windows.Forms.Label();
            this.lblFeedback = new System.Windows.Forms.Label();
            this.picLock = new System.Windows.Forms.PictureBox();
            this.lblFirstHint = new System.Windows.Forms.Label();
            this.lblSecondHint = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.picFeedback = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picWord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFeedback)).BeginInit();
            this.SuspendLayout();
            // 
            // picWord
            // 
            this.picWord.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picWord.BackColor = System.Drawing.Color.Transparent;
            this.picWord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picWord.Location = new System.Drawing.Point(304, 233);
            this.picWord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picWord.Name = "picWord";
            this.picWord.Size = new System.Drawing.Size(555, 230);
            this.picWord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWord.TabIndex = 0;
            this.picWord.TabStop = false;
            this.picWord.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txtAnswer
            // 
            this.txtAnswer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAnswer.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnswer.Location = new System.Drawing.Point(304, 469);
            this.txtAnswer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(555, 34);
            this.txtAnswer.TabIndex = 3;
            this.txtAnswer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAnswer.Enter += new System.EventHandler(this.txtAnswer_Enter);
            this.txtAnswer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAnswer_KeyDown);
            this.txtAnswer.Leave += new System.EventHandler(this.txtAnswer_Leave);
            // 
            // lblAnswer
            // 
            this.lblAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.BackColor = System.Drawing.Color.Transparent;
            this.lblAnswer.Location = new System.Drawing.Point(961, 598);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(148, 17);
            this.lblAnswer.TabIndex = 6;
            this.lblAnswer.Text = "correct answer hidden";
            this.lblAnswer.Visible = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = global::FunEngGames.Properties.Resources.spellingTitle;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(208, -11);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(747, 126);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 13;
            this.pictureBox4.TabStop = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Impact", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(80, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1001, 48);
            this.label4.TabIndex = 14;
            this.label4.Text = "Type the name of object shown in each picture";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAttempts
            // 
            this.lblAttempts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAttempts.BackColor = System.Drawing.Color.Transparent;
            this.lblAttempts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAttempts.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttempts.ForeColor = System.Drawing.Color.Black;
            this.lblAttempts.Location = new System.Drawing.Point(1045, 295);
            this.lblAttempts.Name = "lblAttempts";
            this.lblAttempts.Size = new System.Drawing.Size(36, 36);
            this.lblAttempts.TabIndex = 18;
            this.lblAttempts.Text = "3";
            this.lblAttempts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.ImageLocation = "Images\\\\circle.gif";
            this.pictureBox5.Location = new System.Drawing.Point(973, 233);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(175, 153);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 19;
            this.pictureBox5.TabStop = false;
            // 
            // btnFirstHint
            // 
            this.btnFirstHint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFirstHint.BackColor = System.Drawing.SystemColors.Control;
            this.btnFirstHint.Location = new System.Drawing.Point(304, 511);
            this.btnFirstHint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFirstHint.Name = "btnFirstHint";
            this.btnFirstHint.Size = new System.Drawing.Size(109, 36);
            this.btnFirstHint.TabIndex = 20;
            this.btnFirstHint.Text = "First hint";
            this.btnFirstHint.UseVisualStyleBackColor = true;
            this.btnFirstHint.Click += new System.EventHandler(this.btnFirstHint_Click);
            // 
            // btnSecondHint
            // 
            this.btnSecondHint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSecondHint.Enabled = false;
            this.btnSecondHint.Location = new System.Drawing.Point(304, 550);
            this.btnSecondHint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSecondHint.Name = "btnSecondHint";
            this.btnSecondHint.Size = new System.Drawing.Size(109, 36);
            this.btnSecondHint.TabIndex = 21;
            this.btnSecondHint.Text = "Second hint";
            this.btnSecondHint.UseVisualStyleBackColor = true;
            this.btnSecondHint.Click += new System.EventHandler(this.btnSecondHint_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(304, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(555, 29);
            this.label5.TabIndex = 23;
            this.label5.Text = "Question 1 out of 5";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(973, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 29);
            this.label6.TabIndex = 24;
            this.label6.Text = "Attempts left";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(175, 29);
            this.label7.TabIndex = 27;
            this.label7.Text = "Points";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPoints
            // 
            this.lblPoints.BackColor = System.Drawing.Color.Transparent;
            this.lblPoints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPoints.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.ForeColor = System.Drawing.Color.Black;
            this.lblPoints.Location = new System.Drawing.Point(71, 286);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(59, 49);
            this.lblPoints.TabIndex = 25;
            this.lblPoints.Text = "0";
            this.lblPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox7.ImageLocation = "Images\\\\circle.gif";
            this.pictureBox7.Location = new System.Drawing.Point(12, 233);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(175, 153);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 26;
            this.pictureBox7.TabStop = false;
            // 
            // btnCheckAnswer
            // 
            this.btnCheckAnswer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCheckAnswer.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCheckAnswer.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckAnswer.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCheckAnswer.Location = new System.Drawing.Point(425, 670);
            this.btnCheckAnswer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCheckAnswer.Name = "btnCheckAnswer";
            this.btnCheckAnswer.Size = new System.Drawing.Size(312, 59);
            this.btnCheckAnswer.TabIndex = 28;
            this.btnCheckAnswer.Text = "Check your answer";
            this.btnCheckAnswer.UseVisualStyleBackColor = false;
            this.btnCheckAnswer.Click += new System.EventHandler(this.btnCheckAnswer_Click);
            // 
            // lblCorrectAns
            // 
            this.lblCorrectAns.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCorrectAns.BackColor = System.Drawing.Color.Transparent;
            this.lblCorrectAns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCorrectAns.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorrectAns.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblCorrectAns.Location = new System.Drawing.Point(304, 590);
            this.lblCorrectAns.Name = "lblCorrectAns";
            this.lblCorrectAns.Size = new System.Drawing.Size(555, 29);
            this.lblCorrectAns.TabIndex = 29;
            this.lblCorrectAns.Text = "Correct answer is ";
            this.lblCorrectAns.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCorrectAns.Visible = false;
            // 
            // lblFeedback
            // 
            this.lblFeedback.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblFeedback.BackColor = System.Drawing.Color.Transparent;
            this.lblFeedback.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeedback.ForeColor = System.Drawing.Color.Green;
            this.lblFeedback.Location = new System.Drawing.Point(4, 639);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(1154, 30);
            this.lblFeedback.TabIndex = 30;
            this.lblFeedback.Text = "Good job! Keep up the good work";
            this.lblFeedback.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFeedback.Visible = false;
            // 
            // picLock
            // 
            this.picLock.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picLock.BackColor = System.Drawing.Color.Transparent;
            this.picLock.BackgroundImage = global::FunEngGames.Properties.Resources._lock;
            this.picLock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picLock.Location = new System.Drawing.Point(256, 550);
            this.picLock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picLock.Name = "picLock";
            this.picLock.Size = new System.Drawing.Size(43, 36);
            this.picLock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLock.TabIndex = 22;
            this.picLock.TabStop = false;
            // 
            // lblFirstHint
            // 
            this.lblFirstHint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFirstHint.BackColor = System.Drawing.Color.Transparent;
            this.lblFirstHint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFirstHint.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstHint.ForeColor = System.Drawing.Color.Brown;
            this.lblFirstHint.Location = new System.Drawing.Point(304, 511);
            this.lblFirstHint.Name = "lblFirstHint";
            this.lblFirstHint.Size = new System.Drawing.Size(555, 36);
            this.lblFirstHint.TabIndex = 31;
            this.lblFirstHint.Text = "First hint:";
            this.lblFirstHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFirstHint.Visible = false;
            // 
            // lblSecondHint
            // 
            this.lblSecondHint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSecondHint.BackColor = System.Drawing.Color.Transparent;
            this.lblSecondHint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSecondHint.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecondHint.ForeColor = System.Drawing.Color.Brown;
            this.lblSecondHint.Location = new System.Drawing.Point(304, 550);
            this.lblSecondHint.Name = "lblSecondHint";
            this.lblSecondHint.Size = new System.Drawing.Size(555, 36);
            this.lblSecondHint.TabIndex = 32;
            this.lblSecondHint.Text = "First hint:";
            this.lblSecondHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSecondHint.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // picFeedback
            // 
            this.picFeedback.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.picFeedback.BackColor = System.Drawing.Color.Transparent;
            this.picFeedback.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picFeedback.Location = new System.Drawing.Point(236, 459);
            this.picFeedback.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picFeedback.Name = "picFeedback";
            this.picFeedback.Size = new System.Drawing.Size(63, 53);
            this.picFeedback.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFeedback.TabIndex = 9;
            this.picFeedback.TabStop = false;
            this.picFeedback.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(9, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1139, 29);
            this.label1.TabIndex = 33;
            this.label1.Text = "You need to answer at least three questions to pass this level.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(219, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(725, 29);
            this.label2.TabIndex = 34;
            this.label2.Text = "If you answer correctly the first time with no hints you get five points.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Spelling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FunEngGames.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1162, 734);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.lblFeedback);
            this.Controls.Add(this.lblCorrectAns);
            this.Controls.Add(this.btnCheckAnswer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.picLock);
            this.Controls.Add(this.btnSecondHint);
            this.Controls.Add(this.btnFirstHint);
            this.Controls.Add(this.lblAttempts);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.picFeedback);
            this.Controls.Add(this.lblAnswer);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.picWord);
            this.Controls.Add(this.lblFirstHint);
            this.Controls.Add(this.lblSecondHint);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1071, 724);
            this.Name = "Spelling";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fun English Learning Games: Words - Spelling level";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.spelling_FormClosed);
            this.Load += new System.EventHandler(this.spelling_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picWord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFeedback)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picWord;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAttempts;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button btnFirstHint;
        private System.Windows.Forms.Button btnSecondHint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Button btnCheckAnswer;
        private System.Windows.Forms.Label lblCorrectAns;
        private System.Windows.Forms.Label lblFeedback;
        private System.Windows.Forms.PictureBox picLock;
        private System.Windows.Forms.Label lblFirstHint;
        private System.Windows.Forms.Label lblSecondHint;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox picFeedback;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}