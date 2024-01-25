using api_crud_net.Application.Services.Interfaces;
using api_crud_net.Domain.Entities;
using api_crud_net.Domain.Repositories;

namespace api_crud_net.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return users;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _userRepository.GetById(id);
            return user;
        }

        public async Task Add(User userDto)
        {
            await _userRepository.Add(userDto);
        }

        public async Task Delete(User user)
        {
            await _userRepository.Delete(user);
        }

        public async Task Update(User user)
        {
            await _userRepository.Update(user);
        }
    }
}
