using System.Text;
using Abp.Net.Scaffold.CommandOptions;
using Abp.Net.Scaffold.Utilities;

namespace Abp.Net.Scaffold.Builders
{
    public static class CreateUpdateDtoFileBuilder
    {
        private static string GetContent(string namespaceName, string? entityName)
        {
            return "namespace " + namespaceName + "\n" +
            "{\n" +
            "    public class CreateUpdate" + entityName + "Dto \n" +
            "    {\n" +
            "        // Create Update Dto properties\n" +
            "    }\n" +
            "}";
        }
        public static void Build(string path, string namespaceName, Options options)
        {
            if (File.Exists(path))
            {
                Prompts.ShowError($"File already exists at: {path}");
                return;
            }

            var content = GetContent(namespaceName, options.EntityName);

            File.WriteAllText(path, content, Encoding.UTF8);
            string createdPath = FilePathFinder.GetCreatedFilePath(path);
            Prompts.ShowMessage($"File created at {createdPath}");
        }
    }
}
