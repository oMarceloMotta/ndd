using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {

        }
        public BadRequestException(string message, ValidationResult validationResult) : base(message)
        {

        }
        public List<string> ValidationErros { get; set; }
    }
}
