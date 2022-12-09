using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.DataAccess;
using OrderManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDBContext _dBContext;

        public LoginController(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin login)
        {
            var user = Authenticate(login);
            if (user!= null)
            {
                var token = Generate(user);
                return Ok(token);
            }
            return NotFound("user Not found");
        }

        private string Generate(UserLogin user)
        {
            throw new NotImplementedException();
        }

        private UserLogin Authenticate(UserLogin userLogin)
        {
            throw new NotImplementedException();
        }
    }
}
