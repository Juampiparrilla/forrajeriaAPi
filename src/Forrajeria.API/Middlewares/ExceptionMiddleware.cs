using Forrajeria.API.Models;
using Forrajeria.Domain.Exceptions.Common;

namespace Forrajeria.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
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

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            var response = ex switch
            {
                BusinessRuleException => new ErrorResponse(StatusCodes.Status400BadRequest, ex.Message),

                UnauthorizedException => new ErrorResponse(StatusCodes.Status401Unauthorized, ex.Message),

                NotFoundException => new ErrorResponse(StatusCodes.Status404NotFound, ex.Message),

                ConflictException => new ErrorResponse(StatusCodes.Status409Conflict, ex.Message),

                _ => new ErrorResponse(StatusCodes.Status500InternalServerError, "Ocurrió un error interno.")
            };

            context.Response.StatusCode = response.StatusCode;

            await context.Response.WriteAsJsonAsync(response);

        }
    }
}
