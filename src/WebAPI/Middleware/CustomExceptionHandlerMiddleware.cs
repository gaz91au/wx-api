using Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace WebAPI.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var title = exception.Message;
            var detail = string.Empty;
            var instance = context.Request.Path.Value;
            var type = nameof(Exception);

            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    detail = JsonConvert.SerializeObject(validationException.Failures);
                    type = nameof(ValidationException);
                    break;
                case NotFoundException notFoundException:
                    code = HttpStatusCode.NotFound;
                    type = nameof(NotFoundException);
                    break;
            }

            var response = new ProblemDetails()
            {
                Title = title,
                Detail = detail,
                Instance = instance,
                Status = (int)code,
                Type = type,
            };

            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
