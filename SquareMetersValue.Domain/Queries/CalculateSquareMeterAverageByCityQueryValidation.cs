using System;
using FluentValidation;

namespace SquareMetersValue.Domain.Queries
{
    public class CalculateSquareMeterAverageByCityQueryValidation :
        AbstractValidator<CalculateSquareMeterAverageByCityQuery>
    {
        public CalculateSquareMeterAverageByCityQueryValidation()
        {
            RuleFor(x => x.CityId)
                .NotNull()
                .NotEqual(Guid.Empty)
                .WithMessage("CityId Must not be null or empty");


        }
    }
}