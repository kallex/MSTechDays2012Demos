using System;
using System.IO;
using System.Reflection;
using AbstractionConfig;

namespace AbstractionBuilder
{
    public partial class Builder
    {
        private readonly string LocationFormat;

        public Builder()
        {
            string currentAssemblyLocation = Assembly.GetExecutingAssembly().Location;
            DirectoryInfo dirInfo = new DirectoryInfo(Path.GetDirectoryName(currentAssemblyLocation));
            dirInfo = dirInfo.Parent.Parent.Parent.Parent;
            ContentSupport.ContentRootPath = Path.Combine(dirInfo.FullName, "AbstractionContent");


            LocationFormat = currentAssemblyLocation.Replace(@"\absbuilder\AbstractionBuilder\",
                                                             @"\{0}{1}\").Replace("AbstractionBuilder.exe",
                                                                               "{0}{1}.dll");
        }

        private void WriteGeneratorFiles(Tuple<string, string>[] generatorFiles, string abstractionName, string abstractionTypeString)
        {
            string abstractionPathName = abstractionName + abstractionTypeString;
            string outputPath = Path.Combine(ContentSupport.GetAbstractionOutputFolder(abstractionPathName));
            foreach(var generatorFile in generatorFiles)
            {
                string fileName = Path.Combine(outputPath, generatorFile.Item1);
                string directoryName = Path.GetDirectoryName(fileName);
                if (!Directory.Exists(directoryName))
                    Directory.CreateDirectory(directoryName);
                File.WriteAllText(fileName, generatorFile.Item2);
            }
        }

        private void ExecuteCustomExecution(string abstractionName, string abstractionTypeString, string executinClassName, string executionMethodName)
        {
            throw new NotImplementedException("TODO: Look reflection/DynaInvoke from the method below");            
        }

        private Tuple<string, string>[] ExecuteAssemblyGenerator(string abstractionName, string abstractionTypeString, string generatorClassName)
        {
            string assemblyLocation = String.Format(LocationFormat, abstractionName, abstractionTypeString);
            string[] xmlSourceFiles = ContentSupport.GetInputContentFiles(abstractionName, "*.xml");
            object result = DynaInvoke.InvokeMethod(assemblyLocation, generatorClassName, "GetGeneratorContent",
                                    xmlSourceFiles);
            Tuple<string, string>[] resultTupleArray = (Tuple<string, string>[]) result;
            return resultTupleArray;
        }

        private void FetchTransformationSources(string transformationName, string sourceAbstractionName)
        {
            ContentSupport.CleanupTransformationDirectories(transformationName);
            ContentSupport.CopyFromSourceToTrans(sourceAbstractionName, transformationName);
        }

        private void PushTransformationTargets(string transformationName, string targetAbstractionName)
        {
            ContentSupport.CopyFromTransToTarget(transformationName, targetAbstractionName);
        }

        private void CleanUpAbstractionOutput(string abstractionName)
        {
            ContentSupport.CleanupAbstractionOutputDirectory(abstractionName);
        }

        private void CleanUpTransformationInputAndOutput(string transformationName, string targetAbstractionName)
        {
            ContentSupport.CleanupTransformationDirectories(transformationName);
            ContentSupport.RemoveAllInputDirectoriesMatchingTransformationName(targetAbstractionName, transformationName);
        }
    }
}