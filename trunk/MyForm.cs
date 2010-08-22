using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace myDb
{
    public class MyForm : Form
    {
        public MyForm()
        {
            endState = Forms.FormEnd;
            finalWord = "";
        }
        public Forms endCode()
        {
            return endState;
        }
        public string getFinalWord()
        {
            return finalWord;
        }

        protected Forms endState;
        protected string finalWord;
    }
}