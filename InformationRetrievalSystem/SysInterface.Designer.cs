namespace InformationRetrievalSystem
{
    partial class SysInterface
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Docbutton = new System.Windows.Forms.Button();
            this.structure_button = new System.Windows.Forms.Button();
            this.accent_button = new System.Windows.Forms.Button();
            this.Stopwords_button = new System.Windows.Forms.Button();
            this.noun_button = new System.Windows.Forms.Button();
            this.stemming_button = new System.Windows.Forms.Button();
            this.indexing_button = new System.Windows.Forms.Button();
            this.NonCharacter = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(771, 449);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "Build Index";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NonCharacter);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Location = new System.Drawing.Point(8, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 77);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preprocessing Operations";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(5, 52);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(88, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Case-Folding";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox7);
            this.groupBox2.Controls.Add(this.checkBox6);
            this.groupBox2.Controls.Add(this.checkBox5);
            this.groupBox2.Location = new System.Drawing.Point(8, 261);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 151);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Facilities Index could Support";
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(6, 120);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(142, 17);
            this.checkBox7.TabIndex = 2;
            this.checkBox7.Text = "Provide Wildcard Search";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(6, 75);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(161, 17);
            this.checkBox6.TabIndex = 1;
            this.checkBox6.Text = "Provide Approximate search";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Location = new System.Drawing.Point(6, 32);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(133, 17);
            this.checkBox5.TabIndex = 0;
            this.checkBox5.Text = "Provide Phrase search";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::InformationRetrievalSystem.Properties.Resources.logical_view;
            this.pictureBox1.Location = new System.Drawing.Point(189, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(655, 393);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Docbutton
            // 
            this.Docbutton.Location = new System.Drawing.Point(229, 184);
            this.Docbutton.Name = "Docbutton";
            this.Docbutton.Size = new System.Drawing.Size(88, 47);
            this.Docbutton.TabIndex = 5;
            this.Docbutton.Text = "Documents";
            this.Docbutton.UseVisualStyleBackColor = true;
            this.Docbutton.Click += new System.EventHandler(this.Docbutton_Click);
            // 
            // structure_button
            // 
            this.structure_button.Location = new System.Drawing.Point(304, 289);
            this.structure_button.Name = "structure_button";
            this.structure_button.Size = new System.Drawing.Size(88, 47);
            this.structure_button.TabIndex = 6;
            this.structure_button.Text = "Structure recognition";
            this.structure_button.UseVisualStyleBackColor = true;
            this.structure_button.Click += new System.EventHandler(this.structure_button_Click);
            // 
            // accent_button
            // 
            this.accent_button.Location = new System.Drawing.Point(394, 170);
            this.accent_button.Name = "accent_button";
            this.accent_button.Size = new System.Drawing.Size(77, 79);
            this.accent_button.TabIndex = 7;
            this.accent_button.Text = "Accents, spacing, etc";
            this.accent_button.UseVisualStyleBackColor = true;
            this.accent_button.Click += new System.EventHandler(this.accent_button_Click);
            // 
            // Stopwords_button
            // 
            this.Stopwords_button.Location = new System.Drawing.Point(496, 192);
            this.Stopwords_button.Name = "Stopwords_button";
            this.Stopwords_button.Size = new System.Drawing.Size(74, 31);
            this.Stopwords_button.TabIndex = 8;
            this.Stopwords_button.Text = "Stopwords";
            this.Stopwords_button.UseVisualStyleBackColor = true;
            this.Stopwords_button.Click += new System.EventHandler(this.Stopwords_button_Click);
            // 
            // noun_button
            // 
            this.noun_button.Location = new System.Drawing.Point(588, 184);
            this.noun_button.Name = "noun_button";
            this.noun_button.Size = new System.Drawing.Size(60, 47);
            this.noun_button.TabIndex = 9;
            this.noun_button.Text = "Noun groups";
            this.noun_button.UseVisualStyleBackColor = true;
            this.noun_button.Click += new System.EventHandler(this.noun_button_Click);
            // 
            // stemming_button
            // 
            this.stemming_button.Location = new System.Drawing.Point(666, 194);
            this.stemming_button.Name = "stemming_button";
            this.stemming_button.Size = new System.Drawing.Size(74, 28);
            this.stemming_button.TabIndex = 10;
            this.stemming_button.Text = "Stemming";
            this.stemming_button.UseVisualStyleBackColor = true;
            this.stemming_button.Click += new System.EventHandler(this.stemming_button_Click);
            // 
            // indexing_button
            // 
            this.indexing_button.Location = new System.Drawing.Point(765, 176);
            this.indexing_button.Name = "indexing_button";
            this.indexing_button.Size = new System.Drawing.Size(74, 64);
            this.indexing_button.TabIndex = 11;
            this.indexing_button.Text = "Automatic indexing";
            this.indexing_button.UseVisualStyleBackColor = true;
            this.indexing_button.Click += new System.EventHandler(this.indexing_button_Click);
            // 
            // NonCharacter
            // 
            this.NonCharacter.AutoSize = true;
            this.NonCharacter.Location = new System.Drawing.Point(5, 29);
            this.NonCharacter.Name = "NonCharacter";
            this.NonCharacter.Size = new System.Drawing.Size(141, 17);
            this.NonCharacter.TabIndex = 14;
            this.NonCharacter.Text = "Non-Character Removal";
            this.NonCharacter.UseVisualStyleBackColor = true;
            // 
            // SysInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 500);
            this.Controls.Add(this.indexing_button);
            this.Controls.Add(this.stemming_button);
            this.Controls.Add(this.noun_button);
            this.Controls.Add(this.Stopwords_button);
            this.Controls.Add(this.accent_button);
            this.Controls.Add(this.structure_button);
            this.Controls.Add(this.Docbutton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SysInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Information Retrieval System Interface";
            this.Load += new System.EventHandler(this.SysInterface_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Docbutton;
        private System.Windows.Forms.Button structure_button;
        private System.Windows.Forms.Button accent_button;
        private System.Windows.Forms.Button Stopwords_button;
        private System.Windows.Forms.Button noun_button;
        private System.Windows.Forms.Button stemming_button;
        private System.Windows.Forms.Button indexing_button;
        private System.Windows.Forms.CheckBox NonCharacter;
    }
}

