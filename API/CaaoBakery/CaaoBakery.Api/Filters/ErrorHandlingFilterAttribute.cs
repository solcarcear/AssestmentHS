﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CaaoBakery.Api.Filters
{
    public class ErrorHandlingFilterAttribute: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var problemsDetails = new ProblemDetails { 
                Title = "An error occured while processing your request.",
                Status= (int)HttpStatusCode.InternalServerError,
            };


            context.Result = new ObjectResult(problemsDetails);

            context.ExceptionHandled = true;
        }
    }
}
