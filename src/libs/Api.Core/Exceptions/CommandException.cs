using System;

namespace Api.Core.Exceptions
{
    public class CommandException : Exception
    {
        public string FullStackTrace { get; set; }
        public CommandException(string message, string stackTrace) : base(message)
        {
            FullStackTrace = stackTrace;
        }
    }
}
