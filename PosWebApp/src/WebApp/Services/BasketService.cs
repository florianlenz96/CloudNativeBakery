using System.Collections.Generic;
using System.Linq;
using WebApp.Models.Products;
using WebApp.Models.ShoppingCart;

namespace WebApp.Services
{
    public class BasketService
    {
        private readonly List<CartArticle> _items = new();

        public IReadOnlyCollection<CartArticle> Items => _items.AsReadOnly();
        public int TotalCount => _items.Count;
        public double TotalPrice => _items.Sum(i => i.Price);

        public void Add(Article article)
        {
            var existingArticle = _items.FirstOrDefault(i => i.Name == article.Name);
            if (existingArticle != null)
            {
                existingArticle.Quantity++;
            }
            else
            {
                _items.Add(new CartArticle(article.Name, article.Price, 1));
            }
        }

        public void Remove(CartArticle article)
        {
            _items.Remove(article);
        }

        public void Clear()
        {
            _items.Clear();
        }
    }
}