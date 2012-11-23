using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Minis
{
    public partial class MainContainer : Form
    {
        public MainContainer()
        {
            InitializeComponent();
            // opening screen
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // show about
            // about is dialog
            AboutBox box = new AboutBox();
            box.ShowDialog();
        }
    }
}