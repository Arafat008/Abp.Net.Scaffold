using System.Text;
using Abp.Net.Scaffold.CommandOptions;
using Abp.Net.Scaffold.Utilities;

namespace Abp.Net.Scaffold.Builders
{
    public static class EntityFileBuilder
    {
        private static string GetContent(string namespaceName, Options options)
        {
            switch (options.EntityType)
            {
                case EntityTypeOptions.AuditedAggregateRoot:
                    return GetAuditedAggregateRootContent(namespaceName, options.EntityName);

                case EntityTypeOptions.AuditedEntity:
                    return GetAuditedEntityContent(namespaceName, options.EntityName);

                case EntityTypeOptions.AggregateRoot:
                    return GetAggregateRootContent(namespaceName, options.EntityName);

                case EntityTypeOptions.Entity:
                    return GetEntityContent(namespaceName, options.EntityName);

                case EntityTypeOptions.Blank:
                    return GetBlankContent(namespaceName, options.EntityName);

                default:
                    return string.Empty;
            }
        }

        private static string GetBlankContent(string namespaceName, string? entityName)
        {
            return "namespace " + namespaceName + "\n" +
            "{\n" +
            "    public class " + entityName + " \n" +
            "    {\n" +
            "        // Entity properties\n" +
            "    }\n" +
            "}";
        }

        private static string GetAuditedEntityContent(string namespaceName, string? entityName)
        {
            return "using System;" + "\n" +
                "using Volo.Abp.Domain.Entities.Auditing;" + "\n" +
                "\n" +
                "namespace " + namespaceName + "\n" +
                "{\n" +
                "    public class " + entityName + " : AuditedEntity<Guid>" + " \n" +
                "    {\n" +
                "        // Entity properties\n" +
                "    }\n" +
                "}";
        }

        private static string GetEntityContent(string namespaceName, string? entityName)
        {
            return "using System;" + "\n" +
                "using Volo.Abp.Domain.Entities;" + "\n" +
                "\n" +
                "namespace " + namespaceName + "\n" +
                "{\n" +
                "    public class " + entityName + " : Entity<Guid>" + " \n" +
                "    {\n" +
                "        // Entity properties\n" +
                "    }\n" +
                "}";
        }

        private static string GetAggregateRootContent(string namespaceName, string? entityName)
        {
            return "using System;" + "\n" +
                "using Volo.Abp.Domain.Entities;" + "\n" +
                "\n" +
                "namespace " + namespaceName + "\n" +
                "{\n" +
                "    public class " + entityName + " : AggregateRoot<Guid>" + " \n" +
                "    {\n" +
                "        // Entity properties\n" +
                "    }\n" +
                "}";
        }

        private static string GetAuditedAggregateRootContent(string namespaceName, string? entityName)
        {
            return "using System;" + "\n" +
                "using Volo.Abp.Domain.Entities.Auditing;" + "\n" +
                "\n" +
                "namespace " + namespaceName + "\n" +
                "{\n" +
                "    public class " + entityName + " : AuditedAggregateRoot<Guid>" + " \n" +
                "    {\n" +
                "        // Entity properties\n" +
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
