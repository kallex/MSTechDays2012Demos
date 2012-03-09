using System;
using ADMDemoCompleteContract;
using DemoServiceInterface;

namespace ADMDemoCompleteServer
{
    public static class BusinessLogicHandler
    {
        public static string ADMCompletedDemoService_GetData(int value, int value2)
        {
            return "Sum of values (complete demo): " + value + value2;
        }

        public static string ADMCompletedDemoService_SayHi(MyComposite customParam)
        {
            return "Hello from server: " + customParam.Message;
        }
    }
}