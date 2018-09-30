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
    }
}
