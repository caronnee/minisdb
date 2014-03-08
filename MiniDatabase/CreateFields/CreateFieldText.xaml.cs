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
    /// Interaction logic for CreateFieldText.xaml
    /// </summary>
    public partial class CreateFieldText : UserControl, CreateFieldBase
    {
        public CreateFieldText()
        {
            InitializeComponent();
        }
        public bool Valid() { return true; }
        public Record GetRecord()
        {
            RecordText r = new RecordText();
            return r;
        }
    }
}
