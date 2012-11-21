using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Minis
{
    // formular that is possible to show as main window
    public enum Forms
    {
        // in this formular user can choose if it create a database or will load old one
        FormLoad,
        // bye bye formular - program should end at this state
        FormEnd,
        // database id loaded
        FormFormular,
        // formular for creating database - insetring columns etc
        FormCreateBd
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false); //IF sa spravi tu
            Application.Run (new MainContainer());
        }
    }
}
