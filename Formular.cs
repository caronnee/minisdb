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
            records.addRow(this.insertToolStripMenuItem, values);
        }
        void selectToolStripMenuItem_recordChosen(Value v)
        {
            this.tabs.Controls.Add(records.getDetail(v));
        }
        void tabs_MouseClick(object sender, MouseEventArgs e)
        {
            TabControl tabControl = sender as TabControl;

            if (e.Button != MouseButtons.Middle)
                return;

            TabPage tabPageCurrent = null;

            for (var i = 0; i < tabControl.TabCount; i++)
            {
                if (!tabControl.GetTabRect(i).Contains(e.Location))
                    continue;
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
    }
}
