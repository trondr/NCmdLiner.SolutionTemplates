using System.Windows.Input;
using _S_LibraryProjectName_S_.Module.Common.UI;

namespace _S_LibraryProjectName_S_.Module.ViewModels
{
    public interface IMainViewModel: ILoadable
    {
        int MaxLabelWidth { get; set; }
        string ProductDescription { get; set; }
        string ProductDescriptionLabelText { get; set; }
        ICommand ExitCommand { get; set; }
        ICommand LoadCommand { get; set; }
        ICommand UnLoadCommand { get; set; }
    }
}
