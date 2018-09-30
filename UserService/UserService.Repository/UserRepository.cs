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

        public IQueryable<User> Get()
        {
            return _context.Users.Select(q => q);
        }
    }
}
