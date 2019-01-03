using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Notifications
{
    public class Email : BaseEntity
    {
        private string Subject { get; set; }

        private string Body { get; set; }

        private ICollection<string> Receivers { get; set; }
    }
}
