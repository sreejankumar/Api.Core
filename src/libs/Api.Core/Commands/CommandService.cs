using System;
using System.Threading.Tasks;

namespace Api.Core.Commands
{
    public class CommandService : ICommandService 
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<ICommand<TInput, TOutput>> GetValidatedCommand<TCommand, TInput, TOutput>(TInput model)
            where TCommand : ICommand<TInput, TOutput>
        {
            var commandType = typeof(TCommand);
            if (!(_serviceProvider.GetService(commandType) is ICommand<TInput, TOutput> command))
            {
                throw new Exception($"Could not instantiate command: {commandType}");
            }
            await command.Validate(model);
            return command;
        }
    }
}