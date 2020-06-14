using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace chatapp.web.server.Controllers
{
    public class AuthorizeTokenAttribute : AuthorizeAttribute
    {
        public AuthorizeTokenAttribute()
        {
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
        }
    }


    /// <summary>
    /// Manages the Web API calls
    /// </summary>
    public class ApiController : Controller
    {
        public IConfiguration Configuration { get; }

        public ApiController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [Route("api/login")]
        public IActionResult LogIn()
        {
            // TODO: get users login information and check it is correct

            var username = "youngmin";
            var email = "sym1945@gmail.com";

            // Set our tokens claims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(ClaimsIdentity.DefaultNameClaimType, username),
                new Claim("my key", "my value"),
            };

            // Create the credentials used to generate the token
            var credentials = new SigningCredentials(
                 new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"])),
                 SecurityAlgorithms.HmacSha256);

            // Generate the Jwt Token
            var token = new JwtSecurityToken(
                issuer: Configuration["Jwt:Issuer"],
                audience: Configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMonths(3),
                signingCredentials: credentials
                );

            // Return token to user
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }


        [AuthorizeToken]
        [Route("api/private")]
        public IActionResult Private()
        {
            var user = HttpContext.User;

            return Ok(new { privateData = $"Some secret for {user.Identity.Name}" });
        }
    }
}