using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace MiniDatabase.Content.ResultsTab
{
  public class RecordableTab : TabItem
  {
    public static readonly DependencyProperty ParentContentProperty = DependencyProperty.Register("ParentContent", typeof(ContentGeneric), typeof(RecordableTab), new PropertyMetadata(null));

    public ContentGeneric ParentContent
    {
      get
      {
        return (ContentGeneric)GetValue(ParentContentProperty);
      }
      set
      {
        SetValue(ParentContentProperty, value);
      }
    }
  }
}
