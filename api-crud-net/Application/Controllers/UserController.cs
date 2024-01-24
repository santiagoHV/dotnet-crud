using api_crud_net.Application.Services.Interfaces;
using api_crud_net.Domain.Entities;
using api_crud_net.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_crud_net.Application.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, DataContext context)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            await _userService.Add(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id)
        {
            var user = await _userService.GetById(id);

            if (user == null)
                return NotFound();

            await _userService.Update(user);

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetById(id);

            if (user == null)
                return NotFound();

            await _userService.Delete(user);

            return NoContent();
        }   
    }
}
