using Common.Logging;
using NCmdLiner.Attributes;
using _S_LibraryProjectName_S_.Commands.Example;
using _S_LibraryProjectName_S_.Common;

namespace _S_ConsoleProjectName_S_.Commands
{
    public class ExampleCommand: CommandsBase
    {
        private readonly ISomething _something;
        private readonly ILog _logger;

        public ExampleCommand(ISomething something, ILog logger)
        {
            _something = something;
            _logger = logger;
        }

        [Command(Description = "Just an example command. To be deleted or renamed for your own use")]
        public int CreateSomething(
            [RequiredCommandParameter(Description = "Just an example parameter.", AlternativeName = "xp", ExampleValue = @"c:\temp")]
            string exampleParameter
            )
        {
            var returnValue = 0;
            _logger.Info("Start CreateSomething...");
            returnValue = _something.Create(exampleParameter);
            _logger.Info("End CreateSomething.");
            return returnValue;
        }
    }
}
