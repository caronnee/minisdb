using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Minis
{
    public partial class CreateEnum : Panel
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
            this.toDefine.Focus();
        }

        private void remove_Click(object sender, EventArgs e)
        {
            this.defined.Items.Remove(this.defined.SelectedItem);
        }

        private void ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.defined.Items.Count == 0)
                    throw new Exception("No enum defined");
                if (this.name.Text.Length == 0)
                    throw new Exception("Name of enum is ntot valid!");
                //TODO inform about changed state
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
