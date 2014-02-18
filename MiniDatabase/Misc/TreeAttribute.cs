﻿using System;
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
