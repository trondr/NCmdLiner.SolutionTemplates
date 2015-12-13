using _S_LibraryProjectName_S_.Service_References._S_ShortProductName_S_Service;

namespace _S_LibraryProjectName_S_.Module.Services
{
    //_S_ShortProductName_S_ManagerFacade

    public class _S_ShortProductName_S_ManagerFacade : I_S_ShortProductName_S_ManagerFacade
    {
        public void SomeExampleServiceMethod(string someExampleparameter)
        {
            var serviceClient = new I_S_ShortProductName_S_ManagerClient();
            serviceClient.SomeExampleServiceMethod(someExampleparameter);
        }
    }
}