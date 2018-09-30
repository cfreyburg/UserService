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

        [TestMethod]
        public void repo_should_return_one_user()
        {
            var id = 1;
            var actual = _repo.Get(id);

            Assert.AreEqual(actual.Count(), 1);
            Assert.AreEqual(actual.First().Id, 1);
            Assert.AreEqual(actual.First().Name, "test");
        }

        [TestMethod]
        public void repo_should_add_users()
        {
            var user = new User { Name = "test3" };
            _repo.Add(user);
            _context.SaveChanges();

            Assert.AreEqual(_context.Users.Count(), 3);
        }

        [TestMethod]
        public void repo_should_delete_user()
        {
            var user = _context.Users.Where(q => q.Id == 2).First();
            _repo.Delete(user);
            _context.SaveChanges();

            var expected = _context.Users.Where(q => q.Id == 2).FirstOrDefault();

            Assert.AreEqual(expected, null);
        }

        [TestMethod]
        public void repo_should_update_user()
        {
            var expected = "test1";
            var user = _context.Users.Where(q => q.Id == 1).First();
            user.Name = expected;
            _repo.Update(user);
            _context.SaveChanges();

            var actual = _context.Users.Where(q => q.Id == 1).First();

            Assert.AreEqual(actual.Name, expected);
        }
    }
}
