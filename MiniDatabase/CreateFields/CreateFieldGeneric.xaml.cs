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
using MiniDatabase.Banks;

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
            if (EnumBank.Bank.Collections.Count == 0)
            {
                MessageBox.Show("Unable to create enums, no enum defined\nPlease go to the manage enums and create the one enum", "Unable to create enum", MessageBoxButton.OK);
                return;
            }
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
