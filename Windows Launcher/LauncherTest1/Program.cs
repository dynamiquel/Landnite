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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherTest1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Start();
        }
        static void Start()
        {
            if (Properties.Settings.Default.language == 'e')
            {
                Application.Run(new InitialLanguage());
            }
            else
            {
                Application.Run(new mainForm());
            }
        }

        public static void LanguageSelected()
        {
            Application.Restart();
        }
    }
}
