 

using System.ServiceModel;
		// Services
namespace ADMDemoCompleteContract {
		    [ServiceContract]
    public interface IADMCompletedDemoService
    {

		        [OperationContract]
        string GetData(int value, int value2);
		
		    }
		
		}
		