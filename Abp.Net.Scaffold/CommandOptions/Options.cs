using CommandLine;

namespace Abp.Net.Scaffold.CommandOptions
{
    public class Options
    {
        [Option(longName: "info", shortName: 'i', HelpText = "Show info message.")]
        public bool Info { get; set; }

        [Option(longName: "feature", shortName: 'f', HelpText = "Name of the feature.")]
        public string? FeatureName { get; set; }

        [Option(longName: "entity", shortName: 'e', HelpText = "Name of the entity.")]
        public string? EntityName { get; set; }

        [Option("entity-type", HelpText = "Type of entity to generate (e.g., AuditedEntity, AuditedAggregateRoot, AggregateRoot, Entity, Blank).")]
        public string EntityType { get; set; } = string.Empty;

        [Option("dto-type", HelpText = "Type of dto to generate (e.g., Entity, AuditedEntity, Blank).")]
        public string DtoType { get; set; } = string.Empty;

        [Option("service-type", HelpText = "Type of service to generate (e.g., CrudAppServie, AppService, Blank).")]
        public string ServiceType { get; set; } = string.Empty;

    }
}
