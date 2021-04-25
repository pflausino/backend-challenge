using System;
using MediatR;
using SquareMetersValue.Domain.Core;
using CSharpFunctionalExtensions;


namespace SquareMetersValue.Domain.Commands
{
    public class CreatePropertyCommand : IRequest<Result<Unit, Error>>
    {
        public int Size { get; set; }
        public decimal TotalValue { get; set; }
        public Guid CityId { get; set; }
        public string Description { get; set; }
    }
}
