
namespace TwitterClone.Domain.Entities
{
    public class Like
    {
        private Guid _userId;
        private Guid _tweetId;
        private DateTime _likedAt;

        public Guid UserId
        {
            get { return _userId; }
        }
        public Guid TweetId
        {
            get { return _tweetId; }
        }

        public DateTime LikedAt
        {
            get { return _likedAt; }
        }
    }
}
