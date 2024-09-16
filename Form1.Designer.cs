namespace APPR_TriviaBlitz_22SD_Dman
{
    partial class Form1
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
            this.btnHalloDman = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnHalloDman
            // 
            this.btnHalloDman.AutoSize = true;
            this.btnHalloDman.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHalloDman.Location = new System.Drawing.Point(302, 190);
            this.btnHalloDman.Name = "btnHalloDman";
            this.btnHalloDman.Size = new System.Drawing.Size(163, 30);
            this.btnHalloDman.TabIndex = 0;
            this.btnHalloDman.Text = "Hallo Daan";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnHalloDman);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label btnHalloDman;
    }
}

