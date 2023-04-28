using CaaoBakery.Application.Common.Interfaces.Persistence;
using CaaoBakery.Domain.ProductAggregate;
using CaaoBakery.Domain.ProductAggregate.Enums;
using CaaoBakery.Domain.ProductAggregate.ValueObjects;

namespace CaaoBakery.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CaaoBakeryDbContext _dbContext;

        public ProductRepository(CaaoBakeryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product Add(Product product)
        {
            _dbContext.Add(product);

            return product;
        }

        public bool Delete(ProductId productId)
        {
            
        }

        public List<Product> List(string name, ProductType productType)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
