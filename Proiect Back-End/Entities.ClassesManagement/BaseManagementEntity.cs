using System;

namespace Entities.ClassesManagement
{
    public abstract class BaseManagementEntity : BaseEntity
    {
        public Guid ClassId { get; set; }

        // add person for one to many relationship
        public Guid UserId { get; set; }
        public UserPosition UserPosition { get; set; }
    }
}
