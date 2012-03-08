using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;

namespace AbstractionConfig
{
    public static class ContentSupport
    {
        public static string ContentRootPath;

        public static string GetContentRoot()
        {
            return ContentRootPath;
        }

        public static string GetAbstractionContentRoot(string abstractionName)
        {
            string polishedName = abstractionName.Replace("TRANS", "").Replace("ABS", "");
            return Path.Combine(GetContentRoot(), polishedName);
        }

        public static string GetAbstractionInputRoot(string abstractionName)
        {
            return Path.Combine(GetAbstractionContentRoot(abstractionName), AbstractionInputFolder);
        }

        public static string GetAbstractionOutputFolder(string abstractionName)
        {
            return Path.Combine(GetAbstractionContentRoot(abstractionName), AbstractionOutputFolder);
        }

        private const string AbstractionInputFolder = "In";
        private const string AbstractionOutputFolder = "Out";
        private const string ContentFolderPrefixFilter = "Content_v";

        public static void CopyFromSourceToTrans(string sourceAbstractionName, string transName)
        {
            string sourceContentInputRoot = GetAbstractionInputRoot(sourceAbstractionName);
            string transContentInputRoot = GetTransContentInputRoot(transName);
            //string[] directoryNames = Directory.GetDirectories(sourceContentInputRoot, ContentFolderPrefixFilter + "*");
            //DirectoryInfo[] directories = directoryNames.Select(dirName => new DirectoryInfo(dirName)).ToArray();
            DirectoryInfo sourceDir = new DirectoryInfo(sourceContentInputRoot);
            DirectoryInfo targetDir = new DirectoryInfo(transContentInputRoot);
            if (sourceDir.Exists == false)
                sourceDir.Create();
            CopyDirectoryTree(sourceDir, targetDir);
            //foreach(var sourceDir in directories)
            //{
            //    CopyDirectoryTree(sourceDir, targetDir);
            //}
        }

        private static string GetTransContentInputRoot(string transName)
        {
            return GetAbstractionInputRoot(transName);
        }

        public static void CleanupTransformationDirectories(string transName)
        {
            Contract.Requires(transName.EndsWith("TRANS"));
            string transContentInputRoot = GetTransContentInputRoot(transName);
            CleanupDirectory(transContentInputRoot);
            string transContentOutputRoot = GetTransContentOutputRoot(transName);
            CleanupDirectory(transContentOutputRoot);
        }

        public static void CleanupAbstractionOutputDirectory(string abstractionName)
        {
            string outputDirectory = GetAbstractionOutputFolder(abstractionName);
            CleanupDirectory(outputDirectory);
        }

        public static void CleanupDirectory(string directoryName)
        {
            Contract.Requires(string.IsNullOrEmpty(ContentRootPath) == false);
            Contract.Requires(directoryName.StartsWith(ContentRootPath));
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryName);
            if(directoryInfo.Exists)
                directoryInfo.Delete(true);
            directoryInfo.Create();
        }

        public static void CopyDirectoryTree(DirectoryInfo source, DirectoryInfo target, string contentTargetName = null, bool deleteIfContentExists = false)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
            {
                bool isContentDir = dir.Name.StartsWith(ContentFolderPrefixFilter);
                string targetDirName = isContentDir && contentTargetName != null
                                           ? Path.Combine(dir.Name, contentTargetName)
                                           : dir.Name;
                if(isContentDir && deleteIfContentExists)
                {
                    string targetDirFullName = Path.Combine(target.FullName, targetDirName);
                    if(Directory.Exists(targetDirFullName))
                    {
                        Directory.Delete(targetDirFullName, true);
                    }
                }
                CopyDirectoryTree(dir, target.CreateSubdirectory(targetDirName));
            }
            foreach (FileInfo file in source.GetFiles())
                file.CopyTo(Path.Combine(target.FullName, file.Name), true);
        } 


        public static void CopyFromTransToTarget(string transName, string targetAbstractionName)
        {
            string transContentOutputRoot = GetTransContentOutputRoot(transName);
            string targetContentRootInputRoot = GetAbstractionInputRoot(targetAbstractionName);
            string targetPath = Path.Combine(targetContentRootInputRoot, transName);
            CleanupDirectory(targetPath);
            CopyDirectoryTree(new DirectoryInfo(transContentOutputRoot),
                              new DirectoryInfo(targetPath));
        }

        private static string GetTransContentOutputRoot(string transName)
        {
            return Path.Combine(GetAbstractionContentRoot(transName), AbstractionOutputFolder);
        }

        public static string[] GetInputContentFiles(string abstractionName, string filefilter)
        {
            string abstractionInputRoot = GetAbstractionInputRoot(abstractionName);
            string[] fileNames = Directory.GetFiles(abstractionInputRoot, filefilter, SearchOption.AllDirectories);
            return fileNames;
        }

        public static void RemoveAllInputDirectoriesMatchingTransformationName(string targetAbstractionName, string transformationName)
        {
            string inputRoot = GetAbstractionInputRoot(targetAbstractionName);
            DirectoryInfo inputDir = new DirectoryInfo(inputRoot);
            if(inputDir.Exists == false)
                inputDir.Create();
            DirectoryInfo[] transformationDirectories = inputDir.GetDirectories(transformationName,
                                                                                SearchOption.AllDirectories);
            Array.ForEach(transformationDirectories, dir => dir.Delete(true));
        }
    }
}