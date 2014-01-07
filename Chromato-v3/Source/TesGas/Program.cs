﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ChromatoTool.ini;

namespace TestGas
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
            Setting.Read();

            Application.Run(new TestGasFrm());
        }
    }
}
