using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace myDb
{
    public enum WinType
    {
        WCreateNew =1,
        WLoad = 2
    };

    public class MyForm : Form
    {
        protected int endState;
        public MyForm()
        {
            endState = 0;
        }
        public int endCode()
        {
            return endState;
        }
    }
}