using System;
using System.Collections.Generic;
using System.Linq;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _repo;
        public UserLogic(IUserRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<User> Get()
        {
            return _repo.Get().ToArray();
        }
    }
}
