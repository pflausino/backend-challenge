using System;
using SquareMetersValue.Domain.Core;

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
            SetAveregePerSquareMeter();

        }
        public int Size { get; private set; }
        public decimal TotalValue { get; private set; }
        public Guid CityId { get; private set; }
        public string Description { get; private set; }
        public decimal AveregePerSquareMeter { get; private set; }

        public void SetAveregePerSquareMeter()
        {
            if(Size >= 1)
            {
                var averege = TotalValue / Size;

                AveregePerSquareMeter = averege;

            }
        }
    }
}
