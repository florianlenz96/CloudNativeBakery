using Backery.Application.ShoppingBasket.Command;
using BackeryApi.Domain.ShoppingBasket.Events;
using Dapr.Client;

namespace Backery.Application.ShoppingBasket.Handler;

public class CreateOrderCommandHandler(DaprClient daprClient)
{
    public async Task Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var orderCreatedEvent = new OrderCreatedEvent(command.Articles, Guid.NewGuid().ToString());
        await daprClient.PublishEventAsync("pubsub", "ordercreated", orderCreatedEvent, cancellationToken);
    }
}