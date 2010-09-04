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
	protected override onClick(EventArgs e)
	{
		base.Click(e);
		active = true;
	}

        public MyToolStrip(string name)
        {
		active = false;
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
        private List<AbstractControl> controls;

        private NumericUpDown howMany;
        private int numberOfValues; //na ukladanie do jedneho pola

        /* events */
        /* event no adding rows */
        public delegate void addRecordsHandler(object sender, RecordEventArgs rea);
        public event addRecordsHandler addRecord;

        /* event on adding rows */
        public delegate void addRowHandler(InsertStrip sender);
        public event addRowHandler addRow;

        /* event on setting labels */
        public delegate void AddLabels(InsertStrip sender);
        public event AddLabels addLabels;

        private List<Label> labels;

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
        public InsertStrip() : base("Insert")
        {
            this.labels = new List<Label>();
            this.toAddRecords = new List<AbstractControl>();
            this.controls = new List<AbstractControl>();

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
                active = false; //toto je FUJ, spolieha sa na to, ze pridam 
		//naco sakra potrebujem active?
//		getTab().Parent.Controls.Remove(this.getTab()); //TEST!
//		toto bude platne pre vsetky taby
	    }
        }
	/* sets labels according to labels */
        private void internal_clean(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            onAddRow();
            onAddLabels();
            if (active)
                return;
            active = true;
            if (labels.Count != this.controls.Count)
                throw new Exception("Labels and boxes have different dimensions ");
            //a to je uplne jedno kde to tam je...
            for (int i = 0; i < labels.Count; i++)
            {
                labels[i].Location = new System.Drawing.Point(((Control)controls[i]).Location.X, 0);

                ((Control) controls[i]).Location = new System.Drawing.Point(recordPanel.Controls[i].Location.X, labels[i].PreferredHeight + 10);
            }
            for (int i = 0; i < labels.Count; i++)
                recordPanel.Controls.Add(labels[i]);
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
        public void add(List<AbstractControl> ctrls) //row..FUJ, budem musiet pretypovavat na controly
        {
            if (ctrls.Count == 0)
                throw new Exception("Zero attributes, not legal database!");

            this.numberOfValues = ctrls.Count;
            this.controls.AddRange(ctrls);

            Control c = (Control)ctrls[0];
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            if (toAddRecords.Count > 0)
                point = new System.Drawing.Point(0, (toAddRecords.Count)*c.PreferredSize.Height + labels[0].PreferredHeight + 10 );

            c.Location = new System.Drawing.Point(point.X, point.Y);
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
            }
            RecordEventArgs e = new RecordEventArgs(r);
            onAddRecord(e);
        }
    }
    public class SelectStrip : MyToolStrip
	{
		public delegate void SetGrid(DataGridView); //nejak osetrit, aby to bolo len jedine?
		public event SetGrid setGrid;

		private Textbox select;
		private Button search;
		private DataGridView results;

		public SelectStrip() : base("Select")
		{
			search = new Button();
			search.Text = "Search";
			search.AutoSize = true;
			search.Location = new Point(this.Width - search.Width - 10, 
					this.Height - search.Height - 10);
			search.Anchor = AnchorStyles.Top | AnchorStyle.Left;

			select= new TextBox();
			select.MultiLine = true;
			select.AutoScroll = true;
			select.Size = new Size(this.Width, this.Height =)
				select.Location = new Point(0,0);
			select.Anchor = AnchorStyles.Top | AnchorStyle.Left;

			results = new DataGridView();
			results.Anchor = AnchorStyles.Top | AnchorStyle.Left;
			results.Location = new Size(select.Location.x, select.location.y+select.Height +10);
			search.Click += new EventHandler(this.start);//potom to nejak premenovat
			this.Controls.Add(select);
			this.Controls.Add(search);
			this.Controls.Add(grid);
		}
		protected void start(object sender, EventArgs e)
		{
			//TODO
		}
		protected override onLoad(EventArgs e)
		{
			onSetGrid();
			base.Load(this,e);
		}

		public void onSetGrid()
		{
			if (setGrid == null)
				return; //mozno throw exception
			setGrid(this.grid);
		}
	}
}
