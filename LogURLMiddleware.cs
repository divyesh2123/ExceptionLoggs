﻿namespace WebApplication2
{
    public class LogURLMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogURLMiddleware> _logger;

        public LogURLMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
           
            _next = next;
            _logger = loggerFactory?.CreateLogger<LogURLMiddleware>() ??
            throw new ArgumentNullException(nameof(loggerFactory));
        }

        public async Task InvokeAsync(HttpContext context)
        {
           

            _logger.LogInformation($"Request URL: {Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(context.Request)}");
            await this._next(context);
        }
    }
    static public class LogURLMiddlewareExtensions
    {

        public static IApplicationBuilder UseLogUrl(this IApplicationBuilder app)
        {

            return app.UseMiddleware<LogURLMiddleware>();
        }
    }


}
