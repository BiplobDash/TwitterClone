using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Data
{
    public class TweetRepository
    {
        private readonly List<Tweet> _tweets = new List<Tweet>();

        public List<Tweet> GetTweets()
        {
            return _tweets;
        }

        public List<Tweet> GetTweetsByUserId(Guid userId)
        {
            return _tweets.Where(u => u.UserId == userId).ToList();
        }

        public Tweet? GetTweetById(Guid id)
        {
            return _tweets.SingleOrDefault(u => u.Id == id);
        }

        public void AddTweet(Tweet tweet)
        {
            _tweets.Add(tweet);
            //return tweet;
        }

        public void UpdateTweet(Tweet tweet) // fully
        {
            _tweets.RemoveAll(u => u.Id == tweet.Id);
            _tweets.Add(tweet);
            //return tweet;
        }

        public bool DeleteTweet(Tweet tweet)
        {
            return _tweets.Remove(tweet);
        }
    }
}
