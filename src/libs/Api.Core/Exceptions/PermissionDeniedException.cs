using System;
using Api.Core.Data.Constants;

namespace Api.Core.Exceptions
{
    public class PermissionDeniedException : Exception
    {
        public PermissionDeniedException(string message) : base(message) { }
    }
}
