using WebApp.Models.Products;

namespace WebApp.Services;

public class BackendApiService(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<IReadOnlyCollection<Category>?> LoadCategoriesAsync()
    {
        return await _httpClient.GetFromJsonAsync<IReadOnlyCollection<Category>>("category");
    }
}