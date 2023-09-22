using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.Primitives
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        //protected BaseEntity(List<Notification> notifications)
        //{
        //    _notifications = notifications;
        //}

        //private List<Notification> _notifications;

        [Key]
        public Guid Id { get; protected init; }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            if (obj is not BaseEntity entity)
                return false;

            return entity.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        private DateTime _createdAt;

        public DateTime CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = DateTime.UtcNow; }
        }

        private DateTimeOffset? _updatedAt;

        public DateTimeOffset? UpdatedAt
        {
            get { return _updatedAt; }
            set { _updatedAt = value; }
        }

        //public IReadOnlyCollection<Notification> Notifications => _notifications;

        //protected void SetNotifications(Notification notification)
        //{
        //    _notifications.Add(notification);
        //}

      
    }
}
