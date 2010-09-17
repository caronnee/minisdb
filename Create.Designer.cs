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
            this.SuspendLayout();
            // 
            // regexp
            // 
            this.regexp.Location = new System.Drawing.Point(176, 338);
            this.regexp.Name = "regexp";
            this.regexp.Size = new System.Drawing.Size(100, 20);
            this.regexp.TabIndex = 17;
            this.regexp.Visible = false;
            // 
            // chosen
            // 
            this.chosen.Location = new System.Drawing.Point(296, 338);
            this.chosen.Name = "chosen";
            this.chosen.Size = new System.Drawing.Size(100, 20);
            this.chosen.TabIndex = 18;
            this.chosen.Visible = false;
            // 
            // addInteger
            // 
            this.addInteger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addInteger.Location = new System.Drawing.Point(702, 79);
            this.addInteger.Name = "addInteger";
            this.addInteger.Size = new System.Drawing.Size(77, 22);
            this.addInteger.TabIndex = 4;
            this.addInteger.Text = "add integer";
            this.addInteger.UseVisualStyleBackColor = true;
            this.addInteger.Click += new System.EventHandler(this.addInteger_Click);
            // 
            // addTextAttribute
            // 
            this.addTextAttribute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addTextAttribute.Location = new System.Drawing.Point(702, 50);
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
            this.definitionPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.definitionPanel.Location = new System.Drawing.Point(12, 50);
            this.definitionPanel.Name = "definitionPanel";
            this.definitionPanel.Size = new System.Drawing.Size(160, 68);
            this.definitionPanel.TabIndex = 6;
            // 
            // addEnum
            // 
            this.addEnum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addEnum.Location = new System.Drawing.Point(702, 192);
            this.addEnum.Name = "addEnum";
            this.addEnum.Size = new System.Drawing.Size(77, 23);
            this.addEnum.TabIndex = 7;
            this.addEnum.Text = "add enum";
            this.addEnum.UseVisualStyleBackColor = true;
            this.addEnum.Click += new System.EventHandler(this.addEnum_Click);
            // 
            // addImage
            // 
            this.addImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addImage.Location = new System.Drawing.Point(702, 107);
            this.addImage.Name = "addImage";
            this.addImage.Size = new System.Drawing.Size(77, 21);
            this.addImage.TabIndex = 8;
            this.addImage.Text = "add image";
            this.addImage.UseVisualStyleBackColor = true;
            this.addImage.Click += new System.EventHandler(this.addImage_Click);
            // 
            // createEnum
            // 
            this.createEnum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createEnum.Location = new System.Drawing.Point(702, 163);
            this.createEnum.Name = "createEnum";
            this.createEnum.Size = new System.Drawing.Size(75, 23);
            this.createEnum.TabIndex = 10;
            this.createEnum.Text = "Create enum";
            this.createEnum.UseVisualStyleBackColor = true;
            this.createEnum.Click += new System.EventHandler(this.createEnum_Click);
            // 
            // addTime
            // 
            this.addTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addTime.Location = new System.Drawing.Point(702, 134);
            this.addTime.Name = "addTime";
            this.addTime.Size = new System.Drawing.Size(75, 23);
            this.addTime.TabIndex = 11;
            this.addTime.Text = "add time";
            this.addTime.UseVisualStyleBackColor = true;
            this.addTime.Click += new System.EventHandler(this.addTime_Click);
            // 
            // createButton
            // 
            this.createButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createButton.Location = new System.Drawing.Point(534, 338);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 12;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // definedEnums
            // 
            this.definedEnums.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.definedEnums.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.definedEnums.FormattingEnabled = true;
            this.definedEnums.Location = new System.Drawing.Point(702, 225);
            this.definedEnums.Name = "definedEnums";
            this.definedEnums.Size = new System.Drawing.Size(74, 21);
            this.definedEnums.TabIndex = 13;
            // 
            // removeEnum
            // 
            this.removeEnum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeEnum.Location = new System.Drawing.Point(702, 256);
            this.removeEnum.Name = "removeEnum";
            this.removeEnum.Size = new System.Drawing.Size(77, 23);
            this.removeEnum.TabIndex = 14;
            this.removeEnum.Text = "remove enum";
            this.removeEnum.UseVisualStyleBackColor = true;
            this.removeEnum.Click += new System.EventHandler(this.removeEnum_Click);
            // 
            // dbName
            // 
            this.dbName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dbName.Location = new System.Drawing.Point(133, 12);
            this.dbName.Name = "dbName";
            this.dbName.Size = new System.Drawing.Size(517, 20);
            this.dbName.TabIndex = 15;
            this.dbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(625, 338);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // dbNameLabel
            // 
            this.dbNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dbNameLabel.AutoSize = true;
            this.dbNameLabel.Location = new System.Drawing.Point(45, 15);
            this.dbNameLabel.Name = "dbNameLabel";
            this.dbNameLabel.Size = new System.Drawing.Size(82, 13);
            this.dbNameLabel.TabIndex = 19;
            this.dbNameLabel.Text = "Database name";
            // 
            // Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(796, 378);
            this.Controls.Add(this.dbNameLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.dbName);
            this.Controls.Add(this.removeEnum);
            this.Controls.Add(this.definedEnums);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.addTime);
            this.Controls.Add(this.createEnum);
            this.Controls.Add(this.addImage);
            this.Controls.Add(this.addEnum);
            this.Controls.Add(this.definitionPanel);
            this.Controls.Add(this.addTextAttribute);
            this.Controls.Add(this.addInteger);
            this.Controls.Add(this.regexp);
            this.Controls.Add(this.chosen);
            this.Name = "Create";
            this.Text = "Create";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}
