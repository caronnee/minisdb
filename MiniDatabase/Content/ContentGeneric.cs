using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

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

    protected void OnInfo(string ctx)
    {
      Info(ctx);
    }

    public virtual void Init()
    {

    }
  }
}
