namespace _S_LibraryProjectName_S_.Module.Common.Install
{
    public interface IWindowsExplorerContextMenuInstaller
    {
        void Install(string commandId, string commandName, string command, string arguments);

        void UnInstall(string commandId);
    }
}
