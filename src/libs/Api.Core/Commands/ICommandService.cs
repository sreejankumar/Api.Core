using System.Threading.Tasks;

namespace Api.Core.Commands
{
    public interface ICommandService 
    {
        Task<ICommand<TInput, TOutput>> GetValidatedCommand<TCommand, TInput, TOutput>(TInput model)
            where TCommand : ICommand<TInput, TOutput>;
    }
}
