using NUnit.Framework;
using _S_LibraryProjectName_S_.Module.Common.Install;
using _S_TestsProjectName_S_.Common;

namespace _S_TestsProjectName_S_.UnitTests.ContainerRegistrationTests.Module
{
    [TestFixture(Category = "UnitTests")]
    public class WindowsExplorerContextMenuInstallerRegistrationTests
    {        
        [Test, RequiresSTA]
        public static void WindowsExplorerContextMenuInstallerRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<IWindowsExplorerContextMenuInstaller>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<IWindowsExplorerContextMenuInstaller, WindowsExplorerContextMenuInstaller>();
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<IWindowsExplorerContextMenuInstaller>();
        }

    }
}