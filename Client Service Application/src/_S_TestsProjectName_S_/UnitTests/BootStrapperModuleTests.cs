using Common.Logging.Simple;
using NUnit.Framework;
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

        
    }
}