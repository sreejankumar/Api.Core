using Microsoft.Extensions.DependencyInjection;

namespace Api.Core.Commands
{
    public static class CommandsExtensions
    {
        public static void AddCommandsFromAssembly(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICommandService, CommandService>();
        }
    }
}