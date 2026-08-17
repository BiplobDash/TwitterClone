using TwitterClone.Domain.Entities;

var notifications = new List<Notification>()
{
    new LikeNotification(Guid.NewGuid()),
    new CommentNotification(Guid.NewGuid()),
    new FriendRequestNotification(Guid.NewGuid()),
    new MentionNotification(Guid.NewGuid()),
    new SystemNotification()
};

foreach(var notifiction in notifications)
{
    Console.WriteLine(notifiction.GetMessage());
}