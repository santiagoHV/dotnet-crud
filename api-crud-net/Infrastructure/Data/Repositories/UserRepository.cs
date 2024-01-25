using api_crud_net.Domain.Entities;
using api_crud_net.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api_crud_net.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _context.Users.ToListAsync();

            if (users == null)
            {
                return Enumerable.Empty<User>();
            }

            return users;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task Add(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            var userToDelete = await _context.Users.FindAsync(user.Id);
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
