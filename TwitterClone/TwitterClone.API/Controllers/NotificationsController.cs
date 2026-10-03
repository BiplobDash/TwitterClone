using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        NotificationsController() { }


        // /api/notifications
        [HttpGet]
        public IActionResult GetAllNotifications() { 
            return Ok(new
            {
                NotificationId = Guid.NewGuid(),
                Message = "Notification",
            });
        }

        // /api/{id}
        [HttpGet("{id}")]
        public IActionResult GetNotificationsById([FromRoute] Guid id) { 
            return Ok(new
            {
                NotificationsId = id,
            });
        }

        // /api/{userId}
        [HttpGet("users/{userId}")]
        public IActionResult GetUserNotificationsId([FromRoute] Guid userId)
        {
            return Ok(new
            {
                UserId = userId,
            });
        }


        // /api/{id}/read
        [HttpPut("{id}/read")]
        public IActionResult MarkAsRead([FromRoute] Guid id) {
            return Ok(new
            {
                ReadId = id,
                Message = "Notification marked as read.",
            });
        }
    }
}
