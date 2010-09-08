using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;

namespace myDb
{
    public class MyToolStrip : System.Windows.Forms.ToolStripMenuItem
    {
        private System.Windows.Forms.TabPage tabpage;
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
        private int heigthToAdd;
        private int numberOfValues; //na ukladanie do jedneho pola
        private Panel recordPanel;
        private Panel buttonPanel; //jaj, tu by sa mi hodilo QT!
        private NumericUpDown howMany;
        private List<Label> labels;
        private List<AbstractControl> controls;
        private List<AbstractControl> toAddRecords;

        /* events */
        /* event no adding values */
        public delegate void addRecordsHandler(object sender, RecordEventArgs rea);
        public event addRecordsHandler addRecord;

        /* event on adding rows */
        public delegate void addRowHandler(InsertStrip sender);
        public event addRowHandler addRow;

        /* event on setting labels */
        public delegate void AddLabels(InsertStrip sender);
        public event AddLabels addLabels;

        protected virtual void onAddLabels()
        {
            if (addLabels == null)
                return;
            addLabels(this);
        }
        protected virtual void onAddRow()
        {
            if (addRow == null)
                return;
            addRow(this);
        }
        protected virtual void onAddRecord(RecordEventArgs args)
        {
            if (addRecord == null)
                return;
            addRecord(this, args);
        }
        public void setNames(List<string> names)
        {
            for (int i = 0; i < names.Count; i++)
            {
                Label l = new Label();
                l.Text = names[i];
                labels.Add(l);
            }
        }
        public InsertStrip()
            : base("Insert")
        {
            this.labels = new List<Label>();
            this.toAddRecords = new List<AbstractControl>();
            this.controls = new List<AbstractControl>();
            this.heigthToAdd = 0;

            recordPanel = new Panel();
            recordPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            recordPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            recordPanel.AutoScroll = true;

            buttonPanel = new Panel();
            buttonPanel.AutoSize = true;
            buttonPanel.Size = new System.Drawing.Size(0, 0);
            buttonPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            //two separate panels, one scrollable, other stacic

            // button for adding new rows & number of rows
            System.Windows.Forms.Button addButton =
                new System.Windows.Forms.Button();

            addButton.Text = "Add selected number of rows";
            addButton.AutoSize = true;
            addButton.Anchor = System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left;
            addButton.Location = new System.Drawing.Point(10, 10);
            addButton.Click += new EventHandler(addRows_click);

            buttonPanel.Controls.Add(addButton);

            howMany = new NumericUpDown();
            howMany.Minimum = 1;
            howMany.Maximum = 99; //NAHODNE obmedzenie - TODO
            howMany.Location = new System.Drawing.Point(addButton.Location.X + addButton.PreferredSize.Width + 10, 10);

            buttonPanel.Controls.Add(howMany);

            addButton = new Button();
            addButton.Text = "Add selected records";
            addButton.AutoSize = true;
            addButton.Location = new System.Drawing.Point(howMany.Location.X + howMany.Width + 10, 0);
            addButton.Click += new System.EventHandler(addButton_Click);
            buttonPanel.Controls.Add(addButton);

            getTab().Controls.Add(buttonPanel);
            getTab().Controls.Add(recordPanel);
            getTab().Resize += new EventHandler(InsertStrip_Resize);

            this.MouseUp += new MouseEventHandler(internal_clean);
            this.getTab().MouseUp += new MouseEventHandler(tabActive);

            InsertStrip_Resize(null, null);
        }
        /* sets the tab to be active */
        void tabActive(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                //		getTab().Parent.Controls.Remove(this.getTab()); //TEST!
                //		toto bude platne pre vsetky taby
            }
        }
        /* sets labels according to labels */
        private void internal_clean(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            onAddRow();
            onAddLabels();
            if (getTab().Parent == null)
                return;
            if (labels.Count != this.controls.Count)
                throw new Exception("Labels and boxes have different dimensions ");
            //a to je uplne jedno kde to tam je...
            for (int i = 0; i < labels.Count; i++)
            {
                labels[i].Location = new System.Drawing.Point(((Control)controls[i]).Location.X, 0);

                ((Control)controls[i]).Location = new System.Drawing.Point(labels[i].Location.X, labels[i].PreferredHeight + 10);
            }
            for (int i = 0; i < labels.Count; i++)
                recordPanel.Controls.Add(labels[i]);
            this.heigthToAdd += labels[0].PreferredHeight +10;
        }
        void InsertStrip_Resize(object sender, EventArgs e)
        {
            recordPanel.Location = new System.Drawing.Point(0, 0);
            recordPanel.Size = new System.Drawing.Size(getTab().Width,
                getTab().Height - buttonPanel.PreferredSize.Height);
            buttonPanel.Location = new System.Drawing.Point(0,
                recordPanel.Height - recordPanel.Location.X);
        }
        /* add row to */
        public void add(List<AbstractControl> ctrls) 
        {
            if (ctrls.Count == 0)
                throw new Exception("Zero attributes, not legal database!");

            this.numberOfValues = ctrls.Count;
            this.controls.AddRange(ctrls);

            Control c = (Control)ctrls[0];
            System.Drawing.Point point = new System.Drawing.Point(0, this.heigthToAdd);
            c.Location = new System.Drawing.Point(0, this.heigthToAdd);
            this.recordPanel.Controls.Add(c);

            for (int i = 1; i < ctrls.Count; i++)
            {
                c = (Control)ctrls[i];
                point = new System.Drawing.Point(point.X + ((Control)ctrls[i - 1]).Width + 10, point.Y);// FIXME UPRAVIT
                c.Location = point;
                this.recordPanel.Controls.Add(c);
            }
            this.toAddRecords.AddRange(ctrls);
            this.heigthToAdd += c.Height + 10;
        }
        /* sender calls for filling boxes */
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
                r.Add(record);
            }
            RecordEventArgs e = new RecordEventArgs(r);
            onAddRecord(e);
        }
    }
    public class SelectStrip : MyToolStrip
    {
        public delegate void SetGrid(DataGridView grid); //nejak osetrit, aby to bolo len jedine?
        public event SetGrid setGrid;

        private TextBox select;
        private Button search;
        private DataGridView results;

        public SelectStrip()
            : base("Select")
        {
            search = new Button();
            search.Text = "Search";
            search.AutoSize = true;
            search.Location = new System.Drawing.Point(this.Width - search.Width - 10,
                    this.Height - search.Height - 10);
            search.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            select = new TextBox();
            select.Multiline = true;
            select.Size = new System.Drawing.Size(this.Width, this.Height);
            select.Location = new System.Drawing.Point(0, 0);
            select.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            results = new DataGridView();
            results.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            results.Location = new System.Drawing.Point(select.Location.X, select.Location.Y + select.Height + 10);
            search.Click += new EventHandler(this.start);//potom to nejak premenovat
            getTab().GotFocus +=new EventHandler(callSetGrid);
            this.getTab().Controls.Add(select);
            this.getTab().Controls.Add(search);
            this.getTab().Controls.Add(results);
        }
        protected void start(object sender, EventArgs e)
        {
            //TODO
        }
        protected void callSetGrid(object sender, EventArgs e)
        {
            onSetGrid();
        }
        public void onSetGrid()
        {
            if (setGrid == null)
                return; //mozno throw exception
            setGrid(this.results);
        }
    }
}
