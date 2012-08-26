namespace Minis
{
    partial class CreateGroup
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
            this.RecordItemsArea = new System.Windows.Forms.GroupBox();
            this.removeEnum = new System.Windows.Forms.Button();
            this.definedEnums = new System.Windows.Forms.ComboBox();
            this.addEnum = new System.Windows.Forms.Button();
            this.createEnum = new System.Windows.Forms.Button();
            this.addImage = new System.Windows.Forms.Button();
            this.addTextAttribute = new System.Windows.Forms.Button();
            this.addTime = new System.Windows.Forms.Button();
            this.addInteger = new System.Windows.Forms.Button();
            this.RecordItemsArea.SuspendLayout();
            this.SuspendLayout();
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
            this.RecordItemsArea.Location = new System.Drawing.Point(637, 0);
            this.RecordItemsArea.Name = "RecordItemsArea";
            this.RecordItemsArea.Size = new System.Drawing.Size(78, 352);
            this.RecordItemsArea.TabIndex = 22;
            this.RecordItemsArea.TabStop = false;
            // 
            // removeEnum
            // 
            this.removeEnum.Dock = System.Windows.Forms.DockStyle.Top;
            this.removeEnum.Location = new System.Drawing.Point(3, 172);
            this.removeEnum.Name = "removeEnum";
            this.removeEnum.Size = new System.Drawing.Size(72, 23);
            this.removeEnum.TabIndex = 14;
            this.removeEnum.Text = "remove enum";
            this.removeEnum.UseVisualStyleBackColor = true;
            // 
            // definedEnums
            // 
            this.definedEnums.Dock = System.Windows.Forms.DockStyle.Top;
            this.definedEnums.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.definedEnums.FormattingEnabled = true;
            this.definedEnums.Location = new System.Drawing.Point(3, 151);
            this.definedEnums.Name = "definedEnums";
            this.definedEnums.Size = new System.Drawing.Size(72, 21);
            this.definedEnums.TabIndex = 13;
            // 
            // addEnum
            // 
            this.addEnum.Dock = System.Windows.Forms.DockStyle.Top;
            this.addEnum.Location = new System.Drawing.Point(3, 128);
            this.addEnum.Name = "addEnum";
            this.addEnum.Size = new System.Drawing.Size(72, 23);
            this.addEnum.TabIndex = 7;
            this.addEnum.Text = "add enum";
            this.addEnum.UseVisualStyleBackColor = true;
            // 
            // createEnum
            // 
            this.createEnum.Dock = System.Windows.Forms.DockStyle.Top;
            this.createEnum.Location = new System.Drawing.Point(3, 105);
            this.createEnum.Name = "createEnum";
            this.createEnum.Size = new System.Drawing.Size(72, 23);
            this.createEnum.TabIndex = 10;
            this.createEnum.Text = "Create enum";
            this.createEnum.UseVisualStyleBackColor = true;
            // 
            // addImage
            // 
            this.addImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.addImage.Location = new System.Drawing.Point(3, 84);
            this.addImage.Name = "addImage";
            this.addImage.Size = new System.Drawing.Size(72, 21);
            this.addImage.TabIndex = 8;
            this.addImage.Text = "add image";
            this.addImage.UseVisualStyleBackColor = true;
            // 
            // addTextAttribute
            // 
            this.addTextAttribute.Dock = System.Windows.Forms.DockStyle.Top;
            this.addTextAttribute.Location = new System.Drawing.Point(3, 61);
            this.addTextAttribute.Name = "addTextAttribute";
            this.addTextAttribute.Size = new System.Drawing.Size(72, 23);
            this.addTextAttribute.TabIndex = 5;
            this.addTextAttribute.Text = "add text";
            this.addTextAttribute.UseVisualStyleBackColor = true;
            // 
            // addTime
            // 
            this.addTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.addTime.Location = new System.Drawing.Point(3, 38);
            this.addTime.Name = "addTime";
            this.addTime.Size = new System.Drawing.Size(72, 23);
            this.addTime.TabIndex = 11;
            this.addTime.Text = "add time";
            this.addTime.UseVisualStyleBackColor = true;
            // 
            // addInteger
            // 
            this.addInteger.Dock = System.Windows.Forms.DockStyle.Top;
            this.addInteger.Location = new System.Drawing.Point(3, 16);
            this.addInteger.Name = "addInteger";
            this.addInteger.Size = new System.Drawing.Size(72, 22);
            this.addInteger.TabIndex = 4;
            this.addInteger.Text = "add integer";
            this.addInteger.UseVisualStyleBackColor = true;
            // 
            // CreateGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 352);
            this.Controls.Add(this.RecordItemsArea);
            this.Name = "CreateGroup";
            this.Text = "CreateGroup";
            this.RecordItemsArea.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox RecordItemsArea;
        private System.Windows.Forms.Button removeEnum;
        private System.Windows.Forms.ComboBox definedEnums;
        private System.Windows.Forms.Button addEnum;
        private System.Windows.Forms.Button createEnum;
        private System.Windows.Forms.Button addImage;
        private System.Windows.Forms.Button addTextAttribute;
        private System.Windows.Forms.Button addTime;
        private System.Windows.Forms.Button addInteger;

    }
}