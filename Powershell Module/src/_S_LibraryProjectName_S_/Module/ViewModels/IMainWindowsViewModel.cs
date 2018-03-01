using System.Windows.Input;
using GalaSoft.MvvmLight;
using _S_LibraryProjectName_S_.Module.Common.UI;

namespace _S_LibraryProjectName_S_.Module.ViewModels
{
    public interface IMainWindowsViewModel: ILoadable
    {
        ViewModelBase SelectedViewModel { get; set; }

        ICommand LoadCommand { get; set; }

        ICommand UnLoadCommand { get; set; }
    }
}