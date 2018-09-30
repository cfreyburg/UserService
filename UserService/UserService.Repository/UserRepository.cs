using System.Linq;
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

        public IQueryable<User> Get()
        {
            return _context.Users.Select(q => q);
        }

        public IQueryable<User> Get(int id)
        {
            return _context.Users
                .Where(q => q.Id == id)
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
