using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using DemoServiceInterface;
using WCFServiceDemo;

namespace WCFClientDemo
{
    public class DemoServiceClient
    {
        public static string GetData(int value)
        {
            BasicHttpBinding basicHttpBinding = new BasicHttpBinding();
            EndpointAddress endpointAddress = new EndpointAddress("http://localhost:56071/DemoService.svc");
            IDemoService demoService =
                new ChannelFactory<IDemoService>(basicHttpBinding, endpointAddress).CreateChannel();
            string serviceResponse = demoService.GetData(value);
            return serviceResponse;
        }
    }
}
