using BackeryApi.Domain.ShoppingBasket.Models;

namespace BackeryApi.Domain.ShoppingBasket.Events;

public record OrderCreatedEvent(IReadOnlyCollection<CartArticle> Articles, string OrderId);