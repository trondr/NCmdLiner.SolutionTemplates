using System.Threading.Tasks;

namespace _S_LibraryProjectName_S_.Module.Common.UI
{
    public interface ILoadable
    {        
        Task LoadAsync();
        
        Task UnloadAsync();

        LoadStatus LoadStatus { get; set; }
    }
}