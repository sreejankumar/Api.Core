using System.Threading.Tasks;
using Api.Core.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Api.Core.Controller
{
    public class ControllerBase : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ICommandService _commandService;

        protected ControllerBase(ICommandService commandService)
        {
            _commandService = commandService;
        }

        /// <summary>
        /// Executing the Commands
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        protected async Task<ActionResult> Run<TCommand, TInput, TOutput>(TInput model)
            where TCommand : Command<TInput, TOutput>
        {
            var command = await _commandService.GetValidatedCommand<TCommand, TInput, TOutput>(model);
            var response = await command.Run(model);
            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }
    }
}