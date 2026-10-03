using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FollowsController : ControllerBase
    {
        FollowsController() { }

        // /api/followers
        [HttpGet]
        public IActionResult GetAllFollowers() {
            return Ok(new
            {
                FollowId = Guid.NewGuid(),
            });
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteFollowers([FromRoute] Guid id)
        {
            return Ok(new
            {
                FollowId = id,
                Message = "Deletd Successfully",
            });
        }


        [HttpPost]
        public IActionResult CreateFollower()
        {
            return Ok();
        }

        [HttpGet("following/{userId}")]
        public IActionResult GetFollowing(int userId)
        {
            return Ok();
        }
    }
}
