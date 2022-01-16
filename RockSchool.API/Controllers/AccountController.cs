using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RockSchool.API.Entities;
using RockSchool.API.Models;

namespace RockSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : MyBaseController
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountController(RockSchoolContext rockSchoolContext, IMapper mapper, IPasswordHasher<User> passwordHasher)
            : base (rockSchoolContext, mapper)
        {
            _passwordHasher = passwordHasher;
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody] RegisterUserDto registerUserDto)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Incorrect model for registration.");
            }

            var newUser = new User()
            {
                Login = registerUserDto.Login,
                RoleId = registerUserDto.RoleId,  
            };

            var passwordHash = _passwordHasher.HashPassword(newUser, registerUserDto.Password);
            newUser.PasswordHash = passwordHash;

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return Ok();
        }

    }
}
