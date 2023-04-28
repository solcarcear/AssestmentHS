namespace CaaoBakery.Contracts.Products
{
    public record ProductResponse(
           string Id,
        string Name,
        string Description,
        decimal Price,
        List<StockResponse> Stokcs);

    public record StockResponse(
        string Id,
        int Quantity,
        DateTime ProductionDateTime,
        DateTime ExpirationDateTime,
        string Status);
}
