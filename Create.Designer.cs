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
            this.regexp = new System.Windows.Forms.TextBox();
            this.chosen = new System.Windows.Forms.TextBox();
            this.addInteger = new System.Windows.Forms.Button();
            this.addTextAttribute = new System.Windows.Forms.Button();
            this.definitionPanel = new System.Windows.Forms.Panel();
            this.addEnum = new System.Windows.Forms.Button();
            this.addImage = new System.Windows.Forms.Button();
            this.createEnum = new System.Windows.Forms.Button();
            this.addTime = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.definedEnums = new System.Windows.Forms.ComboBox();
            this.removeEnum = new System.Windows.Forms.Button();
            this.dbName = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.dbNameLabel = new System.Windows.Forms.Label();
            this.ManipulationControls = new System.Windows.Forms.GroupBox();
            this.RecordItemsArea = new System.Windows.Forms.GroupBox();
            this.dbNameArea = new System.Windows.Forms.GroupBox();
            this.ManipulationControls.SuspendLayout();
            this.RecordItemsArea.SuspendLayout();
            this.dbNameArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // regexp
            // 
            this.regexp.Dock = System.Windows.Forms.DockStyle.Left;
            this.regexp.Location = new System.Drawing.Point(3, 16);
            this.regexp.Name = "regexp";
            this.regexp.Size = new System.Drawing.Size(100, 20);
            this.regexp.TabIndex = 17;
            this.regexp.Visible = false;
            // 
            // chosen
            // 
            this.chosen.Dock = System.Windows.Forms.DockStyle.Left;
            this.chosen.Location = new System.Drawing.Point(103, 16);
            this.chosen.Name = "chosen";
            this.chosen.Size = new System.Drawing.Size(100, 20);
            this.chosen.TabIndex = 18;
            this.chosen.Visible = false;
            // 
            // addInteger
            // 
            this.addInteger.Dock = System.Windows.Forms.DockStyle.Top;
            this.addInteger.Location = new System.Drawing.Point(3, 16);
            this.addInteger.Name = "addInteger";
            this.addInteger.Size = new System.Drawing.Size(72, 23);
            this.addInteger.TabIndex = 4;
            this.addInteger.Text = "add integer";
            this.addInteger.UseVisualStyleBackColor = true;
            this.addInteger.Click += new System.EventHandler(this.addInteger_Click);
            // 
            // addTextAttribute
            // 
            this.addTextAttribute.Dock = System.Windows.Forms.DockStyle.Top;
            this.addTextAttribute.Location = new System.Drawing.Point(3, 62);
            this.addTextAttribute.Name = "addTextAttribute";
            this.addTextAttribute.Size = new System.Drawing.Size(72, 23);
            this.addTextAttribute.TabIndex = 5;
            this.addTextAttribute.Text = "add text";
            this.addTextAttribute.UseVisualStyleBackColor = true;
            this.addTextAttribute.Click += new System.EventHandler(this.addTextAttribute_Click);
            // 
            // definitionPanel
            // 
            this.definitionPanel.AutoScroll = true;
            this.definitionPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.definitionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.definitionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.definitionPanel.Location = new System.Drawing.Point(0, 49);
            this.definitionPanel.Name = "definitionPanel";
            this.definitionPanel.Size = new System.Drawing.Size(718, 283);
            this.definitionPanel.TabIndex = 6;
            // 
            // addEnum
            // 
            this.addEnum.Dock = System.Windows.Forms.DockStyle.Top;
            this.addEnum.Location = new System.Drawing.Point(3, 129);
            this.addEnum.Name = "addEnum";
            this.addEnum.Size = new System.Drawing.Size(72, 23);
            this.addEnum.TabIndex = 7;
            this.addEnum.Text = "add enum";
            this.addEnum.UseVisualStyleBackColor = true;
            this.addEnum.Click += new System.EventHandler(this.addEnum_Click);
            // 
            // addImage
            // 
            this.addImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.addImage.Location = new System.Drawing.Point(3, 85);
            this.addImage.Name = "addImage";
            this.addImage.Size = new System.Drawing.Size(72, 21);
            this.addImage.TabIndex = 8;
            this.addImage.Text = "add image";
            this.addImage.UseVisualStyleBackColor = true;
            this.addImage.Click += new System.EventHandler(this.addImage_Click);
            // 
            // createEnum
            // 
            this.createEnum.Dock = System.Windows.Forms.DockStyle.Top;
            this.createEnum.Location = new System.Drawing.Point(3, 106);
            this.createEnum.Name = "createEnum";
            this.createEnum.Size = new System.Drawing.Size(72, 23);
            this.createEnum.TabIndex = 10;
            this.createEnum.Text = "Create enum";
            this.createEnum.UseVisualStyleBackColor = true;
            this.createEnum.Click += new System.EventHandler(this.createEnum_Click);
            // 
            // addTime
            // 
            this.addTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.addTime.Location = new System.Drawing.Point(3, 39);
            this.addTime.Name = "addTime";
            this.addTime.Size = new System.Drawing.Size(72, 23);
            this.addTime.TabIndex = 11;
            this.addTime.Text = "add time";
            this.addTime.UseVisualStyleBackColor = true;
            this.addTime.Click += new System.EventHandler(this.addTime_Click);
            // 
            // createButton
            // 
            this.createButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.createButton.Location = new System.Drawing.Point(718, 16);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 27);
            this.createButton.TabIndex = 12;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // definedEnums
            // 
            this.definedEnums.Dock = System.Windows.Forms.DockStyle.Top;
            this.definedEnums.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.definedEnums.FormattingEnabled = true;
            this.definedEnums.Location = new System.Drawing.Point(3, 152);
            this.definedEnums.Name = "definedEnums";
            this.definedEnums.Size = new System.Drawing.Size(72, 21);
            this.definedEnums.TabIndex = 13;
            // 
            // removeEnum
            // 
            this.removeEnum.Dock = System.Windows.Forms.DockStyle.Top;
            this.removeEnum.Location = new System.Drawing.Point(3, 173);
            this.removeEnum.Name = "removeEnum";
            this.removeEnum.Size = new System.Drawing.Size(72, 23);
            this.removeEnum.TabIndex = 14;
            this.removeEnum.Text = "remove enum";
            this.removeEnum.UseVisualStyleBackColor = true;
            this.removeEnum.Click += new System.EventHandler(this.removeEnum_Click);
            // 
            // dbName
            // 
            this.dbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbName.Location = new System.Drawing.Point(85, 16);
            this.dbName.Name = "dbName";
            this.dbName.Size = new System.Drawing.Size(708, 20);
            this.dbName.TabIndex = 15;
            this.dbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cancelButton
            // 
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.cancelButton.Location = new System.Drawing.Point(643, 16);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 27);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // dbNameLabel
            // 
            this.dbNameLabel.AutoSize = true;
            this.dbNameLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.dbNameLabel.Location = new System.Drawing.Point(3, 16);
            this.dbNameLabel.Name = "dbNameLabel";
            this.dbNameLabel.Size = new System.Drawing.Size(82, 13);
            this.dbNameLabel.TabIndex = 19;
            this.dbNameLabel.Text = "Database name";
            // 
            // ManipulationControls
            // 
            this.ManipulationControls.Controls.Add(this.cancelButton);
            this.ManipulationControls.Controls.Add(this.chosen);
            this.ManipulationControls.Controls.Add(this.createButton);
            this.ManipulationControls.Controls.Add(this.regexp);
            this.ManipulationControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ManipulationControls.Location = new System.Drawing.Point(0, 332);
            this.ManipulationControls.Name = "ManipulationControls";
            this.ManipulationControls.Size = new System.Drawing.Size(796, 46);
            this.ManipulationControls.TabIndex = 20;
            this.ManipulationControls.TabStop = false;
            // 
            // RecordItemsArea
            // 
            this.RecordItemsArea.Controls.Add(this.removeEnum);
            this.RecordItemsArea.Controls.Add(this.definedEnums);
            this.RecordItemsArea.Controls.Add(this.addEnum);
            this.RecordItemsArea.Controls.Add(this.createEnum);
            this.RecordItemsArea.Controls.Add(this.addImage);
            this.RecordItemsArea.Controls.Add(this.addTextAttribute);
            this.RecordItemsArea.Controls.Add(this.addTime);
            this.RecordItemsArea.Controls.Add(this.addInteger);
            this.RecordItemsArea.Dock = System.Windows.Forms.DockStyle.Right;
            this.RecordItemsArea.Location = new System.Drawing.Point(718, 49);
            this.RecordItemsArea.Name = "RecordItemsArea";
            this.RecordItemsArea.Size = new System.Drawing.Size(78, 283);
            this.RecordItemsArea.TabIndex = 21;
            this.RecordItemsArea.TabStop = false;
            // 
            // dbNameArea
            // 
            this.dbNameArea.Controls.Add(this.dbName);
            this.dbNameArea.Controls.Add(this.dbNameLabel);
            this.dbNameArea.Dock = System.Windows.Forms.DockStyle.Top;
            this.dbNameArea.Location = new System.Drawing.Point(0, 0);
            this.dbNameArea.Name = "dbNameArea";
            this.dbNameArea.Size = new System.Drawing.Size(796, 49);
            this.dbNameArea.TabIndex = 22;
            this.dbNameArea.TabStop = false;
            // 
            // Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 378);
            this.Controls.Add(this.definitionPanel);
            this.Controls.Add(this.RecordItemsArea);
            this.Controls.Add(this.ManipulationControls);
            this.Controls.Add(this.dbNameArea);
            this.Name = "Create";
            this.Text = "Create";
            this.ManipulationControls.ResumeLayout(false);
            this.ManipulationControls.PerformLayout();
            this.RecordItemsArea.ResumeLayout(false);
            this.dbNameArea.ResumeLayout(false);
            this.dbNameArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addInteger;
        private System.Windows.Forms.Button addTextAttribute;
        private System.Windows.Forms.Panel definitionPanel;
        private System.Windows.Forms.Button addEnum;
        private System.Windows.Forms.Button addImage;
        private System.Windows.Forms.Button createEnum;
        private System.Windows.Forms.Button addTime;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.ComboBox definedEnums;
        private System.Windows.Forms.Button removeEnum;
        private System.Windows.Forms.TextBox dbName;
        private System.Windows.Forms.Button cancelButton;

	private System.Windows.Forms.TextBox regexp;
	private System.Windows.Forms.TextBox chosen;
    private System.Windows.Forms.Label dbNameLabel;
    private System.Windows.Forms.GroupBox ManipulationControls;
    private System.Windows.Forms.GroupBox RecordItemsArea;
    private System.Windows.Forms.GroupBox dbNameArea;
    }
}
