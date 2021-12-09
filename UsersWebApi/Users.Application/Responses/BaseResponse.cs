using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Users.Application.Responses
{
    public class BaseResponse
    {
        public ResponseStatus Status { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }

        public BaseResponse()
        {
            ValidationErrors = new List<string>();
            Success = true;
        }
        public BaseResponse(string message = null) : this()
        { 
            Message = message;
        }

        public BaseResponse(string message, bool success) : this(message)
        {
            Success = success;
        }

        public BaseResponse(ValidationResult validationResult)
        {
            ValidationErrors = new List<String>();
            Success = validationResult.Errors.Count < 0;
            foreach (var item in validationResult.Errors)
            {
                ValidationErrors.Add(item.ErrorMessage);
            }

        }
    }

    public enum ResponseStatus
    {
        Success = 0,
        NotFound = 1,
        BadQuery = 2,
        ValidationError = 3
    }
}
