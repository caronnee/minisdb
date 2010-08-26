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
        }
    }
}
