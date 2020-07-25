namespace LauncherTest1
{
    partial class SettingsForm
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
            this.useCustomDirectoryCheckbox = new System.Windows.Forms.CheckBox();
            this.settingsTabControl = new System.Windows.Forms.TabControl();
            this.mainTabPage = new System.Windows.Forms.TabPage();
            this.languageLabel = new System.Windows.Forms.Label();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.customDirectoryError = new System.Windows.Forms.Label();
            this.downloadGameButton = new System.Windows.Forms.Button();
            this.locateFileButton = new System.Windows.Forms.Button();
            this.customDirectoryTextbox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.aboutLabel_appName = new System.Windows.Forms.Label();
            this.aboutLabel_version = new System.Windows.Forms.Label();
            this.aboutLabel_madeBy = new System.Windows.Forms.Label();
            this.findCustomFile = new System.Windows.Forms.OpenFileDialog();
            this.findCustomFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.settingsTabControl.SuspendLayout();
            this.mainTabPage.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // useCustomDirectoryCheckbox
            // 
            this.useCustomDirectoryCheckbox.AutoSize = true;
            this.useCustomDirectoryCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.useCustomDirectoryCheckbox.Location = new System.Drawing.Point(16, 12);
            this.useCustomDirectoryCheckbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.useCustomDirectoryCheckbox.Name = "useCustomDirectoryCheckbox";
            this.useCustomDirectoryCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.useCustomDirectoryCheckbox.Size = new System.Drawing.Size(164, 23);
            this.useCustomDirectoryCheckbox.TabIndex = 1;
            this.useCustomDirectoryCheckbox.Text = "Use custom directory";
            this.useCustomDirectoryCheckbox.UseVisualStyleBackColor = true;
            this.useCustomDirectoryCheckbox.CheckedChanged += new System.EventHandler(this.useCustomDirectoryCheckbox_CheckedChanged);
            // 
            // settingsTabControl
            // 
            this.settingsTabControl.Controls.Add(this.mainTabPage);
            this.settingsTabControl.Controls.Add(this.tabPage2);
            this.settingsTabControl.Location = new System.Drawing.Point(-3, 0);
            this.settingsTabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.settingsTabControl.Name = "settingsTabControl";
            this.settingsTabControl.SelectedIndex = 0;
            this.settingsTabControl.Size = new System.Drawing.Size(342, 436);
            this.settingsTabControl.TabIndex = 2;
            // 
            // mainTabPage
            // 
            this.mainTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainTabPage.Controls.Add(this.languageLabel);
            this.mainTabPage.Controls.Add(this.languageComboBox);
            this.mainTabPage.Controls.Add(this.customDirectoryError);
            this.mainTabPage.Controls.Add(this.downloadGameButton);
            this.mainTabPage.Controls.Add(this.locateFileButton);
            this.mainTabPage.Controls.Add(this.customDirectoryTextbox);
            this.mainTabPage.Controls.Add(this.useCustomDirectoryCheckbox);
            this.mainTabPage.Location = new System.Drawing.Point(4, 28);
            this.mainTabPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mainTabPage.Name = "mainTabPage";
            this.mainTabPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mainTabPage.Size = new System.Drawing.Size(334, 404);
            this.mainTabPage.TabIndex = 0;
            this.mainTabPage.Text = "Main";
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Location = new System.Drawing.Point(11, 110);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(75, 19);
            this.languageLabel.TabIndex = 7;
            this.languageLabel.Text = "Language:";
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
            this.languageComboBox.Location = new System.Drawing.Point(97, 107);
            this.languageComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.languageComboBox.Size = new System.Drawing.Size(122, 27);
            this.languageComboBox.TabIndex = 6;
            this.languageComboBox.Text = "English";
            this.languageComboBox.SelectedIndexChanged += new System.EventHandler(this.languageComboBox_SelectedIndexChanged);
            // 
            // customDirectoryError
            // 
            this.customDirectoryError.AutoSize = true;
            this.customDirectoryError.ForeColor = System.Drawing.Color.Red;
            this.customDirectoryError.Location = new System.Drawing.Point(11, 77);
            this.customDirectoryError.Name = "customDirectoryError";
            this.customDirectoryError.Size = new System.Drawing.Size(288, 19);
            this.customDirectoryError.TabIndex = 5;
            this.customDirectoryError.Text = "Choose a directory or use default directory";
            this.customDirectoryError.Visible = false;
            // 
            // downloadGameButton
            // 
            this.downloadGameButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.downloadGameButton.Location = new System.Drawing.Point(88, 352);
            this.downloadGameButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.downloadGameButton.Name = "downloadGameButton";
            this.downloadGameButton.Size = new System.Drawing.Size(158, 34);
            this.downloadGameButton.TabIndex = 4;
            this.downloadGameButton.Text = "Download Game";
            this.downloadGameButton.UseVisualStyleBackColor = false;
            this.downloadGameButton.Click += new System.EventHandler(this.downloadGameButton_Click);
            // 
            // locateFileButton
            // 
            this.locateFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.locateFileButton.Location = new System.Drawing.Point(223, 44);
            this.locateFileButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.locateFileButton.Name = "locateFileButton";
            this.locateFileButton.Size = new System.Drawing.Size(99, 27);
            this.locateFileButton.TabIndex = 3;
            this.locateFileButton.Text = "Locate";
            this.locateFileButton.UseVisualStyleBackColor = false;
            this.locateFileButton.Click += new System.EventHandler(this.locateFileButton_Click);
            // 
            // customDirectoryTextbox
            // 
            this.customDirectoryTextbox.BackColor = System.Drawing.Color.White;
            this.customDirectoryTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.customDirectoryTextbox.Location = new System.Drawing.Point(16, 44);
            this.customDirectoryTextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.customDirectoryTextbox.Name = "customDirectoryTextbox";
            this.customDirectoryTextbox.Size = new System.Drawing.Size(203, 27);
            this.customDirectoryTextbox.TabIndex = 2;
            this.customDirectoryTextbox.TextChanged += new System.EventHandler(this.customDirectoryTextbox_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.aboutLabel_appName);
            this.tabPage2.Controls.Add(this.aboutLabel_version);
            this.tabPage2.Controls.Add(this.aboutLabel_madeBy);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(334, 404);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "About";
            // 
            // aboutLabel_appName
            // 
            this.aboutLabel_appName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutLabel_appName.Location = new System.Drawing.Point(15, 117);
            this.aboutLabel_appName.Name = "aboutLabel_appName";
            this.aboutLabel_appName.Size = new System.Drawing.Size(303, 18);
            this.aboutLabel_appName.TabIndex = 1;
            this.aboutLabel_appName.Text = "app name";
            this.aboutLabel_appName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // aboutLabel_version
            // 
            this.aboutLabel_version.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutLabel_version.Location = new System.Drawing.Point(15, 143);
            this.aboutLabel_version.Name = "aboutLabel_version";
            this.aboutLabel_version.Size = new System.Drawing.Size(303, 18);
            this.aboutLabel_version.TabIndex = 2;
            this.aboutLabel_version.Text = "version";
            this.aboutLabel_version.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // aboutLabel_madeBy
            // 
            this.aboutLabel_madeBy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutLabel_madeBy.Location = new System.Drawing.Point(15, 194);
            this.aboutLabel_madeBy.Name = "aboutLabel_madeBy";
            this.aboutLabel_madeBy.Size = new System.Drawing.Size(303, 18);
            this.aboutLabel_madeBy.TabIndex = 3;
            this.aboutLabel_madeBy.Text = "made by";
            this.aboutLabel_madeBy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // findCustomFile
            // 
            this.findCustomFile.FileName = "findCustomFile";
            this.findCustomFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // findCustomFolder
            // 
            this.findCustomFolder.Description = "Locate game folder";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(335, 434);
            this.Controls.Add(this.settingsTabControl);
            this.Font = new System.Drawing.Font("Prompt", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.settingsTabControl.ResumeLayout(false);
            this.mainTabPage.ResumeLayout(false);
            this.mainTabPage.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox useCustomDirectoryCheckbox;
        private System.Windows.Forms.TabControl settingsTabControl;
        private System.Windows.Forms.TabPage mainTabPage;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.OpenFileDialog findCustomFile;
        private System.Windows.Forms.Button locateFileButton;
        private System.Windows.Forms.TextBox customDirectoryTextbox;
        private System.Windows.Forms.Label aboutLabel_appName;
        private System.Windows.Forms.Label aboutLabel_version;
        private System.Windows.Forms.Label aboutLabel_madeBy;
        private System.Windows.Forms.Button downloadGameButton;
        private System.Windows.Forms.Label customDirectoryError;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.FolderBrowserDialog findCustomFolder;
    }
}