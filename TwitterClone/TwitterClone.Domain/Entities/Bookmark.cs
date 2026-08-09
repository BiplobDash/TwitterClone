
namespace TwitterClone.Domain.Entities
{
    public class Bookmark
    {
        private Guid _userId;
        private Guid _tweetId;
        private DateTime _bookmarkedAt;

        public Guid UserId
        {
            get { return _userId; }
        }

        public Guid TweetId
        {
            get { return _tweetId; }
        }

        public DateTime BookmarkedAt
        {
            get { return _bookmarkedAt; }
        }
    }
}
