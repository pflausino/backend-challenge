using System.Collections.Generic;
using System.Linq;
using SquareMetersValue.Domain.Core;

namespace SquareMetersValue.Domain.Models
{
    public class RealEstateStatisticData : Base
    {
        public RealEstateStatisticData(List<Property> properties)
        {
            var totalCities = properties
                .Select(x => x.CityId)
                .Distinct()
                .Count();

            if (totalCities != 1)
            {
                AddNotification("Multiple_Cities", "Only one citie is allowed");

                return;
            }

            TotalAccounted = properties.Count;
            SetAveregePerSquareMeter(properties);
            Validate(this, new RealEstateStatisticDataValidator());
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
