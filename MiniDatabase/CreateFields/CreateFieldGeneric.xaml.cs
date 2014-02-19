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
    /// Interaction logic for CreateFieldGeneric.xaml
    /// </summary>
    public partial class CreateFieldGeneric : UserControl
    {
        public delegate void ControlCreated(UserControl control);
        public event ControlCreated controlCreated;

        public CreateFieldGeneric()
        {
            InitializeComponent();
        }

        private void createTextClick(object sender, RoutedEventArgs e)
        {
            if (controlCreated == null)
                return;
            controlCreated(new CreateFieldText());
        }

        private void createEnumClick(object sender, RoutedEventArgs e)
        {
            if (controlCreated == null)
                return;
            controlCreated(new CreateFieldEnum());
        }

        private void createIntClick(object sender, RoutedEventArgs e)
        {
            if (controlCreated == null)
                return;
            controlCreated( new CreateFieldInteger() );
        }

        private void createCompositeClick(object sender, RoutedEventArgs e)
        {
            // TODO implement
            return;
        }
    }
}
