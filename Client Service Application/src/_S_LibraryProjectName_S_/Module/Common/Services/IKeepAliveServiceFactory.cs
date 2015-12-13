namespace _S_LibraryProjectName_S_.Module.Common.Services
{
    public interface IKeepAliveServiceFactory
    {
        IKeepAliveService GetKeepAliveService(string keepAliveFile);
        void Release(IKeepAliveService keepAliveService);
    }
}
