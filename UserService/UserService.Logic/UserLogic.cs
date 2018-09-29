using System;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.Logic
{
    public class UserLogic : IUserLogic
    {
        public UserLogic()
        {

        }

        public User Get()
        {
            return new User();
        }
    }
}
