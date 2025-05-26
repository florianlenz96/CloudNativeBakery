using Backery.Application.ShoppingBasket.Command;
using BackeryApi.Domain.ShoppingBasket.Events;
using Dapr.Client;

namespace Backery.Application.ShoppingBasket.Handler;

public class CreateOrderCommandHandler
{
    private readonly DaprClient _daprClient;
    public CreateOrderCommandHandler(DaprClient daprClient)
    {
        _daprClient = daprClient;
    }
    
    public async Task Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var orderCreatedEvent = new OrderCreatedEvent(command.Articles, Guid.NewGuid().ToString());
        
        await this._daprClient.PublishEventAsync(
            pubsubName: "orderpubsub",
            topicName: "ordercreated",
            data: orderCreatedEvent,
            cancellationToken: cancellationToken);
    }
}