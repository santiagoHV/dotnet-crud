using api_crud_net.Application.Services.Interfaces;
using api_crud_net.Domain.Entities;
using api_crud_net.Domain.Repositories;

namespace api_crud_net.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _productRepository.GetAll();
            return products;
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _productRepository.GetById(id);
            return product;
        }
        public async Task Add(Product product)
        {
            await _productRepository.Add(product);
        }

        public async Task Update(Product product)
        {
            await _productRepository.Update(product);
        }

        public async Task Delete(Product product)
        {
            await _productRepository.Delete(product);
        }
    }
}
