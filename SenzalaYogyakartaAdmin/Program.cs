﻿using SenzalaYogyakartaManajemenSiswa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SenzalaYogyakartaAdmin
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
            LaunchBar launchBar = new LaunchBar();
            MainLibrary.launchBar = launchBar;
            Application.Run(launchBar);
        }
    }
}
