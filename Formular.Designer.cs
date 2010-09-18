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
            this.firstPage = new System.Windows.Forms.TabPage();
            this.grid = new System.Windows.Forms.DataGridView();
            this.refresh = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.insertToolStripMenuItem = new myDb.InsertStrip();
            this.selectToolStripMenuItem = new myDb.SelectStrip();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeDb = new System.Windows.Forms.ToolStripMenuItem();
            this.b = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.firstPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoBox
            // 
            this.infoBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.infoBox.Location = new System.Drawing.Point(685, 24);
            this.infoBox.Multiline = true;
            this.infoBox.Name = "infoBox";
            this.infoBox.ReadOnly = true;
            this.infoBox.Size = new System.Drawing.Size(156, 242);
            this.infoBox.TabIndex = 0;
            this.infoBox.Text = "Information: \r\n";
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.firstPage);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 24);
            this.tabs.Multiline = true;
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(685, 242);
            this.tabs.TabIndex = 3;
            // 
            // firstPage
            // 
            this.firstPage.Controls.Add(this.grid);
            this.firstPage.Controls.Add(this.refresh);
            this.firstPage.Location = new System.Drawing.Point(4, 22);
            this.firstPage.Name = "FirstPage";
            this.firstPage.Size = new System.Drawing.Size(677, 216);
            this.firstPage.TabIndex = 0;
            this.firstPage.Text = "All records";
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(677, 193);
            this.grid.TabIndex = 0;
            this.grid.DoubleClick += new System.EventHandler(this.grid_DoubleClick);
            // 
            // refresh
            // 
            this.refresh.AutoSize = true;
            this.refresh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.refresh.Location = new System.Drawing.Point(0, 193);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(677, 23);
            this.refresh.TabIndex = 1;
            this.refresh.Text = "Refresh";
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
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
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.selectToolStripMenuItem,
            this.backToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(841, 24);
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
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.selectToolStripMenuItem.Text = "select";
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.Menu_Click);
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.backToolStripMenuItem.Text = "Choose another db";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // changeDb
            // 
            this.changeDb.Name = "changeDb";
            this.changeDb.Size = new System.Drawing.Size(32, 19);
            this.changeDb.Text = "Edit db";
            this.changeDb.Click += new System.EventHandler(this.changeDb_Click);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 266);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Formular";
            this.Text = "Formular";
            this.tabs.ResumeLayout(false);
            this.firstPage.ResumeLayout(false);
            this.firstPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
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

        private System.Windows.Forms.DataGridView grid; //je to FUJ, ale co uz
        private System.Windows.Forms.TextBox infoBox;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeDb;
        private InsertStrip insertToolStripMenuItem;
        private SelectStrip selectToolStripMenuItem;
        private System.Windows.Forms.Button b;
        private System.Windows.Forms.TabPage firstPage;
        private System.Windows.Forms.Button refresh; 
    }
}
