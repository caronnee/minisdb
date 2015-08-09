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
  /// Interaction logic for CreateFieldText.xaml
  /// </summary>
  public partial class FieldText : UserControl, FieldInterface
  {
    public static DependencyProperty CRecord = DependencyProperty.Register("CreatedRecord", typeof(RecordDescriptionText), typeof(FieldText), new PropertyMetadata(null));

    public RecordDescriptionText CreatedRecord
     {
      get { return GetValue(CRecord) as RecordDescriptionText; }
      set { SetValue(CRecord, value); }
    }

    public RecordDescription GetRecordDescription()
    {
      return CreatedRecord;
    }

    public FieldText()
    {
      CreatedRecord = new RecordDescriptionText();
      InitializeComponent();
    }   
  }
}
