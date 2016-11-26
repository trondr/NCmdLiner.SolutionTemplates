using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using _S_LibraryProjectName_S_.Module.Common.UI;
using _S_LibraryProjectName_S_.Module.ViewModels;

namespace _S_LibraryProjectName_S_.Module.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            Loaded+=OnLoaded;
            InitializeComponent();
        }
        public MainViewModel ViewModel { get; set; }
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            if (DesignerProperties.GetIsInDesignMode(this))
                return;
            ViewHelper.LoadViewModel(this, this.ViewModel);
        }
    }    
}
