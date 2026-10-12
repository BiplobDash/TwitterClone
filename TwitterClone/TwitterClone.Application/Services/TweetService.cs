using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.API.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class TweetService : ITweetService
    {
        private readonly ITweetRepository _tweetRepository;

        public TweetService(ITweetRepository tweetRepository)
        {
            _tweetRepository = tweetRepository;
        }

        public List<Tweet> GetTweets()
        {
            return _tweetRepository.GetTweets();
        }

        public List<Tweet> GetTweetsByUserId(Guid userId)
        {
            return _tweetRepository.GetTweetsByUserId(userId);
        }

        public Tweet? GetTweetById(Guid id)
        {
            return _tweetRepository.GetTweetById(id);
        }

        public bool DeleteTweet(Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);

            if (tweet == null)
            {
                return false;
            }

            return _tweetRepository.DeleteTweet(tweet);
        }

        public Tweet? UpdateTweet(Guid id, UpdateTweetDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Content))
            {
                return null;
            }

            if (dto.Content.Length > 280)
            {
                return null;
            }

            var tweet = _tweetRepository.GetTweetById(id);

            if (tweet == null)
            {
                return null;
            }

            tweet.Content = dto.Content;

            return _tweetRepository.UpdateTweet(tweet);
        }

        public Tweet? AddTweet(CreateTweetDto tweet)
        {
            // Business logic
            if (string.IsNullOrWhiteSpace(tweet.Content))
            {
                return null;
            }

            var newTweet = new Tweet(tweet.Content);

            _tweetRepository.AddTweet(newTweet);

            return newTweet;
        }
    }
}
