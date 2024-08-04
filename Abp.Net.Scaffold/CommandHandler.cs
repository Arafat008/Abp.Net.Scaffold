using Abp.Net.Scaffold.Builders;
using Abp.Net.Scaffold.CommandOptions;
using Abp.Net.Scaffold.Utilities;

namespace Abp.Net.Scaffold
{
    public class CommandHandler
    {
        public async static Task<int> HandleOptions(Options options)
        {
            if (options.Info)
            {
                Prompts.ShowInfo();
                return 0;
            }

            if (string.IsNullOrEmpty(options.EntityType))
            {
                options.EntityType = Prompts.GetEntityTypeAsync();
            }

            if (string.IsNullOrEmpty(options.DtoType)) 
            {
                options.DtoType = Prompts.GetDtoTypeAsync();
            }

            if (string.IsNullOrEmpty(options.ServiceType))
            {
                options.ServiceType = Prompts.GetServiceTypeAsync();
            }

            FileBuilder.Build(options);

            return await Task.FromResult(0);
        }
    }
}
