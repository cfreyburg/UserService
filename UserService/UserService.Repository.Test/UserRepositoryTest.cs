using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TestSupport.EfHelpers;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.Repository.Test
{
    [TestClass]
    public class UserRepositoryTest
    {
        private readonly IUserRepository _repo;
        private readonly UserContext _context;
        public UserRepositoryTest()
        {
            var options = SqliteInMemory.CreateOptions<UserContext>();
            _context = new UserContext(options);
            
            _context.Database.EnsureCreated();
            _repo = new UserRepository(_context);

            _context.Add(new User { Id = 1, Name = "test" });
            _context.Add(new User { Id = 2, Name = "test2" });
            _context.SaveChanges();
        }

        [TestMethod]
        public void repo_should_return_all_users()
        {
            var actual = _repo.Get();
            
            Assert.AreEqual(actual.Count(), 2);
        }
    }
}
