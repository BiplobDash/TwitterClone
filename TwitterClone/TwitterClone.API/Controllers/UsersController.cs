using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TwitterClone.API.Data;
using TwitterClone.API.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        // /api/users
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetUsers()
        {

            return Ok(_userService.GetUsers());

        }

        // /api/users
        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser([FromBody] CreateUserDto createUserDto)
        {

            var createdUser = _userService.CreateUser(createUserDto);

            if (createdUser == null) {
                return BadRequest("A error happen during create user.");
            }

            return Ok(createdUser);
        }


        // /api/users/{id}
        [HttpGet("{userId}")]
        public IActionResult GetUserById([FromRoute] Guid userId){

            var user = _userService.GetUserById(userId);
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
            var user = _userService.UpdateUser(userId, updateUserDto);
            if (user == null)
            {
                return NotFound();
            }

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

            var isDeleted = _userService.DeleteUser(userId);
            if (isDeleted == false)
            {
                return NotFound();
            }

            return Ok(isDeleted);
        }
    }
}
