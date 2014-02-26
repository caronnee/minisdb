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
        public delegate void Done( ContentGeneric next );
        public event Done Result;

        virtual public void OnResult( ContentGeneric next )
        {
            if (Result == null)
                return;
            Result(next);
        }
    }
}
