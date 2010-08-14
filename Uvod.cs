using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace myDb
{
    public partial class Uvod : MyForm
    {
        public Uvod()
        {       
            InitializeComponent();
          
            //Load to combobox all databases
            DirectoryInfo dirInfo = new DirectoryInfo(".");
            FileInfo[] dbs = dirInfo.GetFiles("*.myDb");
            this.chooseDb.Items.AddRange(dbs);
        }
        private void CreateButton_Click(object sender, EventArgs e)
        {
            endState = Forms.FormCreateBd;
            this.Close();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            if (this.chooseDb.SelectedIndex < 0)
            {
                MessageBox.Show("Hold on! No database chosen");
                return;
            }
            endState = Forms.FormFormular;
            this.finalWord = ((FileInfo)this.chooseDb.SelectedItem).Name;
            this.Close();
        }
    }
}
