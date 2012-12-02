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
        public void ChangeState(UserControl sender, State s,String param)
        {
            //change state and plan repaint
            _modeChanged = s;
            //repaint();
        }
        public MainContainer()
        {
            InitializeComponent();
            this.screen.StateChanged += new StateManager.StateHandler(this.ChangeState);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // show about
            // about is dialog
            AboutBox box = new AboutBox();
            box.ShowDialog();
        }

        private void CheckControls(object sender, PaintEventArgs e)
        {
            return;
            //TODO use repaint or not?
            if (_modeChanged == State.StateNone)
                return;
            this.Controls.Remove(this.screen);
            this.screen = new Create();
            this.screen.StateChanged += new StateManager.StateHandler(this.ChangeState);
            this.Controls.Add(this.screen);            
            _modeChanged = State.StateNone;
        }
        private State _modeChanged;
    }
}