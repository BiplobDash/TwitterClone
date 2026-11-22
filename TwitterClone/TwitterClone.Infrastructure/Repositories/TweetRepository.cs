using Microsoft.EntityFrameworkCore;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistance;

namespace TwitterClone.Infrastructure.Repositories
{
    public class TweetRepository : ITweetRepository
    {

        private readonly TwitterCloneDbContext _context;

        public Tweet AddTweet(Tweet tweet)
        {
            _context.Tweets.Add(tweet);
            _context.SaveChanges();

            return tweet;
        }

        public Tweet UpdateTweet(Tweet tweet)
        {
            _context.Tweets.Update(tweet);
            _context.SaveChanges();
            return tweet;
        }

        public bool DeleteTweet(Tweet tweet)
        {
            var existingUser = _context.Tweets
                .SingleOrDefault(t => t.Id == tweet.Id);

            if (existingUser is null)
                return false;

            _context.Tweets.Remove(existingUser);
            _context.SaveChanges();

            return true;
        }

        public int DeleteTweetsByUserId(Guid userId)
        {

            return _context.Tweets
                .Where(t => t.UserId == userId)
                .ExecuteDelete();
        }

        public Tweet? GetTweetById(Guid id)
        {
            return _context.Tweets
                .SingleOrDefault(t => t.Id == id);
        }

        public List<Tweet> GetTweets()
        {
            return _context.Tweets.ToList();
        }

        public List<Tweet> GetTweetsByUserId(Guid userId)
        {
            return _context.Tweets
                .Where(t => t.UserId == userId)
                .ToList();
        }
    }
}
