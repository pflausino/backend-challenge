using System;
using SquareMetersValue.Domain.Core;
using SquareMetersValue.Domain.ValueObjects;

namespace SquareMetersValue.Domain.Models
{
    public class Property : Entity
    {
        public Property(int size, decimal totalValue, Guid cityId, string description)
        {
            Size = size;
            TotalValue = totalValue;
            CityId = cityId;
            Description = description;
            AveragePerSquareMeter = new AveragePerSquareMeter(TotalValue,Size);

        }

        public int Size { get; private set; }
        public decimal TotalValue { get; private set; }
        public Guid CityId { get; private set; }
        public string Description { get; private set; }
        public AveragePerSquareMeter AveragePerSquareMeter { get; private set; }

    }
}
