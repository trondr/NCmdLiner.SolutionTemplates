using _S_LibraryProjectName_S_.Infrastructure;
using _S_LibraryProjectName_S_.Module.Services;

namespace _S_LibraryProjectName_S_.Module.Commands.ExampleCreateUsingService
{
    public class ExampleCreateUsingServiceCommandProvider : CommandProvider, IExampleCreateUsingServiceCommandProvider
    {
        private readonly I_S_ShortProductName_S_ManagerFacade _managerF;

        public ExampleCreateUsingServiceCommandProvider(I_S_ShortProductName_S_ManagerFacade managerF)
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