using System.Collections;
using System.ComponentModel;

namespace _S_ConsoleProjectName_S_.Module
{
    [RunInstaller(true)]
    public partial class CustomInstaller : System.Configuration.Install.Installer
    {
        public CustomInstaller()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            //Example: Adding a command to windows explorer contect menu
            //this.Context.LogMessage("Adding _S_ConsoleProjectName_S_ to File Explorer context menu...");
            //new WindowsExplorerContextMenuInstaller().Install("_S_ConsoleProjectName_S_", "Create Something...", Assembly.GetExecutingAssembly().Location, "CreateSomething /exampleParameter=\"%1\"");
            //this.Context.LogMessage("Finnished adding _S_ConsoleProjectName_S_ to File Explorer context menu.");
            
            base.Install(stateSaver);
        }

        public override void Uninstall(IDictionary savedState)
        {
            //Example: Removing previously installed command from windows explorer contect menu
            //this.Context.LogMessage("Removing _S_ConsoleProjectName_S_ from File Explorer context menu...");
            //new WindowsExplorerContextMenuInstaller().UnInstall("_S_ConsoleProjectName_S_");
            //this.Context.LogMessage("Finished removing _S_ConsoleProjectName_S_ from File Explorer context menu.");
            
            base.Uninstall(savedState);
        }        
    }
}
