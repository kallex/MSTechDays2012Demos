 

using System.Runtime.Serialization;
using System.ServiceModel;
		// Services
namespace ADMDemoCompleteContract {
		    [ServiceContract]
    public interface IADMCompletedDemoService
    {

		        [OperationContract]
        string GetData(int value, int value2);
		
		        [OperationContract]
        string SayHi(MyComposite customParam);
		
		    }
		
		    [DataContract]
    public class MyComposite
    {
		        string _Message = "Hi!";

        [DataMember]
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
			}
		}
		