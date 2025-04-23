using BackeryApi.Domain.ShoppingBasket.Models;

namespace Backery.Application.ShoppingBasket.Command;

public record CreateOrderCommand(IReadOnlyCollection<CartArticle> Articles);