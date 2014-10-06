using System.Windows;
using _S_LibraryProjectName_S_.Views;

namespace _S_LibraryProjectName_S_.Common.UI
{
    public abstract class ViewModelBase : DependencyObject
    {
        public MainWindow MainWindow { get; set; }
    }
}
