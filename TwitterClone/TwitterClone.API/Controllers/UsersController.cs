using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TwitterClone.API.Data;
using TwitterClone.API.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {

        private readonly UserRepository _userRepository;
        public UsersController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        // /api/users
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetUsers()
        {
            
            var users = _userRepository.GetUsers();

            return Ok(users);

        }

        // /api/users
        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser([FromBody] CreateUserDto createUserDto)
        {
            if (string.IsNullOrWhiteSpace(createUserDto.FirstName) ||
                string.IsNullOrWhiteSpace(createUserDto.LastName) ||
                string.IsNullOrWhiteSpace(createUserDto.Email)) {
                return BadRequest("All fields are required.");
            }

            var existingUser = _userRepository.GetUserByEmail(createUserDto.Email);
            if (existingUser == null) { 
                return BadRequest("A user with this email already exists");
            }

            var createdUser = _userRepository.AddUser(new User()
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email,
            });

            return Ok(createdUser);
        }


        // /api/users/{id}
        [HttpGet("{userId}")]
        public IActionResult GetUserById([FromRoute] Guid userId){
            var user = _userRepository.GetUserById(userId);
            if (user == null) { 
                return NotFound();
            }
            return Ok(user);
        }


        //PUT /api/users/{id}
        [HttpPut("{userId}")]
        public IActionResult UpdateUser([FromRoute] Guid userId, 
            [FromBody] UpdateUserDto updateUserDto)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;

            _userRepository.UpdateUser(user);

            return Ok(user);
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


        // /api/users/{id}
        [HttpDelete("{userId}")]
        public IActionResult DeleteUser([FromRoute] Guid userId) {

            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }

            var isDeleted = _userRepository.DeleteUser(user);

            return Ok(isDeleted);
        }
    }
}
