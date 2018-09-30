using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserService.Domain.DTO;
using UserService.Domain.Entities;

namespace UserService.Domain.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<UserDTO> Get();
        User Add(User user);
        IQueryable<UserDTO> Get(int id);
        void Delete(User user);
        void Update(User user);
        void SaveChanges();
        IQueryable<User> Get(string email);
    }
}
