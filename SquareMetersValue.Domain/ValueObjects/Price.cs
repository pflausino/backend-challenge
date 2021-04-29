using System;
using System.Collections.Generic;
using SquareMetersValue.Domain.Core;

namespace SquareMetersValue.Domain.ValueObjects
{
    public class Price : ValueObject
    {
        public virtual decimal Value { get; protected set; }

        protected Price()
        {
        }

        public Price(decimal price)
        {
            if (price <= 0)
            {
              throw new ArgumentException($"Price cannot be negative, Actual {price}");
            }

            Value = Math.Round(price, 2, MidpointRounding.AwayFromZero);
            
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}