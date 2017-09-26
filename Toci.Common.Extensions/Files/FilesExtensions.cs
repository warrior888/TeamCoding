using System.IO;

namespace Toci.Common.Extensions.Files
{
    public static class FilesExtensions
    {
        public static bool IsDirectory(this string filePath)
        {
            FileAttributes attr = File.GetAttributes(filePath);

            //detect whether its a directory or file
            return (attr & FileAttributes.Directory) == FileAttributes.Directory;
        }
    }
}