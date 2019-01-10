using System;

namespace Entities.Gamification
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public Guid? AuthorId { get; set; }
    }
}
