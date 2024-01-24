using api_crud_net.Domain.Entities;

namespace api_crud_net.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task Add(User user);
        Task Update(User user);
        Task Delete(User user);
    }
}
