using System.Collections.Generic;

namespace myDb
{
    partial class Formular
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
        private void Menu_Click(object sender, System.EventArgs e)
        {
            if (!this.tabs.Contains(((MyToolStrip) sender).getTab()))
                this.tabs.Controls.Add(((MyToolStrip) sender).getTab());
            this.tabs.SelectedIndex =
                this.tabs.Controls.GetChildIndex(((MyToolStrip) sender).getTab());
        }
        private void InitializeComponent()
        {
            this.infoBox = new System.Windows.Forms.TextBox();
            this.tabs = new System.Windows.Forms.TabControl();
            this.infoLabel = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.insertToolStripMenuItem = new myDb.InsertStrip();
            this.selectToolStripMenuItem = new myDb.SelectStrip();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeDb = new System.Windows.Forms.ToolStripMenuItem();
            this.b = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoBox
            // 
            this.infoBox.Enabled = false;
            infoBox.Text = "TEST";
            this.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.infoBox.Location = new System.Drawing.Point(563, 41);
            this.infoBox.Multiline = true;
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(156, 202);
            this.infoBox.TabIndex = 0;
            this.infoBox.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
            // 
            // tabs
            // 
            this.tabs.Size = new System.Drawing.Size(545, 223);
            this.tabs.Location = new System.Drawing.Point(20, 22); //dame to na panel, no   
            this.tabs.Name = "Tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Multiline = true;
          //  this.tabs.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabs.Size = new System.Drawing.Size(40, 100);
            this.tabs.Appearance = System.Windows.Forms.TabAppearance.Normal;
            this.tabs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            //changeDb
            this.changeDb.Name = "Edit db";
            this.changeDb.Text = "Edit db";
            this.changeDb.AutoSize = true;
            this.changeDb.Click += new System.EventHandler(changeDb_Click);
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.selectToolStripMenuItem.Text = "select";
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.Menu_Click);
            this.selectToolStripMenuItem.fillGrid += new SelectStrip.DataToGrid(this.records.filter);
            this.selectToolStripMenuItem.deleteData +=new SelectStrip.DeleteData(records.delete);
    	    this.selectToolStripMenuItem.setGrid += new SelectStrip.SetGrid(records.settingGrid);
            this.selectToolStripMenuItem.edit += new SelectStrip.EditRecords(this.edit);
            // 
            // backToolStripMenuItem
            //
            this.backToolStripMenuItem.Name = "backToolStripMenuItem.Name";
            this.backToolStripMenuItem.AutoSize = true;
            this.backToolStripMenuItem.Text = "Choose another db";
            this.backToolStripMenuItem.Click += new System.EventHandler(backToolStripMenuItem_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(571, 22);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(25, 13);
            this.infoLabel.TabIndex = 2;
            this.infoLabel.Text = "Info";
            this.infoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.selectToolStripMenuItem,
            this.backToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(732, 24);
            this.menu.TabIndex = 3;
            this.menu.Text = "menu";
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.insertToolStripMenuItem.Text = "insert";
            this.insertToolStripMenuItem.Click += new System.EventHandler(this.Menu_Click);
            // 
            // b
            // 
            this.b.Location = new System.Drawing.Point(0, 0);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(75, 23);
            this.b.TabIndex = 0;
            // 
            // Formular
            // 

            //layout
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoBox.Dock = System.Windows.Forms.DockStyle.Right;
            
            //default page showing all racords
            System.Windows.Forms.TabPage firstPage = new System.Windows.Forms.TabPage();
            firstPage.Text = "All records";

            System.Windows.Forms.DataGridView grid = new System.Windows.Forms.DataGridView();
            grid.AllowUserToAddRows = false;
            grid.ReadOnly = true;
            grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            grid.DoubleClick += new System.EventHandler(grid_DoubleClick);
            grid.Dock = System.Windows.Forms.DockStyle.Fill;

            records.settingGrid(grid);
            records.filter(grid, "");
            firstPage.Controls.Add(grid);
            tabs.Controls.Add(firstPage);
                     
         // this.Resize += new System.EventHandler(Formular_Resize);
	    this.AutoModeSize = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 266);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(tabs);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "Formular";
            this.Text = "Formular";
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.tabs.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void grid_DoubleClick(object sender, System.EventArgs e)
        {
            System.Windows.Forms.DataGridView d = sender as System.Windows.Forms.DataGridView;
           foreach ( System.Windows.Forms.DataGridViewRow r in d.SelectedRows)

               selectToolStripMenuItem_recordChosen(r.Cells[Files.Id].Value as Value);
        }
        private void edit(List<Value> values)
        {
            records.addRow(this.insertToolStripMenuItem,values);
        }
        void changeDb_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        void backToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.endState = Forms.FormLoad;
            this.Close();
        }
     
        #endregion

        private System.Windows.Forms.TextBox infoBox;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeDb;
        private InsertStrip insertToolStripMenuItem;
        private SelectStrip selectToolStripMenuItem;
        private Records records;
        private System.Windows.Forms.Button b; 
    }
}
