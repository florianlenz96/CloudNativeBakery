using Backery.Application.ShoppingBasket.Command;
using BackeryApi.Domain.ShoppingBasket.Events;

namespace Backery.Application.ShoppingBasket.Handler;

public class CreateOrderCommandHandler
{
    private readonly IMessagingService _messagingService;
    
    public CreateOrderCommandHandler(IMessagingService messagingService)
    {
        _messagingService = messagingService;
    }
    
    public async Task Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var orderCreatedEvent = new OrderCreatedEvent(command.Articles, Guid.NewGuid().ToString());
        await _messagingService.SendOrderCreatedEventAsync(orderCreatedEvent, cancellationToken);
    }
}