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
        public Formular(string dbName)
        {
            records = new Records(dbName);
            InitializeComponent();

            this.insertToolStripMenuItem.addRecord += new InsertStrip.addRecordsHandler(records.addRecord);
            this.insertToolStripMenuItem.addRow += new InsertStrip.addRowHandler(records.addRow);
            this.insertToolStripMenuItem.addLabels += new InsertStrip.AddLabels(records.addNames);
            this.tabs.MouseClick += new MouseEventHandler(tabs_MouseClick);
            this.Disposed += new EventHandler(Formular_Disposed);
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
