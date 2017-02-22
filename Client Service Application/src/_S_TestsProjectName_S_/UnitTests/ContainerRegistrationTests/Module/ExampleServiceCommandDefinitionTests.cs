using NUnit.Framework;
using _S_ConsoleProjectName_S_.Module.Commands;
using _S_LibraryProjectName_S_.Infrastructure;
using _S_TestsProjectName_S_.Common;

namespace _S_TestsProjectName_S_.UnitTests.ContainerRegistrationTests.Module
{
    [TestFixture(Category=TestCategory.UnitTests)]
    public class ExampleServiceCommandDefinitionTests
    {        
        [Test, RequiresSTA]
        public static void ExampleServiceCommandDefinitionTest()
        {
            BootStrapperTestsHelper.CheckThatOneOfTheResolvedServicesAre<CommandDefinition, ExampleServiceCommandDefinition>("Not registered: " + typeof(ExampleServiceCommandDefinition).FullName);
        }        
    }
}