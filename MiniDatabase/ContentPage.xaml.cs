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
using MiniDatabase.Content;

namespace MiniDatabase
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class ContentPage : Window
  {
    public static readonly DependencyProperty AContent = DependencyProperty.Register("CurrentContent", typeof(Content.ContentGeneric), typeof(ContentPage), new PropertyMetadata(null));

    public Content.ContentGeneric CurrentContent
    {
      set { SetValue(AContent, value); }
      get { return (Content.ContentGeneric)GetValue(AContent); }
    }

    public ContentPage()
    {
      try
      {
        InitializeComponent();
        ContentGeneric page = new ChooseDatabase();
        CurrentContent_Result(page);
      }

      catch (Exception e)
      {
        Console.Write("Something wrong happened {0}", e.ToString());
      }
    }

    private void AboutClick(object sender, RoutedEventArgs e)
    {
      AboutBox a = new AboutBox();
      a.ShowDialog();
    }

    private void RequestNewDatabase(object sender, RoutedEventArgs e)
    {
      CurrentContent_Result(new Content.CreateDatabase());
    }

    void CurrentContent_Result(Content.ContentGeneric nextPage)
    {
      CurrentContent = nextPage;
      if (CurrentContent != null)
      {
        CurrentContent.Result += new MiniDatabase.Content.ContentGeneric.Done(CurrentContent_Result);
        CurrentContent.Info += new ContentGeneric.InfoHandler(CurrentContent_Info);
        CurrentContent.Init();
      }
    }

    void CurrentContent_Info(string message)
    {
      infoBlock.Text += message;
      infoBlock.Text += "\n";
    }

    private void RequestSwitchDatabase(object sender, RoutedEventArgs e)
    {
      CurrentContent_Result(new Content.ChooseDatabase());
    }

    private void RequestManageEnums(object sender, RoutedEventArgs e)
    {
      CurrentContent_Result(new Content.CreateEnums());
    }
  }
}
