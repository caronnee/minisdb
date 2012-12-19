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
        //public void ChangeState(UserControl sender, State s,String param)
        //{
        //    //change state and plan repaint
        //    _modeChanged = s;
        //    //repaint();
        //}
        public MainContainer()
        {
            InitializeComponent();
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