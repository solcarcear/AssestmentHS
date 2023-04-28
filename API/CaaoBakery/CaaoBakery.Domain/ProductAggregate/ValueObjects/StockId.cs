using CaaoBakery.Domain.Common.Models;

namespace CaaoBakery.Domain.ProductAggregate.ValueObjects
{
    public sealed class StockId : ValueObject
    {
        public StockId(Guid value)
        {
            Value = value;
        }
        public Guid Value { get; private set; }


        public static StockId CreateUnique()
        {
            return new StockId(Guid.NewGuid());
        }

        public static StockId Create(Guid value)
        {
            return new StockId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

#pragma warning disable CS8618
        private StockId()
        {
        }
#pragma warning restore CS8618
    }
}
