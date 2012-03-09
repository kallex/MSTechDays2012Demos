using System;
using DemoServiceInterface;

namespace WCFServiceDemo
{
    public static class BusinessLogicHandler
    {
        public static string ADMService_GetData(int value)
        {
            return "ADM Demo Business Logic: " + value;
        }

        public static ADMCompositeType ADMService_GetDataUsingDataContract(ADMCompositeType composite)
        {
            throw new NotImplementedException();
        }
    }
}