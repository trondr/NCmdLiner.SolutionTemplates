using NUnit.Framework;
using _S_LibraryProjectName_S_.Module.ViewModels;
using _S_TestsProjectName_S_.Common;

namespace _S_TestsProjectName_S_.UnitTests.ContainerRegistrationTests.Module
{
    [TestFixture(Category = TestCategory.UnitTests)]
    public class MainWindowViewModelRegistrationTests
    {
        [Test, RequiresSTA]
        public void MainWindowViewModelRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<MainWindowViewModel>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<MainWindowViewModel, MainWindowViewModel>();
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<MainWindowViewModel>();
        }
    }
}