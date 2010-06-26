using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace myDb
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
            MyForm activeForm = new Create();
            while (activeForm != null)
            {
                Application.Run(activeForm);
                if (activeForm.endCode() > 0)
                {
                    switch (activeForm.endCode())
                    {
                        case 1: activeForm = new Create();
                            break;
                        case 2: activeForm = new Formular();
                            break;
                        default: throw new Exception("No such type in zero level switch handled");
                    }
                }
                else activeForm = null;
            }
        }
    }
}
