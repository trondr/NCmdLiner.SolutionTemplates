using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Common.Logging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using _S_LibraryProjectName_S_.Module.Common.UI;
using _S_LibraryProjectName_S_.Module.Views;

namespace _S_LibraryProjectName_S_.Module.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private readonly ILog _logger;
        private int _maxLabelWidth;
        private string _productDescription;
        private string _productDescriptionLabelText;
        private ICommand _loadCommand;
        private ICommand _unLoadCommand;
        private ICommand _exitCommand;

        public MainViewModel(IMessenger messenger, ILog logger) : base(messenger)
        {
            _logger = logger;
        }

        public int MaxLabelWidth
        {
            get { return _maxLabelWidth; }
            set { this.SetProperty(ref _maxLabelWidth, value); }
        }

        public string ProductDescription
        {
            get { return _productDescription; }
            set { this.SetProperty(ref _productDescription, value); }
        }

        public string ProductDescriptionLabelText
        {
            get { return _productDescriptionLabelText; }
            set { this.SetProperty(ref _productDescriptionLabelText, value); }
        }

        public Task LoadAsync()
        {
            if (LoadStatus == LoadStatus.Loaded || LoadStatus == LoadStatus.Loading || LoadStatus == LoadStatus.UnLoading )
                return Task.FromResult(true);
            
            LoadStatus = LoadStatus.Loading;
            _logger.Info($"Loading {this.GetType().Name}");
            ProductDescriptionLabelText = "Product Description:";
            ProductDescription = "My Product";
            MaxLabelWidth = 200;
            ExitCommand = new RelayCommand(() => MessengerInstance.Send(new CloseWindowMessage()));
            LoadStatus = LoadStatus.Loaded;
            return Task.FromResult(true);
        }

        public Task UnloadAsync()
        {
            if (LoadStatus == LoadStatus.NotLoaded || LoadStatus == LoadStatus.Loading || LoadStatus == LoadStatus.UnLoading )
                return Task.FromResult(true);
            
            LoadStatus = LoadStatus.UnLoading;
            _logger.Info($"Unloading {this.GetType().Name}");
            ProductDescriptionLabelText = string.Empty;
            ProductDescription = string.Empty;
            MaxLabelWidth = 0;            
            LoadStatus = LoadStatus.NotLoaded;
            return Task.FromResult(true);
        }

        public ICommand ExitCommand
        {
            get { return _exitCommand ?? (_exitCommand = new RelayCommand(() => MessengerInstance?.Send(new CloseWindowMessage()))); }
            set { _exitCommand = value; }
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