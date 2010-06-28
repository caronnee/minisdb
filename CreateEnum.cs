using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace myDb
{
    public partial class CreateEnum : MyForm
    {
        public CreateEnum()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (this.toDefine.Text.Length == 0)
                return; //message s varovanim!
            for (int i = 0; i < this.defined.Items.Count; i++)
            {
                if (((String)defined.Items[i]).Equals(this.toDefine.Text))
                    return;
            }
            this.defined.Items.Add(toDefine.Text);
            this.toDefine.Text = "";
        }

        private void remove_Click(object sender, EventArgs e)
        {
            this.defined.Items.Remove(this.defined.SelectedItem);
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (this.defined.Items.Count == 0)
                return;
            if (this.name.Text.Length == 0)
                return;
            this.endState = 1;
            this.Close();
        }
        public string getName()
        {
            return this.name.Text;
        }
        public object[] getValues()
        {
            object[] o = new object[this.defined.Items.Count];
            this.defined.Items.CopyTo(o,0);
            return o;
        }
    }
}
