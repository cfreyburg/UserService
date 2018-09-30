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
    }
}
