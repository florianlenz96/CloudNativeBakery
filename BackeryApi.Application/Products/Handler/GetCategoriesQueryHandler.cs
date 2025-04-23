using Backery.Application.Products.Queries;
using BackeryApi.Domain.Products;

namespace Backery.Application.Products.Handler;

public class GetCategoriesQueryHandler(IProductRepository productRepository)
{
    public async Task<IEnumerable<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await productRepository.GetCategoriesAsync(cancellationToken);
        return categories;
    }
}