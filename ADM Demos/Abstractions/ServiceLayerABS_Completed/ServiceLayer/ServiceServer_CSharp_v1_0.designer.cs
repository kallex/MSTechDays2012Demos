 



using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using ADMDemoCompleteContract;

		
namespace ADMDemoCompleteServer
{
				
    public class ADMCompletedDemoService : IADMCompletedDemoService
    {
		        
        public string  GetData(int value, int value2)
        {
            // NOTE! Business logic is properly routed from service layer to business logic layer
            return BusinessLogicHandler.ADMCompletedDemoService_GetData(value, value2);
		}
		
		
		    }
		}
		