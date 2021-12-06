using CCPolandAPI.Properties;
using CCPolandAPI.Services.ErrorHandling.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CCPolandAPI.Services.ErrorHandling.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, Resource.ResourceManager.GetString("itemNotFound"));
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.ExpectationFailed;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.ExpectationFailed;
                await context.Response.WriteAsync(ex.Message);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, Resource.ResourceManager.GetString("unexpectedError")); 
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}
