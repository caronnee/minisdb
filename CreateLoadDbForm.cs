using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Minis
{
    public partial class CreateLoadDbForm : UserControl
    {
        public CreateLoadDbForm()
        {       
            InitializeComponent();
          
            //Load to combobox all databases
            DirectoryInfo dirInfo = new DirectoryInfo(".");
            FileInfo[] dbs = dirInfo.GetFiles("*" + Files.fileType);
            if (dbs.Length == 0)
            {
                // TODO inform about changed formular
            }
            this.chooseDb.Items.AddRange(dbs);
            this.chooseDb.SelectedIndex = 0;
        }
        private void CreateButton_Click(object sender, EventArgs e)
        {
            // TODO inform main formular
        }
        private void Load_Click(object sender, EventArgs e)
        {
            if (this.chooseDb.SelectedIndex < 0)
            {
                MessageBox.Show("Hold on! No database chosen");
                return;
            }
            // TODO inform main formular
        }
        private void removeButton_Click(object sender, EventArgs e)
        {
            if (this.chooseDb.Items.Count == 0)
                return; //ziadne warnig?
            DialogResult result = MessageBox.Show("Are you sure to remove " + this.chooseDb.SelectedItem.ToString()+ "?","Warning!",MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                return;
            File.Delete("./" + this.chooseDb.SelectedItem.ToString());
            this.chooseDb.Items.Remove(this.chooseDb.SelectedItem);
            if (chooseDb.Items.Count == 0)
            {
                // TODO inform main formular
            }
            this.chooseDb.SelectedIndex = 0;
        }
    }
}
