using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Utilities.Extensions
{
    public static class StringExtensions
    {
        public static string AddToHashTags(this string word)
        {
            return $"#{word}";
        }

        public static bool IsPopular(this Tweet tweet)
        {
            return tweet.Likes >= 100;
        }
    }
}
