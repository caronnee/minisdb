namespace Minis
{
    partial class MainContainer
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainContainer));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.managersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enumManegerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.about = new System.Windows.Forms.ToolStripMenuItem();
            this.screen = new Minis.Intro();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.managersToolStripMenuItem,
            this.about});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(582, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // managersToolStripMenuItem
            // 
            this.managersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.groupManagerToolStripMenuItem,
            this.enumManegerToolStripMenuItem,
            this.databaseManagerToolStripMenuItem});
            this.managersToolStripMenuItem.Name = "managersToolStripMenuItem";
            this.managersToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.managersToolStripMenuItem.Text = "Managers";
            // 
            // groupManagerToolStripMenuItem
            // 
            this.groupManagerToolStripMenuItem.Name = "groupManagerToolStripMenuItem";
            this.groupManagerToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.groupManagerToolStripMenuItem.Text = "Group manager";
            // 
            // enumManegerToolStripMenuItem
            // 
            this.enumManegerToolStripMenuItem.Name = "enumManegerToolStripMenuItem";
            this.enumManegerToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.enumManegerToolStripMenuItem.Text = "Enum maneger";
            // 
            // databaseManagerToolStripMenuItem
            // 
            this.databaseManagerToolStripMenuItem.Name = "databaseManagerToolStripMenuItem";
            this.databaseManagerToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.databaseManagerToolStripMenuItem.Text = "Database manager";
            // 
            // about
            // 
            this.about.Name = "about";
            this.about.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.about.Size = new System.Drawing.Size(52, 20);
            this.about.Text = "About";
            this.about.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // screen
            // 
            this.screen.AutoSize = true;
            this.screen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.screen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screen.Location = new System.Drawing.Point(0, 24);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(582, 206);
            this.screen.TabIndex = 1;
            // 
            // MainContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 230);
            this.Controls.Add(this.screen);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainContainer";
            this.Text = "Mini database";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem managersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enumManegerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem about;
        private System.Windows.Forms.ToolStripMenuItem databaseManagerToolStripMenuItem;
        private Intro screen;
    }
}