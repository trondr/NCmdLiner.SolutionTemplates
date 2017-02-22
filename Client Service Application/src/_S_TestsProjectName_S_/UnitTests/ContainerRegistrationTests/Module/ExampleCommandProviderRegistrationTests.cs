using NUnit.Framework;
using _S_LibraryProjectName_S_.Infrastructure;
using _S_LibraryProjectName_S_.Module.Commands.Example;
using _S_TestsProjectName_S_.Common;

namespace _S_TestsProjectName_S_.UnitTests.ContainerRegistrationTests.Module
{
    [TestFixture(Category=TestCategory.UnitTests)]
    public class ExampleCommandProviderRegistrationTests
    {        
        [Test, RequiresSTA]
        public static void ExampleCommandProviderRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<IExampleCommandProvider>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceTypeName<IExampleCommandProvider>("IExampleCommandProviderProxy");
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<IExampleCommandProvider>();
        }

    }
}