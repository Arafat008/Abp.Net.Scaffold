namespace Abp.Net.Scaffold.Utilities
{
    public static class FilePathFinder
    {
        public static string GetCreatedFilePath(string path)
        {
            var srcPath = Path.Combine(Directory.GetCurrentDirectory(), "src");
            return path.Replace(srcPath, string.Empty).Replace("\\", "/").Substring(1);
        }
    }
}
