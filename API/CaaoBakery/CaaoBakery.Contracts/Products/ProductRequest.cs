namespace CaaoBakery.Contracts.Products
{
    public record  CreateProductRequest
    (string Id,
        string Name, 
        string Description, 
        decimal Price,
        List<Stock> Stokcs);

    public record Stock(string Id, int Quantity,
        DateTime ProductionDateTime,
        DateTime ExpirationDateTime,
        string Status);
}
