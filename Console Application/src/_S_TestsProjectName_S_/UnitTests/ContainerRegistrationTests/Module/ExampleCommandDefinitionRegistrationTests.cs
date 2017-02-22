using NUnit.Framework;
using _S_ConsoleProjectName_S_.Module.Commands;
using _S_LibraryProjectName_S_.Infrastructure;
using _S_TestsProjectName_S_.Common;

namespace _S_TestsProjectName_S_.UnitTests.ContainerRegistrationTests.Module
{
    [TestFixture(Category=TestCategory.UnitTests)]
    public class ExampleCommandDefinitionRegistrationTests
    {        
        [Test, RequiresSTA]
        public static void ExampleCommandDefinitionRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatOneOfTheResolvedServicesAre<CommandDefinition, ExampleCommandDefinition>("Not registered: " + typeof(ExampleCommandDefinition).FullName);
        }        
    }
}