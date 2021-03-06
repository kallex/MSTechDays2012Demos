﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ADMDemoCompleteClient;
using ADMDemoCompleteContract;
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
            string admCompletedServiceResponse = ADMCompletedDemoServiceClient.GetData(123, 345);
            Console.WriteLine(admCompletedServiceResponse);
            string admCompositeServiceResponse = ADMCompletedDemoServiceClient.SayHi(new MyComposite()
                                                                                         {
                                                                                             Message = "My Composite - TD 2012"
                                                                                         });
            Console.WriteLine(admCompositeServiceResponse);
            Console.ReadLine();
        }
    }
}
