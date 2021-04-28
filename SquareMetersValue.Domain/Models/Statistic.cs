using System;
using System.Collections.Generic;
using System.Linq;
using SquareMetersValue.Domain.Core;

namespace SquareMetersValue.Domain.Models
{
    public class Statistic : Base
    {
        public Statistic(List<Property> properties)
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
            Validate(this, new StatisticValidator());
        }

        public int TotalAccounted { get; private set; }
        public decimal AveregePerSquareMeter { get; private set; }


        private void SetAveregePerSquareMeter(List<Property> properties)
        {
            var sumOfSquareMeter = properties.Sum(x => x.AveregePerSquareMeter);
            var average = sumOfSquareMeter / TotalAccounted;

            AveregePerSquareMeter = average;
        }

        public string GetAverageDisplay()
        {

            var displayNumber = Math.Round(AveregePerSquareMeter, 2, MidpointRounding.AwayFromZero);
            var displayString = displayNumber.ToString();

            return displayString;
        }

    }
}
