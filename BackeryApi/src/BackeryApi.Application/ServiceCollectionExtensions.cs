using Backery.Application.Products.Handler;
using Backery.Application.ShoppingBasket.Handler;
using Microsoft.Extensions.DependencyInjection;

namespace Backery.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<GetCategoriesQueryHandler>();
        services.AddScoped<CreateOrderCommandHandler>();
        return services;
    }
}