using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace Minis
{
    //public class MyToolStrip : ToolStripMenuItem
    //{
    //    private System.Windows.Forms.TabPage tabpage;
    //    public static System.Windows.Forms.TabPage createTab(string name)
    //    {
    //        System.Windows.Forms.TabPage tabPage = new System.Windows.Forms.TabPage();
    //        tabPage.Location = new System.Drawing.Point(4, 22);
    //        tabPage.Name = name;
    //        tabPage.Padding = new System.Windows.Forms.Padding(3);
    //        tabPage.Size = new System.Drawing.Size(490, 197);
    //        tabPage.TabIndex = 0;
    //        tabPage.Text = name;
    //        tabPage.UseVisualStyleBackColor = true;
    //        return tabPage;
    //    }

    //    public MyToolStrip(string name)
    //    {
    //        tabpage = createTab(name);
    //    }
    //    public System.Windows.Forms.TabPage getTab()
    //    {
    //        return tabpage;
    //    }
    //}
    public class SelectStrip : Control
    {
        public delegate void SetGrid(DataGridView grid); //nejak osetrit, aby to bolo len jedine? Inak je to nebezpecne..alebo delegate ide sekvencne?
        public event SetGrid setGrid;

        public delegate void DataToGrid(DataGridView gr, string Conditions );
        public event DataToGrid fillGrid;

        public delegate void DeleteData(DataGridView gr);
        public event DeleteData deleteData;

        public delegate void EditRecords(List<Value> toChange);
        public event EditRecords edit;

        public delegate void RecordChosen(Value v); //preoc neprenasam cele, je mi tiez zahadou...
        public event RecordChosen recordChosen;

        private TextBox select;
        private Button search;
        private DataGridView results;
        private Button gridColumns;
        private Button deleteButton;
        private Button editRecordsButton;
        private Panel buttonPanel;
        private GridPanel controlPanel;

        public SelectStrip()
            : base("Select")
        {
            select = new TextBox();
            select.Multiline = true;
            // use dock
            //select.Size = new System.Drawing.Size(getTab().Width, 50);
            select.Location = new System.Drawing.Point(0, 0);
            select.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            search = new Button();
            search.Text = "Search";
            search.AutoSize = true;
            //search.Location = new System.Drawing.Point(getTab().Width - search.Width - 10,
             //       getTab().Height - search.Height - 10);
            search.Anchor = AnchorStyles.Bottom| AnchorStyles.Right;
            search.Click += new EventHandler(search_Click);
        
            results = new DataGridView();
            results.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            results.Location = new System.Drawing.Point(select.Location.X, select.Location.Y + select.Height + 10);
            results.AllowUserToAddRows = false;
            results.SortCompare += new DataGridViewSortCompareEventHandler(results_SortCompare);
            results.DefaultCellStyle.NullValue = "-";
            results.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            select.Dock = DockStyle.Top;
            results.Dock = DockStyle.Top| DockStyle.Fill;
            search.Dock = DockStyle.Top;

            //getTab().GotFocus +=new EventHandler(callSetGrid);
            //moje nove
            this.buttonPanel = new Panel();
            this.buttonPanel.Size = new System.Drawing.Size(100, 20);
            this.buttonPanel.Dock = DockStyle.Bottom;

            this.gridColumns = new Button();
            this.gridColumns.Text = "Choose columns";
            this.gridColumns.Dock = DockStyle.Left;
            this.gridColumns.Click += new EventHandler(gridColumns_Click);

            this.deleteButton = new Button();
            this.deleteButton.Text = "Delete";
            this.deleteButton.Dock = DockStyle.Left;
            this.deleteButton.Click += new EventHandler(deleteButton_Click);

            this.editRecordsButton = new Button();
            this.editRecordsButton.Text = "Edit";
            this.editRecordsButton.Dock = DockStyle.Left;
            this.editRecordsButton.Click += new EventHandler(editRecordsButton_Click);

           // results.ReadOnly = true;
            //this.getTab().ParentChanged += new EventHandler(SelectStrip_ParentChanged);

            this.Controls.Add(results);
            this.Controls.Add(search);
            this.Controls.Add(select);

            this.buttonPanel.Controls.Add(gridColumns);
            this.buttonPanel.Controls.Add(deleteButton);
            this.buttonPanel.Controls.Add(editRecordsButton);

            this.Controls.Add(buttonPanel);
            this.results.DoubleClick += new EventHandler(results_DoubleClick);
            this.results.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        void editRecordsButton_Click(object sender, EventArgs e)
        {
            onEdit();
        }

        void results_DoubleClick(object sender, EventArgs e)
        {
            onRecordChosen();
        }
        protected void onRecordChosen()
        {
            if (recordChosen == null)
                throw new Exception("No action on chosen record");
            recordChosen(results.SelectedRows[0].Cells[Files.Id].Value as Value);
        }
        protected void onEdit()
        {
            if (results.SelectedRows.Count == 0)
                return;
            List<Value> v = new List<Value>();
            foreach (DataGridViewRow row in results.SelectedRows)
            {
                v.Add(row.Cells[Files.Id].Value as Value);
            }
            edit(v);
        }
        protected void onDeleteData()
        {
            if (deleteData == null)
                return;
            deleteData(this.results);
        }
        protected void onSetGrid()
        {
            if (setGrid == null)
                return; //mozno throw exception
            setGrid(this.results);
        }
        protected void onFillGrid()
        {
            if (fillGrid == null)
                throw new Exception("No connection set");
            fillGrid(this.results, this.select.Text);
        }

        protected void callSetGrid(object sender, EventArgs e)
        {
            onSetGrid();
        }
        void deleteButton_Click(object sender, EventArgs e)
        {
            this.onDeleteData();
        }
        void gridColumns_Click(object sender, EventArgs e)
        {
            if ( (this.controlPanel == null) ||this.controlPanel.IsDisposed)
                this.controlPanel = new GridPanel(this.results);
            this.controlPanel.Show(); ///alebo run?
        }
        void results_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.CellValue1 == null)
            {
                e.SortResult = 0;
                return;
            }
            if (e.CellValue2 == null)
            {
                e.SortResult = 1; //kontrola!
                return;
            }
            e.SortResult = (e.CellValue1 as Value).compare(e.CellValue2 as Value);
        }
        void search_Click(object sender, EventArgs e)
        {
            onFillGrid();
        }
        void SelectStrip_ParentChanged(object sender, EventArgs e)
        {
            if (this.Parent == null)
                return; //skontrolovat
            onSetGrid();
        }
    }
}
