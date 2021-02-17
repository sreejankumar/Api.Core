namespace Api.Core.Middleware.CustomResponseHeaders
{
    public class CustomResponseHeadersBuilder
    {
        private readonly CustomResponseHeadersPolicy _policy = new CustomResponseHeadersPolicy();

        public CustomResponseHeadersBuilder AddCustomResponseHeadersPolicy(string[] httpVerbs)
        {
            AddAccessControlAllowOrigin();
            AddAccessControlAllowHeaders();
            AddAccessControlAllowMethods(httpVerbs);
            AddAccessControlMaxAgeAllowHeaders();
            AddCacheControl();
            AddPragma();
            return this;
        }

        private CustomResponseHeadersBuilder AddAccessControlAllowOrigin()
        {
            _policy.SetHeaders["Access-Control-Allow-Origin"] = "*";
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpVerbs">GET, POST, PUT, OPTIONS</param>
        /// <returns></returns>
        private CustomResponseHeadersBuilder AddAccessControlAllowMethods(string[] httpVerbs)
        {
            _policy.SetHeaders["Access-Control-Allow-Methods"] = string.Join(",", httpVerbs);
            return this;
        }

        private CustomResponseHeadersBuilder AddAccessControlAllowHeaders()
        {
            _policy.SetHeaders["Access-Control-Allow-Headers"] = "x-requested-with";
            return this;
        }

        private CustomResponseHeadersBuilder AddAccessControlMaxAgeAllowHeaders()
        {
            _policy.SetHeaders["Access-Control-Max-Age"] = "864000";
            return this;
        }

        private CustomResponseHeadersBuilder AddCacheControl()
        {
            _policy.SetHeaders["Cache-control"] = "no-store";
            return this;
        }

        private CustomResponseHeadersBuilder AddPragma()
        {
            _policy.SetHeaders["Pragma"] = "no-cache";
            return this;
        }

        public CustomResponseHeadersBuilder AddCustomHeader(string header, string value)
        {
            _policy.SetHeaders[header] = value;
            return this;
        }

        public CustomResponseHeadersBuilder RemoveHeader(string header)
        {
            _policy.RemoveHeaders.Add(header);
            return this;
        }

        public CustomResponseHeadersPolicy Build()
        {
            return _policy;
        }
    }
}
