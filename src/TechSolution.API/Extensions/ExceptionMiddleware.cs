using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace TechSolution.API.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public ExceptionMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                HandleException(context, ex);
            }
        }

        static void HandleException(HttpContext httpContext, Exception ex)
        {
            //Threat exception here
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}
