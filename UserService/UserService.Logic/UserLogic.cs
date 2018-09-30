using System;
using System.Collections.Generic;
using System.Linq;
using UserService.Domain.DTO;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _repo;
        private readonly IHashHelper _helper;
        public UserLogic(IUserRepository repo, IHashHelper helper)
        {
            _repo = repo;
            _helper = helper;
        }

        public User Add(User user)
        {

            byte[] passwordHash, passwordSalt;
            _helper.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;


            _repo.Add(user);
            _repo.SaveChanges();

            return user;
        }

        public IEnumerable<UserDTO> Get()
        {
            return _repo.Get().ToArray();
        }

        public User Get(string email)
        {
            return _repo.Get(email).FirstOrDefault();
        }

        public UserDTO Get(int id)
        {
            return _repo.Get(id).FirstOrDefault();
        }

        public void Update(User user)
        {

            byte[] passwordHash, passwordSalt;
            _helper.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _repo.Update(user);
            _repo.SaveChanges();
        }

        public void Delete(User user)
        {
            _repo.Delete(user);
            _repo.SaveChanges();
        }

        public User Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = Get(email);

            if (user == null)
                return null;

            if (!_helper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        
    }
}
