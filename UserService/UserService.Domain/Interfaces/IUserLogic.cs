using System;
using System.Collections.Generic;
using System.Text;
using UserService.Domain.DTO;
using UserService.Domain.Entities;

namespace UserService.Domain.Interfaces
{
    public interface IUserLogic
    {
        IEnumerable<UserDTO> Get();
        UserDTO Get(int id);
        User Add(User user);
        void Update(User user);
        void Delete(User user);
        User Authenticate(string username, string password);
    }
}
