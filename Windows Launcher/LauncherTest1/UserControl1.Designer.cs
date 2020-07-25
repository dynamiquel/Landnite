namespace LauncherTest1
{
    partial class InitialLanguage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialLanguage));
            this.doneButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // doneButton
            // 
            this.doneButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.doneButton.Location = new System.Drawing.Point(121, 65);
            this.doneButton.Margin = new System.Windows.Forms.Padding(4);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(100, 34);
            this.doneButton.TabIndex = 1;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = false;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(3, 3);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(153, 19);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Choose your language";
            // 
            // languageComboBox
            // 
            this.languageComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.languageComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.languageComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.languageComboBox.Items.AddRange(new object[] {
            "English",
            "Français",
            "Polski"});
            this.languageComboBox.Location = new System.Drawing.Point(51, 30);
            this.languageComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.languageComboBox.Size = new System.Drawing.Size(122, 27);
            this.languageComboBox.TabIndex = 7;
            this.languageComboBox.Text = "English";
            // 
            // InitialLanguage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 106);
            this.Controls.Add(this.languageComboBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.doneButton);
            this.Font = new System.Drawing.Font("Prompt", 9.749999F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "InitialLanguage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Landnite Alpha";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ComboBox languageComboBox;
    }
}
