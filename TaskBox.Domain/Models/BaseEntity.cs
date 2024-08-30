namespace TaskBox.Domain.Models
{
    public abstract class BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        public virtual TKey Id { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }

    public abstract class BaseEntity : BaseEntity<Guid>
    {

    }
}
