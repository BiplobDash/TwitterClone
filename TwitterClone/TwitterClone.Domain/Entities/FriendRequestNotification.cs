namespace TwitterClone.Domain.Entities
{
    public class FriendRequestNotification : Notification
    {
        public FriendRequestNotification(Guid requestByUserId) : base("FriendRequest")
        {
            RequestByUserId = requestByUserId;
        }

        public Guid RequestByUserId { get; set; }
    }
}
