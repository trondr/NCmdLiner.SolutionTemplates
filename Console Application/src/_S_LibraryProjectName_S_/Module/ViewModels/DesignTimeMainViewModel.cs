using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using _S_LibraryProjectName_S_.Module.Common.UI;

namespace _S_LibraryProjectName_S_.Module.ViewModels
{
    public class DesignTimeMainViewModel : ViewModelBase, IMainViewModel
    {
        public DesignTimeMainViewModel()
        {
            this.ProductDescription = "My Product Description";
            this.ProductDescriptionLabelText = "Product Description:";
            this.MaxLabelWidth = 200;
        }

        public int MaxLabelWidth { get; set; }
        public string ProductDescription { get; set; }
        public string ProductDescriptionLabelText { get; set; }
        
        public async Task LoadAsync()
        {
            await Task.FromResult(true);
        }

        public async Task UnloadAsync()
        {
            await Task.FromResult(true);
        }

        public LoadStatus LoadStatus { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand UnLoadCommand { get; set; }
    }
}