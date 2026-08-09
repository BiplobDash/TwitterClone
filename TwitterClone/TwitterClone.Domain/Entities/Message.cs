namespace TwitterClone.Domain.Entities
{
    public class Message
    {
        private Guid _id;
        private Guid _senderId;
        private Guid _receiverId;
        private string _content;
        private DateTime _sentAt;

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

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public DateTime SentAt
        {
            get { return _sentAt; }
        }
    }
}
