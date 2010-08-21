using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;

namespace myDb
{
    public class MyToolStrip : System.Windows.Forms.ToolStripMenuItem
    {
        public static System.Windows.Forms.TabPage createTab(string name)
        {
            System.Windows.Forms.TabPage tabPage = new System.Windows.Forms.TabPage();
            tabPage.Location = new System.Drawing.Point(4, 22);
            tabPage.Name = name;
            tabPage.Padding = new System.Windows.Forms.Padding(3);
            tabPage.Size = new System.Drawing.Size(490, 197);
            tabPage.TabIndex = 0;
            tabPage.Text = name;
            tabPage.UseVisualStyleBackColor = true;
            return tabPage;
        }

        private System.Windows.Forms.TabPage tabpage;
        public MyToolStrip(string name)
        {
            tabpage = createTab(name);
        }

        public System.Windows.Forms.TabPage getTab()
        {
            return tabpage;
        }
    }
    public class InsertStrip : MyToolStrip
    {
        public List<Record> toAddRecords;

        public delegate void addRecordsHandler(object sender, RecordEventArgs rea);
        public event addRecordsHandler addRecord;

        protected virtual void onAddRecord(RecordEventArgs args)
        {
            if (addRecord == null)
                return;
            addRecord(this, args);
        }

        public InsertStrip()
            : base("Insert")
        {
            this.toAddRecords = new List<Record>();
            //add Button
            System.Windows.Forms.Button addButton = new System.Windows.Forms.Button();
            addButton.Text = "add records";
            addButton.AutoSize = true;
            addButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Right;
            System.Drawing.Size s = getTab().Size;
            addButton.Location = new System.Drawing.Point(s.Width - addButton.Width - 10,
                s.Height - addButton.Height - 10);
            getTab().Controls.Add(addButton);
            addButton.Click += new System.EventHandler(addButton_Click);
            //raise event
        }

        void addButton_Click(object sender, System.EventArgs args)
        {
            //zistime vsetky recordy, ktore na uzibvatel zadal..ZAJTRA/VECER
            RecordEventArgs e = new RecordEventArgs(toAddRecords);
            onAddRecord(e);
        }
    }
}
