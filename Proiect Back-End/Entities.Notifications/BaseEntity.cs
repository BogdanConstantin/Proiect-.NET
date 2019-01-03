using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Notifications
{
    public class BaseEntity
    {
        private Guid Id { get; set; }

        private Guid? AuthorId { get; set; }
    }
}
