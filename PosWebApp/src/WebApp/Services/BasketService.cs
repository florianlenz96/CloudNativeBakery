using System.Collections.Generic;
using System.Linq;
using WebApp.Models.Products;

namespace WebApp.Services
{
    public class BasketService
    {
        private readonly List<Article> _items = new();

        public IReadOnlyCollection<Article> Items => _items.AsReadOnly();
        public int TotalCount => _items.Count;
        public double TotalPrice => _items.Sum(i => i.Price);

        public void Add(Article article)
        {
            _items.Add(article);
        }

        public void Remove(Article article)
        {
            _items.Remove(article);
        }

        public void Clear()
        {
            _items.Clear();
        }
    }
}