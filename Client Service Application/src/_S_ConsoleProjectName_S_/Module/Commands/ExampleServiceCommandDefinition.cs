using Common.Logging;
using NCmdLiner.Attributes;
using _S_LibraryProjectName_S_.Infrastructure;
using _S_LibraryProjectName_S_.Module.Commands.Example;
using _S_LibraryProjectName_S_.Module.Commands.ExampleCreateUsingService;

namespace _S_ConsoleProjectName_S_.Module.Commands
{
    public class ExampleServiceCommandDefinition: CommandDefinition
    {
        private readonly IExampleCreateUsingService _exampleCreateUsingService;
        private readonly ILog _logger;

        public ExampleServiceCommandDefinition(IExampleCreateUsingService exampleCreateUsingService, ILog logger)
        {
            _exampleCreateUsingService = exampleCreateUsingService;
            _logger = logger;
        }

        [Command(Description = "Just an example command. To be deleted or renamed for your own use")]
        public int ExampleCreateUsingService(
            [RequiredCommandParameter(Description = "Just an example parameter.", AlternativeName = "xsp", ExampleValue = @"c:\temp")]
            string exampleParameter
            )
        {            
            return _exampleCreateUsingService.Create(exampleParameter);
        }
    }

    
}
