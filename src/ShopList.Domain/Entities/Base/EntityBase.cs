namespace ShopList.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTimeOffset.UtcNow;
        }

        public Guid Id { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset? DeletedAt { get; private set; }

        public void Delete()
        {
            if (DeletedAt == null)
                DeletedAt = DateTimeOffset.UtcNow;
        }
    }
}
