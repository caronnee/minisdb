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
  /// Interaction logic for CreateFieldDate.xaml
  /// </summary>
  public partial class FieldDate : UserControl, FieldInterface
  {
    public FieldDate()
    {
      CreatedRecord = new RecordDescriptionDate();
      InitializeComponent();
    }

    public static DependencyProperty CRecord = DependencyProperty.Register("CreatedRecord", typeof(RecordDescriptionDate), typeof(FieldDate), new PropertyMetadata(null));

    public RecordDescriptionDate CreatedRecord
    { 
      get { return GetValue(CRecord) as RecordDescriptionDate; }
      set { SetValue(CRecord, value); }
    }

    /* Return valid record corresponding to the control that implements this */
    public RecordDescription GetRecordDescription()
    {
      return CreatedRecord;
    }
  }
}
