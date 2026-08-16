namespace TwitterClone.Domain.Entities
{
    public class FriendRequestNotification : Notification
    {
        public FriendRequestNotification(Guid requestByUserId) : base("FriendRequest")
        {
            RequestByUserId = requestByUserId;
        }

        public Guid RequestByUserId { get; set; }

        public override string GetMessage()
        {
            return $"User with ID {RequestByUserId} sent you a friend request.";
        }
    }
}
