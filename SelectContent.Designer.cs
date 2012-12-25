namespace Minis
{
    partial class SelectContent
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.select = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.saveSearch = new System.Windows.Forms.Button();
            this.results = new System.Windows.Forms.DataGridView();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.gridColumns = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editRecordsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.results)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // select
            // 
            this.select.Dock = System.Windows.Forms.DockStyle.Top;
            this.select.Location = new System.Drawing.Point(0, 0);
            this.select.Multiline = true;
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(314, 73);
            this.select.TabIndex = 2;
            // 
            // search
            // 
            this.search.AutoSize = true;
            this.search.Dock = System.Windows.Forms.DockStyle.Top;
            this.search.Location = new System.Drawing.Point(0, 73);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(314, 23);
            this.search.TabIndex = 1;
            this.search.Text = "Search";
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // results
            // 
            this.results.AllowUserToAddRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.NullValue = "-";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.results.DefaultCellStyle = dataGridViewCellStyle3;
            this.results.Dock = System.Windows.Forms.DockStyle.Fill;
            this.results.Location = new System.Drawing.Point(0, 96);
            this.results.Name = "results";
            this.results.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.results.Size = new System.Drawing.Size(314, 111);
            this.results.TabIndex = 0;
            this.results.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.results_SortCompare);
            this.results.DoubleClick += new System.EventHandler(this.results_DoubleClick);
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.gridColumns);
            this.buttonPanel.Controls.Add(this.deleteButton);
            this.buttonPanel.Controls.Add(this.editRecordsButton);
            this.buttonPanel.Controls.Add(this.saveSearch);
            this.buttonPanel.Size = new System.Drawing.Size(100,50);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 207);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(314, 20);
            this.buttonPanel.TabIndex = 3;
            // 
            // gridColumns
            // 
            this.gridColumns.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridColumns.Location = new System.Drawing.Point(150, 0);
            this.gridColumns.Name = "gridColumns";
            this.gridColumns.Size = new System.Drawing.Size(75, 20);
            this.gridColumns.TabIndex = 0;
            this.gridColumns.Text = "Choose columns";
            this.gridColumns.Click += new System.EventHandler(this.gridColumns_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.deleteButton.Location = new System.Drawing.Point(75, 0);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 20);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "Delete";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editRecordsButton
            // 
            this.editRecordsButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.editRecordsButton.Location = new System.Drawing.Point(0, 0);
            this.editRecordsButton.Name = "editRecordsButton";
            this.editRecordsButton.Size = new System.Drawing.Size(75, 20);
            this.editRecordsButton.TabIndex = 2;
            this.editRecordsButton.Text = "Edit";
            this.editRecordsButton.Click += new System.EventHandler(this.editRecordsButton_Click);
            //
            // SaveSearch
            //
            this.saveSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.saveSearch.Text = "Save search";
            this.saveSearch.TabIndex = 3;
            // 
            // SelectContent
            // 
            this.Controls.Add(this.results);
            this.Controls.Add(this.search);
            this.Controls.Add(this.select);
            this.Controls.Add(this.buttonPanel);
            this.Size = new System.Drawing.Size(314, 227);
            ((System.ComponentModel.ISupportInitialize)(this.results)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox select;
        private System.Windows.Forms.Button saveSearch;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.DataGridView results;
        private System.Windows.Forms.Button gridColumns;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editRecordsButton;
        private System.Windows.Forms.Panel buttonPanel;
        private GridPanel controlPanel;

        #endregion

    }
}
