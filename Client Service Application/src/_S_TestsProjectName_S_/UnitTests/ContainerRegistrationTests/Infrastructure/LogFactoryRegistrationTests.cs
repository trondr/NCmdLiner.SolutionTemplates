using NUnit.Framework;
using _S_ConsoleProjectName_S_.Infrastructure.ContainerExtensions;
using _S_TestsProjectName_S_.Common;

namespace _S_TestsProjectName_S_.UnitTests.ContainerRegistrationTests.Infrastructure
{
    [TestFixture(Category = "UnitTests")]
    public class LogFactoryRegistrationTests
    {
        [Test, RequiresSTA]
        public void LogFactoryRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<ILogFactory>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<ILogFactory, LogFactory>();
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<ILogFactory>();
        }
    }
}