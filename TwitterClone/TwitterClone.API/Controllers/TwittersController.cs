using Microsoft.AspNetCore.Mvc;
using TwitterClone.API.Data;
using TwitterClone.API.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitterController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly TweetRepository _tweetRepository;

        public TwitterController(IConfiguration configuration, 
            TweetRepository tweetRepository) {
            _configuration = configuration;
            _tweetRepository = tweetRepository;
        }

        // GET: /api/Tweets
        [HttpGet]
        public IActionResult GetTweets()
        {
            var tweets = _tweetRepository.GetTweets();

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
            var tweet = _tweetRepository.GetTweetById(id);

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
            if (string.IsNullOrWhiteSpace(tweet.Content))
            {
                return BadRequest("Tweet can't be empty!");
            }

            var newTweet = new Tweet(
               
                tweet.Content
             );

            _tweetRepository.AddTweet(newTweet);

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
        public IActionResult UpdateTweet(
            [FromRoute] Guid id,
            [FromBody] UpdateTweetDto content)
        {
            if (string.IsNullOrWhiteSpace(content.Content))
            {
                return BadRequest("Tweet can't be empty!");
            }

            var tweet = _tweetRepository.GetTweetById(id);

            if (tweet == null)
            {
                return NotFound();
            }

            tweet.Content = content.Content;

            _tweetRepository.UpdateTweet(tweet);

            var tweetDto = new TweetDto
            {
                Id = tweet.Id,
                UserId = tweet.UserId,
                Content = tweet.Content
            };

            return Ok(tweetDto);
        }

        // DELETE: /api/Tweets/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTweet([FromRoute] Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);

            if (tweet == null)
            {
                return NotFound();
            }

            _tweetRepository.DeleteTweet(tweet);

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
