using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using UserService.API.Controllers;
using UserService.API.Helpers;
using UserService.Domain.DTO;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.API.Test
{
    [TestClass]
    public class UsersControllerTest
    {
        private readonly Mock<IUserLogic> _logic;
        private readonly Mock<IOptions<AppSettings>> _helper;
        private readonly UsersController _controller;

        public UsersControllerTest()
        {
            _logic = new Mock<IUserLogic>();
            _helper = new Mock<IOptions<AppSettings>>();
            _controller = new UsersController(_logic.Object, _helper.Object);
        }

        [TestMethod]
        public void controller_should_bring_all_users()
        {
            var expected = new List<UserDTO>();
            _logic.Setup(q => q.Get()).Returns(expected);

            var actual = _controller.Get();

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void controller_should_bring_a_user()
        {
            var id = 1;
            var expected = new UserDTO { Id = id, Name = "test" };
            _logic.Setup(q => q.Get(id)).Returns(expected);

            var actual = _controller.Get(id);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void controller_should_add_a_user()
        {
            var expected = new User {  Name = "test" };
            _logic.Setup(q => q.Add(expected)).Returns(expected);

            var actual = _controller.Post(expected);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void controller_should_update_a_user()
        {
            var id = 1;
            var expected = new User { Name = "test" };
            
            _controller.Put(id, expected);

            _logic.Verify(q => q.Update(expected), Times.Once);
        }

        [TestMethod]
        public void controller_should_delete_a_user()
        {
            var expected = new User { Id=1, Name = "test" };

            _controller.Delete(expected);

            _logic.Verify(q => q.Delete(expected), Times.Once);
        }
    }
}
