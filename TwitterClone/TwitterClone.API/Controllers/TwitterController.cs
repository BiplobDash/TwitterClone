using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitterController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TwitterController(IConfiguration configuration) {
            _configuration = configuration;
        }

        public void GetTweet()
        {
            var connectionString = _configuration.GetValue<string>("Logging:LogLevel:Default");
        }

        [HttpGet]
        public IActionResult GetTweets() {
            var tweets = new List<Tweet>{
                new Tweet("My First Tweet"){
                    UserId = Guid.NewGuid(),
                    Content = "Hello World",
                },
                new Tweet("My Second Tweet"){
                    UserId = Guid.NewGuid(),
                    Content = "This is my second tweet",
                }
            };

            return Ok(tweets);
        }

    }
}
