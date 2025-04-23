namespace BackeryApi.Domain.Products;

public record Article
{
    public required string Name { get; init; }
    public required double Price { get; init; }
}