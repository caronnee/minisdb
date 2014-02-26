using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace MiniDatabase.Content
{
    public class ContentGeneric : UserControl
    {
        public enum ContentResult
        {
            ResultSuccess,
            ResultCancel,
        }
        public delegate void Done(ContentResult result);
        public event Done Result;
    }
}
