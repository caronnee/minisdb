using System.Collections.Generic;

namespace myDb
{
      /*System.Windows.Forms.Button button = new System.Windows.Forms.Button();
            button.Text = "add new";
            button.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;
            button.AutoSize = true;
            button.Location = new System.Drawing.Point(ins.getTab().Width - button.Width - 10,
                ins.getTab().Height - button.Height - 10);
            ins.getTab().Controls.Add(button);
            button.Click+=new System.EventHandler();
       * */

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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabs = new System.Windows.Forms.TabControl();
            this.infoLabel = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MenuStrip();
            InsertStrip ins = new InsertStrip();
            ins.addRecord += new InsertStrip.addRecordsHandler(records.addRecord);
            ins.addRow +=new InsertStrip.addRowHandler(records.addRow);
            ins.addLabels +=new InsertStrip.AddLabels(records.addNames);
            this.insertToolStripMenuItem = ins;
            this.selectToolStripMenuItem = new MyToolStrip("select");

            //osobitne pridat click..FUJ. Nastastie ziadne dalsie 
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.Menu_Click);
            this.insertToolStripMenuItem.Click += new System.EventHandler(this.Menu_Click);
            this.tabs.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(563, 41);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(156, 202);
            this.textBox1.TabIndex = 0;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(selectToolStripMenuItem.getTab());
            this.tabs.Location = new System.Drawing.Point(30, 20);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(498, 223);
            this.tabs.TabIndex = 1;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(571, 22);
            this.infoLabel.Name = "Info";
            this.infoLabel.Size = new System.Drawing.Size(25, 13);
            this.infoLabel.TabIndex = 2;
            this.infoLabel.Text = "Info";
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.selectToolStripMenuItem});
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
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.selectToolStripMenuItem.Text = "select";
            // 
            // Formular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 266);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menu);

            System.Windows.Forms.Button b = new System.Windows.Forms.Button();

            this.MainMenuStrip = this.menu;
            this.Name = "Formular";
            this.Text = "Formular";
            this.tabs.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.MenuStrip menu;
        private MyToolStrip insertToolStripMenuItem;
        private MyToolStrip selectToolStripMenuItem;
        private Records records; 
    }
}
