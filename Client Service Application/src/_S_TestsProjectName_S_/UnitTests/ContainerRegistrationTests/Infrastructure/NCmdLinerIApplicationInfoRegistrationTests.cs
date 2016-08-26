using NCmdLiner;
using NUnit.Framework;
using _S_TestsProjectName_S_.Common;

namespace _S_TestsProjectName_S_.UnitTests.ContainerRegistrationTests.Infrastructure
{
    [TestFixture(Category = "UnitTests")]
    public class NCmdLinerIApplicationInfoRegistrationTests
    {
        [Test, RequiresSTA]
        public void NCmdLinerIApplicationInfoRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<IApplicationInfo>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<IApplicationInfo, ApplicationInfo>();
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<IApplicationInfo>();
        }
    }
}