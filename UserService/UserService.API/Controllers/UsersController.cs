using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UserService.API.Helpers;
using UserService.Domain.DTO;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserLogic _logic;
        private readonly AppSettings _appSettings;

        public UsersController(IUserLogic logic, IOptions<AppSettings> appSettings)
        {
            _logic = logic;
            _appSettings = appSettings.Value;
        }
        // GET api/Users
        [HttpGet]
        public IEnumerable<UserDTO> Get()
        {
            return _logic.Get();
        }

        // GET api/Users/5
        [HttpGet("{id}")]
        public UserDTO Get(int id)
        {
            return _logic.Get(id);
        }

        // POST api/Users
        [AllowAnonymous]
        [HttpPost]
        public User Post(User user)
        {
            return _logic.Add(user);
        }

        // PUT api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, User user)
        {
            user.Id = id;
            _logic.Update(user);
        }

        // DELETE api/Users
        [HttpDelete]
        public void Delete(User user)
        {
            _logic.Delete(user);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(User user)
        {
            var entity = _logic.Authenticate(user.Email, user.Password);

            if (entity == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, entity.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = entity.Id,
                Username = entity.Email,
                Name = entity.Name,
                Token = tokenString
            });
        }
    }
}
