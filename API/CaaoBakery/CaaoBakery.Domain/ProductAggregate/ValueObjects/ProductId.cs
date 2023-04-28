using CaaoBakery.Domain.Common.Models;
using CaaoBakery.Domain.Common.DomainErrors;
using ErrorOr;

namespace CaaoBakery.Domain.ProductAggregate.ValueObjects
{
    public sealed class ProductId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private ProductId(Guid value)
        {
            Value = value;
        }

        public static ProductId CreateUnique()
        {
            return new ProductId(Guid.NewGuid());
        }

        public static ProductId Create(Guid value)
        {
            return new ProductId(value);
        }

        public static ErrorOr<ProductId> Create(string value)
        {
            return !Guid.TryParse(value, out var guid) ? (ErrorOr<ProductId>)Errors.Product.InvalidProductId : (ErrorOr<ProductId>)new ProductId(guid);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

#pragma warning disable CS8618
        private ProductId()
        {
        }
#pragma warning restore CS8618
    }
}
