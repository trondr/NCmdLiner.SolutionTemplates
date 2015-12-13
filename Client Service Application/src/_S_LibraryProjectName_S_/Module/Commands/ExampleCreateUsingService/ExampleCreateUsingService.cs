using _S_LibraryProjectName_S_.Module.Services;
using _S_ServiceContractsProjectName_S_;

namespace _S_LibraryProjectName_S_.Module.Commands.ExampleCreateUsingService
{
    public class ExampleCreateUsingService : IExampleCreateUsingService
    {
        private readonly I_S_ShortProductName_S_ManagerFacade _managerF;

        public ExampleCreateUsingService(I_S_ShortProductName_S_ManagerFacade managerF)
        {
            _managerF = managerF;
        }

        public int Create(string exampleParameter)
        {
            _managerF.SomeExampleServiceMethod(exampleParameter);
            return 0;
        }
    }
}