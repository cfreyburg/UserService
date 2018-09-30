using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.Logic.Test
{
    [TestClass]
    public class UserLogicTest
    {
        private readonly Mock<IUserRepository> _repo;
        private readonly IUserLogic _logic;
        public UserLogicTest()
        {
            _repo = new Mock<IUserRepository>();
            _logic = new UserLogic(_repo.Object);
        }


        [TestMethod]
        public void logic_should_return_all_users()
        {
            var expected = new List<User>();
            _repo.Setup(q => q.Get()).Returns(expected.AsQueryable());

            var actual =_logic.Get();

            CollectionAssert.AreEquivalent(expected, actual.ToList());
        }

        [TestMethod]
        public void logic_should_return_a_user()
        {
            var id = 1;
            var user = new User { Id = 1, Name = "test"};
            var list = new List<User> { user };
            _repo.Setup(q => q.Get(id)).Returns(list.AsQueryable());

            var actual = _logic.Get(id);

            Assert.AreSame(user, actual);
        }

        [TestMethod]
        public void logic_should_add_a_user()
        {
            var user = new User { Name = "test" };
            _repo.Setup(q => q.Add(user)).Returns(user);

            var actual = _logic.Add(user);

            Assert.AreEqual(user, actual);
        }

        [TestMethod]
        public void logic_should_update_a_user()
        {
            var user = new User { Name = "test" };
            
            _logic.Update(user);

            _repo.Verify(q => q.Update(user), Times.Once);
            _repo.Verify(q => q.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void logic_should_delete_a_user()
        {
            var user = new User { Name = "test" };

            _logic.Delete(user);

            _repo.Verify(q => q.Delete(user), Times.Once);
            _repo.Verify(q => q.SaveChanges(), Times.Once);
        }
    }
}
