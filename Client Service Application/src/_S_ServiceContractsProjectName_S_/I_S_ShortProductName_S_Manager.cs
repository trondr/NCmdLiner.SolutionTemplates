using System.ServiceModel;

namespace _S_ServiceContractsProjectName_S_
{

    [ServiceContract(Namespace = "_S_ServiceProjectName_S_")]
    public interface I_S_ShortProductName_S_Manager
    {
        [OperationContract]
        void SomeExampleServiceMethod(string someExampleparameter);
    }
}
