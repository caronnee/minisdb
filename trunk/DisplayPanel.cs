using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Minis
{
    public partial class DisplayPanel : Control
    {
        private void SetState(State state, String args)
        {
            _state = state; //TODO args
        }
        public DisplayPanel()
        {
            _state = State.StateNone;
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: Add custom paint code here
            if (_state != State.StateNone)
                InitializeComponent();// initialize again
            _state = State.StateNone;
            // Calling the base class OnPaint
            base.OnPaint(pe);
        }

        //public delegate void StateHandler(UserControl sender, State s, String str);
        //public event StateHandler StateChanged;
        State _state;
    }
}
