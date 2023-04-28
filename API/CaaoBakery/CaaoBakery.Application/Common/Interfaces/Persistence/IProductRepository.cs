using CaaoBakery.Domain.ProductAggregate;
using CaaoBakery.Domain.ProductAggregate.Enums;
using CaaoBakery.Domain.ProductAggregate.ValueObjects;

namespace CaaoBakery.Application.Common.Interfaces.Persistence
{
    public interface IProductRepository
    {
        List<Product> List(string name, ProductType productType);

        Product Add(Product product);
        Product Update(Product product);
        bool Delete(ProductId productId);

    }
}
