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
using MiniDatabase.Records;

namespace MiniDatabase.CreateFields
{
    /// <summary>
    /// Interaction logic for CreateFieldInteger.xaml
    /// </summary>
    public partial class CreateFieldInteger : UserControl, CreateFieldInterface
    {
        public CreateFieldInteger()
        {
            InitializeComponent();
        }
        public bool Valid() { return true; }

        public RecordDescription GetRecordDescription()
        {
            throw new Exception("not implemented yet");
        }
    }
}
