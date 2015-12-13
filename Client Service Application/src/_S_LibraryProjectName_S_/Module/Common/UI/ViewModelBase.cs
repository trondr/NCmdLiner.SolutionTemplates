using System.Windows;
using _S_LibraryProjectName_S_.Module.Views;

namespace _S_LibraryProjectName_S_.Module.Common.UI
{
    public abstract class ViewModelBase : DependencyObject
    {
        public MainWindow MainWindow { get; set; }
    }
}
