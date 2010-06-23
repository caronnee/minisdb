using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace myDb
{
    public partial class Uvod : MyForm
    {
        public Uvod()
        {       
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            endState = (int)WinType.WCreateNew;
        }

        private void Load_Click(object sender, EventArgs e)
        {
            endState = (int)WinType.WLoad;
            this.Close();
        }
    }
}
