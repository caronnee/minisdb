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
    public partial class Create : MyForm
    {
        public Create()
        {
            InitializeComponent();
        }

        private void LoadFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog b = new OpenFileDialog();
            b.InitialDirectory = Environment.SpecialFolder.Recent.ToString();
            b.Multiselect = true;
            b.ShowDialog();
            String s = "Subory";
            for (int i =0; i < b.FileNames.Length; i++)
                s+= " " + b.FileNames.GetValue(i);
            MessageBox.Show(s + " boli vybrane");
        }
    }
}
