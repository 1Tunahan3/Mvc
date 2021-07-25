using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MvcW03.MyMiddlewares
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;

        public LogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //request logic here
            //await context.Response.WriteAsJsonAsync("Request handled Middleware 0 -custom\n");

            var reqPathLog =
                $"{DateTime.Now} {DateTime.Now.Millisecond}:{context.Request.Path} {context.Request.QueryString}\n";
            await File.AppendAllTextAsync(Environment.CurrentDirectory + "\\log.txt", reqPathLog);

            await _next(context);
                //response logic here
                //await context.Response.WriteAsync("Response handled Middleware 0 -custom\n");

        }

       
    }

    public static class MyMiddlewareExtension
    {
        public static IApplicationBuilder UseMyLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogMiddleware>();
        }
    }
}
