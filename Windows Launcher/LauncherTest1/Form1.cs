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
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace LauncherTest1
{
    public partial class mainForm : Form
    {
        Int16 playButtonState;
        Language l;
        SettingsForm settings;
        string[] playButtonText = new string[3];
        string gamePath;
        string[] noGameInstalledText = new string[2];
        public static mainForm instance;

        public mainForm()
        {
            Console.WriteLine("Start.");
            InitializeComponent();
            Initialise();
            LanguageSetup();
            SettingsSetup();
            CheckForExistence();
            //geckoWebBrowser.Navigate("http://odinostudios.weebly.com/landnite.html");
        }

        void Initialise()
        {
            if (instance == null) //If Form1 does not already exist, then create this as the instance.
            {
                instance = this;
            }
        }

        public void LanguageSetup() //This method figures out what text to display later depending on the language the user selected.
        {
            switch (Properties.Settings.Default.language)
            {
                case 'f': //French
                    playButtonText[0] = "CHARGE";
                    playButtonText[1] = "JOUER";
                    playButtonText[2] = "RÉPARER";
                    noGameInstalledText[0] = "Aller au «Menu > Préférences» pour localiser manuellement le dossier de Landnite. Sinon, vous devez réinstaller Landnite.";
                    noGameInstalledText[1] = "Landnite non trouvé";
                    Console.WriteLine("Language: Français.");
                    break;
                case 'p': //Polish
                    playButtonText[0] = "ŁADUJĘ";
                    playButtonText[1] = "ZAGRAJ";
                    playButtonText[2] = "NAPRAWA";
                    noGameInstalledText[0] = "Przejdź do 'Menu > Ustawienia', aby ręcznie zlokalizować folder Landnite. W przeciwnym razie musisz przeinstalować Landnite";
                    noGameInstalledText[1] = "Landnite nie znaleziono";
                    Console.WriteLine("Language: Polski.");
                    break;
                case 'e': //English
                    playButtonText[0] = "LOADING";
                    playButtonText[1] = "PLAY";
                    playButtonText[2] = "REPAIR";
                    noGameInstalledText[0] = "Go to 'Menu > Preferences' to manually locate the Landnite folder. Otherwise, you must reinstall Landnite.";
                    noGameInstalledText[1] = "Landnite not found";
                    Console.WriteLine("Language: English.");
                    break;
                default: //None (English)
                    playButtonText[0] = "LOADING";
                    playButtonText[1] = "PLAY";
                    playButtonText[2] = "REPAIR";
                    noGameInstalledText[0] = "Go to 'Menu > Preferences' to manually locate the Landnite folder. Otherwise, you must reinstall Landnite.";
                    noGameInstalledText[1] = "Landnite not found";
                    Console.WriteLine("Language: None (setting to English).");
                    break;
            }

            playButton.Text = playButtonText[0]; //Sets the text of the 'playButton' to the string saved in 'playButton[0]'.
        }

        private void playButton_Click(object sender, EventArgs e) //When 'playButton' is clicked.
        {
            CheckState(); //Calls the 'CheckState' method.
        }

        void CheckState() //This method figures out if the game is installed, and does something depending if it is.
        {
            if (playButtonState == 1) //If the game is installed ('playButtonState' is 1), then...
            {
                PlayGame(); //Calls the 'PlayGame' method.
            }
            else if (playButtonState == 2) //If the game is installed ('playButtonState' is 2), then...
            {
                NoGameInstalled(); //Calls the 'NoGameInstalled' method.
            }
        }

        void NoGameInstalled() //This method displays an error message.
        {
            Console.WriteLine("Displaying 'NoGameInstalled' message.");
            DialogResult mb = MessageBox.Show(noGameInstalledText[0],
                noGameInstalledText[1]); //Displays an error message saying the game is not installed.
        }

        void PlayGame() //This method checks if the game is installed and if it is, starts the .exe file in the gamepath (Landnite).
        {
            if (File.Exists(gamePath)) //If the file exists at the gamepath (Landnite.exe exists), then...
            {
                Console.WriteLine("Starting Game...");
                System.Diagnostics.Process.Start(gamePath); //Launch the file at the gamepath (Landnite).
                Console.WriteLine("Game started.");
            }
            else //Else...
                NoGameInstalled(); //Call the NoGameInstalled method.
        }

        void SettingsSetup() //This method creates an object of 'SettingsForm' (the settings page).
        {
            settings = new SettingsForm(); //Create an object of 'SettingsForm' called 'settings'.
        }

        private void settingsButton_Click(object sender, EventArgs e) //When 'settingsButton' is clicked...
        {
            ToggleSettings(); //Call the 'ToggleSettings' method.
        }

        void ToggleSettings() //This method opens or closes the settings page.
        {
            if (settings.Visible) //If 'settings' is already open, then...
            {
                Console.WriteLine("Closing Settings...");
                CloseSettings(); //Calls the 'CloseSettings' method.
                Console.WriteLine("Settings closed.");
            }
            else //Else...
            {
                Console.WriteLine("Opening Settings...");
                OpenSettings(); //Calls the 'OpenSettings' method.
                Console.WriteLine("Settings open.");
            }
        }

        void OpenSettings() //This method creates a new object of 'SettingsForm' and displays it.
        {
            settings = new SettingsForm(); //Create an object of 'SettingsForm' called 'settings'.
            settings.Show(); //Show the 'settings' form.
        }

        void CloseSettings() //This method closes the 'settings' form.
        {
            settings.Close(); //Close the 'settings' form.
        }

        public void CheckForExistence() //This method checks if there is a file at the directory the user chose and tells the program the result.
        {
            if (Properties.Settings.Default.useCustomDirectory) //If the user has chosen to use a custom directory, then...
            {
                gamePath = Properties.Settings.Default.customDirectory + "/game/landnite.exe"; //Set the 'gamePath' to the custom directory + "/game/landnite.exe".
                Console.WriteLine("Using custom directory at '" + gamePath + "'.");
            }
            else //Else...
            {
                gamePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/game/landnite.exe"; //Set the 'gamePath' to the default directory.
                Console.WriteLine("Using default directory at '" + gamePath + "'.");
            }

            if (File.Exists(gamePath)) //If a file exists at the chosen 'gamePath', then...
            {
                playButtonState = 1; //Sets the 'playButtonState' to 1.
                playButton.Text = playButtonText[1]; //Changes the text of the 'playButton' to 'PLAY'.
                Console.WriteLine("Game exists.");
            }
            else //Else...
            {
                playButtonState = 2; //Sets the 'playButtonState' to 2.
                playButton.Text = playButtonText[2]; //Changes the text of the 'playButton' to 'REPAIR'.
                Console.WriteLine("Game does not exist.");
            }
        }
    }
}