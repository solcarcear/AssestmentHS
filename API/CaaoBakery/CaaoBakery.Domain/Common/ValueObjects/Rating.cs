using CaaoBakery.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaaoBakery.Domain.Common.ValueObjects
{
    public sealed class Rating : ValueObject
    {
        public Rating(int value)
        {
            Value = value;
        }

        public int Value { get; private set; }

        public static Rating Create(int value)
        {
            // TODO: Enforce invariants
            return new Rating(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
