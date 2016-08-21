using Common.Logging.Simple;
using NUnit.Framework;
using _S_ConsoleProjectName_S_.Module.Commands;
using _S_LibraryProjectName_S_.Infrastructure;
using _S_LibraryProjectName_S_.Module.Commands.Example;
using _S_TestsProjectName_S_.Common;
using LogLevel = Common.Logging.LogLevel;

namespace _S_TestsProjectName_S_.UnitTests
{
    [TestFixture(Category = "UnitTests")]
    public class BootStrapperModuleTests
    {
        private ConsoleOutLogger _logger;

        [SetUp]
        public void SetUp()
        {
            _logger = new ConsoleOutLogger(this.GetType().Name, LogLevel.All, true, false, false, "yyyy-MM-dd hh:mm:ss");
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test, RequiresSTA]
        public static void ExampleCommandDefinitionRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatOneOfTheResolvedServicesAre<CommandDefinition, ExampleCommandDefinition>("Not registered: " + typeof(ExampleCommandDefinition).FullName);
        }


        [Test, RequiresSTA]
        public static void ExampleCommandProviderRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<IExampleCommandProvider>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceTypeName<IExampleCommandProvider>("IExampleCommandProviderProxy");
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<IExampleCommandProvider>();
        }

    }
}