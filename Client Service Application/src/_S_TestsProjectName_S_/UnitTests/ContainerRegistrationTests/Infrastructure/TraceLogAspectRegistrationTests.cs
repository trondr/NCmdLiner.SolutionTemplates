using NUnit.Framework;
using _S_ConsoleProjectName_S_.Infrastructure.ContainerExtensions;
using _S_TestsProjectName_S_.Common;

namespace _S_TestsProjectName_S_.UnitTests.ContainerRegistrationTests.Infrastructure
{
    [TestFixture(Category = "UnitTests")]
    public class TraceLogAspectRegistrationTests
    {
        [Test, RequiresSTA]
        public void TraceLogAspectRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<TraceLogAspect>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<TraceLogAspect, TraceLogAspect>();
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<TraceLogAspect>();
        }
    }
}