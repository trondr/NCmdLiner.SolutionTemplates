using _S_LibraryProjectName_S_.Module.Common.UI;
using _S_LibraryProjectName_S_.Module.ViewModels;

namespace _S_LibraryProjectName_S_.Module.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : ViewBase
    {
        public MainView(MainViewModel viewModel)
        {
            this.ViewModel = viewModel;
            InitializeComponent();
        }
    }
}
