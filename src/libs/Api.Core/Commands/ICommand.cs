using System.Threading.Tasks;

namespace Api.Core.Commands
{
    public interface ICommand<in TInput, TOutput>
    {
        Task Validate(TInput input);
        Task<TOutput> Run(TInput input);
    }
}