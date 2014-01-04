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
        // bind to depedency
        public CreateFieldGeneric()
        {
            InitializeComponent();
            Specialization = new CreateFieldInteger();
        }
        public Control Specialization
        {
            get;
            set;
        }
    }
}
