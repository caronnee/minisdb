using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Minis
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Text;

    public partial class SelectContent : TabPage
    {
        public delegate void SetGrid(DataGridView grid);
        public event SetGrid setGrid;

        public delegate void DataToGrid(DataGridView gr, string Conditions);
        public event DataToGrid fillGrid;

        public delegate void DeleteData(DataGridView gr);
        public event DeleteData deleteData;

        public delegate void EditRecords(List<Value> toChange);
        public event EditRecords edit;

        public delegate void RecordChosen(Value v);
        public event RecordChosen recordChosen;

        public SelectContent()
        {
            InitializeComponent();
            // init grid according to some filter?
            RecordsManager.LoadColumns(this.results);
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
            if ((this.controlPanel == null) || this.controlPanel.IsDisposed)
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
    }
}
