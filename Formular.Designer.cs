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
        private void MyToolStrip_Click(object sender, System.EventArgs e)
        {
            if (!this.selectTab.Contains(((MyToolStrip) sender).getTab()))
                this.selectTab.Controls.Add(((MyToolStrip) sender).getTab());
            this.selectTab.SelectedIndex =
                this.selectTab.Controls.GetChildIndex(((MyToolStrip) sender).getTab());
        }

        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.selectTab = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            InsertStrip ins = new InsertStrip();
            ins.addRecord += new InsertStrip.addRecordsHandler(records.addRecord);
            this.insertToolStripMenuItem = ins;
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new MyToolStrip("select");

            //osobitne pridat click..FUJ. Nastastie ziadne dalsie 
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.MyToolStrip_Click);
            this.insertToolStripMenuItem.Click += new System.EventHandler(this.MyToolStrip_Click);
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.MyToolStrip_Click);
            this.selectTab.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            // selectTab
            // 
            this.selectTab.Controls.Add(selectToolStripMenuItem.getTab());
            this.selectTab.Location = new System.Drawing.Point(30, 20);
            this.selectTab.Name = "selectTab";
            this.selectTab.SelectedIndex = 0;
            this.selectTab.Size = new System.Drawing.Size(498, 223);
            this.selectTab.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(571, 22);
            this.label1.Name = "Info";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Info";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.selectToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(732, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.insertToolStripMenuItem.Text = "insert";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.deleteToolStripMenuItem.Text = "delete";
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
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectTab);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);

            System.Windows.Forms.Button b = new System.Windows.Forms.Button();

            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Formular";
            this.Text = "Formular";
            this.selectTab.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl selectTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private MyToolStrip insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private MyToolStrip selectToolStripMenuItem;
        private Records records; 
    }
}
