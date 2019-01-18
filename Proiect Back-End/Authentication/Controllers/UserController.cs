﻿using System;

namespace Authentication.Controllers
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    using BusinessLogic.Authentication.Abstractions;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;

    using Models.Authentication;

    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/users")]
    public class UserController : ControllerBase
    {
        private readonly AppSettings _appSettings;

        private readonly IUserLogic _userLogic;

        public UserController(IUserLogic userLogic, IOptions<AppSettings> appSettings)
        {
            _userLogic = userLogic;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserAuthenticationDto userDto)
        {
            var user = _userLogic.Authenticate(userDto.Username, userDto.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
                                      {
                                          Subject = new ClaimsIdentity(new Claim[]
                                                                           {
                                                                               new Claim(ClaimTypes.Name, user.Id.ToString())
                                                                           }),
                                          Expires = DateTime.UtcNow.AddDays(7),
                                          SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                                      };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new
                          {
                              user.Id,
                              user.Username,
                              user.FirstName,
                              user.LastName,
                              user.Email,
                              Token = tokenString
                          });

        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

             var user = _userLogic.Create(userDto, userDto.Password);

            var userInformationDto = new UserInformationsDto
                                         {
                                             Email = user.Email,
                                             FirstName = user.FirstName,
                                             LastName = user.LastName,
                                             Username = user.Username
                                         };

             return Ok(userInformationDto);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userLogic.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _userLogic.GetById(id);
            return Ok(user);
        }
    }
}
