using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessagesController : ControllerBase
    {

        // /api/messages
        [HttpGet]
        public IActionResult GetAllMessages()
        {
            return Ok(new
            {
                MessageId = Guid.NewGuid(),
            });
        }

        [HttpGet("users/{userId}")]
        public IActionResult GetMessageById([FromRoute] Guid userId)
        {
            return Ok(new
            {
                UserId = userId,
            });
        }

        [HttpGet("sender/{senderId}")]
        public IActionResult GetMessagesBySender([FromRoute]Guid senderId)
        {
            return Ok(new
            {
                SenderId = senderId,
                SenderMessage = "",
            });
        }

        [HttpGet("receiver/{receiverId}")]
        public IActionResult GetMessagesByReceiver([FromRoute]Guid receiverId)
        {
            return Ok(new
            {
                ReceiverId = receiverId,
                ReceiverMessage = "",
            });
        }

        [HttpPost("{userId}/message")]
        public IActionResult SendMessage([FromRoute] Guid userId, [FromBody] string message)
        {
            return Ok(new
            {
                UserId = userId,
                UserMessage = message,
            });
        }

   

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage([FromRoute]Guid id)
        {

            return Ok(new
            {
                MessageId = id,
            });
        }
    }
}