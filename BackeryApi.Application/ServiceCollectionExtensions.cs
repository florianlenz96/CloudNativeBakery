using Backery.Application.Products.Handler;
using Microsoft.Extensions.DependencyInjection;

namespace Backery.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<GetCategoriesQueryHandler>();
        return services;
    }
}