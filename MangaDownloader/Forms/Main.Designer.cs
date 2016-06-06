namespace MangaDownloader.Forms
{
    partial class Main
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
            this.mangaInformationGroupBox = new System.Windows.Forms.GroupBox();
            this.toUpDown = new System.Windows.Forms.NumericUpDown();
            this.toLabel = new System.Windows.Forms.Label();
            this.fromUpDown = new System.Windows.Forms.NumericUpDown();
            this.chaptersLabel = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.urlLabel = new System.Windows.Forms.Label();
            this.logGroupBox = new System.Windows.Forms.GroupBox();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.downloadButton = new System.Windows.Forms.Button();
            this.mangaInformationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromUpDown)).BeginInit();
            this.logGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mangaInformationGroupBox
            // 
            this.mangaInformationGroupBox.Controls.Add(this.toUpDown);
            this.mangaInformationGroupBox.Controls.Add(this.toLabel);
            this.mangaInformationGroupBox.Controls.Add(this.fromUpDown);
            this.mangaInformationGroupBox.Controls.Add(this.chaptersLabel);
            this.mangaInformationGroupBox.Controls.Add(this.urlTextBox);
            this.mangaInformationGroupBox.Controls.Add(this.urlLabel);
            this.mangaInformationGroupBox.Location = new System.Drawing.Point(12, 12);
            this.mangaInformationGroupBox.Name = "mangaInformationGroupBox";
            this.mangaInformationGroupBox.Size = new System.Drawing.Size(260, 77);
            this.mangaInformationGroupBox.TabIndex = 0;
            this.mangaInformationGroupBox.TabStop = false;
            this.mangaInformationGroupBox.Text = "Manga Information";
            // 
            // toUpDown
            // 
            this.toUpDown.Location = new System.Drawing.Point(176, 49);
            this.toUpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.toUpDown.Name = "toUpDown";
            this.toUpDown.Size = new System.Drawing.Size(78, 22);
            this.toUpDown.TabIndex = 5;
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(152, 51);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(18, 13);
            this.toLabel.TabIndex = 4;
            this.toLabel.Text = "to";
            // 
            // fromUpDown
            // 
            this.fromUpDown.Location = new System.Drawing.Point(68, 49);
            this.fromUpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.fromUpDown.Name = "fromUpDown";
            this.fromUpDown.Size = new System.Drawing.Size(78, 22);
            this.fromUpDown.TabIndex = 3;
            // 
            // chaptersLabel
            // 
            this.chaptersLabel.AutoSize = true;
            this.chaptersLabel.Location = new System.Drawing.Point(6, 51);
            this.chaptersLabel.Name = "chaptersLabel";
            this.chaptersLabel.Size = new System.Drawing.Size(56, 13);
            this.chaptersLabel.TabIndex = 2;
            this.chaptersLabel.Text = "Chapters:";
            // 
            // urlTextBox
            // 
            this.urlTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.urlTextBox.Location = new System.Drawing.Point(37, 21);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(217, 22);
            this.urlTextBox.TabIndex = 1;
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(6, 24);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(25, 13);
            this.urlLabel.TabIndex = 0;
            this.urlLabel.Text = "Url:";
            // 
            // logGroupBox
            // 
            this.logGroupBox.Controls.Add(this.logTextBox);
            this.logGroupBox.Location = new System.Drawing.Point(12, 95);
            this.logGroupBox.Name = "logGroupBox";
            this.logGroupBox.Size = new System.Drawing.Size(260, 150);
            this.logGroupBox.TabIndex = 1;
            this.logGroupBox.TabStop = false;
            this.logGroupBox.Text = "Log";
            // 
            // logTextBox
            // 
            this.logTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.logTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logTextBox.Location = new System.Drawing.Point(6, 21);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(248, 123);
            this.logTextBox.TabIndex = 0;
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(197, 251);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(75, 23);
            this.downloadButton.TabIndex = 2;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 286);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.logGroupBox);
            this.Controls.Add(this.mangaInformationGroupBox);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MangaDownloader";
            this.mangaInformationGroupBox.ResumeLayout(false);
            this.mangaInformationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromUpDown)).EndInit();
            this.logGroupBox.ResumeLayout(false);
            this.logGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox mangaInformationGroupBox;
        private System.Windows.Forms.NumericUpDown toUpDown;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.NumericUpDown fromUpDown;
        private System.Windows.Forms.Label chaptersLabel;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.GroupBox logGroupBox;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Button downloadButton;
    }
}