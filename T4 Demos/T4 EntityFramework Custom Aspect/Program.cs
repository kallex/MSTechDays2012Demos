using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T4_EntityFramework_Custom_Aspect
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Printing Classes and properties...");
            using(TechDays2012DemoEntities ctx = new TechDays2012DemoEntities())
            {
                foreach(var classItem in ctx.Classes)
                {
                    Console.WriteLine(classItem.ToString());
                    foreach(var propItem in classItem.ClassProperties)
                    {
                        Console.WriteLine(propItem.ToString());
                        Console.WriteLine(""
                            );
                    }
                    Console.WriteLine("");
                }
            }
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
}
