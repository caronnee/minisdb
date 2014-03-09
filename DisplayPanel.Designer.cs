namespace Minis
{
    partial class DisplayPanel
    {
        private void InitScreenShot()
        {

            this.screenContent.InitState();
            // 
            // screenContent
            // 
            this.screenContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screenContent.Location = new System.Drawing.Point(0, 0);
            this.screenContent.Name = "screenContent";
            this.screenContent.Size = new System.Drawing.Size(0, 0);
            this.screenContent.TabIndex = 0;
        }
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
            this.screenContent = new Intro();
            this.SuspendLayout();
            
            InitScreenShot();
            // 
            // DisplayPanel
            // 
            this.Controls.Add(this.screenContent);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion



    }
}
