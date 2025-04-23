using Azure.Messaging.ServiceBus;
using Backery.Application;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackeryApi.Messaging;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMessaging(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAzureClients(clientBuilder =>
        {
            clientBuilder.AddServiceBusClient(configuration.GetConnectionString("ServiceBusConnectionString"))
                .WithName("ServiceBusClient")
                .ConfigureOptions(options =>
                {
                    options.RetryOptions.Delay = TimeSpan.FromMilliseconds(50);
                    options.RetryOptions.MaxDelay = TimeSpan.FromSeconds(5);
                    options.RetryOptions.MaxRetries = 3;
                });
        });

        services.AddScoped<IMessagingService, MessagingService>();
        
        return services;
    }
}