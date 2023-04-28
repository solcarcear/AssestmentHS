using Ardalis.SmartEnum;

namespace CaaoBakery.Domain.ProductAggregate.Enums
{
    public class StockStatus : SmartEnum<StockStatus>
    {
        public StockStatus(string name, int value) : base(name, value)
        {
        }
        public static readonly StockStatus ForSale = new(nameof(ForSale), 1);
        public static readonly StockStatus SoldOut = new(nameof(SoldOut), 2);
        public static readonly StockStatus Hold = new(nameof(Hold), 3);
    }
}
