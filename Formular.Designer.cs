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

        private class MyToolStrip : System.Windows.Forms.ToolStripMenuItem
        {
            private System.Windows.Forms.TabPage tabpage;
            public MyToolStrip(string name)
            {
                tabpage = createTab(name);
                this.Click += new System.EventHandler(MyToolStrip_Click);
            }

            void MyToolStrip_Click(object sender, System.EventArgs e)
            {
                Formular f = (Formular)(this.Parent.FindForm());
                if (!f.selectTab.Contains(this.getTab()))
                    f.selectTab.Controls.Add(this.getTab());
                f.selectTab.SelectedIndex = 
                    f.selectTab.Controls.GetChildIndex(this.getTab());
            }
            public System.Windows.Forms.TabPage getTab()
            {
                return tabpage;
            }
        }
        private class InsertStrip : MyToolStrip
        {
            public delegate void addRecordsHandler(object sender, RecordEventArgs rea);
            public event addRecordsHandler addRecord;

            protected virtual void onAddRecord(RecordEventArgs args)
            {
                if (addRecord == null)
                    return;
                addRecord(this, args);
            }

            public InsertStrip() : base("Insert")
            {
                
                //add Button
                System.Windows.Forms.Button addButton = new System.Windows.Forms.Button();
                addButton.Text = "add records";
                addButton.AutoSize = true;
                addButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | 
                    System.Windows.Forms.AnchorStyles.Right;
                System.Drawing.Size s = getTab().Size;
                addButton.Location = new System.Drawing.Point(s.Width - addButton.Width - 10,
                    s.Height - addButton.Height - 10);
                getTab().Controls.Add(addButton);
                addButton.Click += new System.EventHandler(addButton_Click);
                //raise event
            }

            void addButton_Click(object sender, System.EventArgs e)
            {
                //zistime vsetky recordy, ktore na uzibvatel zadal..ZAJTRA/VECER
            }
        }
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.selectTab = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            MyToolStrip ins = new MyToolStrip("insert");
            this.insertToolStripMenuItem = ins;
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new MyToolStrip("select");
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
