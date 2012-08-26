using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace myDb
{
    public class DisplayedForm : Form
    {
        public DisplayedForm()
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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AbstractForm
            // 
            this.ClientSize = new System.Drawing.Size(505, 342);
            this.Name = "AbstractForm";
            this.ResumeLayout(false);

        }
    }
}