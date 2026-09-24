using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // /api/users
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

        // /api/users
        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser()
        {
            return Ok(new { 
                UserId = Guid.NewGuid(),
                UserName = "Test",
            });
        }


        // /api/users/{id}
        [HttpGet("{userId}")]
        public IActionResult GetUserById([FromRoute] Guid userId){
            return Ok(new
            {
                UserId = userId,
                UserName = "Test" + userId.ToString(),
            });
        }


        //PUT /api/users/{id}
        [HttpPut("{userId}")]
        public IActionResult UpdateUser([FromRoute] Guid userId)
        {
            return Ok(new
            {
                UserId = userId,
                UserName = "Test" + userId.ToString(),
            });
        }


        // I want to update only user phone number
        // PATCH /api/users/{id}/phoneNumber
        [HttpPatch("{userId}/phoneNumber")]
        public IActionResult UpdatePhone([FromRoute] Guid userId, [FromBody] string phoneNumber)
        {
            return Ok(new
            {
                UserId = userId,
                PhoneNumber = phoneNumber,
            });
        }


        [HttpDelete("{userId}")]
        public IActionResult DeleteUser([FromRoute] Guid userId) { 
            return Ok(new
            {
                UserId = userId,
                Message = "User Deleted Successfully",
            });
        }
    }
}
