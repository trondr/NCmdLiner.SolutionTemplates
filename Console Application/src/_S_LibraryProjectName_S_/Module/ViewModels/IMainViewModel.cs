using System.Windows.Input;

namespace _S_LibraryProjectName_S_.Module.ViewModels
{
    public interface IMainViewModel
    {
        int MaxLabelWidth { get; set; }
        string ProductDescription { get; set; }
        string ProductDescriptionLabelText { get; set; }
        ICommand OkCommand { get; set; }
    }
}
