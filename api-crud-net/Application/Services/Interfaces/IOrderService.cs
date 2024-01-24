using api_crud_net.Domain.Entities;

namespace api_crud_net.Application.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetById(int id);
        Task Add(Order order);
        Task Update(Order order);
        Task Delete(Order order);
    }
}
