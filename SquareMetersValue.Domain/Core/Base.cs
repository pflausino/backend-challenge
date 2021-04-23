using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;

namespace SquareMetersValue.Domain.Core
{
    public abstract class Base
    {
        public virtual bool Valid { get; private set; }
        public virtual bool Invalid => !Valid;
        public virtual ValidationResult ValidationResult { get; private set; }

        public virtual bool Validate<T>(T model, AbstractValidator<T> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }
    }
}
