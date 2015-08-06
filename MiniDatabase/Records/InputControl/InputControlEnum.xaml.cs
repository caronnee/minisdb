using MiniDatabase.Banks;
using MiniDatabase.Records.Description;
using MiniDatabase.Records.Values;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace MiniDatabase.Records.InputControl
{
  /// <summary>
  /// Interaction logic for InputControlEnum.xaml
  /// </summary>
  public partial class InputControlEnum : ComboBox, ControlValue
  {
    public static DependencyProperty EnumContainerProp = DependencyProperty.Register("EnumContainer", typeof(EnumCollection), typeof(InputControlEnum), new PropertyMetadata(null));

    public EnumCollection EnumContainer
    {
      get { return GetValue(EnumContainerProp) as EnumCollection; }
      set { 
        SetValue(EnumContainerProp, value); 
      }
    }

    public InputControlEnum()
    {
      EnumContainer = new EnumCollection("Nothing");
      InitializeComponent();
    }

    public Value ConvertToValue()
    {
      int index = SelectedIndex;
      return new ValueInteger(index);
    }
    
    public void SetValue(Value value)
    {
      ValueInteger i = value as ValueInteger;
      SelectedIndex = i.NNumber;
    }

    public String GetStringValue()
    {
      if ( SelectedIndex == -1)
        return "Undefined";
      return EnumContainer.Values[SelectedIndex];
    }

    public Control Clone()
    {
      InputControlEnum i = new InputControlEnum();
      i.EnumContainer = EnumContainer;
      return i;
    }
  }
}
