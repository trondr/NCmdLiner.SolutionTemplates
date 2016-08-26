using NUnit.Framework;
using _S_ConsoleProjectName_S_.Infrastructure.ContainerExtensions;
using _S_TestsProjectName_S_.Common;

namespace _S_TestsProjectName_S_.UnitTests.ContainerRegistrationTests.Infrastructure
{
    [TestFixture(Category = "UnitTests")]
    public class DebugLogAspectRegistrationTests
    {
        [Test, RequiresSTA]
        public void DebugLogAspectRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<DebugLogAspect>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<DebugLogAspect, DebugLogAspect>();
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<DebugLogAspect>();
        }
    }
}