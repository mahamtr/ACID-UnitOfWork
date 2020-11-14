using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using backend.Core.Common;
using backend.Core.Entities;
using backend.Infrastructure.Data;
using CleanArchitecture.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SQLitePCL;

namespace backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IConfiguration _config;
        

        public AuthenticationController(IUnitOfWork unitOfWork, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _config = config;
        }
       
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]

        public IActionResult Login([FromBody]UserRequestInfo login)
        {
            IActionResult response = Unauthorized("Incorrect username or password");
            var user = _unitOfWork.Users.GetFiltered(i => i.UserName == login.UserName.Trim()).FirstOrDefault();
            if (user == null) return response;
            if (user.AuthenticateUser(login.PassWord))
            {
                var tokenString = GenerateJSONWebToken(login);
                response = Ok(new { token = tokenString });
            }
            
            return response;
        }
        
        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody]UserRequestInfo login)
        {
            IActionResult response = BadRequest("Username is taken");
            var user = _unitOfWork.Users.GetFiltered(i => i.UserName == login.UserName.Trim()).FirstOrDefault();
            if (user != null) return response;
            var account = new Account()
            {
                Id = new Guid(),
                Balance = 0
            };
            _unitOfWork.Accounts.Add(account);
            _unitOfWork.Users.Add(new User()
            {
                Id = new Guid(),
                UserName = login.UserName,
                Password =  PasswordHasher.HashPassword(login.PassWord),
                AccountId = account.Id
            });
            _unitOfWork.Commit();
            var tokenString = GenerateJSONWebToken(login);
            return Ok(new { token = tokenString });
        }
        
        private string GenerateJSONWebToken(UserRequestInfo userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(credentials);
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var payload = new JwtPayload(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(60)
            ) ;

            var token = new JwtSecurityToken(
                header,
                payload
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
