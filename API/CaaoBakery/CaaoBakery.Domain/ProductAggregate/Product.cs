using CaaoBakery.Domain.Common.Models;
using CaaoBakery.Domain.Common.ValueObjects;
using CaaoBakery.Domain.ProductAggregate.Entities;
using CaaoBakery.Domain.ProductAggregate.ValueObjects;

namespace CaaoBakery.Domain.ProductAggregate
{
    public sealed class Product : AggregateRoot<ProductId, Guid>
    {
        private readonly List<Stock> _stocks = new();

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public Uri ImageUrl { get; private set; }

        public AverageRating AverageRating { get; private set; }


        public IReadOnlyList<Stock> Stocks => _stocks.AsReadOnly();

        private Product(
            ProductId productId, 
            string name, 
            string description,
            decimal price, 
            Uri imageUrl, 
            AverageRating averageRating, 
            List<Stock> stocks)
        {
            Name = name;
            Description = description;
            Price = price;
            ImageUrl = imageUrl;
            AverageRating = averageRating;
            _stocks = stocks;
        }

        public static Product Create(
            string name,
            string description,
            decimal price,
            Uri imageUrl,
            List<Stock>? stocks = null
            )
        {
            return new Product(
                ProductId.CreateUnique(),
                name,
                description,
                price,
                imageUrl,
                AverageRating.CreateNew(),
                stocks ?? new()
                );
        }

#pragma warning disable CS8618
        private Product()
        {
        }
#pragma warning restore CS8618

    }
}
