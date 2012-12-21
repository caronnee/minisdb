using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Minis
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
            Application.SetCompatibleTextRenderingDefault(false); //IF sa spravi tu
            Application.Run (new MainContainer());
        }
    }
}
