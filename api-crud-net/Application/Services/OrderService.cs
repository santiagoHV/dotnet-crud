using api_crud_net.Application.Services.Interfaces;
using api_crud_net.Domain.Entities;

namespace api_crud_net.Application.Services
{
    public class OrderService : IOrderService
    {
        public Task Add(Order order)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
