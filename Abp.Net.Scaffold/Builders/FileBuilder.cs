using Abp.Net.Scaffold.CommandOptions;

namespace Abp.Net.Scaffold.Builders
{
    public static class FileBuilder
    {
        public static void Build(Options opts)
        {
            string basePath = Directory.GetCurrentDirectory();
            string srcPath = Path.Combine(basePath, "src");
            // Detect project directories
            var domainProjectName = Directory.GetDirectories(srcPath).FirstOrDefault(d => d.EndsWith(".Domain", StringComparison.OrdinalIgnoreCase))
                                    ?? throw new DirectoryNotFoundException("Domain project directory not found.");
            var applicationProjectName = Directory.GetDirectories(srcPath).FirstOrDefault(d => d.EndsWith(".Application", StringComparison.OrdinalIgnoreCase))
                                    ?? throw new DirectoryNotFoundException("Application project directory not found.");
            var applicationContractsProjectName = Directory.GetDirectories(srcPath).FirstOrDefault(d => d.EndsWith(".Application.Contracts", StringComparison.OrdinalIgnoreCase))
                                    ?? throw new DirectoryNotFoundException("Application.Contracts project directory not found.");

            // Create feature paths
            string featureName = opts.FeatureName ?? "";
            string entityName = opts.EntityName ?? "";

            var domainProjectPath = Path.Combine(domainProjectName, featureName);
            var applicationProjectPath = Path.Combine(applicationProjectName, featureName);
            var applicationContractsProjectPath = Path.Combine(applicationContractsProjectName, featureName);

            // Define namespace
            string rootNamespace = NamespaceBuilder.Build(domainProjectName, featureName);
            rootNamespace = $"{rootNamespace}.{featureName}";

            // Create directories
            DirectoryBuilder.Build(domainProjectPath);
            DirectoryBuilder.Build(applicationProjectPath);
            DirectoryBuilder.Build(applicationContractsProjectPath);

            // Create files with content
            DtoFileBuilder.Build(Path.Combine(applicationContractsProjectPath, $"{entityName}Dto.cs"), rootNamespace, opts);
            EntityFileBuilder.Build(Path.Combine(domainProjectPath, $"{entityName}.cs"), rootNamespace, opts);
            CreateUpdateDtoFileBuilder.Build(Path.Combine(applicationContractsProjectPath, $"CreateUpdate{entityName}Dto.cs"), rootNamespace, opts);
            ServiceInterfaceFileBuilder.Build(Path.Combine(applicationContractsProjectPath, $"I{entityName}AppService.cs"), rootNamespace, opts);
            ServiceFileBuilder.Build(Path.Combine(applicationProjectPath, $"{entityName}AppService.cs"), rootNamespace, opts);
        }
    }
}
