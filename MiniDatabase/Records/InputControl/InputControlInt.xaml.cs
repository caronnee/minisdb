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
using MiniDatabase.Misc;

namespace MiniDatabase.Records.InputControl
{
  /// <summary>
  /// Interaction logic for InputControlInt.xaml
  /// </summary>
  public partial class InputControlInt : NumericUpDown, ControlValue
  {
    public InputControlInt()
    {
      InitializeComponent();
    }

    public Value ConvertToValue()
    {
      ValueInteger i = new ValueInteger();
      i.NNumber = NumericValue;
      return i;
    }
    public void SetValue(Value value)
    {
      ValueInteger v = value as ValueInteger;
      NumericValue = v.NNumber;
    }
    public String GetStringValue()
    {
      return NumericValue.ToString();
    }

    public Control Clone()
    {
      InputControlInt ret = new InputControlInt();
      ret.Minimum = Minimum;
      ret.Maximum = Maximum;
      ret.NumericValue = NumericValue;
      return ret;
    }

  }
}
