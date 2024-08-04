namespace Abp.Net.Scaffold.Builders
{
    public static class NamespaceBuilder
    {
        private static string ExtractProjectNamespace(string projectPath)
        {
            var projectDirectory = new DirectoryInfo(projectPath);
            return projectDirectory.Name.Replace("src\\", "").Replace("\\", ".");
        }

        public static string Build(string projectPath, string featureName)
        {
            string rootNamespace = ExtractProjectNamespace(projectPath);

            return rootNamespace.Replace(".Domain", "");
        }
    }
}
