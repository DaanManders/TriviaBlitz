namespace APPR_TriviaBlitz_22SD_Dman
{
    partial class Hub
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
            this.pnlBackgroundDman = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tbcHubDman = new System.Windows.Forms.TabControl();
            this.tbpGameDman = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExitDman = new System.Windows.Forms.Button();
            this.btnStartGameDman = new System.Windows.Forms.Button();
            this.tbpRankingDman = new System.Windows.Forms.TabPage();
            this.tbpTriviaDman = new System.Windows.Forms.TabPage();
            this.pnlBackgroundDman.SuspendLayout();
            this.tbcHubDman.SuspendLayout();
            this.tbpGameDman.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBackgroundDman
            // 
            this.pnlBackgroundDman.BackColor = System.Drawing.Color.Red;
            this.pnlBackgroundDman.Controls.Add(this.radioButton2);
            this.pnlBackgroundDman.Controls.Add(this.radioButton1);
            this.pnlBackgroundDman.Location = new System.Drawing.Point(-3, 0);
            this.pnlBackgroundDman.Name = "pnlBackgroundDman";
            this.pnlBackgroundDman.Size = new System.Drawing.Size(806, 55);
            this.pnlBackgroundDman.TabIndex = 0;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.ForeColor = System.Drawing.Color.White;
            this.radioButton2.Location = new System.Drawing.Point(693, 16);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(87, 24);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "Ranking";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(31, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(109, 24);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Start Game";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // tbcHubDman
            // 
            this.tbcHubDman.Controls.Add(this.tbpGameDman);
            this.tbcHubDman.Controls.Add(this.tbpTriviaDman);
            this.tbcHubDman.Controls.Add(this.tbpRankingDman);
            this.tbcHubDman.Location = new System.Drawing.Point(-9, 54);
            this.tbcHubDman.Name = "tbcHubDman";
            this.tbcHubDman.SelectedIndex = 0;
            this.tbcHubDman.Size = new System.Drawing.Size(821, 399);
            this.tbcHubDman.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbcHubDman.TabIndex = 1;
            // 
            // tbpGameDman
            // 
            this.tbpGameDman.BackColor = System.Drawing.Color.White;
            this.tbpGameDman.Controls.Add(this.label2);
            this.tbpGameDman.Controls.Add(this.label1);
            this.tbpGameDman.Controls.Add(this.btnExitDman);
            this.tbpGameDman.Controls.Add(this.btnStartGameDman);
            this.tbpGameDman.Location = new System.Drawing.Point(4, 25);
            this.tbpGameDman.Name = "tbpGameDman";
            this.tbpGameDman.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGameDman.Size = new System.Drawing.Size(813, 370);
            this.tbpGameDman.TabIndex = 0;
            this.tbpGameDman.Text = "Start Game";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(409, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Made with great pleasure by Daan Manders";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "TriviaBlitz Version 1.01";
            // 
            // btnExitDman
            // 
            this.btnExitDman.BackColor = System.Drawing.Color.DarkRed;
            this.btnExitDman.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitDman.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitDman.ForeColor = System.Drawing.Color.White;
            this.btnExitDman.Location = new System.Drawing.Point(593, 300);
            this.btnExitDman.Name = "btnExitDman";
            this.btnExitDman.Size = new System.Drawing.Size(180, 57);
            this.btnExitDman.TabIndex = 1;
            this.btnExitDman.Text = "Exit";
            this.btnExitDman.UseVisualStyleBackColor = false;
            this.btnExitDman.Click += new System.EventHandler(this.btnExitDman_Click);
            // 
            // btnStartGameDman
            // 
            this.btnStartGameDman.BackColor = System.Drawing.Color.Red;
            this.btnStartGameDman.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartGameDman.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGameDman.ForeColor = System.Drawing.Color.White;
            this.btnStartGameDman.Location = new System.Drawing.Point(33, 300);
            this.btnStartGameDman.Name = "btnStartGameDman";
            this.btnStartGameDman.Size = new System.Drawing.Size(554, 57);
            this.btnStartGameDman.TabIndex = 0;
            this.btnStartGameDman.Text = "Start Game";
            this.btnStartGameDman.UseVisualStyleBackColor = false;
            this.btnStartGameDman.Click += new System.EventHandler(this.btnStartGameDman_Click);
            // 
            // tbpRankingDman
            // 
            this.tbpRankingDman.Location = new System.Drawing.Point(4, 25);
            this.tbpRankingDman.Name = "tbpRankingDman";
            this.tbpRankingDman.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRankingDman.Size = new System.Drawing.Size(813, 370);
            this.tbpRankingDman.TabIndex = 1;
            this.tbpRankingDman.Text = "Ranking";
            this.tbpRankingDman.UseVisualStyleBackColor = true;
            // 
            // tbpTriviaDman
            // 
            this.tbpTriviaDman.Location = new System.Drawing.Point(4, 25);
            this.tbpTriviaDman.Name = "tbpTriviaDman";
            this.tbpTriviaDman.Size = new System.Drawing.Size(813, 370);
            this.tbpTriviaDman.TabIndex = 2;
            this.tbpTriviaDman.Text = "Trivia";
            this.tbpTriviaDman.UseVisualStyleBackColor = true;
            // 
            // Hub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 448);
            this.Controls.Add(this.tbcHubDman);
            this.Controls.Add(this.pnlBackgroundDman);
            this.Name = "Hub";
            this.Text = "Hub";
            this.Load += new System.EventHandler(this.Hub_Load);
            this.pnlBackgroundDman.ResumeLayout(false);
            this.pnlBackgroundDman.PerformLayout();
            this.tbcHubDman.ResumeLayout(false);
            this.tbpGameDman.ResumeLayout(false);
            this.tbpGameDman.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBackgroundDman;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TabControl tbcHubDman;
        private System.Windows.Forms.TabPage tbpGameDman;
        private System.Windows.Forms.TabPage tbpRankingDman;
        private System.Windows.Forms.Button btnExitDman;
        private System.Windows.Forms.Button btnStartGameDman;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tbpTriviaDman;
    }
}