using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using SquareMetersValue.Domain.Enums;

namespace SquareMetersValue.Domain.Core
{
    public sealed class Error : ValueObject
    {
        public ErrorType ErrorType { get; }
        public string Code { get; }
        public string Message { get; }
        public IList<ValidationFailure> Errors { get; }

        internal Error(ErrorType errorType, string code, string message)
        {
            ErrorType = errorType;
            Code = code;
            Message = message;
        }

        internal Error(ErrorType errorType, string code, List<ValidationFailure> errors)
        {
            ErrorType = errorType;
            Code = code;
            Errors = errors;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return ErrorType;
            yield return Code;
            yield return Message;
        }

        public static Error NotFound(string entityName, Guid entityId)
        {
            var error = new Error(ErrorType.NotFound, entityName, $"{entityName} not found for id {entityId}");

            return error;
        }

        public static Error NotFound(string entityName)
        {
            var error = new Error(ErrorType.NotFound, entityName, $"{entityName} not found");

            return error;
        }



        public static Error Invalid(string description, IList<ValidationFailure> errors)
        {
            var error = new Error(ErrorType.Invalid, description, errors.ToList());

            return error;
        }

        public static Error Invalid(string description)
        {
            var error = new Error(ErrorType.Invalid, description, description);

            return error;
        }
    }
}
