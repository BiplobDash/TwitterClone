using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = new List<User>
            {
                new User(
                    Guid.NewGuid(),
                    "harry_potter@gmail.com",
                    "Harry Potter",
                    "Harry",
                    DateTime.UtcNow,
                    Guid.NewGuid()
                ),
                new User(
                    Guid.NewGuid(),
                    "percy_jackson@gmail.com",
                    "Percy Jackson",
                    "Percy",
                    DateTime.UtcNow,
                    Guid.NewGuid()
                ),
                new User(
                    Guid.NewGuid(),
                    "frodo_baggins@gmail.com",
                    "Frodo Baggins",
                    "Frodo",
                    DateTime.UtcNow,
                    Guid.NewGuid()
                ),
            };

            return Ok(users);
        }
    }
}
