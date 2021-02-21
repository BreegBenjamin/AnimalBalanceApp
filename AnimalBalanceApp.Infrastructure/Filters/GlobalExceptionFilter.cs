using AnimalBalanceApp.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace AnimalBalanceApp.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        //Controlador para manejar las excepcione globales del api-Instanciada en el startup
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(BusinessException))
            {
                var exception = (BusinessException)context.Exception;
                _throwException(context,exception.Message);
            }
            else if (context.Exception.GetType() == typeof(ParameterException)) 
            {
                var exception = (ParameterException)context.Exception;
                _throwException(context, exception.Message);
            }
        }

        private void _throwException(ExceptionContext context, string message)
        {
            var validation = new
            {
                Status = 400,
                Title = "Bad Request",
                Detail = message
            };
            var json = new
            {
                errors = new[] { validation }
            };

            context.Result = new BadRequestObjectResult(json);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.ExceptionHandled = true;
        }
    }
}
