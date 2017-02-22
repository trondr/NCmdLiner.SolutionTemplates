using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Input;
using Common.Logging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using _S_LibraryProjectName_S_.Module.Common.UI;
using _S_LibraryProjectName_S_.Module.Views;

namespace _S_LibraryProjectName_S_.Module.ViewModels
{
    public class MainWindowViewModel: ViewModelBase, IMainWindowsViewModel
    {
        private readonly MainViewModel _mainViewModel;
        private readonly ILog _logger;
        private ViewModelBase _selectedViewModel;
        private ICommand _loadCommand;
        private ICommand _unLoadCommand;

        public MainWindowViewModel(IMessenger messenger, MainViewModel mainViewModel, ILog logger) : base(messenger)
        {
            _mainViewModel = mainViewModel;
            _logger = logger;
        }
        
        public async Task LoadAsync()
        {            
            _logger.Info($"Loading {this.GetType().Name}...");
            SelectedViewModel = _mainViewModel;
            await Task.FromResult(true);
        }

        public async Task UnloadAsync()
        {
            _logger.Info($"Unloading {this.GetType().Name}...");
            await Task.FromResult(true);
        }

        public ViewModelBase SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { this.SetProperty(ref _selectedViewModel, value); }
        }

        public LoadStatus LoadStatus { get; set; }

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
