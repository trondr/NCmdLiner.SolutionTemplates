using NUnit.Framework;
using _S_LibraryProjectName_S_.Module.Commands.ExampleCreateUsingService;
using _S_TestsProjectName_S_.Common;

namespace _S_TestsProjectName_S_.UnitTests.ContainerRegistrationTests.Module
{
    [TestFixture(Category=TestCategory.UnitTests)]
    public class ExampleCreateUsingServiceCommandProviderTests
    {        
        [Test, RequiresSTA]
        public static void ExampleCreateUsingServiceCommandProviderTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<IExampleCreateUsingServiceCommandProvider>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceTypeName<IExampleCreateUsingServiceCommandProvider>("IExampleCreateUsingServiceCommandProviderProxy");
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<IExampleCreateUsingServiceCommandProvider>();
        }

    }
}