using api_crud_net.Application.Services.Interfaces;
using api_crud_net.Domain.Entities;
using api_crud_net.Domain.Repositories;

namespace api_crud_net.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var orders = await _orderRepository.GetAll();
            return orders;
        }

        public async Task<Order> GetById(int id)
        {
            var order = await _orderRepository.GetById(id);
            return order;
        }
        public async Task Add(Order order)
        {
            var product = await _productRepository.GetById(order.ProductId);
            var iva = 0.19m;
            order.UnitPrice = product.Price;
            order.Subtotal = order.Quantity * order.UnitPrice;
            order.Iva = order.Subtotal * iva;
            order.Total = order.Subtotal + order.Iva;

            var user = await _userRepository.GetById(order.UserId);
            order.User = user;

            await _orderRepository.Add(order);
        }

        public async Task Delete(Order order)
        {
            await _orderRepository.Delete(order);
        }


        public async Task Update(Order order)
        {
            await _orderRepository.Update(order);
        }
    }
}
