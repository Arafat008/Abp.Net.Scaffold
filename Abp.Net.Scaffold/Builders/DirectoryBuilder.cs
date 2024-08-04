namespace Abp.Net.Scaffold.Builders
{
    public static class DirectoryBuilder
    {
        public static void Build(string? path)
        {
            if (!Directory.Exists(path) && path is not null)
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
