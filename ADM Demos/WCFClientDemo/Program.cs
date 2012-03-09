using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using WCFServiceDemo;

namespace WCFClientDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicHttpBinding basicHttpBinding = new BasicHttpBinding();
            EndpointAddress endpointAddress = new EndpointAddress("http://localhost:56071/DemoService.svc");
            IDemoService demoService =
                new ChannelFactory<IDemoService>(basicHttpBinding, endpointAddress).CreateChannel();
            string serviceResponse = demoService.GetData(123);
            Console.WriteLine(serviceResponse);
            Console.ReadLine();
        }
    }
}
