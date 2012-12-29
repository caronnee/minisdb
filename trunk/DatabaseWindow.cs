using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Minis
{
    public partial class DatabaseWindow : StateManager
    {
        public DatabaseWindow(string dbName)
        {
            RecordsManager.Load(dbName);
            InitializeComponent();
            
            this.selectPage.fillGrid += new SelectContent.DataToGrid(RecordsManager.Filter);
            //this.selectToolStripMenuItem.deleteData += new SelectContent.DeleteData(records.delete);
            //this.selectToolStripMenuItem.edit += new SelectContent.EditRecords(this.edit);
            RecordsManager.LoadColumns(this.grid);
            RecordsManager.Filter(this.grid, "");

            this.insertPage.addRecord += new InsertContent.addRecordsHandler(RecordsManager.AddRecords);
            this.insertPage.addRow += new InsertContent.addRowHandler(RecordsManager.CreateEmpty);
            //this.selectToolStripMenuItem.recordChosen += new SelectContent.RecordChosen(selectToolStripMenuItem_recordChosen);
            this.tabs.MouseClick += new MouseEventHandler(tabs_MouseClick);
            RecordsManager.infoHandler += new RecordsManager.InfoHandler(records_infoHandler);
            RecordsManager.updateHandler += new RecordsManager.UpdateHandler(this.UpdateTabs);

            this.Disposed += new EventHandler(Formular_Disposed);
        }
        void UpdateTabs(String name, String value)
        {
            switch (name)
            {
                case Misc.savedSearch:
                    {
                        break;
                    }
                default:
                    break;
            }
        }
        void changeDb_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        void backToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            //TODO change to infrom main component
        }
        void records_infoHandler(string s)
        {
            this.infoBox.Text += s;
        }
        void refresh_Click(object sender, System.EventArgs e)
        {
            RecordsManager.Filter(this.grid, "");
        }
        private void edit(List<Value> values)
        {
            //this.insertToolStripMenuItem.
            //this.insertToolStripMenuItem.removeRows();
            //records.addRow(this.insertToolStripMenuItem, values); //inrt najskor cleannuty
            //if (this.insertToolStripMenuItem.getTab().Parent != this.tabs)
            //    this.tabs.Controls.Add(this.insertToolStripMenuItem.getTab());
            //this.tabs.SelectedTab = this.insertToolStripMenuItem.getTab();
        }
        void selectToolStripMenuItem_recordChosen(Value v)
        {
            //if not exists
            foreach (TabPage p in this.tabs.Controls)
                if (p.Text.Equals(v.ToString()))
                {
                    this.tabs.SelectedTab = p;
                    return;
                }
            TabPage t = RecordsManager.GetDetail(v);
            this.tabs.Controls.Add(t);
            this.tabs.SelectedTab = t;
        }
        void tabs_MouseClick(object sender, MouseEventArgs e)
        {
            TabControl tabControl = sender as TabControl;

            if (e.Button != MouseButtons.Middle)
                return;

            TabPage tabPageCurrent = null;

            for (int i = 0; i < tabControl.TabCount; i++)
            {
                if (!tabControl.GetTabRect(i).Contains(e.Location))
                    continue;
                if (tabControl.TabPages[i].Text.ToLower().Equals("all records"))
                    return;
                tabPageCurrent = tabControl.TabPages[i];
                break;
            }
            if (tabPageCurrent != null)
                tabControl.TabPages.Remove(tabPageCurrent);

        }    
        void Formular_Disposed(object sender, EventArgs e)
        {
            RecordsManager.SaveActive();
        }
        void grid_DoubleClick(object sender, System.EventArgs e)
        {
            System.Windows.Forms.DataGridView d = sender as System.Windows.Forms.DataGridView;
            foreach (System.Windows.Forms.DataGridViewRow r in d.SelectedRows)

                selectToolStripMenuItem_recordChosen(r.Cells[Misc.Id].Value as Value);
        }
    }
}
