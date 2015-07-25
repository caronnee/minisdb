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
using MiniDatabase.Records.Description;

namespace MiniDatabase.Content.CreateFields
{
    /// <summary>
    /// Interaction logic for FieldInteger.xaml
    /// </summary>
    public partial class FieldInteger : UserControl, FieldInterface
    {
      public static DependencyProperty CRecord = DependencyProperty.Register("CreatedRecord", typeof(RecordDescriptionInt), typeof(FieldInteger), new PropertyMetadata(null));

      public RecordDescriptionInt CreatedRecord
      {
        get { return GetValue(CRecord) as RecordDescriptionInt; }
        set { SetValue(CRecord, value); }
      }
        public FieldInteger()
        {
          CreatedRecord = new RecordDescriptionInt();
          InitializeComponent();
        }
        public bool Valid() { return true; }

        public RecordDescription GetRecordDescription()
        {
          return CreatedRecord;
        }
    }
}
