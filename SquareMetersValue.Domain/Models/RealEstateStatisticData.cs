using System;
using System.Collections.Generic;
using System.Linq;
using SquareMetersValue.Domain.Core;

namespace SquareMetersValue.Domain.Entities
{
    public class RealEstateStatisticData : Base
    {
        public RealEstateStatisticData(List<Property> properties)
        {
            var totalCities = properties
                .Select(x => x.City.Id)
                .Distinct()
                .Count();

            if (totalCities != 1)
            {
                return;
            }

            TotalAccounted = properties.Count;
            SetAveregePerSquareMeter(properties);
        }


        public int TotalAccounted { get; private set; }
        public decimal AveregePerSquareMeter { get; private set; }


        private void SetAveregePerSquareMeter(List<Property> properties)
        {
            var sumOfSquareMeter = properties.Sum(x => x.AveregePerSquareMeter);
            var average = sumOfSquareMeter / TotalAccounted;

            AveregePerSquareMeter = average;
            
        }

    }
}
