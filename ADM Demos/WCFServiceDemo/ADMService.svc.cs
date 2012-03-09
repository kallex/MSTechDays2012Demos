using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ADMService" in code, svc and config file together.
    public class ADMService : IADMService
    {
        public string GetData(int value)
        {
            return "ADM Demo: " + value;
        }

        public ADMCompositeType GetDataUsingDataContract(ADMCompositeType composite)
        {
            return composite;
        }
    }
}
