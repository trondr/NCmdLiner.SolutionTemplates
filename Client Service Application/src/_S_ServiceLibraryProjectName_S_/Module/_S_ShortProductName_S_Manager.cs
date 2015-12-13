using Common.Logging;
using _S_ServiceContractsProjectName_S_;

namespace _S_ServiceLibraryProjectName_S_.Module
{
    public class _S_ShortProductName_S_Manager: I_S_ShortProductName_S_Manager
    {
        private readonly ILog _logger;
        public _S_ShortProductName_S_Manager(ILog logger)
        {
            _logger = logger;
        }

        public void SomeExampleServiceMethod(string someExampleparameter)
        {
            _logger.InfoFormat("Some example service method: " + someExampleparameter);
        }
    }
}
