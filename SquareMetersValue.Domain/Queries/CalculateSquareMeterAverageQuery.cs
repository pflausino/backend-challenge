using System;
using CSharpFunctionalExtensions;
using MediatR;
using SquareMetersValue.Domain.Core;
using SquareMetersValue.Domain.ViewModel;

namespace SquareMetersValue.Domain.Queries
{
    public class CalculateSquareMeterAverageByCityQuery : Base, IRequest<Result<RealStateStatisticDataViewModel, Error>>
    {


        public CalculateSquareMeterAverageByCityQuery(Guid id)
        {
            CityId = id;
            Validate(this, new CalculateSquareMeterAverageByCityQueryValidation ());
        }

        public Guid CityId { get; set; }
    }
}
