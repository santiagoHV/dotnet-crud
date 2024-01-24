using api_crud_net.Application.Services.Interfaces;
using api_crud_net.Domain.Entities;

namespace api_crud_net.Application.Services
{
    public class ProductService : IProductService
    {
        public Task Add(Product product)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
