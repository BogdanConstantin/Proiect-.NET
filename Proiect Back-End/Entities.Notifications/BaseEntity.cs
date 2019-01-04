using System;

namespace Entities.Notifications
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public Guid? AuthorId { get; set; }
    }
}
