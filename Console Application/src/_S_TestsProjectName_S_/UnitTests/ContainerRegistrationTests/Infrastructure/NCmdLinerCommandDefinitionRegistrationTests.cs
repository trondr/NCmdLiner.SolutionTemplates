using NUnit.Framework;
using _S_LibraryProjectName_S_.Infrastructure;
using _S_TestsProjectName_S_.Common;

namespace _S_TestsProjectName_S_.UnitTests.ContainerRegistrationTests.Infrastructure
{
    [TestFixture(Category = "UnitTests")]
    public class NCmdLinerCommandDefinitionRegistrationTests
    {
        [Test, RequiresSTA]
        public void NCmdLinerCommandDefinitionRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<CommandDefinition>(1, "The number should equal the number of service implementations. The programmer should manually adjust the expected number in this unit test for each added or removed service implementation.");
        }
    }
}