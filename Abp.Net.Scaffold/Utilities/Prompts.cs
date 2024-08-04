using Abp.Net.Scaffold.CommandOptions;
using Spectre.Console;

namespace Abp.Net.Scaffold.Utilities
{
    public static class Prompts
    {
        public static string GetServiceTypeAsync()
        {
            return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select Interface Type:")
                    .AddChoices(
                    ServiceTypeOptions.AppService,
                    ServiceTypeOptions.CrudAppService,
                    ServiceTypeOptions.Blank));
        }

        public static string GetDtoTypeAsync()
        {
            return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select Dto Type:")
                    .AddChoices(
                    DtoOptions.AuditedEntityDto,
                    DtoOptions.EntityDto,
                    DtoOptions.Blank));
        }

        public static string GetEntityTypeAsync()
        {
            return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select Entity Type:")
                    .AddChoices(
                    EntityTypeOptions.AuditedAggregateRoot,
                    EntityTypeOptions.AggregateRoot,
                    EntityTypeOptions.AuditedEntity,
                    EntityTypeOptions.Entity,
                    EntityTypeOptions.Blank));
        }

        public static void ShowInfo()
        {
            AnsiConsole.MarkupLine("[bold]Info[/]");
            AnsiConsole.MarkupLine("Use the following options:");
            AnsiConsole.MarkupLine("[yellow]--info | --i[/] : Show this info message.");
            AnsiConsole.MarkupLine("[yellow]--feature <FEATURE> | --f <FEATURE>[/] : Name of the feature.");
            AnsiConsole.MarkupLine("[yellow]--entity <ENTITY> | --e <FEATURE>[/] : Name of the entity.");
            AnsiConsole.MarkupLine("[yellow]--entity-type <TYPE>[/] : Type of entity (e.g., AuditedEntity, AuditedAggregateRoot, Entity, AggregateRoot, Blank).");
            AnsiConsole.MarkupLine("[yellow]--dto-type <TYPE>[/] : Type of dto (e.g., EntityDto, AuditedEntityDto, Blank).");
            AnsiConsole.MarkupLine("[yellow]--service-type <TYPE>[/] : Type of service (e.g., AppService, Blank, CrudAppService).");
        }

        public static void ShowError(string message)
        {
            AnsiConsole.MarkupLine($"[red]{message}[/]");
        }

        public static void ShowMessage(string message)
        {
            AnsiConsole.MarkupLine($"[green]{message}[/]");
        }
    }
}
