using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace myDb
{
    public class ShowBox
    {
        public Control showControl;

        public ShowBox(Control c)
        {
            showControl = c;
            showControl.ParentChanged += new EventHandler(showControl_ParentChanged);
        }

        void showControl_ParentChanged(object sender, EventArgs e)
        {
            setContext(showControl);
        }
        protected void setContext(Control cc)
        {
            ContextMenu c = new ContextMenu();
            MenuItem m = new MenuItem("Resize");
            m.Click += new EventHandler(newSize);
            c.MenuItems.Add(m);
            m = new MenuItem("Move");
            m.Click += new EventHandler(beginMove);
            c.MenuItems.Add(m);
            cc.ContextMenu = c;
        }
        void newSize(object sender, EventArgs e)
        {
            setSizeForm s = new setSizeForm();
            s.width.Value = showControl.Size.Width;
            s.heigth.Value = showControl.Size.Height;
            s.ShowDialog();
            Control c = ((sender as MenuItem).Parent as ContextMenu).SourceControl;
            int x = decimal.ToInt32(s.width.Value);
            int y = decimal.ToInt32(s.heigth.Value);
            c.Size = new System.Drawing.Size(x, y);
        }
        
        void beginMove(object sender, EventArgs e)
        {
            ContextMenu m = (sender as MenuItem).Parent as ContextMenu;
            //zrusit double click?
            Control c = m.SourceControl;
            
            System.Drawing.Point p = System.Windows.Forms.Cursor.Position;
            p = c.Parent.PointToClient(p);

            c.Parent.MouseMove +=new MouseEventHandler(parent_move);
            c.MouseMove += new MouseEventHandler(move);
            c.Parent.MouseDown += new MouseEventHandler(endMove);
            c.MouseDown += new MouseEventHandler(endMove);
        }
        void parent_move(object sender, EventArgs e)
        {
            Control c = sender as Control;
            System.Drawing.Point p = System.Windows.Forms.Cursor.Position;
            p = c.PointToClient(p);
            this.showControl.Location = new System.Drawing.Point(p.X-6, p.Y-6);
        }
        void move(object sender, EventArgs e)
        {
            Control c = sender as Control;
            parent_move(c.Parent, null);
        }
        void endMove(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            c.MouseClick -= endMove;
            c.MouseMove -= move;
            c.Parent.MouseMove -= parent_move;
        }

    }
}
