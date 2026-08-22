namespace TwitterClone.Domain.Entities
{
    public interface IFollowable
    {
        void Follow(Guid userId);
        void Unfollow(Guid userId);
    }
}
