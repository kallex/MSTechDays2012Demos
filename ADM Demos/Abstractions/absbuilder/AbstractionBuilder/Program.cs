using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
//using DocumentationABS.Documentation;
using Microsoft.VisualStudio.TextTemplating;
//using OperationABS.Operation;

namespace AbstractionBuilder
{
    class Program
    {
        static int Main(string[] args)
        {
            //CustomCmdLineHost host = new CustomCmdLineHost();
            //host.TemplateFileValue = @"C:\GitHub\kallex\private\Demos\CQRS_CustomerBankAccountDemo\Abstractions\OperationABS\Operation\CSharpCode_v1_0.tt";
            //OperationABS.Operation.CSharpCode_v1_0 generator = new CSharpCode_v1_0();
            //generator.Host = host;
            //string result = generator.TransformText();
            //TransformDocumentation();
            //GenerateDocumentation();
            if(args != null && args.Length > 0)
            {
                return ExecuteProgram(args);
            }
            Builder builder = new Builder();
            builder.Build();
            Console.WriteLine("Generations Done!");
            return 0;
        }

        private static int ExecuteProgram(string[] args)
        {
            Debugger.Launch();
            if (args.Length == 2 && args[0] == "-XSDInclude")
                return ExecuteXSDIncludeGenerator(args[1]);
            Console.WriteLine("Absbuilder Succeeded 0");
            Console.Error.WriteLine("Errori virhe!!!");
            return -1;
            //return 0;
        }

        private static int ExecuteXSDIncludeGenerator(string xsdFileName)
        {
            FileInfo fileInfo = new FileInfo(xsdFileName);
            xsdFileName = fileInfo.FullName;
            DirectoryInfo dirInfo = new DirectoryInfo(Path.GetDirectoryName(xsdFileName));
            // Generate the include files to parent directory, not in the content directory
            dirInfo = dirInfo.Parent;
            // Generating the T4 generator usable no-namespace include with T4 tags
            SchemaIncludeSupport.GenerateTTInclude(xsdFileName, dirInfo.FullName);
            // Generating the Transformation usable namespace include without T4 tags 
            SchemaIncludeSupport.GenerateTTInclude(xsdFileName, dirInfo.FullName, generateNamespace: true, generateT4Tags: false);
            return 0;
        }

        private static void TransformDocumentation()
        {
        }

        /*
        private static void GenerateDocumentation()
        {
            CustomCmdLineHost host = new CustomCmdLineHost();
            host.TemplateFileValue = @"C:\GitHub\kallex\private\Demos\CQRS_CustomerBankAccountDemo\Abstractions\DocumentationABS\Documentation\DesignDocumentation_v1_0.tt";
            DocumentationABS.Documentation.DesignDocumentation_v1_0 generator = new DesignDocumentation_v1_0();
            generator.Host = host;
            var result = generator.GenerateDocuments();
            foreach(var item in result)
            {
                string fileName = @"c:\tmp\" + item.Name;
                File.WriteAllText(fileName, item.Content);
            }
        }
         * */
    }
}
