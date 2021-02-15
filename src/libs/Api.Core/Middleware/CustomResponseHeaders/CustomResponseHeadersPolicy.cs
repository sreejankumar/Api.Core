﻿using System.Collections.Generic;

namespace CloudCall.Lambda.Api.Core.Middleware.CustomResponseHeaders
{
    public class CustomResponseHeadersPolicy
    {
        public IDictionary<string, string> SetHeaders { get; }
            = new Dictionary<string, string>();

        public ISet<string> RemoveHeaders { get; }
            = new HashSet<string>();
    }
}