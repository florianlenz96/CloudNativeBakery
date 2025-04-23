using System.Text.Json;
using Azure.Messaging.ServiceBus;
using Backery.Application;
using BackeryApi.Domain.ShoppingBasket.Events;
using Microsoft.Extensions.Azure;

namespace BackeryApi.Messaging;

public class MessagingService : IMessagingService
{
    private readonly ServiceBusClient _serviceBusClient;
    
    public MessagingService(IAzureClientFactory<ServiceBusClient> serviceBusClientFactory)
    {
        _serviceBusClient = serviceBusClientFactory.CreateClient("ServiceBusClient");
    }

    public Task SendOrderCreatedEventAsync(OrderCreatedEvent order, CancellationToken cancellationToken)
    {
        var sender = _serviceBusClient.CreateSender("order-created");
        var message = new ServiceBusMessage(JsonSerializer.Serialize(order));
        return sender.SendMessageAsync(message, cancellationToken);
    }
}