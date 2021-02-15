using System;
using Logging.Interfaces;

namespace Api.Core.Data
{
    public class ApiLogContext : IContextLogModel
    {
        public ApiLogContext()
        {
            InternalCorrelationId = Guid.NewGuid();
        }

        public Guid ExternalCorrelationId { get; set; }
        public Guid InternalCorrelationId { get; }
    }
}
