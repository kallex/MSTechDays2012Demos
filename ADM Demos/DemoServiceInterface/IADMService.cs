using System.ServiceModel;
using WCFServiceDemo;

namespace DemoServiceInterface
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IADMService
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        ADMCompositeType GetDataUsingDataContract(ADMCompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
}
