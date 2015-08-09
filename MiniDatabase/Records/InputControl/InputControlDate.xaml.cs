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
using MiniDatabase.Records.Values;

namespace MiniDatabase.Records.InputControl
{
  /// <summary>
  /// Interaction logic for InputControlDate.xaml
  /// </summary>
  public partial class InputControlDate : DatePicker, ControlValue
  {
    public InputControlDate()
    {
      InitializeComponent();
      SelectedDate = DateTime.Today;
    }

    public Control Clone()
    {
      InputControlDate d = new InputControlDate();
      d.SelectedDate = SelectedDate;
      return d;
    }
    public void SetValue(Value value)
    {
      ValueDate d = value as ValueDate;
      this.SelectedDate = d.DTime;
    }
    public String GetStringValue()
    {
      return SelectedDate.ToString();
    }
    public Value ConvertToValue()
    {
      ValueDate date = new ValueDate();
      if ( SelectedDate!=null)
       date.DTime = (DateTime)SelectedDate;
      return date;
    }

  }
}
