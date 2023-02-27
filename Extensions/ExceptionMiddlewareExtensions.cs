using FolderTestApp.Middlewares;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace FolderTestApp.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        public static void ConfigureBuiltinExceptionHandler(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(options =>
                {
                    options.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var ex = context.Features.Get<IExceptionHandlerFeature>();
                        if (ex != null)
                        {
                            await context.Response.WriteAsync(ex.Error.Message);
                        }
                    });
                });
            }
        }
    }
}
