using System.Collections.Generic;

namespace Entities.Notifications
{
    public class Email : BaseEntity
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        public string Receiver { get; set; }
    }
}
