using domaren.realstate.Domain.Exceptions;
using System.Net;
using System.Text;
using System.Text.Json;

namespace domaren.realestate.API.Middleware
{
    public class BusinessExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private const string ContentType = "application/json; charset=utf-8";

        public BusinessExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IWebHostEnvironment env)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (BaseBusinessException businessException)
            {
                var jsonBody = JsonSerializer.Serialize($"{businessException.GetType().Name}: {businessException.Message}");
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = ContentType;
                await context.Response.WriteAsync(jsonBody, Encoding.UTF8);
            }
            catch (Exception ex) 
            {
                var jsonBody = string.Empty;

                if (env.IsDevelopment())
                    jsonBody = JsonSerializer.Serialize($"Internal server error: {ex.StackTrace.Substring(0, 500)}");
                else
                    jsonBody = JsonSerializer.Serialize("Internal server error: Something went wrong!");

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = ContentType;
                await context.Response.WriteAsync(jsonBody, Encoding.UTF8);
            }
        }
    }
}
