using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using _S_LibraryProjectName_S_.Module.Common.UI;

namespace _S_LibraryProjectName_S_.Module.ViewModels
{
    public class DesignTimeMainWindowsViewModel : IMainWindowsViewModel
    {
        private ICommand _loadCommand;
        private ICommand _unLoadCommand;

        public DesignTimeMainWindowsViewModel()
        {
            LoadStatus = LoadStatus.Loaded;
            SelectedViewModel = new DesignTimeMainViewModel();
        }

        public Task LoadAsync()
        {
            return Task.FromResult(true);
        }

        public Task UnloadAsync()
        {
            return Task.FromResult(true);
        }

        public LoadStatus LoadStatus { get; set; }
        public ViewModelBase SelectedViewModel { get; set; }
        public ICommand LoadCommand
        {
            get { return _loadCommand ?? (_loadCommand = new RelayCommand(async () => await LoadAsync())); }
            set { _loadCommand = value; }
        }

        public ICommand UnLoadCommand
        {
            get { return _unLoadCommand ?? (_unLoadCommand = new RelayCommand(async () => await UnloadAsync())); }
            set { _unLoadCommand = value; }
        }
    }
}