using WebApp.Models.Products;
using WebApp.Models.ShoppingCart;

namespace WebApp.Services;

public class BackendApiService(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<IReadOnlyCollection<Category>?> LoadCategoriesAsync()
    {
        return await _httpClient.GetFromJsonAsync<IReadOnlyCollection<Category>>("category");
    }
    
    public async Task<bool> SendOrderAsync(IReadOnlyCollection<CartArticle> articles)
    {
        var response = await _httpClient.PostAsJsonAsync("order", new
        {
            articles
        });
        return response.IsSuccessStatusCode;
    }
}