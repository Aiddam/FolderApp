using FolderTestApp.Errors;
using System.Net;

namespace FolderTestApp.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IHostEnvironment env;

        public ExceptionMiddleware(RequestDelegate next,
                                    ILogger<ExceptionMiddleware> logger,
                                    IHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                ApiError response;
                HttpStatusCode statusCode;
                string message;
                switch (ex)
                {
                    case UnauthorizedAccessException:
                        statusCode = HttpStatusCode.Forbidden;
                        message = "You are not authorized";
                        break;
                    case KeyNotFoundException:
                        statusCode = HttpStatusCode.NotFound;
                        message = "Not Found ";
                        break;
                    case ApplicationException:
                        statusCode = HttpStatusCode.BadRequest;
                        message = "Bad request";
                        break;
                    default:
                        statusCode = HttpStatusCode.InternalServerError;
                        message = ex.Message;
                        break;
                }
                if (env.IsDevelopment())
                {
                    response = new ApiError(
                        (int)statusCode, message, ex.StackTrace.ToString());
                }
                else
                {
                    response = new ApiError(
                        (int)statusCode, message);
                }
                logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)statusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(response.ToString());
            }
        }
    }
}
