namespace TwitterClone.Domain.Entities
{
    public sealed class SystemNotification : Notification
    {
        public SystemNotification() : base("System"){ }

        public override string GetMessage()
        {
            return $"System Notification: Unknown Error";
        }
    }
}
