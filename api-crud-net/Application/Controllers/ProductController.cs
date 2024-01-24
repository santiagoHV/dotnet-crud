using api_crud_net.Application.Services.Interfaces;
using api_crud_net.Domain.Entities;
using api_crud_net.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_crud_net.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            await _productService.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id)
        {
            var product = await _productService.GetById(id);

            if (product == null)
                return NotFound();

            await _productService.Update(product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetById(id);

            if (product == null)
                return NotFound();

            await _productService.Delete(product);

            return NoContent();
        }

    }
}
