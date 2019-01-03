using System;

namespace Models.ClassesManagement
{
    public class ManagementDto
    {
        public Guid ClassId { get; set; }

        public Guid UserId { get; set; }

        public string UserPosition { get; set; }
    }
}
