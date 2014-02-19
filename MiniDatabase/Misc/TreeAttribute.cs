using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace MiniDatabase.Misc
{
    class TreeAttribute : TreeViewItem
    {
        public static DependencyProperty AContent = DependencyProperty.Register("AttributeContent", typeof(UserControl), typeof(TreeAttribute), new PropertyMetadata(null));

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
            get
            {
                return (UserControl)GetValue(AContent);
            }
            set
            {
                SetValue(AContent, value);
            }
        }

        public Boolean CanBeRemoved
        {
            set;
            get;
        }
    }
}
