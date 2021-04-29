using System;
using System.Collections.Generic;
using System.Linq;
using SquareMetersValue.Domain.Core;
using SquareMetersValue.Domain.ValueObjects;

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
            AveragePricePerSquareMeter = new AveragePricePerSquareMeter(properties);
            Validate(this, new StatisticValidator());
        }

        public int TotalAccounted { get; private set; }
        public AveragePricePerSquareMeter AveragePricePerSquareMeter { get; private set; }



        public string GetAverageDisplay()
        {

            var displayString = $"R$ {AveragePricePerSquareMeter.Value.ToString()}";

            return displayString;
        }

    }
}
