namespace Api.Core.Commands
{
    public abstract class ReadonlyCommand<TInputModel, TOutputModel> : Command<TInputModel, TOutputModel>
    {
    }

    public abstract class ReadonlyCommand<TModel> : ReadonlyCommand<TModel, TModel>
    {
    }
}