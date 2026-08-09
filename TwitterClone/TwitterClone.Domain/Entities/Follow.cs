

namespace TwitterClone.Domain.Entities
{
    public class Follow
    {
        private Guid _followerId;
        private Guid _followingId;
        private DateTime _followedAt;
        
        public Guid FollowerId
        {
            get { return _followerId; }
        }

        public Guid FollowingId
        {
            get { return _followingId; }
        }

        public DateTime FollowedAt
        {
            get { return _followedAt; }
        }
    }
}
