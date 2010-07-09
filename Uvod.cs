using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace myDb
{
    public partial class Uvod : MyForm
    {
        public Uvod()
        {       
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            endState = Forms.FormCreateBd;
            this.Close();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            endState = Forms.FormFormular;
            this.finalWord = (string)this.chooseDb.SelectedItem;
            this.Close();
        }
    }
}
