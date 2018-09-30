using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using UserService.API.Controllers;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.API.Test
{
    [TestClass]
    public class UsersControllerTest
    {
        private readonly Mock<IUserLogic> _logic;
        private readonly UsersController _controller;

        public UsersControllerTest()
        {
            _logic = new Mock<IUserLogic>();
            _controller = new UsersController(_logic.Object);
        }

        [TestMethod]
        public void controller_should_bring_all_users()
        {
            var expected = new List<User>();
            _logic.Setup(q => q.Get()).Returns(expected);

            var actual = _controller.Get();

            Assert.AreEqual(actual, expected);
        }
    }
}
