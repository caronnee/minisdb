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
        public static DependencyProperty CRecord = DependencyProperty.Register("CurrentContent", typeof(CreateFieldText), typeof(RecordText), new PropertyMetadata(null));

        public CreateFieldText()
        {
            InitializeComponent();
            CreatedRecord = new RecordText(); 
        }

        public RecordText CreatedRecord
        {
            get { return GetValue(CRecord) as RecordText; }
            set { SetValue(CRecord,value); }
        }
     
        public bool Valid() { return true; }

        public RecordDescription GetRecord()
        {
            return CreatedRecord;
        }
    }
}
