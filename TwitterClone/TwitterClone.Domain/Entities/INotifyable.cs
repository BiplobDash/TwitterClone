namespace TwitterClone.Domain.Entities
{
    public interface INotifyable
    {
        void AddNotification(Guid notificationId);
    }
}
