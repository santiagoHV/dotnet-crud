using api_crud_net.Domain.Entities;
using api_crud_net.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api_crud_net.Infrastructure.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var orders = await _context.Orders.ToListAsync();
            if (orders == null)
            {
                return Enumerable.Empty<Order>();
            }
            return orders;
        }

        public async Task<Order> GetById(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                   return null;
            }
            return order;
        }
        public async Task Add(Order order)
        {
            var orderToAdd = new Order
            {
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                UnitPrice = order.UnitPrice,
                Subtotal = order.Subtotal,
                Iva = order.Iva,
                Total = order.Total,
                UserId = order.UserId
            };
            _context.Orders.Add(orderToAdd);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Order order)
        {
            var orderToDelete = await _context.Orders.FindAsync(order.Id);
            if (orderToDelete != null)
            {
                _context.Orders.Remove(orderToDelete);
                await _context.SaveChangesAsync();
            }
        }


        public async Task Update(Order order)
        {
            var orderToUpdate = await _context.Orders.FindAsync(order.Id);
            if (orderToUpdate != null)
            {
                orderToUpdate.ProductId = order.ProductId;
                orderToUpdate.Quantity = order.Quantity;
                orderToUpdate.UnitPrice = order.UnitPrice;
                orderToUpdate.Subtotal = order.Subtotal;
                orderToUpdate.Iva = order.Iva;
                orderToUpdate.Total = order.Total;
                orderToUpdate.UserId = order.UserId;
                await _context.SaveChangesAsync();
            }
        }
    }
}
