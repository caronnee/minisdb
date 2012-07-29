using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace myDb
{
    public partial class Formular : MyForm
    {
        private Records records;

        public Formular(string dbName)
        {
            records = new Records(dbName);
            InitializeComponent();
            this.selectToolStripMenuItem.fillGrid += new SelectStrip.DataToGrid(this.records.filter);
            this.selectToolStripMenuItem.deleteData += new SelectStrip.DeleteData(records.delete);
            this.selectToolStripMenuItem.setGrid += new SelectStrip.SetGrid(records.settingGrid);
            this.selectToolStripMenuItem.edit += new SelectStrip.EditRecords(this.edit);

            records.settingGrid(this.grid);
            records.filter(this.grid, "");

            this.insertToolStripMenuItem.addRecord += new InsertStrip.addRecordsHandler(records.addRecord);
            this.insertToolStripMenuItem.addRow += new InsertStrip.addRowHandler(records.addRow);
            this.insertToolStripMenuItem.addLabels += new InsertStrip.AddLabels(records.addNames);
            this.selectToolStripMenuItem.recordChosen += new SelectStrip.RecordChosen(selectToolStripMenuItem_recordChosen);
            this.tabs.MouseClick += new MouseEventHandler(tabs_MouseClick);
            this.records.infoHandler += new Records.InfoHandler(records_infoHandler);
            this.Disposed += new EventHandler(Formular_Disposed);
        }
        void changeDb_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        void backToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.endState = Forms.FormLoad;
            this.Close();
        }
        void records_infoHandler(string s)
        {
            this.infoBox.Text += s;
        }
        void refresh_Click(object sender, System.EventArgs e)
        {
            records.filter(this.grid, "");
        }
        private void edit(List<Value> values)
        {
            //this.insertToolStripMenuItem.
            this.insertToolStripMenuItem.removeRows();
            records.addRow(this.insertToolStripMenuItem, values); //inrt najskor cleannuty
            if (this.insertToolStripMenuItem.getTab().Parent != this.tabs)
                this.tabs.Controls.Add(this.insertToolStripMenuItem.getTab());
            this.tabs.SelectedTab = this.insertToolStripMenuItem.getTab();
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
            TabPage t = records.getDetail(v);
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
            records.save();
        }
        void grid_DoubleClick(object sender, System.EventArgs e)
        {
            System.Windows.Forms.DataGridView d = sender as System.Windows.Forms.DataGridView;
            foreach (System.Windows.Forms.DataGridViewRow r in d.SelectedRows)

                selectToolStripMenuItem_recordChosen(r.Cells[Files.Id].Value as Value);
        }
        private void selectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //show window with the help of how syntx should lok like
            MessageBox.Show( Files.help,"Syntax Help", MessageBoxButtons.OK);
        }

        private void insertToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show( Files.insertHelp,"Insert help", MessageBoxButtons.OK);
        }
    }
}
