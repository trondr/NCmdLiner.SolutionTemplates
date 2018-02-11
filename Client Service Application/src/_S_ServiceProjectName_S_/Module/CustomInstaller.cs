using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Reflection;

namespace _S_ServiceProjectName_S_.Module
{
    [RunInstaller(true)]
    public partial class CustomInstaller : Installer
    {
        public CustomInstaller()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            Context.LogMessage("Installing service...");
            var exitCode = RunAndWaitForProcess(ServiceExePath(), "install");
            if (exitCode != 0)
                throw new InstallException($"Failed to install _S_ServiceProjectName_S_ service. Exit code: {exitCode}");
            base.Install(stateSaver);
        }

        public override void Uninstall(IDictionary savedState)
        {
            Context.LogMessage("Uninstalling service...");
            var exitCode = RunAndWaitForProcess(ServiceExePath(), "uninstall");
            if (exitCode != 0)
                throw new InstallException($"Failed to uninstall _S_ServiceProjectName_S_ service. Exit code: {exitCode}");
            base.Uninstall(savedState);
        }
        
        private string ServiceExePath()
        {
            return Assembly.GetExecutingAssembly().Location;
        }
        
        private int RunAndWaitForProcess(string exeFilePath, string arguments)
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = exeFilePath,
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = arguments
            };
            int exitCode;
            Context.LogMessage($"Start: \"{exeFilePath}\" {arguments}");
            using (var process = Process.Start(processStartInfo))
            {
                process?.WaitForExit();
                exitCode = process?.ExitCode ?? 1;
            }
            Context.LogMessage($"Stop: \"{exeFilePath}\" {arguments}. Exitcode: {exitCode}");
            return exitCode;
        }
    }
}
