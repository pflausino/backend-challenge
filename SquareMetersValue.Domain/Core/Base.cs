using FluentValidation;
using FluentValidation.Results;

namespace SquareMetersValue.Domain.Core
{
    public abstract class Base 
    {
		public bool Valid { get; private set; }
		public bool Invalid => !Valid;
		public ValidationResult ValidationResult { get; private set; }

		public bool Validate<T>(T model, AbstractValidator<T> validator)
		{
			ValidationResult = validator.Validate(model);
			return Valid = ValidationResult.IsValid;
		}

		public virtual void AddNotification(string key, string message)
		{
			var validationFailure = new ValidationFailure(key, message);

			if (ValidationResult == null)
				ValidationResult = new ValidationResult();

			ValidationResult.Errors.Add(validationFailure);
			Valid = ValidationResult.IsValid;
		}

	}
}
