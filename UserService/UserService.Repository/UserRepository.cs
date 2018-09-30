using System.Linq;
using UserService.Domain.DTO;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public User Add(User user)
        {
            _context.Add(user);
            return user;
        }

        public void Delete(User user)
        {
            _context.Remove(user);
        }

        public IQueryable<UserDTO> Get()
        {
            return _context.Users.Select(UserMapper.ToDTO);
        }

        public IQueryable<UserDTO> Get(int id)
        {
            return _context.Users
                .Where(q => q.Id == id)
                .Select(UserMapper.ToDTO);
        }

        public IQueryable<User> Get(string email)
        {
            return _context.Users
                .Where(q => q.Email == email)
                .Select(q => q);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Update(user);
        }
    }
}
