using System;
using System.Collections.Generic;
using System.Text;
using UserService.Domain.Entities;

namespace UserService.Domain.Interfaces
{
    public interface IUserLogic
    {
        User Get();
    }
}
