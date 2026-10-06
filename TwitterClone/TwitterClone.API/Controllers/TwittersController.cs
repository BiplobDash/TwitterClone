using Microsoft.AspNetCore.Mvc;
using TwitterClone.API.Data;
using TwitterClone.API.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Services;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitterController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITweetService _tweetService;

        public TwitterController(IConfiguration configuration, 
            ITweetService tweetService) {
            _configuration = configuration;
            _tweetService = tweetService;
        }

        // GET: /api/Tweets
        [HttpGet]
        public IActionResult GetTweets()
        {
            var tweets = _tweetService.GetTweets();

            var tweetsDto = tweets.Select(t => new TweetDto
            {
                Id = t.Id,
                UserId = t.UserId,
                Content = t.Content
            }).ToList();

            return Ok(tweetsDto);
        }

        // GET: /api/Tweets/{id}
        [HttpGet("{id}")]
        public IActionResult GetTweetById([FromRoute] Guid id)
        {
            var tweet = _tweetService.GetTweetById(id);

            if (tweet == null)
            {
                return NotFound();
            }

            var tweetDto = new TweetDto
            {
                Id = tweet.Id,
                UserId = tweet.UserId,
                Content = tweet.Content
            };

            return Ok(tweetDto);
        }

        // POST: /api/Tweets
        [HttpPost]
        public IActionResult CreateTweet([FromBody] CreateTweetDto tweet)
        {
            var newTweet = _tweetService.AddTweet(tweet);

            if (newTweet == null)
            {
                return BadRequest("Tweet can't be empty!");
            }

            var tweetDto = new TweetDto
            {
                Id = newTweet.Id,
                UserId = newTweet.UserId,
                Content = newTweet.Content
            };

            return Ok(tweetDto);

        }

        // PUT: /api/Tweets/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTweet( [FromRoute] Guid id, [FromBody] UpdateTweetDto dto)

        {
            var updatedTweet = _tweetService.UpdateTweet(id, dto);

            if (updatedTweet == null)
            {
                return BadRequest("Tweet not found or content is invalid.");
            }

            var tweetDto = new TweetDto
            {
                Id = updatedTweet.Id,
                UserId = updatedTweet.UserId,
                Content = updatedTweet.Content
            };

            return Ok(tweetDto);
        }

        // DELETE: /api/Tweets/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTweet([FromRoute] Guid id)
        {
            var deleted = _tweetService.DeleteTweet(id);

            if (!deleted)
            {
                return NotFound();
            }

            return Ok(new
            {
                Message = "Tweet deleted successfully!"
            });
        }

        // GET: /api/Tweets/AppName-check
        [HttpGet("AppName-check")]
        public IActionResult GetAppName()
        {
            var appName = _configuration.GetValue<string>("AppName");

            return Ok(appName);
        }

    }
}
