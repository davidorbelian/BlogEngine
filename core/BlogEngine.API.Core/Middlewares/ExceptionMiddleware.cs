using System;
using System.Net;
using System.Threading.Tasks;
using BlogEngine.Application.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BlogEngine.API.Core.Middlewares
{
    public sealed class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (EntityNotFoundException entityNotFound)
            {
                await Response(context, HttpStatusCode.NotFound, entityNotFound.Message);
            }
            catch (Exception e)
            {
                await Response(context, HttpStatusCode.InternalServerError, e.Message);
            }
        }

        private static async Task Response(HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.StatusCode = (int) statusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(JsonConvert.SerializeObject(new {message}));
        }
    }
}