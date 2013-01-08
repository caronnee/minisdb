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
            if ( state != State.StateNone)
            {
                this.SuspendLayout();
                Controls.Remove(this.screenContent);
                switch (state)
                {
                    case State.StateIntro:
                        {
                            this.screenContent = new Intro();
                            break;
                        }
                    case State.StateCreateDatabase:
                        {
                            this.screenContent = new Create();
                            break;
                        }
                    case State.StateLoadDatabase:
                        {
                            this.screenContent = new DatabaseWindow(args);
                            break;
                        }
                    default:
                        {
                            this.screenContent = new Intro();
                            break;
                        }
                }
                InitScreenShot();
                this.Controls.Add(this.screenContent);
                this.ResumeLayout();
            }
        }
        public DisplayPanel()
        {
            InitializeComponent();
        }

        //public delegate void StateHandler(UserControl sender, State s, String str);
        //public event StateHandler StateChanged;
    }
}
