namespace MockBookingSystem.Middleware
{
    public class XApiKeyAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public XApiKeyAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("x-api-key"))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Authorization header is missing");
                return;
            }

            string authorizationHeader = context.Request.Headers["x-api-key"];
            if (!IsValidAuthorization(authorizationHeader))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid authorization header");
                return;
            }

            // Call the next middleware in the pipeline
            await _next(context);
        }

        private bool IsValidAuthorization(string authorizationHeader)
        {
            return string.Equals(authorizationHeader, "ZNFYloswP0ZNFYloswP0");
        }
    }

}
