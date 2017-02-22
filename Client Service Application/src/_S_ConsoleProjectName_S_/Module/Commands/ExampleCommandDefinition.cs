using Common.Logging;
using NCmdLiner.Attributes;
using _S_LibraryProjectName_S_.Infrastructure;
using _S_LibraryProjectName_S_.Module.Commands.Example;

namespace _S_ConsoleProjectName_S_.Module.Commands
{
    public class ExampleCommandDefinition: CommandDefinition
    {
        private readonly IExampleCommandProvider _exampleCommandProvider;
        private readonly ILog _logger;

        public ExampleCommandDefinition(IExampleCommandProvider exampleCommandProvider, ILog logger)
        {
            _exampleCommandProvider = exampleCommandProvider;
            _logger = logger;
        }

        [Command(Description = "Just an example command. To be deleted or renamed for your own use.", Summary="Summary of the example command.")]
        public int CreateSomething(
            [RequiredCommandParameter(Description = "Just an example parameter.", AlternativeName = "xp", ExampleValue = @"c:\temp")]
            string exampleParameter
            )
        {            
            return _exampleCommandProvider.Create(exampleParameter);
        }
    }
}
