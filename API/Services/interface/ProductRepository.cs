using API.Helpers;
using API.Model;
using Intuit.Ipp.Core.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public List<ProductModel> GetAll(string seach)
        {
            var products = _context.products.AsQueryable();

            if(products == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(seach))
            {
                products = products.Where(p => p.Name.Contains(seach));
            }

            var result = products.Select(p => new ProductModel
            {
                ProductId = p.ProductId,
                ProductName = p.Name,
                Price = p.Price,
                NameType = p.TypeProduct.TypeName,
            });
            return result.ToList();
        }
    }
}
