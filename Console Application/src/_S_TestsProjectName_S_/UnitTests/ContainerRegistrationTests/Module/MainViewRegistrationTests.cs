using NUnit.Framework;
using _S_ConsoleProjectName_S_.Infrastructure;
using _S_LibraryProjectName_S_.Module.Views;
using _S_TestsProjectName_S_.Common;

namespace _S_TestsProjectName_S_.UnitTests.ContainerRegistrationTests.Module
{
    [TestFixture(Category = "UnitTests")]
    public class MainViewRegistrationTests
    {
        [Test, RequiresSTA]
        public void MainViewRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<MainView>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<MainView, MainView>();
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<MainView>();            
        }
    }
}