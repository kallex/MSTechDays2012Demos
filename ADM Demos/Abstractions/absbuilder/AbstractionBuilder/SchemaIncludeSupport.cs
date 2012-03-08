using System;
using System.IO;

namespace AbstractionBuilder
{
    public static class SchemaIncludeSupport
    {
        public static void GenerateXSDSerializer(string xsdFileName, string outputDirectory, bool generateNamespace, bool generateT4Tags)
        {
            if (xsdFileName.EndsWith(".xsd") == false)
                throw new ArgumentException("XSD file name must end with .xsd: " + xsdFileName, "xsdFileName");
            if(File.Exists(xsdFileName) == false)
                throw new ArgumentException("XSD file name must exist: " + xsdFileName, "xsdFileName");
            string xsdExeFileName = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) +
                                    @"\Microsoft SDKs\Windows\v7.0A\bin\xsd.exe";
            string baseFileName = Path.GetFileNameWithoutExtension(xsdFileName);
            string outputClassFile = outputDirectory + "\\" + baseFileName + ".cs";
            string namespaceFileTag = generateNamespace ? "_namespace" : "";
            string outputttinclude = outputDirectory + "\\" + baseFileName + namespaceFileTag + ".ttinclude";
            string outputCsCode = outputDirectory + "\\" + baseFileName + namespaceFileTag + ".cs";
            string xsdParameters = "/c \"" + xsdFileName + "\" /o:\"" + outputDirectory + "\"";
            string namespaceName = baseFileName;
            if (generateNamespace == true && generateT4Tags == false)
            {
                xsdParameters = "/n:" + namespaceName + " " + xsdParameters;
            }
            System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo(xsdExeFileName, xsdParameters);
            WriteLog("Starting xsd.exe: " + xsdParameters);
            System.Diagnostics.Process proc = System.Diagnostics.Process.Start(processStartInfo);
            proc.WaitForExit();
            WriteLog("System.Diagnostics.Processing include tags...");
            string content = System.IO.File.ReadAllText(outputClassFile);
            System.IO.File.Delete(outputClassFile);
            string outputFile;
            if (generateT4Tags)
            {
                if (generateNamespace)
                {
                    content = "<" + "#+" +
                              System.Environment.NewLine + "public class " + namespaceName + " { " + System.Environment.NewLine +
                              content.Replace("using System.Xml.Serialization;", "") + "} " + "#" + ">";
                }
                else
                {
                    content = "<" + "#+" +
                              System.Environment.NewLine +
                              content.Replace("using System.Xml.Serialization;", "") + "#" + ">";
                }
                outputFile = outputttinclude;
            }
            else
                outputFile = outputCsCode;
            WriteLog("Writing to file: " + outputFile);
            System.IO.File.WriteAllText(outputFile, content);
        }

        static string GetXSDFile(string templateFile)
        {
            string directory = System.IO.Path.GetDirectoryName(templateFile);
            string xsdFile = directory + "\\" + System.IO.Path.GetFileNameWithoutExtension(templateFile) + ".xsd";
            return xsdFile;
        }

        public static void GenerateTTInclude(string xsdFileName, string outputDirectory, bool generateNamespace = false, bool generateT4Tags = true)
        {
            GenerateXSDSerializer(xsdFileName, outputDirectory, generateNamespace, generateT4Tags);
        }

        public static void GenerateTTInclude(string xsdFileName, bool generateNamespace = false)
        {
            GenerateTTInclude(xsdFileName, Path.GetDirectoryName(xsdFileName), generateNamespace);
        }

        static void WriteLog(string entry)
        {
        }

    }
}