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

        public User Add(User user)
        {
            _repo.Add(user);
            _repo.SaveChanges();

            return user;
        }

        public IEnumerable<User> Get()
        {
            return _repo.Get().ToArray();
        }

        public User Get(int id)
        {
            return _repo.Get(id).FirstOrDefault();
        }

        public void Update(User user)
        {
            _repo.Update(user);
            _repo.SaveChanges();
        }

        public void Delete(User user)
        {
            _repo.Delete(user);
            _repo.SaveChanges();
        }
    }
}
