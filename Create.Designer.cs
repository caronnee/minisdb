using System.Collections.Generic;

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
            this.addInteger = new System.Windows.Forms.Button();
            this.addTextAttribute = new System.Windows.Forms.Button();
            this.definitionPanel = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.addEnum = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.LoadFromFile = new System.Windows.Forms.Button();
            this.createEnum = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.definedEnums = new System.Windows.Forms.ComboBox();
            this.removeEnum = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addInteger
            // 
            this.addInteger.Location = new System.Drawing.Point(694, 51);
            this.addInteger.Name = "addInteger";
            this.addInteger.Size = new System.Drawing.Size(77, 22);
            this.addInteger.TabIndex = 4;
            this.addInteger.Text = "add integer";
            this.addInteger.UseVisualStyleBackColor = true;
            this.addInteger.Click += new System.EventHandler(this.addInteger_Click);
            // 
            // addTextAttribute
            // 
            this.addTextAttribute.Location = new System.Drawing.Point(694, 22);
            this.addTextAttribute.Name = "addTextAttribute";
            this.addTextAttribute.Size = new System.Drawing.Size(77, 23);
            this.addTextAttribute.TabIndex = 5;
            this.addTextAttribute.Text = "add text";
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
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(465, 277);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(99, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // addEnum
            // 
            this.addEnum.Location = new System.Drawing.Point(694, 164);
            this.addEnum.Name = "addEnum";
            this.addEnum.Size = new System.Drawing.Size(77, 23);
            this.addEnum.TabIndex = 7;
            this.addEnum.Text = "add enum";
            this.addEnum.UseVisualStyleBackColor = true;
            this.addEnum.Click += new System.EventHandler(this.addEnum_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(694, 79);
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
            this.createEnum.Location = new System.Drawing.Point(694, 135);
            this.createEnum.Name = "createEnum";
            this.createEnum.Size = new System.Drawing.Size(75, 23);
            this.createEnum.TabIndex = 10;
            this.createEnum.Text = "Create enum";
            this.createEnum.UseVisualStyleBackColor = true;
            this.createEnum.Click += new System.EventHandler(this.createEnum_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(694, 106);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "add time";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(621, 273);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 12;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            // 
            // definedEnums
            // 
            this.definedEnums.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.definedEnums.FormattingEnabled = true;
            this.definedEnums.Location = new System.Drawing.Point(694, 197);
            this.definedEnums.Name = "definedEnums";
            this.definedEnums.Size = new System.Drawing.Size(74, 21);
            this.definedEnums.TabIndex = 13;
            // 
            // removeEnum
            // 
            this.removeEnum.Location = new System.Drawing.Point(694, 228);
            this.removeEnum.Name = "removeEnum";
            this.removeEnum.Size = new System.Drawing.Size(77, 23);
            this.removeEnum.TabIndex = 14;
            this.removeEnum.Text = "remove enum";
            this.removeEnum.UseVisualStyleBackColor = true;
            this.removeEnum.Click += new System.EventHandler(this.removeEnum_Click);
            // 
            // Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 322);
            this.Controls.Add(this.removeEnum);
            this.Controls.Add(this.definedEnums);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.createEnum);
            this.Controls.Add(this.LoadFromFile);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.addEnum);
            this.Controls.Add(this.definitionPanel);
            this.Controls.Add(this.addTextAttribute);
            this.Controls.Add(this.addInteger);
            this.Name = "Create";
            this.Text = "Create";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addInteger;
        private System.Windows.Forms.Button addTextAttribute;
        private System.Windows.Forms.Panel definitionPanel;
        private System.Windows.Forms.Button addEnum;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button LoadFromFile;
        private System.Windows.Forms.Button createEnum;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.ComboBox definedEnums;
        private System.Windows.Forms.Button removeEnum;
    }
}