using Dapr.Client;
using WebApp.Models.Products;
using WebApp.Models.ShoppingCart;

namespace WebApp.Services;

public class BackendApiService(DaprClient daprClient)
{
    public async Task<IReadOnlyCollection<Category>?> LoadCategoriesAsync()
    {
        return await daprClient
            .InvokeMethodAsync<IReadOnlyCollection<Category>>(
                HttpMethod.Get,
                "api",
                "api/category");
    }
    
    public async Task<bool> SendOrderAsync(IReadOnlyCollection<CartArticle> articles)
    {
        try
        {
            await daprClient
                .InvokeMethodAsync(
                    HttpMethod.Post,
                    "api",
                    "api/order",
                    new
                    {
                        articles
                    });
            
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}