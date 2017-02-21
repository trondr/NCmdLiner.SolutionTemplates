using NUnit.Framework;
using _S_ConsoleProjectName_S_.Infrastructure;
using _S_LibraryProjectName_S_.Module.Views;
using _S_TestsProjectName_S_.Common;

namespace _S_TestsProjectName_S_.UnitTests.ContainerRegistrationTests.Module
{
    [TestFixture(Category = "UnitTests")]
    public class MainWindowRegistrationTests
    {
        [Test, RequiresSTA]
        public void MainWindowRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<MainWindow>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<MainWindow, MainWindow>();
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<MainWindow>();
            using (var bootStrapper = new BootStrapper())
            {
                var target = bootStrapper.Container.ResolveAll<MainWindow>();
                Assert.IsNotNull(target[0].ViewModel, "View was null");                
            }
        }
    }
}