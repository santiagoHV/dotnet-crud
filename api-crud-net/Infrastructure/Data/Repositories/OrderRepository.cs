using api_crud_net.Domain.Entities;
using api_crud_net.Domain.Repositories;

namespace api_crud_net.Infrastructure.Data.Repositories
{
    public class OrderRepository : IOrderRepository
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
