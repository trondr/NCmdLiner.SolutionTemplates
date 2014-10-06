using _S_LibraryProjectName_S_.Common.UI;
using _S_LibraryProjectName_S_.ViewModels;

namespace _S_LibraryProjectName_S_.Views
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
