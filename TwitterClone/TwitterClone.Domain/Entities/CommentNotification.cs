namespace TwitterClone.Domain.Entities
{
    public class CommentNotification : Notification
    {
        public CommentNotification(Guid commentByUserId) : base("Comment")
        {
            CommentByUserId = commentByUserId;
        }

        public Guid CommentByUserId { get; set; }

        public override string GetMessage()
        {
            return $"User with ID {CommentByUserId} comment your post.";
        }
    }
}
