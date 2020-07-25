/* Landnite Launcher WF
 *
 * Created by Liam Hall on 09/01/19.
 * Copyright © 2019 Liam Hall. All rights reserved.
 *
 * Contributors:
 *   Liam Hall
 */

// Namespaces used by this C# class.
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LauncherTest1
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            LoadUserSettings();
            CheckCustomDirectoryCheckboxState();
            AboutSetup();
        }

        void LoadUserSettings() //This methods sets the values of some objects by the values saved in 'Properties'.
        {
            customDirectoryTextbox.Text = Properties.Settings.Default.customDirectory; //Text stored in 'customDirectoryTextbox' is the text retrieved from the 'customDirectory' string in 'Properties'.
            useCustomDirectoryCheckbox.Checked = Properties.Settings.Default.useCustomDirectory; //Boolean value set in 'customDirectoryCheckbox' is the boolean value retrieved from the 'useCustomDirectory' boolean in 'Properties'.
            LanguageSetup(); //Calls the 'LanguageSetup' method.
        }

        void LanguageSetup() //This method figures out what text to display later depending on the language the user selected.
        {
            switch (Properties.Settings.Default.language)
            {
                case 'f': //French
                    Text = "Menu";
                    mainTabPage.Text = "Préférences";
                    tabPage2.Text = "Propos";
                    useCustomDirectoryCheckbox.Text = "Utiliser un répertoire personnalisé";
                    locateFileButton.Text = "Localiser";
                    downloadGameButton.Text = "Télécharger le jeu";
                    languageLabel.Text = "La langue:";
                    languageComboBox.Text = "Français";
                    break;
                case 'p': //Polish
                    Text = "Menu";
                    mainTabPage.Text = "Ustawienia";
                    tabPage2.Text = "O aplikacji";
                    useCustomDirectoryCheckbox.Text = "Użyj niestandardowej ścieżki";
                    locateFileButton.Text = "Zlokalizuj";
                    downloadGameButton.Text = "Pobierz grę";
                    languageLabel.Text = "Język:";
                    languageComboBox.Text = "Polski";
                    break;
                default: //None (English)
                    Text = "Menu";
                    mainTabPage.Text = "Preferences";
                    tabPage2.Text = "About";
                    useCustomDirectoryCheckbox.Text = "Use custom directory";
                    locateFileButton.Text = "Locate";
                    downloadGameButton.Text = "Download game";
                    languageLabel.Text = "Language:";
                    languageComboBox.Text = "English";
                    break;
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        } //When 'SettingsForm' (this) loads.

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e) //When user presses 'OK' after they have selected a folder.
        {
            if (findCustomFile.CheckFileExists) //If the file exists, then...
            {
                customDirectoryTextbox.Text = findCustomFile.FileName; //Set the text stored in 'customDirectoryTextbox' as the directory retrieved from the 'findCustomFile'.
                UpdateCustomPath(); //Calls the 'UpdateCustomPath' method.
            }
        }

        private void locateFileButton_Click(object sender, EventArgs e) //When the user presses the 'locateFileButton' button...
        {
            //findCustomFile.ShowDialog();
            DialogResult r = findCustomFolder.ShowDialog(); //Open a choose folder dialog to the user.
            if (r == DialogResult.OK) //If the user chooses a folder, then...
            {
                customDirectoryTextbox.Text = findCustomFolder.SelectedPath; //The text stored in 'customDirectoryTextbox' is the directory that was selected in the folder dialog.
                UpdateCustomPath(); //Calls the 'UpdateCustomPath' method.
            }
        }

        void UpdateCustomPath() //This method gets the directory that is stored in the 'customDirectoryTextbox' and saves it as the 'customDirectory' string within 'Properties'.
        {
            Properties.Settings.Default.customDirectory = customDirectoryTextbox.Text; //Sets the string stored in 'customDirectoryT' in 'Properties as the string found in 'customDirectoryTextbox'.
            Properties.Settings.Default.Save(); //Saves all the current 'Properties' to the registry.
            mainForm.instance.CheckForExistence(); //Calls the 'CheckForExistence' method in the 'mainForn' (Form1) instance.

            if ((customDirectoryTextbox.Text == "") && useCustomDirectoryCheckbox.Checked) //If the 'useCustomDirectoryCheckbox' is checked but no directory is given, then...
            {
                customDirectoryError.Visible = true; //Display the 'customDirectoryError' error label.
            }
            else //Else...
            {
                customDirectoryError.Visible = false; //Hide the 'customDirectoryError' error label.
            }
        }

        private void customDirectoryTextbox_TextChanged(object sender, EventArgs e) //When the text in 'customDirectoryTextbox' changes...
        {
            UpdateCustomPath(); //Calls the 'UpdateCustomPath' method.
        }

        private void useCustomDirectoryCheckbox_CheckedChanged(object sender, EventArgs e) //When the 'useCustomDirectoryCheckbox' is changed...
        {
            CheckCustomDirectoryCheckboxState(); //Calls the 'CheckCustomDirectoryCheckboxState' method.
            UpdateCustomPath(); //Calls the 'UpdateCustomPath' method.
        }

        void CheckCustomDirectoryCheckboxState() //This method determines what method to call depending on whether the 'useCustomDirectoryCheckbox' is checked or not.
        {
            if (useCustomDirectoryCheckbox.Checked) //If the 'useCustomDirectoryCheckbox' is checked, then...
            {
                EnableCustomDirectory(); //Calls the 'EnableCustomDirectory'.
            }
            else //Else...
            {
                DisableCustomDirectory(); //Calls the 'DisableCustomDirectory' method.
            }
        }

        void EnableCustomDirectory() //This method tells the rest of the program to use the custom directory.
        {
            Properties.Settings.Default.useCustomDirectory = true; //Sets the 'useCustomDirectory' boolean to true.
            customDirectoryTextbox.Enabled = true; //Allows the 'customDirectoryTextbox' to be altered.
            locateFileButton.Enabled = true; //Allows the 'locateFileButton' button to be clicked.
            mainForm.instance.CheckForExistence(); //Calls the 'CheckForExistence' method in the 'mainForn' (Form1) instance.
        }

        void DisableCustomDirectory() //This method tells the rest of the program to use the default directory.
        {
            Properties.Settings.Default.useCustomDirectory = false; //Sets the 'useCustomDirectory' boolean to false.
            customDirectoryTextbox.Enabled = false; //Does not allow the 'customDirectoryTextbox' to be altered.
            locateFileButton.Enabled = false; //Does not allow the 'locateFileButton' button to be clicked.
            mainForm.instance.CheckForExistence(); //Calls the 'CheckForExistence' method in the 'mainForn' (Form1) instance.
        }

        void AboutSetup() //This method displays the about information of the program
        {
            string appName = "Landnite";
            string version = "1.0";
            string madeBy = "© 2019 Liam Hall. All rights reserved.";

            aboutLabel_appName.Text = appName;
            aboutLabel_version.Text = version;      
            aboutLabel_madeBy.Text = madeBy;      
        }

        private void downloadGameButton_Click(object sender, EventArgs e) //When the 'downloadGameButton' button is clicked...
        {
            DownloadGame(); //Calls the 'DownloadGame' method.
        }

        void DownloadGame() //This method opens up a web page in the user's default browser.
        {
            //Opens game download page in browser
            System.Diagnostics.Process.Start("https://mega.nz/#F!BkFUQYCL!pbi7c3lLUX5dJNkpWgrKcg!sk1RATLI");
        }

        private void languageComboBox_SelectedIndexChanged(object sender, EventArgs e) //When the 'languageComboBox' value has changed...
        {
            LanguageChange(); //Calls the 'LanguageChange' method.
        }

        void LanguageChange() //This method changes the 'language' char in 'Properties' depending on what is selected in the 'languageComboBox'.
        {
            switch (languageComboBox.Text)
            {
                case "English":
                    Properties.Settings.Default.language = 'e';
                    Console.WriteLine("Language changed to English.");
                    break;
                case "Français":
                    Properties.Settings.Default.language = 'f';
                    Console.WriteLine("Language changed to Français.");
                    break;
                case "Polski":
                    Properties.Settings.Default.language = 'p';
                    Console.WriteLine("Language changed to Polski.");
                    break;
                default:
                    Properties.Settings.Default.language = 'e';
                    Console.WriteLine("Language changed to English.");
                    break;
            }

            Properties.Settings.Default.Save(); //Saves all values in 'Properties' to the registry.
            Console.WriteLine("Saving changes.");

            LanguageSetup(); //Calls the 'LanguageSetup' method.
            mainForm.instance.LanguageSetup(); //Calls the 'LanguageSetup' method in the 'mainForm' (Form1) instance.
            mainForm.instance.CheckForExistence(); //Calls the 'CheckForExistence' method in the 'mainForm' (Form1) instance.
        } 
    }
}