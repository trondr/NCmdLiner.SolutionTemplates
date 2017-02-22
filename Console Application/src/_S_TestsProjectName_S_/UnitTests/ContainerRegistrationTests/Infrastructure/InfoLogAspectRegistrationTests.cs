using NUnit.Framework;
using _S_ConsoleProjectName_S_.Infrastructure.ContainerExtensions;
using _S_TestsProjectName_S_.Common;

namespace _S_TestsProjectName_S_.UnitTests.ContainerRegistrationTests.Infrastructure
{
    [TestFixture(Category=TestCategory.UnitTests)]
    public class InfoLogAspectRegistrationTests
    {
        [Test, RequiresSTA]
        public void InfoLogAspectRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<InfoLogAspect>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<InfoLogAspect, InfoLogAspect>();
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<InfoLogAspect>();
        }
    }
}