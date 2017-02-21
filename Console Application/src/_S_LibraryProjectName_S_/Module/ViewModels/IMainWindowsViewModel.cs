using System.Windows.Input;
using GalaSoft.MvvmLight;

namespace _S_LibraryProjectName_S_.Module.ViewModels
{
    public interface IMainWindowsViewModel: ILoadable
    {
        ViewModelBase SelectedViewModel { get; set; }

        ICommand LoadCommand { get; set; }

        ICommand UnLoadCommand { get; set; }
    }
}