using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserLogic _logic;

        public UsersController(IUserLogic logic)
        {
            _logic = logic;
        }
        // GET api/Users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _logic.Get();
        }

        // GET api/Users/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _logic.Get(id);
        }

        // POST api/Users
        [HttpPost]
        public User Post(User user)
        {
            return _logic.Add(user);
        }

        // PUT api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, User user)
        {
            user.Id = id;
            _logic.Update(user);
        }

        // DELETE api/Users/5
        [HttpDelete]
        public void Delete(User user)
        {
            _logic.Delete(user);
        }
    }
}
