using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Minis
{
    public enum State
    {
        StateCreateDatabase,
        StateLoadDatabase,
        StateSearchRecords,
        StateNone
    };

    // todo change for anstract
    public class StateManager : UserControl
    {
        public delegate void StateHandler(UserControl sender, State s, String str);
        public event StateHandler StateChanged;
        protected void OnStateChanged(State newState, String arg )
        {
            if (StateChanged != null)
                StateChanged(this, newState, arg);
        }
        public virtual void InitState() {}
    }
}
