using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace myDb
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
            DisplayedForm activeForm = new CreateLoadDbForm();
            if (activeForm.endCode() == Forms.FormCreateBd)
                activeForm = new Create();
            while (activeForm != null)
            {
                Application.Run(activeForm);
                if (activeForm.endCode() == Forms.FormEnd) //bez toho, zby zmenil
                    break;
                switch (activeForm.endCode())
                {
                    case Forms.FormLoad:
                        activeForm = new CreateLoadDbForm();
                        break;
                    case Forms.FormCreateBd:
                        activeForm = new Create();
                        break;
                    case Forms.FormFormular:
                        activeForm = new Formular(activeForm.getFinalWord());
                        break;
                    default: throw new Exception("No such type in zero level switch handled");
                }
            }
        }
    }
}
