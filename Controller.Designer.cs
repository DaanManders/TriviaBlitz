namespace APPR_TriviaBlitz_22SD_Dman
{
    partial class Controller
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
            this.pnlNavigationDman = new System.Windows.Forms.Panel();
            this.rbtHomeDman = new System.Windows.Forms.RadioButton();
            this.rbtRankingDman = new System.Windows.Forms.RadioButton();
            this.tbcNavigationDman = new System.Windows.Forms.TabControl();
            this.tbpHomeDman = new System.Windows.Forms.TabPage();
            this.btnStartGameDman = new System.Windows.Forms.Button();
            this.btnExitDman = new System.Windows.Forms.Button();
            this.lblDescriptionDman = new System.Windows.Forms.Label();
            this.lblHeaderDman = new System.Windows.Forms.Label();
            this.tbpQuizDman = new System.Windows.Forms.TabPage();
            this.btnAnswerOneDman = new System.Windows.Forms.Button();
            this.btnQuitDman = new System.Windows.Forms.Button();
            this.lblMetaDman = new System.Windows.Forms.Label();
            this.lblQuestionDman = new System.Windows.Forms.Label();
            this.btnAnswerFourDman = new System.Windows.Forms.Button();
            this.btnAnswerThreeDman = new System.Windows.Forms.Button();
            this.btnAnswerTwoDman = new System.Windows.Forms.Button();
            this.pnlStatisticsDman = new System.Windows.Forms.Panel();
            this.lblTimeDman = new System.Windows.Forms.Label();
            this.lblStatisticScoreDman = new System.Windows.Forms.Label();
            this.lblScoreDman = new System.Windows.Forms.Label();
            this.lblStatisticTImeDman = new System.Windows.Forms.Label();
            this.tbpRankingDman = new System.Windows.Forms.TabPage();
            this.btnFiftyFiftyDman = new System.Windows.Forms.Button();
            this.pnlNavigationDman.SuspendLayout();
            this.tbcNavigationDman.SuspendLayout();
            this.tbpHomeDman.SuspendLayout();
            this.tbpQuizDman.SuspendLayout();
            this.pnlStatisticsDman.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNavigationDman
            // 
            this.pnlNavigationDman.BackColor = System.Drawing.Color.Red;
            this.pnlNavigationDman.Controls.Add(this.rbtHomeDman);
            this.pnlNavigationDman.Controls.Add(this.rbtRankingDman);
            this.pnlNavigationDman.Location = new System.Drawing.Point(0, -1);
            this.pnlNavigationDman.Name = "pnlNavigationDman";
            this.pnlNavigationDman.Size = new System.Drawing.Size(802, 63);
            this.pnlNavigationDman.TabIndex = 0;
            // 
            // rbtHomeDman
            // 
            this.rbtHomeDman.AutoSize = true;
            this.rbtHomeDman.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtHomeDman.ForeColor = System.Drawing.Color.White;
            this.rbtHomeDman.Location = new System.Drawing.Point(24, 23);
            this.rbtHomeDman.Name = "rbtHomeDman";
            this.rbtHomeDman.Size = new System.Drawing.Size(66, 21);
            this.rbtHomeDman.TabIndex = 2;
            this.rbtHomeDman.Text = "Home";
            this.rbtHomeDman.UseVisualStyleBackColor = true;
            this.rbtHomeDman.CheckedChanged += new System.EventHandler(this.HandleNavigation);
            // 
            // rbtRankingDman
            // 
            this.rbtRankingDman.AutoSize = true;
            this.rbtRankingDman.Checked = true;
            this.rbtRankingDman.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtRankingDman.ForeColor = System.Drawing.Color.White;
            this.rbtRankingDman.Location = new System.Drawing.Point(705, 23);
            this.rbtRankingDman.Name = "rbtRankingDman";
            this.rbtRankingDman.Size = new System.Drawing.Size(79, 21);
            this.rbtRankingDman.TabIndex = 1;
            this.rbtRankingDman.TabStop = true;
            this.rbtRankingDman.Text = "Ranking";
            this.rbtRankingDman.UseVisualStyleBackColor = true;
            this.rbtRankingDman.CheckedChanged += new System.EventHandler(this.HandleNavigation);
            // 
            // tbcNavigationDman
            // 
            this.tbcNavigationDman.Controls.Add(this.tbpHomeDman);
            this.tbcNavigationDman.Controls.Add(this.tbpQuizDman);
            this.tbcNavigationDman.Controls.Add(this.tbpRankingDman);
            this.tbcNavigationDman.Location = new System.Drawing.Point(-5, 64);
            this.tbcNavigationDman.Name = "tbcNavigationDman";
            this.tbcNavigationDman.SelectedIndex = 0;
            this.tbcNavigationDman.Size = new System.Drawing.Size(813, 418);
            this.tbcNavigationDman.TabIndex = 1;
            // 
            // tbpHomeDman
            // 
            this.tbpHomeDman.Controls.Add(this.btnStartGameDman);
            this.tbpHomeDman.Controls.Add(this.btnExitDman);
            this.tbpHomeDman.Controls.Add(this.lblDescriptionDman);
            this.tbpHomeDman.Controls.Add(this.lblHeaderDman);
            this.tbpHomeDman.Location = new System.Drawing.Point(4, 25);
            this.tbpHomeDman.Name = "tbpHomeDman";
            this.tbpHomeDman.Padding = new System.Windows.Forms.Padding(3);
            this.tbpHomeDman.Size = new System.Drawing.Size(805, 389);
            this.tbpHomeDman.TabIndex = 0;
            this.tbpHomeDman.Text = "Home";
            this.tbpHomeDman.UseVisualStyleBackColor = true;
            // 
            // btnStartGameDman
            // 
            this.btnStartGameDman.BackColor = System.Drawing.Color.Red;
            this.btnStartGameDman.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartGameDman.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGameDman.ForeColor = System.Drawing.Color.White;
            this.btnStartGameDman.Location = new System.Drawing.Point(470, 288);
            this.btnStartGameDman.Name = "btnStartGameDman";
            this.btnStartGameDman.Size = new System.Drawing.Size(294, 61);
            this.btnStartGameDman.TabIndex = 4;
            this.btnStartGameDman.Text = "Start Game";
            this.btnStartGameDman.UseVisualStyleBackColor = false;
            this.btnStartGameDman.Click += new System.EventHandler(this.btnStartGameDman_Click);
            // 
            // btnExitDman
            // 
            this.btnExitDman.BackColor = System.Drawing.Color.DarkRed;
            this.btnExitDman.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitDman.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitDman.ForeColor = System.Drawing.Color.White;
            this.btnExitDman.Location = new System.Drawing.Point(290, 288);
            this.btnExitDman.Name = "btnExitDman";
            this.btnExitDman.Size = new System.Drawing.Size(174, 61);
            this.btnExitDman.TabIndex = 3;
            this.btnExitDman.Text = "Exit";
            this.btnExitDman.UseVisualStyleBackColor = false;
            this.btnExitDman.Click += new System.EventHandler(this.btnExitDman_Click);
            // 
            // lblDescriptionDman
            // 
            this.lblDescriptionDman.AutoSize = true;
            this.lblDescriptionDman.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptionDman.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblDescriptionDman.Location = new System.Drawing.Point(19, 111);
            this.lblDescriptionDman.Name = "lblDescriptionDman";
            this.lblDescriptionDman.Size = new System.Drawing.Size(446, 31);
            this.lblDescriptionDman.TabIndex = 1;
            this.lblDescriptionDman.Text = "Made with a lot of fun by Daan Manders";
            // 
            // lblHeaderDman
            // 
            this.lblHeaderDman.AutoSize = true;
            this.lblHeaderDman.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderDman.Location = new System.Drawing.Point(13, 56);
            this.lblHeaderDman.Name = "lblHeaderDman";
            this.lblHeaderDman.Size = new System.Drawing.Size(526, 62);
            this.lblHeaderDman.TabIndex = 0;
            this.lblHeaderDman.Text = "TriviaBlitz Version 1.01";
            // 
            // tbpQuizDman
            // 
            this.tbpQuizDman.Controls.Add(this.btnFiftyFiftyDman);
            this.tbpQuizDman.Controls.Add(this.btnAnswerOneDman);
            this.tbpQuizDman.Controls.Add(this.btnQuitDman);
            this.tbpQuizDman.Controls.Add(this.lblMetaDman);
            this.tbpQuizDman.Controls.Add(this.lblQuestionDman);
            this.tbpQuizDman.Controls.Add(this.btnAnswerFourDman);
            this.tbpQuizDman.Controls.Add(this.btnAnswerThreeDman);
            this.tbpQuizDman.Controls.Add(this.btnAnswerTwoDman);
            this.tbpQuizDman.Controls.Add(this.pnlStatisticsDman);
            this.tbpQuizDman.Location = new System.Drawing.Point(4, 25);
            this.tbpQuizDman.Name = "tbpQuizDman";
            this.tbpQuizDman.Size = new System.Drawing.Size(805, 389);
            this.tbpQuizDman.TabIndex = 2;
            this.tbpQuizDman.Text = "Quiz";
            this.tbpQuizDman.UseVisualStyleBackColor = true;
            // 
            // btnAnswerOneDman
            // 
            this.btnAnswerOneDman.BackColor = System.Drawing.Color.Red;
            this.btnAnswerOneDman.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnswerOneDman.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnswerOneDman.ForeColor = System.Drawing.Color.White;
            this.btnAnswerOneDman.Location = new System.Drawing.Point(31, 290);
            this.btnAnswerOneDman.Name = "btnAnswerOneDman";
            this.btnAnswerOneDman.Size = new System.Drawing.Size(180, 59);
            this.btnAnswerOneDman.TabIndex = 8;
            this.btnAnswerOneDman.Text = "Answer";
            this.btnAnswerOneDman.UseVisualStyleBackColor = false;
            // 
            // btnQuitDman
            // 
            this.btnQuitDman.BackColor = System.Drawing.Color.Red;
            this.btnQuitDman.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitDman.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitDman.ForeColor = System.Drawing.Color.White;
            this.btnQuitDman.Location = new System.Drawing.Point(729, 52);
            this.btnQuitDman.Name = "btnQuitDman";
            this.btnQuitDman.Size = new System.Drawing.Size(39, 40);
            this.btnQuitDman.TabIndex = 7;
            this.btnQuitDman.Text = "X";
            this.btnQuitDman.UseVisualStyleBackColor = false;
            this.btnQuitDman.Click += new System.EventHandler(this.btnQuitDman_Click);
            // 
            // lblMetaDman
            // 
            this.lblMetaDman.AutoSize = true;
            this.lblMetaDman.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetaDman.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblMetaDman.Location = new System.Drawing.Point(26, 116);
            this.lblMetaDman.Name = "lblMetaDman";
            this.lblMetaDman.Size = new System.Drawing.Size(225, 17);
            this.lblMetaDman.TabIndex = 6;
            this.lblMetaDman.Text = "Netherlands is a Country in Europe";
            // 
            // lblQuestionDman
            // 
            this.lblQuestionDman.AutoSize = true;
            this.lblQuestionDman.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestionDman.Location = new System.Drawing.Point(23, 92);
            this.lblQuestionDman.Name = "lblQuestionDman";
            this.lblQuestionDman.Size = new System.Drawing.Size(313, 25);
            this.lblQuestionDman.TabIndex = 5;
            this.lblQuestionDman.Text = "What is the Capital of Netherlands?";
            // 
            // btnAnswerFourDman
            // 
            this.btnAnswerFourDman.BackColor = System.Drawing.Color.DarkRed;
            this.btnAnswerFourDman.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnswerFourDman.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnswerFourDman.ForeColor = System.Drawing.Color.White;
            this.btnAnswerFourDman.Location = new System.Drawing.Point(589, 290);
            this.btnAnswerFourDman.Name = "btnAnswerFourDman";
            this.btnAnswerFourDman.Size = new System.Drawing.Size(180, 59);
            this.btnAnswerFourDman.TabIndex = 4;
            this.btnAnswerFourDman.Text = "Answer";
            this.btnAnswerFourDman.UseVisualStyleBackColor = false;
            // 
            // btnAnswerThreeDman
            // 
            this.btnAnswerThreeDman.BackColor = System.Drawing.Color.Red;
            this.btnAnswerThreeDman.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnswerThreeDman.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnswerThreeDman.ForeColor = System.Drawing.Color.White;
            this.btnAnswerThreeDman.Location = new System.Drawing.Point(403, 290);
            this.btnAnswerThreeDman.Name = "btnAnswerThreeDman";
            this.btnAnswerThreeDman.Size = new System.Drawing.Size(180, 59);
            this.btnAnswerThreeDman.TabIndex = 3;
            this.btnAnswerThreeDman.Text = "Answer";
            this.btnAnswerThreeDman.UseVisualStyleBackColor = false;
            // 
            // btnAnswerTwoDman
            // 
            this.btnAnswerTwoDman.BackColor = System.Drawing.Color.DarkRed;
            this.btnAnswerTwoDman.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnswerTwoDman.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnswerTwoDman.ForeColor = System.Drawing.Color.White;
            this.btnAnswerTwoDman.Location = new System.Drawing.Point(217, 290);
            this.btnAnswerTwoDman.Name = "btnAnswerTwoDman";
            this.btnAnswerTwoDman.Size = new System.Drawing.Size(180, 59);
            this.btnAnswerTwoDman.TabIndex = 2;
            this.btnAnswerTwoDman.Text = "Answer";
            this.btnAnswerTwoDman.UseVisualStyleBackColor = false;
            // 
            // pnlStatisticsDman
            // 
            this.pnlStatisticsDman.BackColor = System.Drawing.Color.DarkGray;
            this.pnlStatisticsDman.Controls.Add(this.lblTimeDman);
            this.pnlStatisticsDman.Controls.Add(this.lblStatisticScoreDman);
            this.pnlStatisticsDman.Controls.Add(this.lblScoreDman);
            this.pnlStatisticsDman.Controls.Add(this.lblStatisticTImeDman);
            this.pnlStatisticsDman.Location = new System.Drawing.Point(30, 17);
            this.pnlStatisticsDman.Name = "pnlStatisticsDman";
            this.pnlStatisticsDman.Size = new System.Drawing.Size(738, 29);
            this.pnlStatisticsDman.TabIndex = 0;
            // 
            // lblTimeDman
            // 
            this.lblTimeDman.AutoSize = true;
            this.lblTimeDman.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeDman.Location = new System.Drawing.Point(56, 6);
            this.lblTimeDman.Name = "lblTimeDman";
            this.lblTimeDman.Size = new System.Drawing.Size(40, 17);
            this.lblTimeDman.TabIndex = 5;
            this.lblTimeDman.Text = "00:00";
            // 
            // lblStatisticScoreDman
            // 
            this.lblStatisticScoreDman.AutoSize = true;
            this.lblStatisticScoreDman.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatisticScoreDman.Location = new System.Drawing.Point(640, 6);
            this.lblStatisticScoreDman.Name = "lblStatisticScoreDman";
            this.lblStatisticScoreDman.Size = new System.Drawing.Size(45, 17);
            this.lblStatisticScoreDman.TabIndex = 4;
            this.lblStatisticScoreDman.Text = "Score:";
            // 
            // lblScoreDman
            // 
            this.lblScoreDman.AutoSize = true;
            this.lblScoreDman.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreDman.Location = new System.Drawing.Point(691, 6);
            this.lblScoreDman.Name = "lblScoreDman";
            this.lblScoreDman.Size = new System.Drawing.Size(0, 17);
            this.lblScoreDman.TabIndex = 3;
            // 
            // lblStatisticTImeDman
            // 
            this.lblStatisticTImeDman.AutoSize = true;
            this.lblStatisticTImeDman.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatisticTImeDman.Location = new System.Drawing.Point(8, 6);
            this.lblStatisticTImeDman.Name = "lblStatisticTImeDman";
            this.lblStatisticTImeDman.Size = new System.Drawing.Size(43, 17);
            this.lblStatisticTImeDman.TabIndex = 2;
            this.lblStatisticTImeDman.Text = "Time:";
            // 
            // tbpRankingDman
            // 
            this.tbpRankingDman.Location = new System.Drawing.Point(4, 25);
            this.tbpRankingDman.Name = "tbpRankingDman";
            this.tbpRankingDman.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRankingDman.Size = new System.Drawing.Size(805, 389);
            this.tbpRankingDman.TabIndex = 1;
            this.tbpRankingDman.Text = "Ranking";
            this.tbpRankingDman.UseVisualStyleBackColor = true;
            // 
            // btnFiftyFiftyDman
            // 
            this.btnFiftyFiftyDman.BackColor = System.Drawing.Color.DarkRed;
            this.btnFiftyFiftyDman.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiftyFiftyDman.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiftyFiftyDman.ForeColor = System.Drawing.Color.White;
            this.btnFiftyFiftyDman.Location = new System.Drawing.Point(642, 52);
            this.btnFiftyFiftyDman.Name = "btnFiftyFiftyDman";
            this.btnFiftyFiftyDman.Size = new System.Drawing.Size(81, 40);
            this.btnFiftyFiftyDman.TabIndex = 9;
            this.btnFiftyFiftyDman.Text = "50/50";
            this.btnFiftyFiftyDman.UseVisualStyleBackColor = false;
            this.btnFiftyFiftyDman.Click += new System.EventHandler(this.btnFiftyFiftyDman_Click);
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbcNavigationDman);
            this.Controls.Add(this.pnlNavigationDman);
            this.Name = "Controller";
            this.Text = "Controller";
            this.Load += new System.EventHandler(this.Controller_Load);
            this.pnlNavigationDman.ResumeLayout(false);
            this.pnlNavigationDman.PerformLayout();
            this.tbcNavigationDman.ResumeLayout(false);
            this.tbpHomeDman.ResumeLayout(false);
            this.tbpHomeDman.PerformLayout();
            this.tbpQuizDman.ResumeLayout(false);
            this.tbpQuizDman.PerformLayout();
            this.pnlStatisticsDman.ResumeLayout(false);
            this.pnlStatisticsDman.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNavigationDman;
        private System.Windows.Forms.RadioButton rbtRankingDman;
        private System.Windows.Forms.RadioButton rbtHomeDman;
        private System.Windows.Forms.TabControl tbcNavigationDman;
        private System.Windows.Forms.TabPage tbpHomeDman;
        private System.Windows.Forms.TabPage tbpRankingDman;
        private System.Windows.Forms.TabPage tbpQuizDman;
        private System.Windows.Forms.Label lblDescriptionDman;
        private System.Windows.Forms.Label lblHeaderDman;
        private System.Windows.Forms.Button btnExitDman;
        private System.Windows.Forms.Panel pnlStatisticsDman;
        private System.Windows.Forms.Label lblScoreDman;
        private System.Windows.Forms.Label lblStatisticTImeDman;
        private System.Windows.Forms.Label lblStatisticScoreDman;
        private System.Windows.Forms.Label lblTimeDman;
        private System.Windows.Forms.Button btnAnswerFourDman;
        private System.Windows.Forms.Button btnAnswerThreeDman;
        private System.Windows.Forms.Button btnAnswerTwoDman;
        private System.Windows.Forms.Label lblQuestionDman;
        private System.Windows.Forms.Label lblMetaDman;
        private System.Windows.Forms.Button btnQuitDman;
        private System.Windows.Forms.Button btnAnswerOneDman;
        private System.Windows.Forms.Button btnStartGameDman;
        private System.Windows.Forms.Button btnFiftyFiftyDman;
    }
}