using System;

namespace Entities.Gamification
{
    public class Answer : BaseEntity
    {
        public Guid SessionId { get; set; }

        public Session Session { get; set; }

        public string Input { get; set; }
    }
}
