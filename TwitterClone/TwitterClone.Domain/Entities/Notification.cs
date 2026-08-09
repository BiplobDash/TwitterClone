namespace TwitterClone.Domain.Entities
{
    public class Notification
    {
        private Guid _id;
        private Guid _senderId;
        private Guid _receiverId;
        private DateTime _createdAt;
        private bool _isRead;

        public Guid Id
        {
            get { return _id; }
        }
        public Guid SenderId
        {
            get { return _senderId; }
        }

        public Guid ReceiverId
        {
            get { return _receiverId; }
        }

        public DateTime CreatedAt
        {
            get { return _createdAt; }
        }

        public bool IsRead
        {
            get { return _isRead; }
        }
    }
}
