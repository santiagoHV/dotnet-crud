using api_crud_net.Domain.Entities;

namespace api_crud_net.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(Product product);
    }
}
