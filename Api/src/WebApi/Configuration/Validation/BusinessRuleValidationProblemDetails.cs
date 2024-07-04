﻿using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Configuration.Validation
{
    public class BusinessRuleValidationProblemDetails : ProblemDetails
    {
        public BusinessRuleValidationProblemDetails(BusinessRuleValidationException exception)
        {
            Title = "Business rule broken";
            Status = StatusCodes.Status409Conflict;
            Detail = exception.Message;
            Type = "https://somedomain/business-rule-validation-error";
        }
    }
}
