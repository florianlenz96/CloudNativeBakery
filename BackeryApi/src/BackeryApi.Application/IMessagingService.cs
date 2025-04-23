using BackeryApi.Domain.ShoppingBasket.Events;

namespace Backery.Application;

public interface IMessagingService
{
    Task SendOrderCreatedEventAsync(OrderCreatedEvent order, CancellationToken cancellationToken);
}