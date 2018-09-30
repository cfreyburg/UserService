using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using UserService.Domain.DTO;
using UserService.Domain.Entities;

namespace UserService.Repository
{
    public static class UserMapper
    {
        public static Expression<Func<User, UserDTO>> ToDTO = (entity) =>
            new UserDTO
            {
                Email = entity.Email,
                Id = entity.Id,
                Name = entity.Name
            };
    }
}
