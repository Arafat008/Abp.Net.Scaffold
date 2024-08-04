using System.Text;
using Abp.Net.Scaffold.CommandOptions;
using Abp.Net.Scaffold.Utilities;

namespace Abp.Net.Scaffold.Builders
{
    public static class ServiceFileBuilder
    {
        private static string GetContent(string namespaceName, Options options)
        {
            switch (options.ServiceType)
            {
                case ServiceTypeOptions.AppService:
                    return GetAppServiceContent(namespaceName, options.EntityName);

                case ServiceTypeOptions.CrudAppService:
                    return GetCrudAppServiceContent(namespaceName, options.EntityName);

                case ServiceTypeOptions.Blank:
                    return GetBlankContent(namespaceName, options.EntityName);

                default:
                    return string.Empty;
            }
        }

        private static string GetBlankContent(string namespaceName, string? entityName)
        {
            return "namespace " + namespaceName + "\n" +
            "{\n" +
            "    public class " + entityName + "AppService : I" + entityName + "AppService \n" +
            "    {\n" +
            "        // Service implementation\n" +
            "    }\n" +
            "}";
        }

        private static string GetAppServiceContent(string namespaceName, string? entityName)
        {
            return "using Volo.Abp.Application.Services;" + "\n" +
                "\n" +
                "namespace " + namespaceName + "\n" +
                "{\n" +
                "    public class " + entityName + "AppService" + " : ApplicationService, I" + entityName + "AppService" + " \n" +
                "    {\n" +
                "        // Interface methods\n" +
                "    }\n" +
                "}";
        }

        private static string GetCrudAppServiceContent(string namespaceName, string? entityName)
        {
            return "using System;" + "\n" +
                "using Volo.Abp.Application.Dtos;" + "\n" +
                "using Volo.Abp.Application.Services;" + "\n" +
                "using Volo.Abp.Domain.Repositories;" + "\n" +
                "\n" +
                "namespace " + namespaceName + "\n" +
                "{\n" +
                "    public class " + entityName + "AppService" + " : CrudAppService<" + entityName + ", " + entityName + "Dto, Guid, PagedAndSortedResultRequestDto, CreateUpdate" + entityName + "Dto>, I" + entityName + "AppService" + " \n" +
                "    {\n" +
                "        public " + entityName + "AppService(IRepository<" + entityName + ", Guid> repository) : base(repository)" +
                "        {\n" +
                "        }\n" +
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
