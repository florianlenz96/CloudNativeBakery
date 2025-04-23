namespace WebApp.Models.ShoppingCart;

public record CartArticle(string Name, double Price, int Quantity)
{
    public double TotalPrice => Price * Quantity;
    public int Quantity { get; set; } = Quantity;
}