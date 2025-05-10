using BackeryApi.Domain.Products;
using BackeryApi.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackeryApi.SqlServer;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBackerySqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddDbContext<BackeryDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("BackeryApi")));
        
        return services;
    }
}