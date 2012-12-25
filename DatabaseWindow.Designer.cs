using System.Collections.Generic;

namespace Minis
{
    partial class DatabaseWindow
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
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        //private void Menu_Click(object sender, System.EventArgs e)
        //{
        //    if (!this.tabs.Contains
        //        this.tabs.Controls.Add(((MyToolStrip) sender).getTab());
        //    this.tabs.SelectedIndex =
        //        this.tabs.Controls.GetChildIndex(((MyToolStrip) sender).getTab());
        //}
        private void InitializeComponent()
        {
            this.infoBox = new System.Windows.Forms.TextBox();
            this.tabs = new System.Windows.Forms.TabControl();
            this.results = new System.Windows.Forms.TabPage();
            this.grid = new System.Windows.Forms.DataGridView();
            this.refresh = new System.Windows.Forms.Button();
            this.insertPage = new Minis.InsertContent();
            this.selectPage = new Minis.SelectContent();
            this.infoLabel = new System.Windows.Forms.Label();
            this.tabs.SuspendLayout();
            this.results.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // infoBox
            // 
            this.infoBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.infoBox.Location = new System.Drawing.Point(685, 0);
            this.infoBox.Multiline = true;
            this.infoBox.Name = "infoBox";
            this.infoBox.ReadOnly = true;
            this.infoBox.Size = new System.Drawing.Size(156, 300);
            this.infoBox.TabIndex = 0;
            this.infoBox.Text = "Information: \r\n";
            // 
            // tabs
            // 
            this.tabs.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabs.Controls.Add(this.results);
            this.tabs.Controls.Add(this.insertPage);
            this.tabs.Controls.Add(this.selectPage);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Multiline = true;
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(685, 300);
            this.tabs.TabIndex = 3;
            this.tabs.TabStop = false;
            // 
            // results
            // 
            this.results.Controls.Add(this.grid);
            this.results.Controls.Add(this.refresh);
            this.results.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.results.Location = new System.Drawing.Point(29, 4);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(652, 292);
            this.results.TabIndex = 0;
            this.results.Text = "Results";
            this.results.UseVisualStyleBackColor = true;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.ColumnHeadersHeight = 28;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(652, 263);
            this.grid.TabIndex = 0;
            this.grid.DoubleClick += new System.EventHandler(this.grid_DoubleClick);
            // 
            // refresh
            // 
            this.refresh.AutoSize = true;
            this.refresh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.refresh.Location = new System.Drawing.Point(0, 263);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(652, 29);
            this.refresh.TabIndex = 1;
            this.refresh.Text = "Refresh";
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // insertPage
            // 
            this.insertPage.Location = new System.Drawing.Point(29, 4);
            this.insertPage.Name = "insertPage";
            this.insertPage.Size = new System.Drawing.Size(652, 292);
            this.insertPage.TabIndex = 1;
            this.insertPage.Text = "Insert";
            this.insertPage.UseVisualStyleBackColor = true;
            // 
            // selectPage
            // 
            this.selectPage.Location = new System.Drawing.Point(29, 4);
            this.selectPage.Name = "selectPage";
            this.selectPage.Size = new System.Drawing.Size(652, 292);
            this.selectPage.TabIndex = 2;
            this.selectPage.Text = "Select";
            this.selectPage.UseVisualStyleBackColor = true;
            // 
            // infoLabel
            // 
            this.infoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(1120, 22);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(25, 13);
            this.infoLabel.TabIndex = 2;
            this.infoLabel.Text = "Info";
            // 
            // DatabaseWindow
            // 
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.infoBox);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "DatabaseWindow";
            this.Size = new System.Drawing.Size(841, 300);
            this.tabs.ResumeLayout(false);
            this.results.ResumeLayout(false);
            this.results.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }    
        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.TextBox infoBox;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.TabPage results;
        private System.Windows.Forms.Button refresh;
        private SelectContent selectPage;
        private InsertContent insertPage;
    }
}
