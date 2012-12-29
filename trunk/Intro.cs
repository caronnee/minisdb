using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Minis
{
    public partial class Intro : StateManager
    {
        public Intro()
        {       
            InitializeComponent();
            //Load to combobox all databases
            DirectoryInfo dirInfo = new DirectoryInfo(".");
            FileInfo[] dbs = dirInfo.GetFiles("*" + Misc.fileType);
            if (dbs.Length != 0)
            {
                this.chooseDb.Items.AddRange(dbs);
                this.chooseDb.SelectedIndex = 0;
            }
        }
        public override void InitState()
        {
            if (this.chooseDb.Items.Count == 0)
            {
                // create immediately some database
                //OnStateChanged(State.StateCreateDatabase,"");
                OnStateChanged(State.StateCreateDatabase,"");
            }
        }
        
        private void CreateButton_Click(object sender, EventArgs e)
        {
            OnStateChanged( State.StateCreateDatabase, "" );
        }
        private void Load_Click(object sender, EventArgs e)
        {
            if (this.chooseDb.SelectedIndex < 0)
            {
                MessageBox.Show("Hold on! No database chosen");
                return;
            }
            OnStateChanged(State.StateLoadDatabase, this.chooseDb.SelectedItem.ToString() );
        }
        private void removeButton_Click(object sender, EventArgs e)
        {
            Debug.Assert(this.chooseDb.Items.Count == 0);
            DialogResult result = MessageBox.Show("Are you sure to remove " + this.chooseDb.SelectedItem.ToString()+ "?","Warning!",MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                return;
            File.Delete("./" + this.chooseDb.SelectedItem.ToString());
            this.chooseDb.Items.Remove(this.chooseDb.SelectedItem);
            if (chooseDb.Items.Count == 0)
            {
                OnStateChanged(State.StateCreateDatabase,"");
            }
            this.chooseDb.SelectedIndex = 0;
        }
    }
}
