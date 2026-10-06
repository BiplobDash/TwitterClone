using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.API.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface ITweetService
    {
        List<Tweet> GetTweets();

        List<Tweet> GetTweetsByUserId(Guid userId);

        Tweet? GetTweetById(Guid id);

        Tweet? AddTweet(CreateTweetDto tweet);

        Tweet? UpdateTweet(Guid id, UpdateTweetDto dto);

        bool DeleteTweet(Guid id);
    }
}
