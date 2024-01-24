using api_crud_net.Application.Services.Interfaces;
using api_crud_net.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_crud_net.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _service.GetAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _service.GetById(id);
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Order order)
        {
            await _service.Add(order);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Order order)
        {
            await _service.Update(order);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Order order)
        {
            await _service.Delete(order);
            return Ok();
        }

    }
}
