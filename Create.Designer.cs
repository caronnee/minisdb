namespace myDb
{
    partial class Create
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
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.addTextAttribute = new System.Windows.Forms.Button();
            this.definitionPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.LoadFromFile = new System.Windows.Forms.Button();
            this.createEnum = new System.Windows.Forms.Button();
            this.test = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(694, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 21);
            this.button1.TabIndex = 3;
            this.button1.Text = "add real";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(694, 51);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 22);
            this.button3.TabIndex = 4;
            this.button3.Text = "add integer";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // addTextAttribute
            // 
            this.addTextAttribute.Location = new System.Drawing.Point(694, 22);
            this.addTextAttribute.Name = "addTextAttribute";
            this.addTextAttribute.Size = new System.Drawing.Size(77, 23);
            this.addTextAttribute.TabIndex = 5;
            this.addTextAttribute.Text = "add Text";
            this.addTextAttribute.UseVisualStyleBackColor = true;
            this.addTextAttribute.Click += new System.EventHandler(this.addTextAttribute_Click);
            // 
            // definitionPanel
            // 
            this.definitionPanel.AutoScroll = true;
            this.definitionPanel.Location = new System.Drawing.Point(18, 14);
            this.definitionPanel.Name = "definitionPanel";
            this.definitionPanel.Size = new System.Drawing.Size(665, 223);
            this.definitionPanel.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(694, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "add enum";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(694, 135);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(77, 21);
            this.button5.TabIndex = 8;
            this.button5.Text = "add image";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // LoadFromFile
            // 
            this.LoadFromFile.Location = new System.Drawing.Point(31, 269);
            this.LoadFromFile.Name = "LoadFromFile";
            this.LoadFromFile.Size = new System.Drawing.Size(91, 28);
            this.LoadFromFile.TabIndex = 9;
            this.LoadFromFile.Text = "load from file";
            this.LoadFromFile.UseVisualStyleBackColor = true;
            this.LoadFromFile.Click += new System.EventHandler(this.LoadFromFile_Click);
            // 
            // createEnum
            // 
            this.createEnum.Location = new System.Drawing.Point(696, 162);
            this.createEnum.Name = "createEnum";
            this.createEnum.Size = new System.Drawing.Size(75, 23);
            this.createEnum.TabIndex = 10;
            this.createEnum.Text = "Create enum";
            this.createEnum.UseVisualStyleBackColor = true;
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(711, 211);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(44, 25);
            this.test.TabIndex = 11;
            this.test.Text = "test";
            this.test.UseVisualStyleBackColor = true;
            // 
            // Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 322);
            this.Controls.Add(this.test);
            this.Controls.Add(this.createEnum);
            this.Controls.Add(this.LoadFromFile);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.definitionPanel);
            this.Controls.Add(this.addTextAttribute);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Name = "Create";
            this.Text = "Create";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button addTextAttribute;
        private System.Windows.Forms.Panel definitionPanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button LoadFromFile;
        private System.Windows.Forms.Button createEnum;
        private System.Windows.Forms.Button test;
    }
}