using System;

using Entities.ClassesManagement;

namespace Models.ClassesManagement
{
    public class ManagementDto
    {
        public Guid ClassId { get; set; }

        public Guid UserId { get; set; }

        public UserPosition UserPosition { get; set; }
    }
}
