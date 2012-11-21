namespace Minis
{
    partial class CreateEnum
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
            this.add = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.toDefine = new System.Windows.Forms.TextBox();
            this.defined = new System.Windows.Forms.ListBox();
            this.ok = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // add
            // 
            this.add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.add.Location = new System.Drawing.Point(221, 25);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(67, 28);
            this.add.TabIndex = 1;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // remove
            // 
            this.remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.remove.Location = new System.Drawing.Point(221, 107);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(63, 31);
            this.remove.TabIndex = 3;
            this.remove.Text = "Remove";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // toDefine
            // 
            this.toDefine.Location = new System.Drawing.Point(36, 25);
            this.toDefine.Name = "toDefine";
            this.toDefine.Size = new System.Drawing.Size(115, 20);
            this.toDefine.TabIndex = 0;
            // 
            // defined
            // 
            this.defined.FormattingEnabled = true;
            this.defined.Location = new System.Drawing.Point(36, 107);
            this.defined.Name = "defined";
            this.defined.Size = new System.Drawing.Size(100, 95);
            this.defined.TabIndex = 2;
            // 
            // ok
            // 
            this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ok.Location = new System.Drawing.Point(199, 169);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(89, 34);
            this.ok.TabIndex = 4;
            this.ok.Text = "Ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(33, 9);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(67, 13);
            this.infoLabel.TabIndex = 5;
            this.infoLabel.Text = "Value to add";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(37, 55);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(63, 13);
            this.nameLabel.TabIndex = 6;
            this.nameLabel.Text = "Enum name";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(36, 71);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(112, 20);
            this.name.TabIndex = 7;
            // 
            // CreateEnum
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(300, 215);
            this.Controls.Add(this.name);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.defined);
            this.Controls.Add(this.toDefine);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.add);
            this.Name = "CreateEnum";
            this.Text = "CreateEnum";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.TextBox toDefine;
        private System.Windows.Forms.ListBox defined;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox name;
    }
}