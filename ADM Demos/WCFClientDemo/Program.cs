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
            string demoServiceResponse = DemoServiceClient.GetData(222);
            Console.WriteLine(demoServiceResponse);
            string admServiceResponse = ADMServiceClient.GetData(333);
            Console.WriteLine(admServiceResponse);
            Console.ReadLine();
        }
    }
}
