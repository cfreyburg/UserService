using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserService.Domain.Entities;

namespace UserService.Domain.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> Get();
        void Add(User user);
        IQueryable<User> Get(int id);
        void Delete(User user);
        void Update(User user);
    }
}
