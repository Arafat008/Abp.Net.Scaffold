using System.Text;
using Abp.Net.Scaffold.CommandOptions;
using Abp.Net.Scaffold.Utilities;

namespace Abp.Net.Scaffold.Builders
{
    public static class DtoFileBuilder
    {
        private static string GetContent(string namespaceName, Options options)
        {
            switch (options.DtoType)
            {
                case DtoOptions.AuditedEntityDto:
                    return GetAuditedEntityDtoContent(namespaceName, options.EntityName);

                case DtoOptions.EntityDto:
                    return GetEntityDtoContent(namespaceName, options.EntityName);

                case DtoOptions.Blank:
                    return GetBlankDtoContent(namespaceName, options.EntityName);

                default:
                    return string.Empty;
            }
        }

        private static string GetBlankDtoContent(string namespaceName, string? entityName)
        {
            return "namespace " + namespaceName + "\n" +
            "{\n" +
            "    public class " + entityName + "Dto \n" +
            "    {\n" +
            "        // Dto properties\n" +
            "    }\n" +
            "}";
        }

        private static string GetAuditedEntityDtoContent(string namespaceName, string? entityName)
        {
            return "using System;" + "\n" +
                "using Volo.Abp.Application.Dtos;" + "\n" +
                "\n" +
                "namespace " + namespaceName + "\n" +
                "{\n" +
                "    public class " + entityName + "Dto" + " : AuditedEntityDto<Guid> " + "\n" +
                "    {\n" +
                "        // Dto properties\n" +
                "    }\n" +
                "}";
        }

        private static string GetEntityDtoContent(string namespaceName, string? entityName)
        {
            return "using System;" + "\n" +
                "using Volo.Abp.Application.Dtos;" + "\n" +
                "\n" +
                "namespace " + namespaceName + "\n" +
                "{\n" +
                "    public class " + entityName + "Dto" + " : EntityDto<Guid> " + "\n" +
                "    {\n" +
                "        // Dto properties\n" +
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

            var content = GetContent(namespaceName, options);

            File.WriteAllText(path, content, Encoding.UTF8);
            string createdPath = FilePathFinder.GetCreatedFilePath(path);

            Prompts.ShowMessage($"File created at {createdPath}");
        }
    }
}
