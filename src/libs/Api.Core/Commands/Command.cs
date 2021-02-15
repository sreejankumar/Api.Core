using System.Threading.Tasks;

namespace Api.Core.Commands
{
    public abstract class Command<TInput, TOutput> : ICommand<TInput, TOutput>
    {
        public abstract Task Validate(TInput input);
        public abstract Task<TOutput> Run( TInput input);
    }
}