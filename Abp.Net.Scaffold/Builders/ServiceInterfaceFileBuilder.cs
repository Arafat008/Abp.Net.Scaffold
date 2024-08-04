using System.Text;
using Abp.Net.Scaffold.CommandOptions;
using Abp.Net.Scaffold.Utilities;

namespace Abp.Net.Scaffold.Builders
{
    public static class ServiceInterfaceFileBuilder
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
            return
                "namespace " + namespaceName + "\n" +
                "{\n" +
                "    public interface I" + entityName + "AppService \n" +
                "    {\n" +
                "        // Interface methods\n" +
                "    }\n" +
                "}";
        }

        private static string GetAppServiceContent(string namespaceName, string? entityName)
        {
            return "using Volo.Abp.Application.Services;" + "\n" +
                "\n" +
                "namespace " + namespaceName + "\n" +
                "{\n" +
                "    public interface I" + entityName + "AppService" + " : IApplicationService" + " \n" +
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
                "\n" +
                "namespace " + namespaceName + "\n" +
                "{\n" +
                "    public interface I" + entityName + "AppService"+ " : ICrudAppService<" + entityName + "Dto, Guid, PagedAndSortedResultRequestDto, CreateUpdate"+ entityName +"Dto>" + " \n" +
                "    {\n" +
                "        // Interface methods\n" +
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
