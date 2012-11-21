namespace Minis
{
    partial class CreateLoadDbForm
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
            this.CreateButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.chooseDb = new System.Windows.Forms.ComboBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(12, 81);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(117, 34);
            this.CreateButton.TabIndex = 0;
            this.CreateButton.Text = "Create new database";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(169, 26);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(114, 31);
            this.LoadButton.TabIndex = 1;
            this.LoadButton.Text = "Load database";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.Load_Click);
            // 
            // chooseDb
            // 
            this.chooseDb.FormattingEnabled = true;
            this.chooseDb.Location = new System.Drawing.Point(12, 26);
            this.chooseDb.Name = "chooseDb";
            this.chooseDb.Size = new System.Drawing.Size(129, 21);
            this.chooseDb.TabIndex = 2;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(169, 81);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(114, 34);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove database";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // Uvod
            // 
            this.ClientSize = new System.Drawing.Size(295, 127);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.chooseDb);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.CreateButton);
            this.Name = "Uvod";
            this.Text = "Uvod";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.ComboBox chooseDb;
        private System.Windows.Forms.Button removeButton;
    }
}