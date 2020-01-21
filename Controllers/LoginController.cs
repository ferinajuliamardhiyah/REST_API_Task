using System.Net;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using REST_API_Task.Models;
using REST_API_Task.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace REST_API_Task.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {
        
        private TaskDbContext _context;
        public LoginController(TaskDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        // public LoginAuth AddLoginAuth(LoginAuth loginAuth)
        // {
        //     _context.LoginAuths.Add(loginAuth);
        //     _context.SaveChanges();
        //     return loginAuth;
        // }
        public IActionResult Authenticate(LoginAuth loginAuth)
        {
            var _login = _context.LoginAuths.SingleOrDefault(e => e.username==loginAuth.username && e.password==loginAuth.password);
            if(_login == null)
            {
                 return BadRequest(new { message = "Username or password is incorrect" });
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, _login.username),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("miname potatona banana")), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var loginNew = new {
                    id = _login.id,
                    username = _login.username,
                    token = tokenHandler.WriteToken(token)
                };
            
            return Ok(loginNew);
        }
    }
}