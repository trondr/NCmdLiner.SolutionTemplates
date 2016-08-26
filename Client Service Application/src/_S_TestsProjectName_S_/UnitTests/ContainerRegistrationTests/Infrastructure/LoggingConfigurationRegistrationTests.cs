using NUnit.Framework;
using _S_LibraryProjectName_S_.Infrastructure;
using _S_TestsProjectName_S_.Common;

namespace _S_TestsProjectName_S_.UnitTests.ContainerRegistrationTests.Infrastructure
{
    [TestFixture(Category = "UnitTests")]
    public class LoggingConfigurationRegistrationTests
    {
        [Test, RequiresSTA]
        public void LoggingConfigurationRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<ILoggingConfiguration>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<ILoggingConfiguration, LoggingConfiguration>();
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<ILoggingConfiguration>();
        }
    }
}