using System;
using System.Collections.Generic;
using System.Linq;
using SquareMetersValue.Domain.Core;
using SquareMetersValue.Domain.Models;

namespace SquareMetersValue.Domain.ValueObjects
{
    public class AveragePricePerSquareMeter : ValueObject
    {

        public virtual decimal Value { get; protected set; }

        protected AveragePricePerSquareMeter()
        {
        }

        public AveragePricePerSquareMeter(List<Property> properties)
        {

            var sumOfSquareMeter = properties.Sum(x => x.AveragePerSquareMeter.Value);
            var average = sumOfSquareMeter / properties.Count;


            Value = Math.Round(average, 2, MidpointRounding.AwayFromZero);

        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}