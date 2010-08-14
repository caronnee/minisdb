using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace myDb
{

    public enum Forms
    {
        FormEnd,
        FormFormular,
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
            MyForm activeForm = new Uvod();
            while (activeForm != null)
            {
                Application.Run(activeForm);
                if (activeForm.endCode() > 0)
                {
                    switch (activeForm.endCode())
                    {
                        case Forms.FormCreateBd: activeForm = new Create();
                            break;
                        case Forms.FormFormular: activeForm = new Formular(activeForm.getFinalWord());
                            break;
                        default: throw new Exception("No such type in zero level switch handled");
                    }
                }
                else activeForm = null;
            }
        }
    }
}
