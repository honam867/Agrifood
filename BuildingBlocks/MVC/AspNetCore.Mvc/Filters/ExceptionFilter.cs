using AspNetCore.Common.Exceptions;
using AspNetCore.Common.Messages;
using AspNetCore.Mvc.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCore.Mvc.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException)
            {
                var originException = context.Exception as ValidationException;
                context.Result = new BadRequestObjectResult(
                    new ExceptionMessage
                    {
                        Message = originException.Message
                    });

                base.OnException(context);
            }
            else if (context.Exception is UserDefinedException)
            {
                var originException = context.Exception as UserDefinedException;
                context.Result = new BadRequestObjectResult(originException.UserDefinedMessage);

                base.OnException(context);
            }

        }
    }
}
