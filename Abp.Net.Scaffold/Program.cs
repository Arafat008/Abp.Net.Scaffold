using Abp.Net.Scaffold;
using Abp.Net.Scaffold.CommandOptions;
using CommandLine;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        return await Parser.Default.ParseArguments<Options>(args)
            .MapResult(
                async options => await CommandHandler.HandleOptions(options),
                errors => Task.FromResult(1));
    }
}