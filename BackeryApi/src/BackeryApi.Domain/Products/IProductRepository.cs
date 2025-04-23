namespace BackeryApi.Domain.Products;

public interface IProductRepository
{
    Task<IReadOnlyCollection<Category>> GetCategoriesAsync(CancellationToken cancellationToken);
}