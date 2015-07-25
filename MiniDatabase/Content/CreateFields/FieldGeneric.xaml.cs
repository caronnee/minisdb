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
using MiniDatabase.Records.Description;

namespace MiniDatabase.Content.CreateFields
{
  /// <summary>
  /// Interaction logic for CreateFieldGeneric.xaml
  /// </summary>
  public partial class FieldGeneric : UserControl, FieldInterface
  {
    public delegate void ControlCreated(UserControl control);
    public event ControlCreated controlCreated;

    public FieldGeneric()
    {
      InitializeComponent();
    }

    private void createTextClick(object sender, RoutedEventArgs e)
    {
      if (controlCreated == null)
        return;
      try
      {
        controlCreated(new FieldText());
      }
      catch (System.Exception ex)
      {
        System.Console.Write(ex.ToString());
      }
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
      controlCreated(new FieldEnum());
    }

    private void createIntClick(object sender, RoutedEventArgs e)
    {
      if (controlCreated == null)
        return;
      controlCreated(new FieldInteger());
    }

    private void createDateClick(object sender, RoutedEventArgs e)
    {
      if (controlCreated == null)
        return;
      controlCreated(new FieldDate());
    }

    private void createCompositeClick(object sender, RoutedEventArgs e)
    {
      throw new Exception("Not implemented yet");
    }
    public bool Valid() { return false; }

    public RecordDescription GetRecordDescription()
    {
      throw new Exception("not implemented yet");
    }
  }
}
