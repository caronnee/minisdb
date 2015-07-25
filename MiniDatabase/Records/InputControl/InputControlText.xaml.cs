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
  /// Interaction logic for InputControlText.xaml
  /// </summary>
  public partial class InputControlText : TextBox, ControlValue
  {
    private void Init(String val)
    {
      InitializeComponent();
      Text = val;
    }

    public String GetStringValue()
    {
      return Text;
    }

    public void SetValue( Value val)
    {
      if ( val!= null)
        Text = val.ToString();
    }

    public Value ConvertToValue()
    {
      return new ValueText(Text);
    }

    public Control Clone()
    {
      return new InputControlText(Text);
    }

    public InputControlText(String val)
    {
      Init(val);
    }

    public InputControlText()
    {
      Init("");
    }
  }
}
