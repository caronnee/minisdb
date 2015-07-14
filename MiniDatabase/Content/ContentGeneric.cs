using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace MiniDatabase.Content
{
  public class ContentGeneric : UserControl
  {
    public delegate void Done(ContentGeneric next);
    public event Done Result;

    protected void OnResult(ContentGeneric next)
    {
      if ( Result!= null)
        Result(next);
    }

    public delegate void InfoHandler(string message);
    public event InfoHandler Info;

    public void OnInfo(string ctx)
    {
      Info(ctx);
    }

    public virtual void Init()
    {

    }

    public virtual void Finish()
    {

    }
  }
}
