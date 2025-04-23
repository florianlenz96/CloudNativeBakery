namespace BackeryApi.Domain.Products;

public record Category
{
    public required string Name { get; init; }
    public IReadOnlyCollection<Article>? Articles { get; init; }
}