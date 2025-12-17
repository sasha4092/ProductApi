using Oracle.ManagedDataAccess.Client;

namespace ProductApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (OracleException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new
                {
                    success = false,
                    message = ex.Message
                });
            }
            catch (Exception)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new
                {
                    success = false,
                    message = "Internal server error"
                });
            }
        }
    }
}
