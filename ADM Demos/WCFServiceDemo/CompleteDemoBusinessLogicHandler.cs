using System;
using DemoServiceInterface;

namespace ADMDemoCompleteServer
{
    public static class BusinessLogicHandler
    {
        public static string ADMCompletedDemoService_GetData(int value, int value2)
        {
            return "Sum of values (complete demo): " + value + value2;
        }
    }
}