using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Domain.Interfaces
{
    public interface IHashHelper
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
    }
}
