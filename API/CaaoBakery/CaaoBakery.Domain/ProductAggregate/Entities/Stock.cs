using CaaoBakery.Domain.Common.Models;
using CaaoBakery.Domain.ProductAggregate.Enums;
using CaaoBakery.Domain.ProductAggregate.ValueObjects;

namespace CaaoBakery.Domain.ProductAggregate.Entities
{
    public sealed class Stock : Entity<StockId>
    {
        public int Quantity { get; private set; }
        public DateTime ProductionDateTime { get; private set; }
        public DateTime ExpirationDateTime { get; private set; }
        public StockStatus Status { get; private set; }

        private Stock(
            int quantity, 
            DateTime productionDateTime, 
            DateTime expirationDateTime, 
            StockStatus status) : base(StockId.CreateUnique())
        {
            Quantity = quantity;
            ProductionDateTime = productionDateTime;
            ExpirationDateTime = expirationDateTime;
            Status = status;
        }

        public static Stock Create(
            int quantity, 
            DateTime productionDateTime, 
            DateTime expirationDateTime)
        {
            return new Stock(
                quantity, 
                productionDateTime, 
                expirationDateTime,
                StockStatus.Hold);
        }

#pragma warning disable CS8618
        private Stock()
        {
        }
#pragma warning restore CS8618
    }
}
