using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Minis
{
    public enum State
    {
        StateIntro,
        StateCreateDatabase,
        StateLoadDatabase,
        StateSearchRecords,
        StateNone
    };

    // todo change for anstract
    public class StateManager : UserControl
    {
        public delegate void StateHandler( State s, String str);
        public event StateHandler StateChanged;
        public void OnStateChanged(State newState, String arg )
        {
            if (StateChanged != null)
                StateChanged( newState, arg);
        }
        public virtual void InitState() {}
    }
}
