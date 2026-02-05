using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using UserManagement.Application.Models;

namespace UserManagement.Application.Common.Validation;

public static class DataAnnotationValidator
{
    public static Result Validate(this object model)
    {
        var context = new ValidationContext(model);
        var validationResults = new List<ValidationResult>();

        if (Validator.TryValidateObject(model, context, validationResults, true))
        {
            return new Result
            {
                IsSuccess = true
            };
        }
        var errors = validationResults
           .Select(r =>
           {
               var member = r.MemberNames?.FirstOrDefault();
               var message = r.ErrorMessage ?? "Validation error";

               return string.IsNullOrWhiteSpace(member)
                   ? message
                   : $"{member}: {message}";
           })
           .Distinct()
           .ToList();

        return new Result
        {
            IsSuccess = false,
            StatusCode = HttpStatusCode.BadRequest,
            Message = "Validation failed",
            Errors = errors
        };
    }
}
