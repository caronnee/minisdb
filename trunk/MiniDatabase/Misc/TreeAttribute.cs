using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace MiniDatabase.Misc
{
    class TreeAttribute : TreeViewItem
    {
        public TreeAttribute()
        {
            CreateFields.CreateFieldGeneric c = new CreateFields.CreateFieldGeneric();
            c.controlCreated += new CreateFields.CreateFieldGeneric.ControlCreated(changeControl);
            AttributeContent = c;
        }

        void changeControl(UserControl control)
        {
            AttributeContent = control;
        }

        public UserControl AttributeContent
        {
            get;
            set;
        }

        public Boolean CanBeRemoved
        {
            set;
            get;
        }
    }
}
