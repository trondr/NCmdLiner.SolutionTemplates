using NCmdLiner;
using NUnit.Framework;
using _S_ConsoleProjectName_S_.Infrastructure;
using _S_TestsProjectName_S_.Common;

namespace _S_TestsProjectName_S_.UnitTests.ContainerRegistrationTests.Infrastructure
{
    [TestFixture(Category = "UnitTests")]
    public class NCmdLinerIMessengerRegistrationTests
    {
        [Test, RequiresSTA]
        public void NCmdLinerIMessengerRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<IMessenger>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<IMessenger, NotepadMessenger>();
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<IMessenger>();
        }
    }
}