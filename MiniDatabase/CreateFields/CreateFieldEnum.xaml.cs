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

namespace MiniDatabase.CreateFields
{
    /// <summary>
    /// Interaction logic for CreateFieldEnum.xaml
    /// </summary>
    public partial class CreateFieldEnum : UserControl
    {
        public static readonly DependencyProperty NValue = DependencyProperty.Register("EnumSource", typeof(ICollection<String>), typeof(CreateFieldEnum), new PropertyMetadata(0));

        ICollection<String> _enums;

        public ICollection<String> EnumSource
        {
            get { return _enums; }
            set { _enums = value; }
        }
        public CreateFieldEnum()
        {
            _enums.Add("a");
            _enums.Add("ab");
            _enums.Add("aa");
            _enums.Add("x");
            InitializeComponent();
        }
    }
}
