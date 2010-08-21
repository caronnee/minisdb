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
        private List<AbstractControl> toAddRecords;
        private Panel recordPanel;
        private Panel buttonPanel; //jaj, tu by sa mi hodilo QT!
        private NumericUpDown howMany;
        private int numberOfValues;

        /* events */
        /* event no adding rows */
        public delegate void addRecordsHandler(object sender, RecordEventArgs rea);
        public event addRecordsHandler addRecord;

        /* event on adding rows */
        public delegate void addRowHandler(InsertStrip sender);
        public event addRowHandler addRow;

        protected virtual void onAddRecord(RecordEventArgs args)
        {
            if (addRecord == null)
                return;
            addRecord(this, args);
        }
        protected virtual void onAddRow()
        {
            if (addRow == null)
                return;
            addRow(this);
        }

        public InsertStrip()
            : base("Insert")
        {
            this.toAddRecords = new List<AbstractControl>();
            recordPanel = new Panel();
            buttonPanel = new Panel();
            buttonPanel.AutoSize = true;
            //two separate panels, one scrollable, other stacic
            // button for adding new rows & number of rows
            System.Windows.Forms.Button addButton = new System.Windows.Forms.Button();
            //
            addButton.Text = "Add selected number of rows";
            addButton.AutoSize = true;
            addButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Right;
            addButton.Location = new System.Drawing.Point(0,0);
            addButton.Click += new EventHandler(addRows_click);
            buttonPanel.Controls.Add(addButton);

            howMany = new NumericUpDown();
            howMany.Minimum = 1;
            howMany.Location = new System.Drawing.Point(addButton.Width + 10, 0);

            addButton.Click += new System.EventHandler(addButton_Click);
            //raise event
        }
        /* add row to */
        public void add(List<AbstractControl> ctrls) //row..FUJ, budem musiet pretypovavat na controly
        {
            if (ctrls.Count == 0)
                throw new Exception("Zero attributes, not legal database!");
            this.numberOfValues = ctrls.Count;

            Control c = (Control)ctrls[0];
            System.Drawing.Point point = new System.Drawing.Point(0,toAddRecords.Count * c.Height);
            
            c.Location = new System.Drawing.Point(point.X,point.Y);
            this.recordPanel.Controls.Add(c);
            for (int i = 1; i < ctrls.Count; i++)
            {
                c = (Control)ctrls[i];
                point = new System.Drawing.Point(point.X + ((Control)ctrls[i - 1]).Width + 10, point.Y);
                c.Location = point;
                this.recordPanel.Controls.Add(c);
            }
            this.toAddRecords.AddRange(ctrls);
        }
        void addRows_click(object sender, EventArgs e)
        {
            for (int i = 0; i < howMany.Value; i++)
            {
                this.onAddRow();
            }
        }
        void addButton_Click(object sender, System.EventArgs args)
        {
            //zistime vsetky recordy, ktore na uzibvatel zadal..ZAJTRA/VECER
            List<Record> r = new List<Record>();
            for (int i = 0; i < toAddRecords.Count; i += this.numberOfValues)
            {
                Record record = new Record();
                for (int j = 0; j < this.numberOfValues; j++)
                    record.add(toAddRecords[i + j].getValue());
            }
            RecordEventArgs e = new RecordEventArgs(r);
            onAddRecord(e);
        }
    }
}
