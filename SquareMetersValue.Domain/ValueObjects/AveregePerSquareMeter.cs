using System;
using System.Collections.Generic;
using SquareMetersValue.Domain.Core;

namespace SquareMetersValue.Domain.ValueObjects
{
    public class AveragePerSquareMeter : ValueObject
    {
        public virtual decimal Value { get; protected set; }

        protected AveragePerSquareMeter()
        {
        }

        public AveragePerSquareMeter(decimal price, decimal size)
        {

            if (size >= 1)
            {
                var average = price / size;

                Value = Math.Round(average, 2, MidpointRounding.AwayFromZero);
                return;

            }

            Value = 0;

        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }

}
