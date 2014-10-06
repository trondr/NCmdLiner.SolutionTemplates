using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using Microsoft.Win32;

namespace _S_ConsoleProjectName_S_
{
    [RunInstaller(true)]
    public partial class SolutionCreatorInstaller : System.Configuration.Install.Installer
    {
        public SolutionCreatorInstaller()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            this.Context.LogMessage("Adding _S_ConsoleProjectName_S_ to File Explorer context menu...");
            const string solutionCreatorKeyPath = @"Software\Classes\Folder\shell\_S_ConsoleProjectName_S_";
            using (var solutionCreatorKey = Registry.LocalMachine.CreateSubKey(solutionCreatorKeyPath))
            {
                if (solutionCreatorKey == null) throw new NullReferenceException("Failed to create or open registry key: " + solutionCreatorKeyPath);
                solutionCreatorKey.SetValue(null,"Create New NCmdLiner Solution...");               
            }
            
            const string solutionCreatorCommandKeyPath = @"Software\Classes\Folder\shell\_S_ConsoleProjectName_S_\command";
            using (var solutionCreatorCommandKey = Registry.LocalMachine.CreateSubKey(solutionCreatorCommandKeyPath))
            {
                if (solutionCreatorCommandKey == null) throw new NullReferenceException("Failed to create or open registry key: " + solutionCreatorCommandKeyPath);
                solutionCreatorCommandKey.SetValue(null, string.Format("\"{0}\" CreateSolution /targetRootFolder=\"%1\"", Assembly.GetExecutingAssembly().Location), RegistryValueKind.String);
            }

            const string solutionCreatorKeyPath2 = @"Software\Classes\*\shell\_S_ConsoleProjectName_S_";
            using (var solutionCreatorKey = Registry.LocalMachine.CreateSubKey(solutionCreatorKeyPath2))
            {
                if (solutionCreatorKey == null) throw new NullReferenceException("Failed to create or open registry key: " + solutionCreatorKeyPath2);
                solutionCreatorKey.SetValue(null, "Create New NCmdLiner Solution...");
            }

            const string solutionCreatorCommandKeyPath2 = @"Software\Classes\*\shell\_S_ConsoleProjectName_S_\command";
            using (var solutionCreatorCommandKey = Registry.LocalMachine.CreateSubKey(solutionCreatorCommandKeyPath2))
            {
                if (solutionCreatorCommandKey == null) throw new NullReferenceException("Failed to create or open registry key: " + solutionCreatorCommandKeyPath2);
                solutionCreatorCommandKey.SetValue(null, string.Format("\"{0}\" CreateSolution /targetRootFolder=\"%1\"", Assembly.GetExecutingAssembly().Location), RegistryValueKind.String);
            }
            this.Context.LogMessage("Finnished adding _S_ConsoleProjectName_S_ to File Explorer context menu.");
            base.Install(stateSaver);
        }

        public override void Uninstall(IDictionary savedState)
        {
            this.Context.LogMessage("Removing _S_ConsoleProjectName_S_ from File Explorer context menu...");
            const string solutionCreatorKeyPath = @"Software\Classes\Folder\shell\_S_ConsoleProjectName_S_";
            const string solutionCreatorKeyPath2 = @"Software\Classes\*\shell\_S_ConsoleProjectName_S_";
            Registry.LocalMachine.DeleteSubKeyTree(solutionCreatorKeyPath);
            Registry.LocalMachine.DeleteSubKeyTree(solutionCreatorKeyPath2);            
            this.Context.LogMessage("Finished removing _S_ConsoleProjectName_S_ from File Explorer context menu.");
            base.Uninstall(savedState);
        }        
    }
}
