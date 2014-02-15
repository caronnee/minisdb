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
        public static readonly DependencyProperty EnumValue = DependencyProperty.Register("EnumSource", typeof(ICollection<Control>), typeof(CreateFieldEnum), new PropertyMetadata(null));
        
        public ICollection<Control> EnumSource
        {
            get
            {
                return (ICollection<Control>)GetValue(EnumValue);
            }
            set
            {
                SetValue(EnumValue,value);
            }
        }
        public CreateFieldEnum()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                Console.Write("Exception occured {0}",e.ToString());
            }
        }
    }
}
