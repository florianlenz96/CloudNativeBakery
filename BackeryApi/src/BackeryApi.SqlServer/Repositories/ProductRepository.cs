using BackeryApi.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace BackeryApi.SqlServer.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly BackeryDbContext _context;

    public ProductRepository(BackeryDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyCollection<Category>> GetCategoriesAsync(CancellationToken cancellationToken)
        => await this._context
            .Categories
            .Include(c => c.Articles)
            .ToArrayAsync(cancellationToken);
}