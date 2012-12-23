namespace Minis
{
    partial class InsertContent
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
            this.addArrays = new System.Windows.Forms.Button();
            this.recordPanel = new System.Windows.Forms.Panel();
            this.howMany = new System.Windows.Forms.NumericUpDown();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.addRecords = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.howMany)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // addArrays
            // 
            this.addArrays.Dock = System.Windows.Forms.DockStyle.Right;
            this.addArrays.Location = new System.Drawing.Point(246, 0);
            this.addArrays.Name = "addArrays";
            this.addArrays.Size = new System.Drawing.Size(154, 22);
            this.addArrays.TabIndex = 1;
            this.addArrays.Text = "Create arrays";
            this.addArrays.Click += new System.EventHandler(this.addRows_click);
            // 
            // recordPanel
            // 
            this.recordPanel.AutoScroll = true;
            this.recordPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.recordPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordPanel.Location = new System.Drawing.Point(0, 0);
            this.recordPanel.Name = "recordPanel";
            this.recordPanel.Size = new System.Drawing.Size(517, 254);
            this.recordPanel.TabIndex = 1;
            // 
            // howMany
            // 
            this.howMany.Dock = System.Windows.Forms.DockStyle.Right;
            this.howMany.Location = new System.Drawing.Point(126, 0);
            this.howMany.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.howMany.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.howMany.Name = "howMany";
            this.howMany.Size = new System.Drawing.Size(120, 20);
            this.howMany.TabIndex = 2;
            this.howMany.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonPanel
            // 
            this.buttonPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonPanel.Controls.Add(this.howMany);
            this.buttonPanel.Controls.Add(this.addArrays);
            this.buttonPanel.Controls.Add(this.addRecords);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 254);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(517, 22);
            this.buttonPanel.TabIndex = 0;
            // 
            // addRecords
            // 
            this.addRecords.Dock = System.Windows.Forms.DockStyle.Right;
            this.addRecords.Location = new System.Drawing.Point(400, 0);
            this.addRecords.Name = "addRecords";
            this.addRecords.Size = new System.Drawing.Size(117, 22);
            this.addRecords.TabIndex = 0;
            this.addRecords.Text = "Add selected records";
            this.addRecords.Click += new System.EventHandler(this.addButton_Click);
            // 
            // InsertContent
            // 
            this.Controls.Add(this.recordPanel);
            this.Controls.Add(this.buttonPanel);
            this.Size = new System.Drawing.Size(517, 276);
            ((System.ComponentModel.ISupportInitialize)(this.howMany)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button addRecords;
        private System.Windows.Forms.Button addArrays;
        private System.Windows.Forms.Panel recordPanel;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.NumericUpDown howMany;
        
        #endregion
    }
}
