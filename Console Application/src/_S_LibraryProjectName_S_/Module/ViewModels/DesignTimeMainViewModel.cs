using System;
using System.Windows.Input;
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
        public ICommand OkCommand { get; set; }

        public override void Load()
        {
            throw new NotImplementedException();
        }

        public override Action CloseWindow { get; set; }
    }
}