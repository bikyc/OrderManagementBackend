using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OrderManagement.DTO;
using OrderManagement.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private string generatedToken = null;

        public LoginController(IConfiguration config, ITokenService tokenService, IUserRepository userRepository)
        {
            _config = config;
            _tokenService = tokenService;
            _userRepository = userRepository;
        }


        [Route("login")]
        [HttpPost]
        public IActionResult Login(Users userModel)
        {
            if (string.IsNullOrEmpty(userModel.username) || string.IsNullOrEmpty(userModel.password))
            {
                return (RedirectToAction("Error"));
            }
            IActionResult response = Unauthorized();
            var validUser = GetUser(userModel);

            if (validUser != null)
            {
                generatedToken = _tokenService.BuildToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), validUser);
                if (generatedToken != null)
                {
                    var result = new
                    {
                        token = generatedToken
                    };
                    return Ok(result);
                }
            }
            return Ok("please provide valid credentials");
        }

        private UserDTO GetUser(Users userModel)
        {
            // Write your code here to authenticate the user     
            return _userRepository.GetUser(userModel);
        }
    }

    public interface ITokenService
    {
        string BuildToken(string v1, string v2, UserDTO validUser);
        bool IsTokenValid(string v1, string v2, string token);
    }

    public interface IUserRepository
    {
        UserDTO GetUser(Users user);
    }

    public class TokenService : ITokenService
    {
        private const double EXPIRY_DURATION_MINUTES = 30;

        public string BuildToken(string key, string issuer, UserDTO user)
        {
            var claims = new[] {
            new Claim(ClaimTypes.Name, user.username),
            new Claim(ClaimTypes.Email, user.email),
            new Claim(ClaimTypes.NameIdentifier,
            Guid.NewGuid().ToString())
        };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
                expires: DateTime.Now.AddMinutes(EXPIRY_DURATION_MINUTES), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
        public bool IsTokenValid(string key, string issuer, string token)
        {
            var mySecret = Encoding.UTF8.GetBytes(key);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = issuer,
                    ValidAudience = issuer,
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }

    public class UserRepository : IUserRepository
    {
        private readonly List<UserDTO> users = new List<UserDTO>();

        public UserRepository()
        {


            users.Add(new UserDTO
            {
                username = "user",
                password = "user",
                email = "user@user.com",
                Role = "user"
            });
            users.Add(new UserDTO
            {
                username = "admin",
                password = "admin",
                email = "admin@superadmin.com",
                Role = "admin"
            });
        }
        public UserDTO GetUser(Users userModel)
        {
            return users.Where(x => x.username.ToLower() == userModel.username.ToLower()
                 && x.password == userModel.password).FirstOrDefault();
        }
    }


}

