namespace myDb
{
    partial class setSizeForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.heigthLabel = new System.Windows.Forms.Label();
            this.width = new System.Windows.Forms.NumericUpDown();
            this.heigth = new System.Windows.Forms.NumericUpDown();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heigth)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.heigthLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.width, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.heigth, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.WidthLabel, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(49, 89);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(139, 58);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // heigthLabel
            // 
            this.heigthLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heigthLabel.Location = new System.Drawing.Point(3, 29);
            this.heigthLabel.Name = "heigthLabel";
            this.heigthLabel.Size = new System.Drawing.Size(63, 29);
            this.heigthLabel.TabIndex = 1;
            this.heigthLabel.Text = "Heigth";
            this.heigthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // width
            // 
            this.width.Dock = System.Windows.Forms.DockStyle.Fill;
            this.width.Location = new System.Drawing.Point(72, 3);
            this.width.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.width.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(64, 20);
            this.width.TabIndex = 2;
            this.width.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // heigth
            // 
            this.heigth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heigth.Location = new System.Drawing.Point(72, 32);
            this.heigth.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.heigth.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.heigth.Name = "heigth";
            this.heigth.Size = new System.Drawing.Size(64, 20);
            this.heigth.TabIndex = 3;
            this.heigth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // WidthLabel
            // 
            this.WidthLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WidthLabel.Location = new System.Drawing.Point(3, 0);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(63, 29);
            this.WidthLabel.TabIndex = 0;
            this.WidthLabel.Text = "Width";
            this.WidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(113, 153);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // setSizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "setSizeForm";
            this.Text = "Set size";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heigth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label heigthLabel;
        public System.Windows.Forms.NumericUpDown width;
        public System.Windows.Forms.NumericUpDown heigth;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Button okButton;

    }
}