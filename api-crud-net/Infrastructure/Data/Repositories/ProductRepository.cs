using api_crud_net.Domain.Entities;
using api_crud_net.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api_crud_net.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _context.Products.ToListAsync();

            if (products == null)
            {
                return Enumerable.Empty<Product>();
            }
            return products;
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return null;
            }

            return product;
        }

        public async Task Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public Task Update(Product product)
        {
            throw new NotImplementedException();
        }
        public async Task Delete(Product product)
        {
            var productToDelete = await _context.Products.FindAsync(product.Id);
            if (productToDelete != null)
            {
                _context.Products.Remove(productToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
