using System;
using FluentValidation;

namespace SquareMetersValue.Domain.Commands
{
    public class CreatePropertyCommandValidation : AbstractValidator<CreatePropertyCommand>
    {
        public CreatePropertyCommandValidation()
        {
            RuleFor(x => x.Size)
                .GreaterThan(0)
                .WithMessage("Size must be Greater Than 0 ");

            RuleFor(x => x.CityId)
                .NotEmpty()
                .NotNull()
                .WithMessage("City Id can not be Empty ");

            RuleFor(x => x.TotalValue)
                .GreaterThan(1)
                .WithMessage("Total Value Must be Greater Than 1");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description Must Not Be Empty")
                .MinimumLength(3)
                .WithMessage("Description Must Have More Than 3 Letters")
                .MaximumLength(400)
                .WithMessage("Description Must Have No More Than 400 Letters");
        }
    }
}
