using Ardalis.SmartEnum;

namespace CaaoBakery.Domain.ProductAggregate.Enums
{
    public class ProductType : SmartEnum<ProductType>
    {
        public ProductType(string name, int value) : base(name, value)
        {
        }
        public static readonly ProductType Bread = new(nameof(Bread), 1);
        public static readonly ProductType Cake = new(nameof(Cake), 2);
        public static readonly ProductType Dessert = new(nameof(Dessert), 3);
        public static readonly ProductType Cupcake = new(nameof(Cupcake), 4); 
        public static readonly ProductType Coffee = new(nameof(Coffee), 4); 


    }
}
