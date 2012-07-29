using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace myDb
{
    public class MyButton : Button
    {
        private DataGridViewColumn column_;
        public MyButton(DataGridViewColumn column)
        {
            column_ = column;
            this.Click +=new EventHandler(this.hideOrShow);
            this.FlatStyle = (column_.Visible) ? FlatStyle.Flat : FlatStyle.Standard;
        }

        void hideOrShow(object sender, EventArgs e)
        {
            column_.Visible = !column_.Visible;
            this.FlatStyle = (column_.Visible)? FlatStyle.Flat:FlatStyle.Standard;
        }
    }
    public partial class GridPanel : Form
    {
        List<Button> buttons;
        public GridPanel(DataGridView grid)
        {
            InitializeComponent();
            //initialize buttons
            buttons = new List<Button>();
            this.AutoSize = true;
            for (int i = 0; i < grid.ColumnCount -1; i++) //dame bez poslednej, ktora su ID
            {
                Button b = new MyButton(grid.Columns[i]);
                b.Text = grid.Columns[i].Name;
                b.AutoSize = true;
                buttons.Add(b);
                this.Controls.Add(b);
            }
            //do datagridtablu neskor
            for (int i = 0; i < grid.ColumnCount-1 ; i++)
                buttons[i].Dock = DockStyle.Top;

        }
    }
}
