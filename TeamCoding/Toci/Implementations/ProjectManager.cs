using System;
using EnvDTE;

namespace TeamCoding.Toci.Implementations
{
    public static class ProjectManager
    {
        public const string PathDelimiter = "\\";

        public static DTE Dte;
        public static string SolutionDirectoryPath;
        public static string SolutionFileName;

        public static void SetDte(DTE dte)
        {
            Dte = dte;
            CalculatePaths();
        }

        public static void CalculatePaths()
        {
            string[] pathChunks = Dte.Solution.FullName.Split(new[] { PathDelimiter }, StringSplitOptions.None);

            SolutionFileName = pathChunks[pathChunks.Length - 1];
            SolutionDirectoryPath = SolutionFileName?.Length > 0 ? Dte.Solution.FullName?.Replace(SolutionFileName, string.Empty) : null;
        }

        public static string MakeRelativeFilePath(string path)
        {
            if (string.IsNullOrEmpty(SolutionDirectoryPath)) CalculatePaths();
            return path.Replace(SolutionDirectoryPath, string.Empty);
        }

        public static string MakeAbsoluteFilePath(string path)
        {
            return SolutionDirectoryPath + path;
        }
    }
}