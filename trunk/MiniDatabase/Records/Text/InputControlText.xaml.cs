using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiniDatabase.Records.Text
{
    /// <summary>
    /// Interaction logic for InputControlText.xaml
    /// </summary>
    public partial class InputControlText : TextBox
    {
        private void Init(String val)
        {
            InitializeComponent();
            Text = val;
        }
        public InputControlText(String val)
        {
            Init(val);
        }

        public InputControlText()
        {
            Init("");
        }
    }
}
