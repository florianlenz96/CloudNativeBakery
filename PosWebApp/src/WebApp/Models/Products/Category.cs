namespace WebApp.Models.Products;

public record Category(string Name, IReadOnlyCollection<Article> Articles);