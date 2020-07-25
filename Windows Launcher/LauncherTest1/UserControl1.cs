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
using System.Windows.Forms;

namespace LauncherTest1
{
    public partial class InitialLanguage : Form
    {
        public InitialLanguage()
        {
            InitializeComponent();
            //LanguageSwitcher();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            ApplyLanguage();
        }

        void ApplyLanguage()
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
            Application.Restart();
        }

        int lang = 0;

        void LanguageSwitcher()
        {
            var timer = new System.Threading.Timer(
            e => SwitchLanguage(),
            null,
            TimeSpan.Zero,
            TimeSpan.FromSeconds(3));
        }

        void SwitchLanguage()
        {
            if (lang == 0)
            {
                SwitchToEnglish();
                lang++;
            }
            else if (lang == 1)
            {
                SwitchToFrench();
                lang++;
            }
            else if (lang == 2)
            {
                SwitchToPolish();
                lang = 0;
            }
        }

        void SwitchToEnglish()
        {
            titleLabel.Text = "Choose your language";
        }

        void SwitchToFrench()
        {
            titleLabel.Text = "Choisissez votre langue";
        }

        void SwitchToPolish()
        {
            titleLabel.Text = "Wybierz swój język";
        }
    }
}
