using FluentValidation;
using IzleciDepresiju.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace IzleciDepresiju.API.Extensions
{
    public static  class ControllerBaseExtensions
    {
        public static IActionResult HandleException(this ControllerBase c, Exception ex)
        {
            if(ex is EntityNotFoundException)
            {
                return c.NotFound();
            }

            if(ex is ValidationException e)
            {
                var errors = e.Errors.Select(e => new
                {
                    Name = e.PropertyName,
                    Message = e.ErrorMessage
                });
                return c.UnprocessableEntity(errors);
            }

            if(ex is ForbiddenUseCaseExecutionException)
            {
                return c.Forbid();
            }



            return c.StatusCode(500);
        }

        public static IActionResult HandleUseCase(this ControllerBase c, Func<IActionResult> executeUseCase)
        {
            try
            {
                return executeUseCase();
            }catch(Exception ex)
            {
                return c.HandleException(ex);
            }
        }
    }
}
