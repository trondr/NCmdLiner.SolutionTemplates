using _S_LibraryProjectName_S_.Module.Common.UI;
using _S_LibraryProjectName_S_.Module.ViewModels;

namespace _S_LibraryProjectName_S_.Module.Views
{
    public class MainViewBase : ViewBase<MainViewModel> { }

    public partial class MainView : MainViewBase
    {
        public MainView()
        {            
            InitializeComponent();
        }        
    }
}
