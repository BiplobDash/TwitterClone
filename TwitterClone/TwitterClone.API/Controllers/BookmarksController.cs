using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookmarksController : ControllerBase
    {
        BookmarksController() { }

        // /api/bookmarks
        [HttpGet]
        public IActionResult GetAllBookmarks()
        {
            return Ok(new
            {
                BookmarkId = Guid.NewGuid(),
            });
        }

        // /api/{id}
        [HttpPost("{id}")]
        public IActionResult CreateBookmark([FromRoute] Guid id)
        {
            return Ok(new
            {
                BookmarkId = id,
                Message = "Create Successfully",
            });
        }


        // /api/users/{userId}
        [HttpGet("users/{userId}")]
        public IActionResult GetBookmarksByUserId([FromRoute] Guid userId)
        {
            return Ok(new
            {
                UserId = userId,
            });
        }


        // /api/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBookmark([FromRoute] Guid id) { 
            return Ok(new
            {
                BookmarkId = id,
                Message = "Deleted Successfully",
            });
        }
    }
}
