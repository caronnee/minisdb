using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using MiniDatabase.Content.CreateFields;

namespace MiniDatabase.Misc
{
    class TreeAttribute : TreeViewItem
    {
        public static DependencyProperty AContent = DependencyProperty.Register("AttributeContent", typeof(UserControl), typeof(TreeAttribute), new PropertyMetadata(null));

        public TreeAttribute()
        {
            FieldGeneric c = new FieldGeneric();
            c.controlCreated += new FieldGeneric.ControlCreated(changeControl);
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
